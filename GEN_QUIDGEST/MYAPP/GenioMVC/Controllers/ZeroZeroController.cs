using Microsoft.AspNetCore.Mvc;
using CSGenio.business;
using GenioMVC.ViewModels.Jogador;
using System.Globalization;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace GenioMVC.Controllers
{
	/// <summary>
	/// Provides on-demand squad lookups from ZeroZero.pt.
	/// </summary>
	public class ZeroZeroController : ControllerBase
	{
		private const string ZeroZeroBaseUrl = "https://www.zerozero.pt";
		private readonly IHttpClientFactory _httpClientFactory;

		private static readonly Dictionary<string, string> KnownTeamUrls = new(StringComparer.OrdinalIgnoreCase)
		{
			["sporting"] = "/equipa/sporting/16?search=1",
			["sporting cp"] = "/equipa/sporting/16?search=1",
			["sporting clube de portugal"] = "/equipa/sporting/16?search=1",
			["zerozero pt equipa sporting"] = "/equipa/sporting/16?search=1",
			["benfica"] = "/equipa/benfica/4?search=1",
			["sl benfica"] = "/equipa/benfica/4?search=1",
			["porto"] = "/equipa/fc-porto/9?search=1",
			["fc porto"] = "/equipa/fc-porto/9?search=1",
			["braga"] = "/equipa/sp-braga/15?search=1",
			["sp braga"] = "/equipa/sp-braga/15?search=1"
		};

		public ZeroZeroController(UserContextService userContext, IHttpClientFactory httpClientFactory) : base(userContext)
		{
			_httpClientFactory = httpClientFactory;
		}

		public class SquadResponse
		{
			public string Team { get; set; } = string.Empty;
			public string TeamUrl { get; set; } = string.Empty;
			public List<PlayerInfo> Players { get; set; } = [];
		}

		public class PlayerInfo
		{
			public string Name { get; set; } = string.Empty;
			public string? Age { get; set; }
			public string? ProfileLink { get; set; }
			public string? Position { get; set; }
			public string? PositionLabel { get; set; }
			public string? Number { get; set; }
			public string? PhotoUrl { get; set; }
		}


		public class ImportSquadRequest
		{
			public string Team { get; set; } = string.Empty;
			public string TeamUrl { get; set; } = string.Empty;
			public List<PlayerInfo> Players { get; set; } = [];
		}

		public class ImportSquadResponse
		{
			public int Created { get; set; }
			public int Skipped { get; set; }
			public string ClubId { get; set; } = string.Empty;
			public string ClubName { get; set; } = string.Empty;
		}
		private sealed class TeamPage
		{
			public string Name { get; init; } = string.Empty;
			public string Url { get; init; } = string.Empty;
			public string Html { get; init; } = string.Empty;
		}

		[HttpGet]
		public async Task<ActionResult> Squad(string team)
		{
			if (string.IsNullOrWhiteSpace(team))
				return JsonERROR("Indica o nome da equipa a pesquisar no ZeroZero.");

			try
			{
				var httpClient = CreateZeroZeroClient();
				var teamPage = await ResolveTeamPage(httpClient, NormalizeTeamInput(team.Trim()));
				if (teamPage is null)
					return JsonERROR($"Nao foi encontrada nenhuma equipa no ZeroZero para '{team}'.");

				var players = ParsePlayers(teamPage.Html);
				return JsonOK(new SquadResponse
				{
					Team = teamPage.Name,
					TeamUrl = teamPage.Url,
					Players = players
				});
			}
			catch (Exception ex)
			{
				return JsonERROR($"Erro ao obter plantel no ZeroZero: {ex.Message}");
			}
		}


		[HttpPost]
		public ActionResult ImportSquad([FromBody] ImportSquadRequest request)
		{
			if (request is null || request.Players is null || request.Players.Count == 0)
				return JsonERROR("Nao existem jogadores para importar.");

			var clubName = string.IsNullOrWhiteSpace(request.Team) ? "Plantel ZeroZero" : request.Team.Trim();
			var sp = UserContext.Current.PersistentSupport;

			try
			{
				var created = 0;
				var skipped = 0;

				sp.openTransaction();
				var club = FindOrCreateClub(clubName, sp);
				var allPlayers = Models.Jogador.AllModel(UserContext.Current);
				var existingNames = allPlayers
					.Where(player => string.Equals(player.ValCodclube, club.ValCodclube, StringComparison.OrdinalIgnoreCase))
					.Select(player => NormalizeSearchText(player.ValNome ?? string.Empty))
					.ToHashSet(StringComparer.OrdinalIgnoreCase);
				var usedSquadNumbers = allPlayers
					.Select(player => player.ValNumerocamisola ?? 0)
					.Where(number => number > 0)
					.ToHashSet();

				foreach (var player in request.Players)
				{
					var playerName = (player.Name ?? string.Empty).Trim();
					if (string.IsNullOrWhiteSpace(playerName) || existingNames.Contains(NormalizeSearchText(playerName)))
					{
						skipped++;
						continue;
					}

					var jogador = new Jogador_ViewModel(UserContext.Current);
					jogador.New();
					jogador.ValNome = Truncate(playerName, 50);
					jogador.ValCodclube = club.ValCodclube;
					jogador.ValNumerocamisola = AllocateSquadNumber(usedSquadNumbers, ParseDecimal(player.Number));
					jogador.ValNationalidade = "Portugal";
					jogador.ValDatanascimento = EstimateBirthDate(player.Age);
					jogador.ValPedominante = "AMB";
					jogador.ValPosicao = NormalizePosition(player.Position);
					jogador.ValPosicaosegundaria = NormalizePosition(player.Position);
					jogador.ValEquipaanterior = "ZeroZero";
					jogador.ValValormercado = 0;
					jogador.MapToModel();
					jogador.ExecuteModelFormulas();
					jogador.Save();

					existingNames.Add(NormalizeSearchText(playerName));
					created++;
				}

				sp.closeTransaction();

				Navigation.SetValue("ForcePrimaryRead_jogador", "true", true);
				Navigation.SetValue("ForcePrimaryRead_clube", "true", true);

				return JsonOK(new ImportSquadResponse
				{
					Created = created,
					Skipped = skipped,
					ClubId = club.ValCodclube,
					ClubName = club.ValNome
				});
			}
			catch (FieldValidationException ex)
			{
				sp.rollbackTransaction();
				return JsonERROR($"Erro ao importar plantel: {ex.Message} {ex.StatusMessage?.PrintMessages()}".Trim());
			}
			catch (Exception ex)
			{
				sp.rollbackTransaction();
				return JsonERROR($"Erro ao importar plantel: {ex.Message}");
			}
		}
		[HttpGet]
		public Task<ActionResult> AtleticoCacem()
		{
			return Squad("https://www.zerozero.pt/equipa/atletico-cacem/3880?search=1");
		}

		private HttpClient CreateZeroZeroClient()
		{
			var httpClient = _httpClientFactory.CreateClient();
			httpClient.Timeout = TimeSpan.FromSeconds(20);
			httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/124 Safari/537.36");
			httpClient.DefaultRequestHeaders.AcceptLanguage.ParseAdd("pt-PT,pt;q=0.9,en;q=0.8");
			return httpClient;
		}

		private static async Task<TeamPage?> ResolveTeamPage(HttpClient httpClient, string team)
		{
			foreach (var candidateUrl in BuildCandidateUrls(team))
			{
				var directPage = await TryFetchTeamPage(httpClient, candidateUrl, team);
				if (directPage is not null)
					return directPage;
			}

			foreach (var searchUrl in BuildSearchUrls(team))
			{
				var searchHtml = await TryGetString(httpClient, searchUrl);
				if (string.IsNullOrWhiteSpace(searchHtml))
					continue;

				foreach (var candidateUrl in ExtractTeamUrls(searchHtml, team))
				{
					var teamPage = await TryFetchTeamPage(httpClient, candidateUrl, team);
					if (teamPage is not null)
						return teamPage;
				}
			}

			return null;
		}

		private static IEnumerable<string> BuildCandidateUrls(string team)
		{
			if (TryBuildZeroZeroUrl(team, out var inputUrl))
			{
				yield return EnsureSearchFlag(inputUrl);

				var pathSlug = ExtractTeamSlugFromUrl(inputUrl);
				if (!string.IsNullOrWhiteSpace(pathSlug) && KnownTeamUrls.TryGetValue(NormalizeSearchText(pathSlug), out var knownFromUrl))
					yield return ZeroZeroBaseUrl + knownFromUrl;
			}

			if (KnownTeamUrls.TryGetValue(NormalizeSearchText(team), out var knownUrl))
				yield return ZeroZeroBaseUrl + knownUrl;

			var slug = Slugify(team);
			if (!string.IsNullOrWhiteSpace(slug))
			{
				yield return $"{ZeroZeroBaseUrl}/equipa/{slug}?search=1";
				yield return $"{ZeroZeroBaseUrl}/equipa/{slug}";
			}
		}
		private static IEnumerable<string> BuildSearchUrls(string team)
		{
			var encoded = Uri.EscapeDataString(team);
			yield return $"{ZeroZeroBaseUrl}/search.php?inputString={encoded}";
			yield return $"{ZeroZeroBaseUrl}/search.php?search={encoded}";
			yield return $"{ZeroZeroBaseUrl}/pesquisa?search={encoded}";
		}

		private static async Task<TeamPage?> TryFetchTeamPage(HttpClient httpClient, string url, string requestedTeam)
		{
			var html = await TryGetString(httpClient, url);
			if (string.IsNullOrWhiteSpace(html))
				return null;

			var players = ParsePlayers(html);
			if (players.Count == 0)
				return null;

			return new TeamPage
			{
				Name = ExtractTeamName(html) ?? requestedTeam,
				Url = url,
				Html = html
			};
		}

		private static async Task<string?> TryGetString(HttpClient httpClient, string url)
		{
			try
			{
				using var response = await httpClient.GetAsync(url);
				if (!response.IsSuccessStatusCode)
					return null;

				return await response.Content.ReadAsStringAsync();
			}
			catch
			{
				return null;
			}
		}

		private static IEnumerable<string> ExtractTeamUrls(string html, string requestedTeam)
		{
			var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
			var requested = NormalizeSearchText(requestedTeam);
			var teamLinkPattern = new Regex(@"<a[^>]+href=""(?<href>/equipa/[^""?#]+/\d+[^""]*)""[^>]*>(?<text>.*?)</a>", RegexOptions.Singleline | RegexOptions.IgnoreCase);

			foreach (Match match in teamLinkPattern.Matches(html))
			{
				var href = WebUtility.HtmlDecode(match.Groups["href"].Value).Trim();
				var text = StripTags(WebUtility.HtmlDecode(match.Groups["text"].Value));
				var normalizedText = NormalizeSearchText(text);

				if (!string.IsNullOrWhiteSpace(requested) && !normalizedText.Contains(requested) && !requested.Contains(normalizedText))
					continue;

				var absoluteUrl = ZeroZeroBaseUrl + href.Split('#')[0];
				if (!absoluteUrl.Contains("?search=1", StringComparison.OrdinalIgnoreCase))
					absoluteUrl += absoluteUrl.Contains('?') ? "&search=1" : "?search=1";

				if (seen.Add(absoluteUrl))
					yield return absoluteUrl;
			}
		}

		private static List<PlayerInfo> ParsePlayers(string html)
		{
			var players = new List<PlayerInfo>();
			var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
			var playerPattern = new Regex(@"<a[^>]+href=""(?<href>/jogador/[^""?#]+(?:/\d+)?[^""]*)""[^>]*>(?<text>.*?)</a>", RegexOptions.Singleline | RegexOptions.IgnoreCase);
			var agePattern = new Regex(@"(?<age>\d{1,2})\s*anos", RegexOptions.Singleline | RegexOptions.IgnoreCase);
			var sectionMatches = Regex.Matches(html, @"<div[^>]+class=""section""[^>]*>(?<section>.*?)</div>", RegexOptions.Singleline | RegexOptions.IgnoreCase)
				.Cast<Match>()
				.ToList();

			foreach (Match match in playerPattern.Matches(html))
			{
				var relativePath = WebUtility.HtmlDecode(match.Groups["href"].Value).Trim();
				var profilePath = relativePath.Split('?')[0].Split('#')[0];
				var name = StripTags(WebUtility.HtmlDecode(match.Groups["text"].Value));

				if (string.IsNullOrWhiteSpace(name) || name.Length < 3 || !profilePath.StartsWith("/jogador/", StringComparison.OrdinalIgnoreCase) || !seen.Add(profilePath))
					continue;

				var section = FindSectionForIndex(sectionMatches, match.Index);
				var position = MapSectionToPosition(section);
				var staffStart = html.LastIndexOf("<div class=\"staff\"", match.Index, StringComparison.OrdinalIgnoreCase);
				var beforePlayer = staffStart >= 0 ? html.Substring(staffStart, match.Index - staffStart) : html.Substring(Math.Max(0, match.Index - 700), Math.Min(700, match.Index));
				var afterPlayer = html.Substring(match.Index, Math.Min(700, html.Length - match.Index));
				var photoMatch = Regex.Match(beforePlayer, @"background-image:\s*url\('(?<photo>[^']+)'\)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
				var numberMatch = Regex.Match(beforePlayer, @"<div[^>]+class=""number""[^>]*>(?<number>.*?)</div>", RegexOptions.Singleline | RegexOptions.IgnoreCase);
				var ageMatch = agePattern.Match(afterPlayer);

				players.Add(new PlayerInfo
				{
					Name = name,
					Age = ageMatch.Success ? ageMatch.Groups["age"].Value.Trim() : null,
					ProfileLink = ZeroZeroBaseUrl + profilePath,
					Position = position.code,
					PositionLabel = position.label,
					Number = StripTags(numberMatch.Groups["number"].Value),
					PhotoUrl = photoMatch.Success ? photoMatch.Groups["photo"].Value.Trim() : null
				});

				if (players.Count >= 80)
					break;
			}

			return players;
		}
		private static string NormalizeTeamInput(string team)
		{
			if (TryBuildZeroZeroUrl(team, out var url))
				return url;

			return team;
		}

		private static bool TryBuildZeroZeroUrl(string value, out string url)
		{
			url = string.Empty;
			var candidate = value.Trim();

			if (candidate.Contains("zerozero.pt", StringComparison.OrdinalIgnoreCase) && !candidate.StartsWith("http://", StringComparison.OrdinalIgnoreCase) && !candidate.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
				candidate = "https://" + candidate;

			if (!Uri.TryCreate(candidate, UriKind.Absolute, out var uri) || !uri.Host.Contains("zerozero", StringComparison.OrdinalIgnoreCase))
				return false;

			url = uri.ToString();
			return true;
		}

		private static string EnsureSearchFlag(string url)
		{
			if (url.Contains("?search=1", StringComparison.OrdinalIgnoreCase) || url.Contains("&search=1", StringComparison.OrdinalIgnoreCase))
				return url;

			return url + (url.Contains('?') ? "&search=1" : "?search=1");
		}

		private static string? ExtractTeamSlugFromUrl(string url)
		{
			if (!Uri.TryCreate(url, UriKind.Absolute, out var uri))
				return null;

			var parts = uri.AbsolutePath.Split('/', StringSplitOptions.RemoveEmptyEntries);
			var teamIndex = Array.FindIndex(parts, part => part.Equals("equipa", StringComparison.OrdinalIgnoreCase));
			if (teamIndex < 0 || teamIndex + 1 >= parts.Length)
				return null;

			return parts[teamIndex + 1];
		}
		private static int FindFirstSectionAfter(string html, int startIndex, IEnumerable<string> sectionNames)
		{
			var endIndex = html.Length;
			foreach (var sectionName in sectionNames)
			{
				var sectionIndex = html.IndexOf(sectionName, startIndex + 1, StringComparison.OrdinalIgnoreCase);
				if (sectionIndex >= 0 && sectionIndex < endIndex)
					endIndex = sectionIndex;
			}

			return endIndex;
		}

		private static string? ExtractTeamName(string html)
		{
			var h1Match = Regex.Match(html, @"<h1[^>]*>(?<name>.*?)</h1>", RegexOptions.Singleline | RegexOptions.IgnoreCase);
			if (h1Match.Success)
				return StripTags(WebUtility.HtmlDecode(h1Match.Groups["name"].Value));

			var titleMatch = Regex.Match(html, @"<title[^>]*>(?<name>.*?)</title>", RegexOptions.Singleline | RegexOptions.IgnoreCase);
			if (titleMatch.Success)
				return StripTags(WebUtility.HtmlDecode(titleMatch.Groups["name"].Value)).Split('|')[0].Trim();

			return null;
		}

		private static string StripTags(string value)
		{
			var withoutTags = Regex.Replace(value, "<.*?>", " ", RegexOptions.Singleline).Trim();
			return Regex.Replace(withoutTags, @"\s+", " ");
		}

		private Models.Clube FindOrCreateClub(string clubName, CSGenio.persistence.PersistentSupport sp)
		{
			var normalizedClubName = NormalizeSearchText(clubName);
			var existingClub = Models.Clube.AllModel(UserContext.Current)
				.FirstOrDefault(club => NormalizeSearchText(club.ValNome ?? string.Empty) == normalizedClubName);

			if (existingClub is not null)
				return existingClub;

			var club = new Models.Clube(UserContext.Current);
			club.New("FCLUBE", sp);
			club.ValNome = Truncate(clubName, 50);
			club.Save(sp);
			return club;
		}

		private static string Truncate(string value, int maxLength)
		{
			if (string.IsNullOrEmpty(value) || value.Length <= maxLength)
				return value;

			return value[..maxLength];
		}

		private static decimal? ParseDecimal(string? value)
		{
			if (decimal.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out var result))
				return result;

			return null;
		}

		private static decimal AllocateSquadNumber(HashSet<decimal> usedSquadNumbers, decimal? preferredNumber)
		{
			if (preferredNumber.HasValue && preferredNumber.Value >= 1 && preferredNumber.Value <= 99 && usedSquadNumbers.Add(preferredNumber.Value))
				return preferredNumber.Value;

			for (var number = 1; number <= 99; number++)
			{
				if (usedSquadNumbers.Add(number))
					return number;
			}

			throw new InvalidOperationException("Nao existem numeros de camisola livres entre 1 e 99 para importar este plantel.");
		}

		private static DateTime EstimateBirthDate(string? age)
		{
			if (int.TryParse(age, out var years) && years > 0)
				return DateTime.Today.AddYears(-years);

			return DateTime.Today.AddYears(-18);
		}

		private static string NormalizePosition(string? position)
		{
			return position switch
			{
				"GR" => "GR",
				"DEF" => "DEF",
				"MD" => "MD",
				"AT" => "AT",
				_ => "AT"
			};
		}

		private static string FindSectionForIndex(List<Match> sections, int index)
		{
			var section = sections.LastOrDefault(match => match.Index < index);
			return section is null ? string.Empty : StripTags(WebUtility.HtmlDecode(section.Groups["section"].Value));
		}

		private static (string code, string label) MapSectionToPosition(string section)
		{
			var normalized = NormalizeSearchText(section);
			if (normalized.Contains("guarda redes"))
				return ("GR", "Guarda-Redes");
			if (normalized.Contains("defesa"))
				return ("DEF", "Defesa");
			if (normalized.Contains("medio") || normalized.Contains("medios"))
				return ("MD", "Medio");
			if (normalized.Contains("avancado") || normalized.Contains("avancados") || normalized.Contains("atacante"))
				return ("AT", "Atacante");

			return ("AT", "Atacante");
		}
		private static string NormalizeSearchText(string value)
		{
			return Slugify(value).Replace('-', ' ').Trim();
		}

		private static string Slugify(string value)
		{
			var normalized = value.Normalize(NormalizationForm.FormD);
			var builder = new StringBuilder();
			var previousWasSeparator = false;

			foreach (var character in normalized)
			{
				var category = CharUnicodeInfo.GetUnicodeCategory(character);
				if (category == UnicodeCategory.NonSpacingMark)
					continue;

				var lower = char.ToLowerInvariant(character);
				if (char.IsLetterOrDigit(lower))
				{
					builder.Append(lower);
					previousWasSeparator = false;
				}
				else if (!previousWasSeparator)
				{
					builder.Append('-');
					previousWasSeparator = true;
				}
			}

			return builder.ToString().Trim('-');
		}
	}
}
