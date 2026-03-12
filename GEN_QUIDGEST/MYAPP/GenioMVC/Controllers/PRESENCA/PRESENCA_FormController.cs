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
using GenioMVC.ViewModels.Presenca;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL SQB INCLUDE_CONTROLLER PRESENCA]/

namespace GenioMVC.Controllers
{
	public partial class PresencaController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_PRESENCA_CANCEL = new("PRESENCA08209", "Presenca_Cancel", "Presenca") { vueRouteName = "form-PRESENCA", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_PRESENCA_SHOW = new("PRESENCA08209", "Presenca_Show", "Presenca") { vueRouteName = "form-PRESENCA", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_PRESENCA_NEW = new("PRESENCA08209", "Presenca_New", "Presenca") { vueRouteName = "form-PRESENCA", mode = "NEW" };
		private static readonly NavigationLocation ACTION_PRESENCA_EDIT = new("PRESENCA08209", "Presenca_Edit", "Presenca") { vueRouteName = "form-PRESENCA", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_PRESENCA_DUPLICATE = new("PRESENCA08209", "Presenca_Duplicate", "Presenca") { vueRouteName = "form-PRESENCA", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_PRESENCA_DELETE = new("PRESENCA08209", "Presenca_Delete", "Presenca") { vueRouteName = "form-PRESENCA", mode = "DELETE" };

		#endregion

		#region Presenca private

		private void FormHistoryLimits_Presenca()
		{

		}

		#endregion

		#region Presenca_Show

// USE /[MANUAL SQB CONTROLLER_SHOW PRESENCA]/

		[HttpPost]
		public ActionResult Presenca_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Presenca_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Presenca_Show_GET",
				AreaName = "presenca",
				Location = ACTION_PRESENCA_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Presenca();
// USE /[MANUAL SQB BEFORE_LOAD_SHOW PRESENCA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_SHOW PRESENCA]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Presenca_New

// USE /[MANUAL SQB CONTROLLER_NEW_GET PRESENCA]/
		[HttpPost]
		public ActionResult Presenca_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Presenca_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Presenca_New_GET",
				AreaName = "presenca",
				FormName = "PRESENCA",
				Location = ACTION_PRESENCA_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Presenca();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_NEW PRESENCA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_NEW PRESENCA]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Presenca/Presenca_New
// USE /[MANUAL SQB CONTROLLER_NEW_POST PRESENCA]/
		[HttpPost]
		public ActionResult Presenca_New([FromBody]Presenca_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Presenca_New",
				ViewName = "Presenca",
				AreaName = "presenca",
				Location = ACTION_PRESENCA_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_SAVE_NEW PRESENCA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_SAVE_NEW PRESENCA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_NEW_EX PRESENCA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_NEW_EX PRESENCA]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Presenca_Edit

// USE /[MANUAL SQB CONTROLLER_EDIT_GET PRESENCA]/
		[HttpPost]
		public ActionResult Presenca_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Presenca_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Presenca_Edit_GET",
				AreaName = "presenca",
				FormName = "PRESENCA",
				Location = ACTION_PRESENCA_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Presenca();
// USE /[MANUAL SQB BEFORE_LOAD_EDIT PRESENCA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_EDIT PRESENCA]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Presenca/Presenca_Edit
// USE /[MANUAL SQB CONTROLLER_EDIT_POST PRESENCA]/
		[HttpPost]
		public ActionResult Presenca_Edit([FromBody]Presenca_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Presenca_Edit",
				ViewName = "Presenca",
				AreaName = "presenca",
				Location = ACTION_PRESENCA_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_SAVE_EDIT PRESENCA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_SAVE_EDIT PRESENCA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_EDIT_EX PRESENCA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_EDIT_EX PRESENCA]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Presenca_Delete

// USE /[MANUAL SQB CONTROLLER_DELETE_GET PRESENCA]/
		[HttpPost]
		public ActionResult Presenca_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Presenca_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Presenca_Delete_GET",
				AreaName = "presenca",
				FormName = "PRESENCA",
				Location = ACTION_PRESENCA_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Presenca();
// USE /[MANUAL SQB BEFORE_LOAD_DELETE PRESENCA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_DELETE PRESENCA]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Presenca/Presenca_Delete
// USE /[MANUAL SQB CONTROLLER_DELETE_POST PRESENCA]/
		[HttpPost]
		public ActionResult Presenca_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Presenca_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Presenca_Delete",
				ViewName = "Presenca",
				AreaName = "presenca",
				Location = ACTION_PRESENCA_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_DESTROY_DELETE PRESENCA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_DESTROY_DELETE PRESENCA]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Presenca_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("PRESENCA");
		}

		#endregion

		#region Presenca_Duplicate

// USE /[MANUAL SQB CONTROLLER_DUPLICATE_GET PRESENCA]/

		[HttpPost]
		public ActionResult Presenca_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Presenca_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Presenca_Duplicate_GET",
				AreaName = "presenca",
				FormName = "PRESENCA",
				Location = ACTION_PRESENCA_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_DUPLICATE PRESENCA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_DUPLICATE PRESENCA]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Presenca/Presenca_Duplicate
// USE /[MANUAL SQB CONTROLLER_DUPLICATE_POST PRESENCA]/
		[HttpPost]
		public ActionResult Presenca_Duplicate([FromBody]Presenca_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Presenca_Duplicate",
				ViewName = "Presenca",
				AreaName = "presenca",
				Location = ACTION_PRESENCA_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_SAVE_DUPLICATE PRESENCA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_SAVE_DUPLICATE PRESENCA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_DUPLICATE_EX PRESENCA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_DUPLICATE_EX PRESENCA]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Presenca_Cancel

		//
		// GET: /Presenca/Presenca_Cancel
// USE /[MANUAL SQB CONTROLLER_CANCEL_GET PRESENCA]/
		public ActionResult Presenca_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Presenca model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("presenca");

// USE /[MANUAL SQB BEFORE_CANCEL PRESENCA]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL SQB AFTER_CANCEL PRESENCA]/

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

				Navigation.SetValue("ForcePrimaryRead_presenca", "true", true);
			}

			Navigation.ClearValue("presenca");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Presenca_ValPresencaModel : RequestLookupModel
		{
			public Presenca_ViewModel Model { get; set; }
		}

		//
		// GET: /Presenca/Presenca_ValPresenca
		// POST: /Presenca/Presenca_ValPresenca
		[ActionName("Presenca_ValPresenca")]
		public ActionResult Presenca_ValPresenca([FromBody] Presenca_ValPresencaModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_presenca")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_presenca");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Presenca parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Presenca_ValPresenca_ViewModel model = new(m_userContext, parentCtx);

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

		public class Presenca_JogadorValNomeModel : RequestLookupModel
		{
			public Presenca_ViewModel Model { get; set; }
		}

		//
		// GET: /Presenca/Presenca_JogadorValNome
		// POST: /Presenca/Presenca_JogadorValNome
		[ActionName("Presenca_JogadorValNome")]
		public ActionResult Presenca_JogadorValNome([FromBody] Presenca_JogadorValNomeModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_jogador")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_jogador");
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

			Models.Presenca parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Presenca_JogadorValNome_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Presenca/Presenca_SaveEdit
		[HttpPost]
		public ActionResult Presenca_SaveEdit([FromBody] Presenca_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Presenca_SaveEdit",
				ViewName = "Presenca",
				AreaName = "presenca",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_APPLY_EDIT PRESENCA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_APPLY_EDIT PRESENCA]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class PresencaDocumValidateTickets : RequestDocumValidateTickets
		{
			public Presenca_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsPresenca([FromBody] PresencaDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
