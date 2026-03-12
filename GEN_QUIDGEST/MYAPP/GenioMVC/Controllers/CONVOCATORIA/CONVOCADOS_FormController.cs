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
using GenioMVC.ViewModels.Convocatoria;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL SQB INCLUDE_CONTROLLER CONVOCATORIA]/

namespace GenioMVC.Controllers
{
	public partial class ConvocatoriaController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_CONVOCADOS_CANCEL = new("CONVOCATORIA23089", "Convocados_Cancel", "Convocatoria") { vueRouteName = "form-CONVOCADOS", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_CONVOCADOS_SHOW = new("CONVOCATORIA23089", "Convocados_Show", "Convocatoria") { vueRouteName = "form-CONVOCADOS", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_CONVOCADOS_NEW = new("CONVOCATORIA23089", "Convocados_New", "Convocatoria") { vueRouteName = "form-CONVOCADOS", mode = "NEW" };
		private static readonly NavigationLocation ACTION_CONVOCADOS_EDIT = new("CONVOCATORIA23089", "Convocados_Edit", "Convocatoria") { vueRouteName = "form-CONVOCADOS", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_CONVOCADOS_DUPLICATE = new("CONVOCATORIA23089", "Convocados_Duplicate", "Convocatoria") { vueRouteName = "form-CONVOCADOS", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_CONVOCADOS_DELETE = new("CONVOCATORIA23089", "Convocados_Delete", "Convocatoria") { vueRouteName = "form-CONVOCADOS", mode = "DELETE" };

		#endregion

		#region Convocados private

		private void FormHistoryLimits_Convocados()
		{

		}

		#endregion

		#region Convocados_Show

// USE /[MANUAL SQB CONTROLLER_SHOW CONVOCADOS]/

		[HttpPost]
		public ActionResult Convocados_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Convocados_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Convocados_Show_GET",
				AreaName = "convocatoria",
				Location = ACTION_CONVOCADOS_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Convocados();
// USE /[MANUAL SQB BEFORE_LOAD_SHOW CONVOCADOS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_SHOW CONVOCADOS]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Convocados_New

// USE /[MANUAL SQB CONTROLLER_NEW_GET CONVOCADOS]/
		[HttpPost]
		public ActionResult Convocados_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Convocados_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Convocados_New_GET",
				AreaName = "convocatoria",
				FormName = "CONVOCADOS",
				Location = ACTION_CONVOCADOS_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Convocados();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_NEW CONVOCADOS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_NEW CONVOCADOS]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Convocatoria/Convocados_New
// USE /[MANUAL SQB CONTROLLER_NEW_POST CONVOCADOS]/
		[HttpPost]
		public ActionResult Convocados_New([FromBody]Convocados_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Convocados_New",
				ViewName = "Convocados",
				AreaName = "convocatoria",
				Location = ACTION_CONVOCADOS_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_SAVE_NEW CONVOCADOS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_SAVE_NEW CONVOCADOS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_NEW_EX CONVOCADOS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_NEW_EX CONVOCADOS]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Convocados_Edit

// USE /[MANUAL SQB CONTROLLER_EDIT_GET CONVOCADOS]/
		[HttpPost]
		public ActionResult Convocados_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Convocados_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Convocados_Edit_GET",
				AreaName = "convocatoria",
				FormName = "CONVOCADOS",
				Location = ACTION_CONVOCADOS_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Convocados();
// USE /[MANUAL SQB BEFORE_LOAD_EDIT CONVOCADOS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_EDIT CONVOCADOS]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Convocatoria/Convocados_Edit
// USE /[MANUAL SQB CONTROLLER_EDIT_POST CONVOCADOS]/
		[HttpPost]
		public ActionResult Convocados_Edit([FromBody]Convocados_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Convocados_Edit",
				ViewName = "Convocados",
				AreaName = "convocatoria",
				Location = ACTION_CONVOCADOS_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_SAVE_EDIT CONVOCADOS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_SAVE_EDIT CONVOCADOS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_EDIT_EX CONVOCADOS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_EDIT_EX CONVOCADOS]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Convocados_Delete

// USE /[MANUAL SQB CONTROLLER_DELETE_GET CONVOCADOS]/
		[HttpPost]
		public ActionResult Convocados_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Convocados_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Convocados_Delete_GET",
				AreaName = "convocatoria",
				FormName = "CONVOCADOS",
				Location = ACTION_CONVOCADOS_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Convocados();
// USE /[MANUAL SQB BEFORE_LOAD_DELETE CONVOCADOS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_DELETE CONVOCADOS]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Convocatoria/Convocados_Delete
// USE /[MANUAL SQB CONTROLLER_DELETE_POST CONVOCADOS]/
		[HttpPost]
		public ActionResult Convocados_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Convocados_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Convocados_Delete",
				ViewName = "Convocados",
				AreaName = "convocatoria",
				Location = ACTION_CONVOCADOS_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_DESTROY_DELETE CONVOCADOS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_DESTROY_DELETE CONVOCADOS]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Convocados_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("CONVOCADOS");
		}

		#endregion

		#region Convocados_Duplicate

// USE /[MANUAL SQB CONTROLLER_DUPLICATE_GET CONVOCADOS]/

		[HttpPost]
		public ActionResult Convocados_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Convocados_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Convocados_Duplicate_GET",
				AreaName = "convocatoria",
				FormName = "CONVOCADOS",
				Location = ACTION_CONVOCADOS_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_DUPLICATE CONVOCADOS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_DUPLICATE CONVOCADOS]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Convocatoria/Convocados_Duplicate
// USE /[MANUAL SQB CONTROLLER_DUPLICATE_POST CONVOCADOS]/
		[HttpPost]
		public ActionResult Convocados_Duplicate([FromBody]Convocados_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Convocados_Duplicate",
				ViewName = "Convocados",
				AreaName = "convocatoria",
				Location = ACTION_CONVOCADOS_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_SAVE_DUPLICATE CONVOCADOS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_SAVE_DUPLICATE CONVOCADOS]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_DUPLICATE_EX CONVOCADOS]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_DUPLICATE_EX CONVOCADOS]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Convocados_Cancel

		//
		// GET: /Convocatoria/Convocados_Cancel
// USE /[MANUAL SQB CONTROLLER_CANCEL_GET CONVOCADOS]/
		public ActionResult Convocados_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Convocatoria model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("convocatoria");

// USE /[MANUAL SQB BEFORE_CANCEL CONVOCADOS]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL SQB AFTER_CANCEL CONVOCADOS]/

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

				Navigation.SetValue("ForcePrimaryRead_convocatoria", "true", true);
			}

			Navigation.ClearValue("convocatoria");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		public class Convocados_JogadorValNomeModel : RequestLookupModel
		{
			public Convocados_ViewModel Model { get; set; }
		}

		//
		// GET: /Convocatoria/Convocados_JogadorValNome
		// POST: /Convocatoria/Convocados_JogadorValNome
		[ActionName("Convocados_JogadorValNome")]
		public ActionResult Convocados_JogadorValNome([FromBody] Convocados_JogadorValNomeModel requestModel)
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

			Models.Convocatoria parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Convocados_JogadorValNome_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		// POST: /Convocatoria/Convocados_SaveEdit
		[HttpPost]
		public ActionResult Convocados_SaveEdit([FromBody] Convocados_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Convocados_SaveEdit",
				ViewName = "Convocados",
				AreaName = "convocatoria",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_APPLY_EDIT CONVOCADOS]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_APPLY_EDIT CONVOCADOS]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class ConvocadosDocumValidateTickets : RequestDocumValidateTickets
		{
			public Convocados_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsConvocados([FromBody] ConvocadosDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
