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
using GenioMVC.ViewModels.Jogador;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL SQB INCLUDE_CONTROLLER JOGADOR]/

namespace GenioMVC.Controllers
{
	public partial class JogadorController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_JOGADOR_CANCEL = new("JOGADOR34905", "Jogador_Cancel", "Jogador") { vueRouteName = "form-JOGADOR", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_JOGADOR_SHOW = new("JOGADOR34905", "Jogador_Show", "Jogador") { vueRouteName = "form-JOGADOR", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_JOGADOR_NEW = new("JOGADOR34905", "Jogador_New", "Jogador") { vueRouteName = "form-JOGADOR", mode = "NEW" };
		private static readonly NavigationLocation ACTION_JOGADOR_EDIT = new("JOGADOR34905", "Jogador_Edit", "Jogador") { vueRouteName = "form-JOGADOR", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_JOGADOR_DUPLICATE = new("JOGADOR34905", "Jogador_Duplicate", "Jogador") { vueRouteName = "form-JOGADOR", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_JOGADOR_DELETE = new("JOGADOR34905", "Jogador_Delete", "Jogador") { vueRouteName = "form-JOGADOR", mode = "DELETE" };

		#endregion

		#region Jogador private

		private void FormHistoryLimits_Jogador()
		{

		}

		#endregion

		#region Jogador_Show

// USE /[MANUAL SQB CONTROLLER_SHOW JOGADOR]/

		[HttpPost]
		public ActionResult Jogador_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Jogador_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Jogador_Show_GET",
				AreaName = "jogador",
				Location = ACTION_JOGADOR_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Jogador();
// USE /[MANUAL SQB BEFORE_LOAD_SHOW JOGADOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_SHOW JOGADOR]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Jogador_New

// USE /[MANUAL SQB CONTROLLER_NEW_GET JOGADOR]/
		[HttpPost]
		public ActionResult Jogador_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Jogador_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Jogador_New_GET",
				AreaName = "jogador",
				FormName = "JOGADOR",
				Location = ACTION_JOGADOR_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Jogador();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_NEW JOGADOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_NEW JOGADOR]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Jogador/Jogador_New
// USE /[MANUAL SQB CONTROLLER_NEW_POST JOGADOR]/
		[HttpPost]
		public ActionResult Jogador_New([FromBody]Jogador_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Jogador_New",
				ViewName = "Jogador",
				AreaName = "jogador",
				Location = ACTION_JOGADOR_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_SAVE_NEW JOGADOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_SAVE_NEW JOGADOR]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_NEW_EX JOGADOR]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_NEW_EX JOGADOR]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Jogador_Edit

// USE /[MANUAL SQB CONTROLLER_EDIT_GET JOGADOR]/
		[HttpPost]
		public ActionResult Jogador_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Jogador_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Jogador_Edit_GET",
				AreaName = "jogador",
				FormName = "JOGADOR",
				Location = ACTION_JOGADOR_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Jogador();
// USE /[MANUAL SQB BEFORE_LOAD_EDIT JOGADOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_EDIT JOGADOR]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Jogador/Jogador_Edit
// USE /[MANUAL SQB CONTROLLER_EDIT_POST JOGADOR]/
		[HttpPost]
		public ActionResult Jogador_Edit([FromBody]Jogador_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Jogador_Edit",
				ViewName = "Jogador",
				AreaName = "jogador",
				Location = ACTION_JOGADOR_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_SAVE_EDIT JOGADOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_SAVE_EDIT JOGADOR]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_EDIT_EX JOGADOR]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_EDIT_EX JOGADOR]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Jogador_Delete

// USE /[MANUAL SQB CONTROLLER_DELETE_GET JOGADOR]/
		[HttpPost]
		public ActionResult Jogador_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Jogador_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Jogador_Delete_GET",
				AreaName = "jogador",
				FormName = "JOGADOR",
				Location = ACTION_JOGADOR_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Jogador();
// USE /[MANUAL SQB BEFORE_LOAD_DELETE JOGADOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_DELETE JOGADOR]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Jogador/Jogador_Delete
// USE /[MANUAL SQB CONTROLLER_DELETE_POST JOGADOR]/
		[HttpPost]
		public ActionResult Jogador_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Jogador_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Jogador_Delete",
				ViewName = "Jogador",
				AreaName = "jogador",
				Location = ACTION_JOGADOR_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_DESTROY_DELETE JOGADOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_DESTROY_DELETE JOGADOR]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Jogador_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("JOGADOR");
		}

		#endregion

		#region Jogador_Duplicate

// USE /[MANUAL SQB CONTROLLER_DUPLICATE_GET JOGADOR]/

		[HttpPost]
		public ActionResult Jogador_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Jogador_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Jogador_Duplicate_GET",
				AreaName = "jogador",
				FormName = "JOGADOR",
				Location = ACTION_JOGADOR_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_DUPLICATE JOGADOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_DUPLICATE JOGADOR]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Jogador/Jogador_Duplicate
// USE /[MANUAL SQB CONTROLLER_DUPLICATE_POST JOGADOR]/
		[HttpPost]
		public ActionResult Jogador_Duplicate([FromBody]Jogador_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Jogador_Duplicate",
				ViewName = "Jogador",
				AreaName = "jogador",
				Location = ACTION_JOGADOR_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_SAVE_DUPLICATE JOGADOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_SAVE_DUPLICATE JOGADOR]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_DUPLICATE_EX JOGADOR]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_DUPLICATE_EX JOGADOR]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Jogador_Cancel

		//
		// GET: /Jogador/Jogador_Cancel
// USE /[MANUAL SQB CONTROLLER_CANCEL_GET JOGADOR]/
		public ActionResult Jogador_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Jogador model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("jogador");

// USE /[MANUAL SQB BEFORE_CANCEL JOGADOR]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL SQB AFTER_CANCEL JOGADOR]/

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

				Navigation.SetValue("ForcePrimaryRead_jogador", "true", true);
			}

			Navigation.ClearValue("jogador");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Jogador_ClubeValNomeModel : RequestLookupModel
		{
			public Jogador_ViewModel Model { get; set; }
		}

		//
		// GET: /Jogador/Jogador_ClubeValNome
		// POST: /Jogador/Jogador_ClubeValNome
		[ActionName("Jogador_ClubeValNome")]
		public ActionResult Jogador_ClubeValNome([FromBody] Jogador_ClubeValNomeModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_clube")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_clube");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			IsStateReadonly = true;

			Models.Jogador parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Jogador_ClubeValNome_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Jogador/Jogador_SaveEdit
		[HttpPost]
		public ActionResult Jogador_SaveEdit([FromBody] Jogador_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Jogador_SaveEdit",
				ViewName = "Jogador",
				AreaName = "jogador",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_APPLY_EDIT JOGADOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_APPLY_EDIT JOGADOR]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class JogadorDocumValidateTickets : RequestDocumValidateTickets
		{
			public Jogador_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsJogador([FromBody] JogadorDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
