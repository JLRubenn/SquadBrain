using JsonPropertyName = System.Text.Json.Serialization.JsonPropertyNameAttribute;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Entity;
using System.Linq;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using CSGenio.reporting;
using GenioMVC.Helpers;
using GenioMVC.Models;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using GenioMVC.Resources;
using GenioMVC.ViewModels;
using GenioMVC.ViewModels.Presenca;
using GenioServer.business;
using CSGenio.core.ai;

using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL SQB INCLUDE_CONTROLLER PRESENCA]/

namespace GenioMVC.Controllers
{
	public partial class PresencaController : ControllerBase
	{
		private IChatbotService _aiService;
		public PresencaController(UserContextService userContext, IChatbotService aiService) : base(userContext)
		{
			_aiService = aiService;
		}

// USE /[MANUAL SQB CONTROLLER_NAVIGATION PRESENCA]/



		private List<string> GetActionIds(CriteriaSet crs, CSGenio.persistence.PersistentSupport sp = null)
		{
			CSGenio.business.Area area = CSGenio.business.Area.createArea<CSGenioApresenca>(UserContext.Current.User, UserContext.Current.User.CurrentModule);
			return base.GetActionIds(crs, sp, area);
		}

// USE /[MANUAL SQB MANUAL_CONTROLLER PRESENCA]/
		public class AttendanceOptionsResponse
		{
			public List<AttendanceTrainingOption> Trainings { get; set; } = [];
			public List<AttendanceClubOption> Clubs { get; set; } = [];
		}

		public class AttendanceTrainingOption
		{
			public string Id { get; set; } = string.Empty;
			public string Label { get; set; } = string.Empty;
			public DateTime? Date { get; set; }
		}

		public class AttendanceClubOption
		{
			public string Id { get; set; } = string.Empty;
			public string Name { get; set; } = string.Empty;
		}

		public class SquadAttendanceResponse
		{
			public AttendanceTrainingOption Training { get; set; } = new();
			public List<SquadAttendancePlayer> Players { get; set; } = [];
		}

		public class SquadAttendancePlayer
		{
			public string PlayerId { get; set; } = string.Empty;
			public string Name { get; set; } = string.Empty;
			public decimal? Number { get; set; }
			public string Position { get; set; } = string.Empty;
			public string PositionLabel { get; set; } = string.Empty;
			public string ClubName { get; set; } = string.Empty;
			public string State { get; set; } = "P";
			public bool Exists { get; set; }
		}

		public class SaveSquadAttendanceRequest
		{
			public string TrainingId { get; set; } = string.Empty;
			public List<SaveSquadAttendanceItem> Players { get; set; } = [];
		}

		public class SaveSquadAttendanceItem
		{
			public string PlayerId { get; set; } = string.Empty;
			public string State { get; set; } = "P";
		}

		public class SaveSquadAttendanceResponse
		{
			public int Created { get; set; }
			public int Updated { get; set; }
			public int Skipped { get; set; }
		}

		public class AttendanceHistoryResponse
		{
			public List<AttendanceHistoryTraining> Trainings { get; set; } = [];
		}

		public class AttendanceHistoryTraining
		{
			public string Id { get; set; } = string.Empty;
			public string Label { get; set; } = string.Empty;
			public DateTime? Date { get; set; }
			public int Total { get; set; }
			public int Present { get; set; }
			public int Missing { get; set; }
			public int Delayed { get; set; }
			public int Injured { get; set; }
			public int Other { get; set; }
		}

		[HttpGet]
		public ActionResult AttendanceOptions()
		{
			try
			{
				var trainings = Models.Treino.AllModel(UserContext.Current)
					.OrderByDescending(training => training.ValData ?? DateTime.MinValue)
					.Take(80)
					.Select(training => new AttendanceTrainingOption
					{
						Id = training.ValCodtreino,
						Date = training.ValData,
						Label = FormatTrainingLabel(training)
					})
					.ToList();

				var clubs = Models.Clube.AllModel(UserContext.Current)
					.OrderBy(club => club.ValNome)
					.Select(club => new AttendanceClubOption
					{
						Id = club.ValCodclube,
						Name = club.ValNome ?? string.Empty
					})
					.ToList();

				return JsonOK(new AttendanceOptionsResponse { Trainings = trainings, Clubs = clubs });
			}
			catch (Exception ex)
			{
				return JsonERROR($"Erro ao carregar opcoes de presencas: {ex.Message}");
			}
		}

		[HttpGet]
		public ActionResult AttendanceHistory()
		{
			try
			{
				var attendanceRows = Models.Presenca.AllModel(UserContext.Current).ToList();
				var trainingIds = attendanceRows
					.Select(attendance => attendance.ValCodtreino)
					.Where(id => !string.IsNullOrWhiteSpace(id))
					.Distinct(StringComparer.OrdinalIgnoreCase)
					.ToList();

				var trainings = Models.Treino.AllModel(UserContext.Current)
					.Where(training => trainingIds.Contains(training.ValCodtreino))
					.ToDictionary(training => training.ValCodtreino, StringComparer.OrdinalIgnoreCase);

				var history = attendanceRows
					.Where(attendance => !string.IsNullOrWhiteSpace(attendance.ValCodtreino) && trainings.ContainsKey(attendance.ValCodtreino))
					.GroupBy(attendance => attendance.ValCodtreino, StringComparer.OrdinalIgnoreCase)
					.Select(group =>
					{
						var training = trainings[group.Key];
						var states = group
							.Select(attendance => NormalizeAttendanceState(attendance.ValEstado))
							.ToList();

						return new AttendanceHistoryTraining
						{
							Id = training.ValCodtreino,
							Date = training.ValData,
							Label = FormatTrainingLabel(training),
							Total = states.Count,
							Present = states.Count(state => state == "P"),
							Missing = states.Count(state => state == "F" || state == "FJ" || state == "FI"),
							Delayed = states.Count(state => state == "A"),
							Injured = states.Count(state => state == "L"),
							Other = states.Count(state => state == "O")
						};
					})
					.OrderByDescending(training => training.Date ?? DateTime.MinValue)
					.ThenBy(training => training.Label)
					.ToList();

				return JsonOK(new AttendanceHistoryResponse { Trainings = history });
			}
			catch (Exception ex)
			{
				return JsonERROR($"Erro ao carregar historico de presencas: {ex.Message}");
			}
		}

		[HttpGet]
		public ActionResult SavedAttendance(string trainingId)
		{
			if (string.IsNullOrWhiteSpace(trainingId))
				return JsonERROR("Seleciona um treino para consultar presencas.");

			try
			{
				var training = Models.Treino.Find(trainingId, UserContext.Current, "FPRESENCA");
				if (training is null)
					return JsonERROR("Treino nao encontrado.");

				var players = Models.Presenca.AllModel(UserContext.Current)
					.Where(attendance => string.Equals(attendance.ValCodtreino, trainingId, StringComparison.OrdinalIgnoreCase))
					.OrderBy(attendance => attendance.Jogador.ValNumerocamisola ?? 999)
					.ThenBy(attendance => attendance.Jogador.ValNome)
					.Select(attendance => new SquadAttendancePlayer
					{
						PlayerId = attendance.ValCodjogador,
						Name = attendance.Jogador.ValNome ?? string.Empty,
						Number = attendance.Jogador.ValNumerocamisola,
						Position = attendance.Jogador.ValPosicao ?? string.Empty,
						PositionLabel = PositionLabel(attendance.Jogador.ValPosicao),
						ClubName = attendance.Jogador.Clube.ValNome ?? string.Empty,
						State = NormalizeAttendanceState(attendance.ValEstado),
						Exists = true
					})
					.ToList();

				return JsonOK(new SquadAttendanceResponse
				{
					Training = new AttendanceTrainingOption { Id = training.ValCodtreino, Date = training.ValData, Label = FormatTrainingLabel(training) },
					Players = players
				});
			}
			catch (Exception ex)
			{
				return JsonERROR($"Erro ao consultar presencas guardadas: {ex.Message}");
			}
		}

		[HttpGet]
		public ActionResult SquadAttendance(string trainingId, string clubId = "")
		{
			if (string.IsNullOrWhiteSpace(trainingId))
				return JsonERROR("Seleciona um treino para carregar presencas.");

			try
			{
				var training = Models.Treino.Find(trainingId, UserContext.Current, "FPRESENCA");
				if (training is null)
					return JsonERROR("Treino nao encontrado.");

				var attendances = Models.Presenca.AllModel(UserContext.Current)
					.Where(attendance => string.Equals(attendance.ValCodtreino, trainingId, StringComparison.OrdinalIgnoreCase))
					.GroupBy(attendance => attendance.ValCodjogador)
					.ToDictionary(group => group.Key, group => group.First(), StringComparer.OrdinalIgnoreCase);

				var players = Models.Jogador.AllModel(UserContext.Current)
					.Where(player => string.IsNullOrWhiteSpace(clubId) || string.Equals(player.ValCodclube, clubId, StringComparison.OrdinalIgnoreCase))
					.OrderBy(player => player.ValNumerocamisola ?? 999)
					.ThenBy(player => player.ValNome)
					.Select(player =>
					{
						attendances.TryGetValue(player.ValCodjogador, out var attendance);
						return new SquadAttendancePlayer
						{
							PlayerId = player.ValCodjogador,
							Name = player.ValNome ?? string.Empty,
							Number = player.ValNumerocamisola,
							Position = player.ValPosicao ?? string.Empty,
							PositionLabel = PositionLabel(player.ValPosicao),
							ClubName = player.Clube?.ValNome ?? string.Empty,
							State = NormalizeAttendanceState(attendance?.ValEstado),
							Exists = attendance is not null
						};
					})
					.ToList();

				return JsonOK(new SquadAttendanceResponse
				{
					Training = new AttendanceTrainingOption { Id = training.ValCodtreino, Date = training.ValData, Label = FormatTrainingLabel(training) },
					Players = players
				});
			}
			catch (Exception ex)
			{
				return JsonERROR($"Erro ao carregar plantel para presencas: {ex.Message}");
			}
		}

		[HttpPost]
		public ActionResult SaveSquadAttendance([FromBody] SaveSquadAttendanceRequest request)
		{
			if (request is null || string.IsNullOrWhiteSpace(request.TrainingId))
				return JsonERROR("Seleciona um treino para guardar presencas.");
			if (request.Players is null || request.Players.Count == 0)
				return JsonERROR("Nao existem jogadores para guardar.");

			var sp = UserContext.Current.PersistentSupport;
			try
			{
				var created = 0;
				var updated = 0;
				var skipped = 0;

				sp.openTransaction();
				var existing = Models.Presenca.AllModel(UserContext.Current)
					.Where(attendance => string.Equals(attendance.ValCodtreino, request.TrainingId, StringComparison.OrdinalIgnoreCase))
					.GroupBy(attendance => attendance.ValCodjogador)
					.ToDictionary(group => group.Key, group => group.First(), StringComparer.OrdinalIgnoreCase);

				foreach (var item in request.Players)
				{
					if (string.IsNullOrWhiteSpace(item.PlayerId))
					{
						skipped++;
						continue;
					}

					var state = NormalizeAttendanceState(item.State);
					if (existing.TryGetValue(item.PlayerId, out var attendance))
					{
						attendance.ValEstado = state;
						attendance.Save(sp);
						updated++;
						continue;
					}

					var newAttendance = new Models.Presenca(UserContext.Current);
					newAttendance.New("FPRESENCA", sp);
					newAttendance.ValCodtreino = request.TrainingId;
					newAttendance.ValCodjogador = item.PlayerId;
					newAttendance.ValEstado = state;
					newAttendance.Save(sp);
					created++;
				}

				sp.closeTransaction();
				Navigation.SetValue("ForcePrimaryRead_presenca", "true", true);
				return JsonOK(new SaveSquadAttendanceResponse { Created = created, Updated = updated, Skipped = skipped });
			}
			catch (Exception ex)
			{
				sp.rollbackTransaction();
				return JsonERROR($"Erro ao guardar presencas: {ex.Message}");
			}
		}

		private static string FormatTrainingLabel(Models.Treino training)
		{
			var date = training.ValData?.ToString("dd/MM/yyyy HH:mm") ?? "Sem data";
			var number = training.ValNumtreino.HasValue && training.ValNumtreino.Value > 0 ? $"Treino {training.ValNumtreino:0} - " : string.Empty;
			return number + date;
		}

		private static string NormalizeAttendanceState(string state)
		{
			return state switch
			{
				"F" => "F",
				"L" => "L",
				"FJ" => "FJ",
				"FI" => "FI",
				"O" => "O",
				"A" => "A",
				_ => "P"
			};
		}

		private static string PositionLabel(string position)
		{
			return position switch
			{
				"GR" => "Guarda-Redes",
				"DEF" => "Defesa",
				"MD" => "Medio",
				"AT" => "Atacante",
				_ => ""
			};
		}

		[HttpPost]
		public JsonResult ReloadDBEdit([FromBody]RequestReloadDBEditModel requestModel)
		{
			var Identifier = requestModel.Identifier ?? "";
			var qs = new NameValueCollection();
			qs.AddRange(Request.Query);
			// The value of the lookup search field comes in 'Values'
			if (requestModel.Values != null)
				qs.AddRange(requestModel.Values);
			this.IsStateReadonly = true;

			dynamic result = null;
			/*
				Instead of loading the entire record from the database, a record will be created in memory with the keys filled in,
					and additional fields from "Field" type limits will be mapped later.
				This allows us to reduce database queries, as we already have all the necessary information to apply the limits.
			*/
			Models.Presenca row = new Models.Presenca(UserContext.Current, isEmpty: true);
			row.klass.QPrimaryKey = Navigation.GetStrValue("presenca");
			row.LoadKeysFromHistory(Navigation, Navigation.CurrentLevel.Level, false, true, true, true);

			// Only the last reload request is accepted.
			var requestNumber = Request.Headers["ReloadDBEditRequestNumber"];
			if (requestNumber != StringValues.Empty)
				Response.Headers["ReloadDBEditRequestNumber"] = requestNumber.First();

			try
			{
				switch (string.IsNullOrEmpty(Identifier) ? "" : Identifier)
				{
					case "PRESENCA__TREINO__DATA":	// Field (DB)
						{
							var model = new Presenca_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Presenca__treino__data(qs);
							result = model.TableTreinoData;
						}
						break;
					case "PRESENCA__JOGADOR__NOME":	// Field (DB)
						{
							var model = new Presenca_ViewModel(UserContext.Current) { editable = false };
							model.MapFromModel(row);
							model.Load_Presenca__jogador__nome(qs);
							result = model.TableJogadorNome;
						}
						break;
					default:
						break;
				}
			}
			catch (Exception)
			{
				return JsonERROR("On Reload form field: " + Identifier);
			}

			if (result != null)
				return JsonOK(new { List = result.List, TotalRows = result.Pagination.TotalRows, Selected = result.Selected, Value = result.Value });
			return JsonERROR("Not found any valid result");
		}

		[HttpPost]
		public JsonResult GetDependants([FromBody]RequestDependantsModel requestModel)
		{
			var Identifier = requestModel.Identifier;
			var Selected = requestModel.Selected;

			ConcurrentDictionary<string, object> values = null;
			this.IsStateReadonly = true;

			try
			{
				// Only the last reload request is accepted.
				var requestNumber = Request.Headers["GetDependantsRequestNumber"];
				if (requestNumber != StringValues.Empty)
					Response.Headers["GetDependantsRequestNumber"] = requestNumber.First();

				UserContext.Current.PersistentSupport.openConnection();
				switch (string.IsNullOrEmpty(Identifier) ? "" : Identifier)
				{
					case "PRESENCA__TREINO__DATA":	// Field (DB)
						values = new Presenca_ViewModel(UserContext.Current).GetDependant_PresencaTableTreinoData(Selected);
						break;
					case "PRESENCA__JOGADOR__NOME":	// Field (DB)
						values = new Presenca_ViewModel(UserContext.Current).GetDependant_PresencaTableJogadorNome(Selected);
						break;
					default: break;
				}

				if (values == null || !values.Any())
					return JsonERROR("List is empty");

				// Remove DateTime.MinValue
				foreach (KeyValuePair<string, object> field in values)
					if (field.Value is DateTime && (DateTime)field.Value == DateTime.MinValue)
						values.TryUpdate(field.Key, "", DateTime.MinValue);

				// TODO: Sanitize HTML content
				return JsonOK(values);
			}
			catch (Exception)
			{
				return JsonERROR("On Get Dependants - " + Identifier);
			}
			finally
			{
				UserContext.Current.PersistentSupport.closeConnection();
			}
		}





		/// <summary>
		/// Recalculate formulas of the "Presenca" form. (++, CT, SR, CL and U1)
		/// </summary>
		/// <param name="formData">Current form data</param>
		/// <returns></returns>
		[HttpPost]
		public JsonResult RecalculateFormulas_Presenca([FromBody]Presenca_ViewModel formData)
		{
			return GenericRecalculateFormulas(formData, "presenca",
				(primaryKey) => Models.Presenca.Find(primaryKey, UserContext.Current, "FPRESENCA"),
				(model) => formData.MapToModel(model as Models.Presenca)
			);
		}

		/// <summary>
		/// Get "See more..." tree structure
		/// </summary>
		/// <returns></returns>
		public JsonResult GetTreeSeeMore([FromBody]RequestLookupModel requestModel)
		{
			var Identifier = requestModel.Identifier;
			var queryParams = requestModel.QueryParams;

			try
			{
				// We need the request values to apply filters
				var requestValues = new NameValueCollection();
				if (queryParams != null)
					foreach (var kv in queryParams)
						requestValues.Add(kv.Key, kv.Value);

				switch (string.IsNullOrEmpty(Identifier) ? "" : Identifier)
				{
					default:
						break;
				}
			}
			catch (Exception)
			{
				return Json(new { Success = false, Message = "Error" });
			}

			return Json(new { Success = false, Message = "Error" });
		}

		/// <summary>
		/// Gets the necessary tickets to interact with the given document
		/// </summary>
		/// <param name="requestModel">The request model with the table, field and the primary key of the record</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult GetDocumsTickets([FromBody] RequestDocumGetTicketsModel requestModel)
		{
			return base.GetDocumsTickets("PRESENCA", requestModel.FieldName, requestModel.KeyValue);
		}

		/// <summary>
		/// Gets the versions of the specified document
		/// </summary>
		/// <param name="requestModel">The request model with the ticket</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult GetFileVersions([FromBody] RequestDocumGetModel requestModel)
		{
			return base.GetFileVersions(requestModel.Ticket);
		}

		/// <summary>
		/// Gets the properties of the specified document
		/// </summary>
		/// <param name="requestModel">The request model with the ticket</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult GetFileProperties([FromBody] RequestDocumGetModel requestModel)
		{
			return base.GetFileProperties(requestModel.Ticket);
		}

		/// <summary>
		/// Gets the binary file associated to the specified document
		/// </summary>
		/// <param name="requestModel">The request model with the ticket and view type</param>
		/// <returns>A File object with the content of the document</returns>
		public ActionResult GetFile([FromBody] RequestDocumGetModel requestModel)
		{
			return base.GetFile(requestModel.Ticket, requestModel.ViewType);
		}

		/// <summary>
		/// Changes the state/properties of a given document
		/// </summary>
		/// <param name="requestModel">The request model with a list of changes</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult SetFilesState([FromBody] RequestDocumsChangeModel requestModel)
		{
			return base.SetFilesState(requestModel.Documents);
		}
	}
}
