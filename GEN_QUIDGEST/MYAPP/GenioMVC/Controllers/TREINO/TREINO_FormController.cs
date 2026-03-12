using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Dynamic;

using CSGenio.business;
using CSGenio.core.persistence;
using CSGenio.framework;
using CSGenio.persistence;
using CSGenio.reporting;
using GenioMVC.Helpers;
using GenioMVC.Models;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using GenioMVC.Resources;
using GenioMVC.ViewModels;
using GenioMVC.ViewModels.Treino;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL SQB INCLUDE_CONTROLLER TREINO]/

namespace GenioMVC.Controllers
{
	public partial class TreinoController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_TREINO_CANCEL = new("PLANO_DE_TREINO27299", "Treino_Cancel", "Treino") { vueRouteName = "form-TREINO", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_TREINO_SHOW = new("PLANO_DE_TREINO27299", "Treino_Show", "Treino") { vueRouteName = "form-TREINO", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_TREINO_NEW = new("PLANO_DE_TREINO27299", "Treino_New", "Treino") { vueRouteName = "form-TREINO", mode = "NEW" };
		private static readonly NavigationLocation ACTION_TREINO_EDIT = new("PLANO_DE_TREINO27299", "Treino_Edit", "Treino") { vueRouteName = "form-TREINO", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_TREINO_DUPLICATE = new("PLANO_DE_TREINO27299", "Treino_Duplicate", "Treino") { vueRouteName = "form-TREINO", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_TREINO_DELETE = new("PLANO_DE_TREINO27299", "Treino_Delete", "Treino") { vueRouteName = "form-TREINO", mode = "DELETE" };

		#endregion

		#region Treino private

		private void FormHistoryLimits_Treino()
		{

		}

		#endregion

		#region Treino_Show

// USE /[MANUAL SQB CONTROLLER_SHOW TREINO]/

		[HttpPost]
		public ActionResult Treino_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Treino_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Treino_Show_GET",
				AreaName = "treino",
				Location = ACTION_TREINO_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Treino();
// USE /[MANUAL SQB BEFORE_LOAD_SHOW TREINO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_SHOW TREINO]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Treino_New

// USE /[MANUAL SQB CONTROLLER_NEW_GET TREINO]/
		[HttpPost]
		public ActionResult Treino_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Treino_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Treino_New_GET",
				AreaName = "treino",
				FormName = "TREINO",
				Location = ACTION_TREINO_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Treino();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_NEW TREINO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_NEW TREINO]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Treino/Treino_New
// USE /[MANUAL SQB CONTROLLER_NEW_POST TREINO]/
		[HttpPost]
		public ActionResult Treino_New([FromBody]Treino_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Treino_New",
				ViewName = "Treino",
				AreaName = "treino",
				Location = ACTION_TREINO_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_SAVE_NEW TREINO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_SAVE_NEW TREINO]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_NEW_EX TREINO]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_NEW_EX TREINO]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Treino_Edit

// USE /[MANUAL SQB CONTROLLER_EDIT_GET TREINO]/
		[HttpPost]
		public ActionResult Treino_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Treino_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Treino_Edit_GET",
				AreaName = "treino",
				FormName = "TREINO",
				Location = ACTION_TREINO_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Treino();
// USE /[MANUAL SQB BEFORE_LOAD_EDIT TREINO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_EDIT TREINO]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Treino/Treino_Edit
// USE /[MANUAL SQB CONTROLLER_EDIT_POST TREINO]/
		[HttpPost]
		public ActionResult Treino_Edit([FromBody]Treino_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Treino_Edit",
				ViewName = "Treino",
				AreaName = "treino",
				Location = ACTION_TREINO_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_SAVE_EDIT TREINO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_SAVE_EDIT TREINO]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_EDIT_EX TREINO]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_EDIT_EX TREINO]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Treino_Delete

// USE /[MANUAL SQB CONTROLLER_DELETE_GET TREINO]/
		[HttpPost]
		public ActionResult Treino_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Treino_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Treino_Delete_GET",
				AreaName = "treino",
				FormName = "TREINO",
				Location = ACTION_TREINO_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Treino();
// USE /[MANUAL SQB BEFORE_LOAD_DELETE TREINO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_DELETE TREINO]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Treino/Treino_Delete
// USE /[MANUAL SQB CONTROLLER_DELETE_POST TREINO]/
		[HttpPost]
		public ActionResult Treino_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Treino_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Treino_Delete",
				ViewName = "Treino",
				AreaName = "treino",
				Location = ACTION_TREINO_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_DESTROY_DELETE TREINO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_DESTROY_DELETE TREINO]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Treino_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("TREINO");
		}

		#endregion

		#region Treino_Duplicate

// USE /[MANUAL SQB CONTROLLER_DUPLICATE_GET TREINO]/

		[HttpPost]
		public ActionResult Treino_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Treino_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Treino_Duplicate_GET",
				AreaName = "treino",
				FormName = "TREINO",
				Location = ACTION_TREINO_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_DUPLICATE TREINO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_DUPLICATE TREINO]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Treino/Treino_Duplicate
// USE /[MANUAL SQB CONTROLLER_DUPLICATE_POST TREINO]/
		[HttpPost]
		public ActionResult Treino_Duplicate([FromBody]Treino_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Treino_Duplicate",
				ViewName = "Treino",
				AreaName = "treino",
				Location = ACTION_TREINO_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_SAVE_DUPLICATE TREINO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_SAVE_DUPLICATE TREINO]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_DUPLICATE_EX TREINO]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_DUPLICATE_EX TREINO]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Treino_Cancel

		//
		// GET: /Treino/Treino_Cancel
// USE /[MANUAL SQB CONTROLLER_CANCEL_GET TREINO]/
		public ActionResult Treino_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Treino model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("treino");

// USE /[MANUAL SQB BEFORE_CANCEL TREINO]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL SQB AFTER_CANCEL TREINO]/

				}
				catch (Exception e)
				{
					sp.rollbackTransaction();
					sp.closeConnection();

					var exceptionUserMessage = Resources.Resources.PEDIMOS_DESCULPA__OC63848;
					if (e is GenioException && (e as GenioException).UserMessage != null)
						exceptionUserMessage = Translations.Get((e as GenioException).UserMessage, UserContext.Current.User.Language);
					return JsonERROR(exceptionUserMessage);
				}

				Navigation.SetValue("ForcePrimaryRead_treino", "true", true);
			}

			Navigation.ClearValue("treino");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Treino_ValExercicioModel : RequestLookupModel
		{
			public Treino_ViewModel Model { get; set; }
		}

		//
		// GET: /Treino/Treino_ValExercicio
		// POST: /Treino/Treino_ValExercicio
		[ActionName("Treino_ValExercicio")]
		public ActionResult Treino_ValExercicio([FromBody] Treino_ValExercicioModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_exercicio")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_exercicio");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Treino parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Treino_ValExercicio_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(
				requestModel.TableConfiguration,
				requestModel.UserTableConfigName,
				requestModel.LoadDefaultView);

			// Determine rows per page
			tableConfig.RowsPerPage = tableConfig.DetermineRowsPerPage(CSGenio.framework.Configuration.NrRegDBedit, "");

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Treino/Treino_SaveEdit
		[HttpPost]
		public ActionResult Treino_SaveEdit([FromBody] Treino_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Treino_SaveEdit",
				ViewName = "Treino",
				AreaName = "treino",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_APPLY_EDIT TREINO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_APPLY_EDIT TREINO]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class TreinoDocumValidateTickets : RequestDocumValidateTickets
		{
			public Treino_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsTreino([FromBody] TreinoDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
