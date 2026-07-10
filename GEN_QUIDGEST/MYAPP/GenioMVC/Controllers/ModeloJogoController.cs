using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace GenioMVC.Controllers
{
	/// <summary>
	/// Custom game model board used by coaches to organize offensive and defensive ideas.
	/// </summary>
	public class ModeloJogoController : ControllerBase
	{
		private static readonly JsonSerializerOptions JsonOptions = new()
		{
			PropertyNameCaseInsensitive = true,
			WriteIndented = true
		};

		public ModeloJogoController(UserContextService userContext) : base(userContext)
		{
		}

		public class TrainerOption
		{
			public string Id { get; set; } = string.Empty;
			public string Name { get; set; } = string.Empty;
		}

		public class GameModelImage
		{
			public string Id { get; set; } = string.Empty;
			public string Name { get; set; } = string.Empty;
			public string ContentType { get; set; } = string.Empty;
			public string DataUrl { get; set; } = string.Empty;
		}

		public class GameModelItem
		{
			public string Id { get; set; } = string.Empty;
			public string Tipo { get; set; } = "Ofensivo";
			public string Titulo { get; set; } = string.Empty;
			public string Descricao { get; set; } = string.Empty;
			public string CodTreinador { get; set; } = string.Empty;
			public string TreinadorNome { get; set; } = string.Empty;
			public List<GameModelImage> Imagens { get; set; } = [];
			public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
		}

		public class GameModelListResponse
		{
			public List<GameModelItem> Items { get; set; } = [];
		}

		public class DeleteRequest
		{
			public string Id { get; set; } = string.Empty;
		}

		[HttpGet]
		public ActionResult Trainers()
		{
			try
			{
				var trainers = Models.Treinador.AllModel(UserContext.Current)
					.Where(trainer => trainer.ValZzstate == 0)
					.OrderBy(trainer => trainer.ValNome)
					.Select(trainer => new TrainerOption
					{
						Id = trainer.ValCodtreinador,
						Name = trainer.ValNome ?? string.Empty
					})
					.ToList();

				return JsonOK(new { Trainers = trainers });
			}
			catch (Exception ex)
			{
				return JsonERROR($"Erro ao carregar treinadores: {ex.Message}");
			}
		}

		[HttpGet]
		public ActionResult List(string tipo = "")
		{
			try
			{
				var normalizedType = NormalizeType(tipo);
				var items = ReadItems()
					.Where(item => string.IsNullOrWhiteSpace(normalizedType) || item.Tipo == normalizedType)
					.OrderByDescending(item => item.UpdatedAt)
					.ThenBy(item => item.Titulo)
					.ToList();

				return JsonOK(new GameModelListResponse { Items = items });
			}
			catch (Exception ex)
			{
				return JsonERROR($"Erro ao carregar modelos de jogo: {ex.Message}");
			}
		}

		[HttpPost]
		public ActionResult Save([FromBody] GameModelItem request)
		{
			if (request is null)
				return JsonERROR("Indica os dados do modelo de jogo.");
			if (string.IsNullOrWhiteSpace(request.Titulo))
				return JsonERROR("Indica o titulo do modelo de jogo.");
			if (string.IsNullOrWhiteSpace(request.CodTreinador))
				return JsonERROR("Escolhe o treinador.");

			try
			{
				var trainer = Models.Treinador.Find(request.CodTreinador, UserContext.Current, "FMODELOJOGO");
				if (trainer is null || trainer.ValZzstate != 0)
					return JsonERROR("Treinador nao encontrado.");

				var items = ReadItems();
				var id = string.IsNullOrWhiteSpace(request.Id) ? Guid.NewGuid().ToString("N") : request.Id;
				var existingIndex = items.FindIndex(item => string.Equals(item.Id, id, StringComparison.OrdinalIgnoreCase));
				var item = new GameModelItem
				{
					Id = id,
					Tipo = NormalizeType(request.Tipo) == "Defensivo" ? "Defensivo" : "Ofensivo",
					Titulo = request.Titulo.Trim(),
					Descricao = request.Descricao?.Trim() ?? string.Empty,
					CodTreinador = trainer.ValCodtreinador,
					TreinadorNome = trainer.ValNome ?? string.Empty,
					Imagens = (request.Imagens ?? [])
						.Where(image => !string.IsNullOrWhiteSpace(image.DataUrl))
						.Select(image => new GameModelImage
						{
							Id = string.IsNullOrWhiteSpace(image.Id) ? Guid.NewGuid().ToString("N") : image.Id,
							Name = image.Name ?? string.Empty,
							ContentType = image.ContentType ?? string.Empty,
							DataUrl = image.DataUrl
						})
						.ToList(),
					UpdatedAt = DateTime.UtcNow
				};

				if (existingIndex >= 0)
					items[existingIndex] = item;
				else
					items.Add(item);

				WriteItems(items);
				return JsonOK(item);
			}
			catch (Exception ex)
			{
				return JsonERROR($"Erro ao guardar modelo de jogo: {ex.Message}");
			}
		}

		[HttpPost]
		public ActionResult Delete([FromBody] DeleteRequest request)
		{
			if (request is null || string.IsNullOrWhiteSpace(request.Id))
				return JsonERROR("Seleciona um modelo para apagar.");

			try
			{
				var items = ReadItems();
				var removed = items.RemoveAll(item => string.Equals(item.Id, request.Id, StringComparison.OrdinalIgnoreCase));
				WriteItems(items);
				return JsonOK(new { Removed = removed });
			}
			catch (Exception ex)
			{
				return JsonERROR($"Erro ao apagar modelo de jogo: {ex.Message}");
			}
		}

		private static string NormalizeType(string? value)
		{
			return string.Equals(value, "Defensivo", StringComparison.OrdinalIgnoreCase) ? "Defensivo" :
				string.Equals(value, "Ofensivo", StringComparison.OrdinalIgnoreCase) ? "Ofensivo" : string.Empty;
		}

		private List<GameModelItem> ReadItems()
		{
			var path = DataFilePath();
			if (!System.IO.File.Exists(path))
				return [];

			var json = System.IO.File.ReadAllText(path);
			return JsonSerializer.Deserialize<List<GameModelItem>>(json, JsonOptions) ?? [];
		}

		private void WriteItems(List<GameModelItem> items)
		{
			var path = DataFilePath();
			System.IO.File.WriteAllText(path, JsonSerializer.Serialize(items, JsonOptions));
		}

		private static string DataFilePath()
		{
			var directory = Path.Combine(AppContext.BaseDirectory, "App_Data", "ModeloJogo");
			Directory.CreateDirectory(directory);
			return Path.Combine(directory, "modelos.json");
		}
	}
}
