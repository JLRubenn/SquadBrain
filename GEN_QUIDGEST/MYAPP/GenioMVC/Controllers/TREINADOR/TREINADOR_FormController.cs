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
using GenioMVC.ViewModels.Treinador;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL SQB INCLUDE_CONTROLLER TREINADOR]/

namespace GenioMVC.Controllers
{
	public partial class TreinadorController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_TREINADOR_CANCEL = new("TREINADOR19936", "Treinador_Cancel", "Treinador") { vueRouteName = "form-TREINADOR", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_TREINADOR_SHOW = new("TREINADOR19936", "Treinador_Show", "Treinador") { vueRouteName = "form-TREINADOR", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_TREINADOR_NEW = new("TREINADOR19936", "Treinador_New", "Treinador") { vueRouteName = "form-TREINADOR", mode = "NEW" };
		private static readonly NavigationLocation ACTION_TREINADOR_EDIT = new("TREINADOR19936", "Treinador_Edit", "Treinador") { vueRouteName = "form-TREINADOR", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_TREINADOR_DUPLICATE = new("TREINADOR19936", "Treinador_Duplicate", "Treinador") { vueRouteName = "form-TREINADOR", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_TREINADOR_DELETE = new("TREINADOR19936", "Treinador_Delete", "Treinador") { vueRouteName = "form-TREINADOR", mode = "DELETE" };

		#endregion

		#region Treinador private

		private void FormHistoryLimits_Treinador()
		{

		}

		#endregion

		#region Treinador_Show

// USE /[MANUAL SQB CONTROLLER_SHOW TREINADOR]/

		[HttpPost]
		public ActionResult Treinador_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Treinador_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Treinador_Show_GET",
				AreaName = "treinador",
				Location = ACTION_TREINADOR_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Treinador();
// USE /[MANUAL SQB BEFORE_LOAD_SHOW TREINADOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_SHOW TREINADOR]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Treinador_New

// USE /[MANUAL SQB CONTROLLER_NEW_GET TREINADOR]/
		[HttpPost]
		public ActionResult Treinador_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Treinador_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Treinador_New_GET",
				AreaName = "treinador",
				FormName = "TREINADOR",
				Location = ACTION_TREINADOR_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Treinador();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_NEW TREINADOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_NEW TREINADOR]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Treinador/Treinador_New
// USE /[MANUAL SQB CONTROLLER_NEW_POST TREINADOR]/
		[HttpPost]
		public ActionResult Treinador_New([FromBody]Treinador_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Treinador_New",
				ViewName = "Treinador",
				AreaName = "treinador",
				Location = ACTION_TREINADOR_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_SAVE_NEW TREINADOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_SAVE_NEW TREINADOR]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_NEW_EX TREINADOR]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_NEW_EX TREINADOR]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Treinador_Edit

// USE /[MANUAL SQB CONTROLLER_EDIT_GET TREINADOR]/
		[HttpPost]
		public ActionResult Treinador_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Treinador_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Treinador_Edit_GET",
				AreaName = "treinador",
				FormName = "TREINADOR",
				Location = ACTION_TREINADOR_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Treinador();
// USE /[MANUAL SQB BEFORE_LOAD_EDIT TREINADOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_EDIT TREINADOR]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Treinador/Treinador_Edit
// USE /[MANUAL SQB CONTROLLER_EDIT_POST TREINADOR]/
		[HttpPost]
		public ActionResult Treinador_Edit([FromBody]Treinador_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Treinador_Edit",
				ViewName = "Treinador",
				AreaName = "treinador",
				Location = ACTION_TREINADOR_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_SAVE_EDIT TREINADOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_SAVE_EDIT TREINADOR]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_EDIT_EX TREINADOR]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_EDIT_EX TREINADOR]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Treinador_Delete

// USE /[MANUAL SQB CONTROLLER_DELETE_GET TREINADOR]/
		[HttpPost]
		public ActionResult Treinador_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Treinador_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Treinador_Delete_GET",
				AreaName = "treinador",
				FormName = "TREINADOR",
				Location = ACTION_TREINADOR_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Treinador();
// USE /[MANUAL SQB BEFORE_LOAD_DELETE TREINADOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_DELETE TREINADOR]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Treinador/Treinador_Delete
// USE /[MANUAL SQB CONTROLLER_DELETE_POST TREINADOR]/
		[HttpPost]
		public ActionResult Treinador_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Treinador_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Treinador_Delete",
				ViewName = "Treinador",
				AreaName = "treinador",
				Location = ACTION_TREINADOR_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_DESTROY_DELETE TREINADOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_DESTROY_DELETE TREINADOR]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Treinador_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("TREINADOR");
		}

		#endregion

		#region Treinador_Duplicate

// USE /[MANUAL SQB CONTROLLER_DUPLICATE_GET TREINADOR]/

		[HttpPost]
		public ActionResult Treinador_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Treinador_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Treinador_Duplicate_GET",
				AreaName = "treinador",
				FormName = "TREINADOR",
				Location = ACTION_TREINADOR_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_DUPLICATE TREINADOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_DUPLICATE TREINADOR]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Treinador/Treinador_Duplicate
// USE /[MANUAL SQB CONTROLLER_DUPLICATE_POST TREINADOR]/
		[HttpPost]
		public ActionResult Treinador_Duplicate([FromBody]Treinador_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Treinador_Duplicate",
				ViewName = "Treinador",
				AreaName = "treinador",
				Location = ACTION_TREINADOR_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_SAVE_DUPLICATE TREINADOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_SAVE_DUPLICATE TREINADOR]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_DUPLICATE_EX TREINADOR]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_DUPLICATE_EX TREINADOR]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Treinador_Cancel

		//
		// GET: /Treinador/Treinador_Cancel
// USE /[MANUAL SQB CONTROLLER_CANCEL_GET TREINADOR]/
		public ActionResult Treinador_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Treinador model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("treinador");

// USE /[MANUAL SQB BEFORE_CANCEL TREINADOR]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL SQB AFTER_CANCEL TREINADOR]/

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

				Navigation.SetValue("ForcePrimaryRead_treinador", "true", true);
			}

			Navigation.ClearValue("treinador");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Treinador_ClubeValNomeModel : RequestLookupModel
		{
			public Treinador_ViewModel Model { get; set; }
		}

		//
		// GET: /Treinador/Treinador_ClubeValNome
		// POST: /Treinador/Treinador_ClubeValNome
		[ActionName("Treinador_ClubeValNome")]
		public ActionResult Treinador_ClubeValNome([FromBody] Treinador_ClubeValNomeModel requestModel)
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

			Models.Treinador parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Treinador_ClubeValNome_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Treinador/Treinador_SaveEdit
		[HttpPost]
		public ActionResult Treinador_SaveEdit([FromBody] Treinador_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Treinador_SaveEdit",
				ViewName = "Treinador",
				AreaName = "treinador",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_APPLY_EDIT TREINADOR]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_APPLY_EDIT TREINADOR]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class TreinadorDocumValidateTickets : RequestDocumValidateTickets
		{
			public Treinador_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsTreinador([FromBody] TreinadorDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
