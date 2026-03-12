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

		private static readonly NavigationLocation ACTION_CONVOCATORIA_CANCEL = new("CONVOCATORIA23089", "Convocatoria_Cancel", "Convocatoria") { vueRouteName = "form-CONVOCATORIA", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_CONVOCATORIA_SHOW = new("CONVOCATORIA23089", "Convocatoria_Show", "Convocatoria") { vueRouteName = "form-CONVOCATORIA", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_CONVOCATORIA_NEW = new("CONVOCATORIA23089", "Convocatoria_New", "Convocatoria") { vueRouteName = "form-CONVOCATORIA", mode = "NEW" };
		private static readonly NavigationLocation ACTION_CONVOCATORIA_EDIT = new("CONVOCATORIA23089", "Convocatoria_Edit", "Convocatoria") { vueRouteName = "form-CONVOCATORIA", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_CONVOCATORIA_DUPLICATE = new("CONVOCATORIA23089", "Convocatoria_Duplicate", "Convocatoria") { vueRouteName = "form-CONVOCATORIA", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_CONVOCATORIA_DELETE = new("CONVOCATORIA23089", "Convocatoria_Delete", "Convocatoria") { vueRouteName = "form-CONVOCATORIA", mode = "DELETE" };

		#endregion

		#region Convocatoria private

		private void FormHistoryLimits_Convocatoria()
		{

		}

		#endregion

		#region Convocatoria_Show

// USE /[MANUAL SQB CONTROLLER_SHOW CONVOCATORIA]/

		[HttpPost]
		public ActionResult Convocatoria_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Convocatoria_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Convocatoria_Show_GET",
				AreaName = "convocatoria",
				Location = ACTION_CONVOCATORIA_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Convocatoria();
// USE /[MANUAL SQB BEFORE_LOAD_SHOW CONVOCATORIA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_SHOW CONVOCATORIA]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Convocatoria_New

// USE /[MANUAL SQB CONTROLLER_NEW_GET CONVOCATORIA]/
		[HttpPost]
		public ActionResult Convocatoria_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Convocatoria_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Convocatoria_New_GET",
				AreaName = "convocatoria",
				FormName = "CONVOCATORIA",
				Location = ACTION_CONVOCATORIA_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Convocatoria();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_NEW CONVOCATORIA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_NEW CONVOCATORIA]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Convocatoria/Convocatoria_New
// USE /[MANUAL SQB CONTROLLER_NEW_POST CONVOCATORIA]/
		[HttpPost]
		public ActionResult Convocatoria_New([FromBody]Convocatoria_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Convocatoria_New",
				ViewName = "Convocatoria",
				AreaName = "convocatoria",
				Location = ACTION_CONVOCATORIA_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_SAVE_NEW CONVOCATORIA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_SAVE_NEW CONVOCATORIA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_NEW_EX CONVOCATORIA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_NEW_EX CONVOCATORIA]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Convocatoria_Edit

// USE /[MANUAL SQB CONTROLLER_EDIT_GET CONVOCATORIA]/
		[HttpPost]
		public ActionResult Convocatoria_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Convocatoria_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Convocatoria_Edit_GET",
				AreaName = "convocatoria",
				FormName = "CONVOCATORIA",
				Location = ACTION_CONVOCATORIA_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Convocatoria();
// USE /[MANUAL SQB BEFORE_LOAD_EDIT CONVOCATORIA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_EDIT CONVOCATORIA]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Convocatoria/Convocatoria_Edit
// USE /[MANUAL SQB CONTROLLER_EDIT_POST CONVOCATORIA]/
		[HttpPost]
		public ActionResult Convocatoria_Edit([FromBody]Convocatoria_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Convocatoria_Edit",
				ViewName = "Convocatoria",
				AreaName = "convocatoria",
				Location = ACTION_CONVOCATORIA_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_SAVE_EDIT CONVOCATORIA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_SAVE_EDIT CONVOCATORIA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_EDIT_EX CONVOCATORIA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_EDIT_EX CONVOCATORIA]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Convocatoria_Delete

// USE /[MANUAL SQB CONTROLLER_DELETE_GET CONVOCATORIA]/
		[HttpPost]
		public ActionResult Convocatoria_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Convocatoria_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Convocatoria_Delete_GET",
				AreaName = "convocatoria",
				FormName = "CONVOCATORIA",
				Location = ACTION_CONVOCATORIA_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Convocatoria();
// USE /[MANUAL SQB BEFORE_LOAD_DELETE CONVOCATORIA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_DELETE CONVOCATORIA]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Convocatoria/Convocatoria_Delete
// USE /[MANUAL SQB CONTROLLER_DELETE_POST CONVOCATORIA]/
		[HttpPost]
		public ActionResult Convocatoria_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Convocatoria_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Convocatoria_Delete",
				ViewName = "Convocatoria",
				AreaName = "convocatoria",
				Location = ACTION_CONVOCATORIA_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_DESTROY_DELETE CONVOCATORIA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_DESTROY_DELETE CONVOCATORIA]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Convocatoria_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("CONVOCATORIA");
		}

		#endregion

		#region Convocatoria_Duplicate

// USE /[MANUAL SQB CONTROLLER_DUPLICATE_GET CONVOCATORIA]/

		[HttpPost]
		public ActionResult Convocatoria_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Convocatoria_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Convocatoria_Duplicate_GET",
				AreaName = "convocatoria",
				FormName = "CONVOCATORIA",
				Location = ACTION_CONVOCATORIA_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_DUPLICATE CONVOCATORIA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_DUPLICATE CONVOCATORIA]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Convocatoria/Convocatoria_Duplicate
// USE /[MANUAL SQB CONTROLLER_DUPLICATE_POST CONVOCATORIA]/
		[HttpPost]
		public ActionResult Convocatoria_Duplicate([FromBody]Convocatoria_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Convocatoria_Duplicate",
				ViewName = "Convocatoria",
				AreaName = "convocatoria",
				Location = ACTION_CONVOCATORIA_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_SAVE_DUPLICATE CONVOCATORIA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_SAVE_DUPLICATE CONVOCATORIA]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_DUPLICATE_EX CONVOCATORIA]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_DUPLICATE_EX CONVOCATORIA]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Convocatoria_Cancel

		//
		// GET: /Convocatoria/Convocatoria_Cancel
// USE /[MANUAL SQB CONTROLLER_CANCEL_GET CONVOCATORIA]/
		public ActionResult Convocatoria_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Convocatoria model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("convocatoria");

// USE /[MANUAL SQB BEFORE_CANCEL CONVOCATORIA]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL SQB AFTER_CANCEL CONVOCATORIA]/

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


		public class Convocatoria_JogoValTituloModel : RequestLookupModel
		{
			public Convocatoria_ViewModel Model { get; set; }
		}

		//
		// GET: /Convocatoria/Convocatoria_JogoValTitulo
		// POST: /Convocatoria/Convocatoria_JogoValTitulo
		[ActionName("Convocatoria_JogoValTitulo")]
		public ActionResult Convocatoria_JogoValTitulo([FromBody] Convocatoria_JogoValTituloModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_jogo")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_jogo");
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
			Convocatoria_JogoValTitulo_ViewModel model = new(m_userContext, parentCtx);

			CSGenio.core.framework.table.TableConfiguration tableConfig = model.GetTableConfig(requestModel.TableConfiguration);

			model.setModes(Request.Query["m"].ToString());
			model.Load(tableConfig, requestValues, Request.IsAjaxRequest());

			return JsonOK(model);
		}

		public class Convocatoria_ValConvocadosModel : RequestLookupModel
		{
			public Convocatoria_ViewModel Model { get; set; }
		}

		//
		// GET: /Convocatoria/Convocatoria_ValConvocados
		// POST: /Convocatoria/Convocatoria_ValConvocados
		[ActionName("Convocatoria_ValConvocados")]
		public ActionResult Convocatoria_ValConvocados([FromBody] Convocatoria_ValConvocadosModel requestModel)
		{
			var queryParams = requestModel.QueryParams;

			// If there was a recent operation on this table then force the primary persistence server to be called and ignore the read only feature
			if (string.IsNullOrEmpty(Navigation.GetStrValue("ForcePrimaryRead_convocatoria")))
				UserContext.Current.SetPersistenceReadOnly(true);
			else
			{
				Navigation.DestroyEntry("ForcePrimaryRead_convocatoria");
				UserContext.Current.SetPersistenceReadOnly(false);
			}

			NameValueCollection requestValues = [];
			if (queryParams != null)
			{
				// Add to request values
				foreach (var kv in queryParams)
					requestValues.Add(kv.Key, kv.Value);
			}

			Models.Convocatoria parentCtx = requestModel.Model == null ? null : new(m_userContext);
			requestModel.Model?.Init(m_userContext);
			requestModel.Model?.MapToModel(parentCtx);
			Convocatoria_ValConvocados_ViewModel model = new(m_userContext, parentCtx);

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

		// POST: /Convocatoria/Convocatoria_SaveEdit
		[HttpPost]
		public ActionResult Convocatoria_SaveEdit([FromBody] Convocatoria_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Convocatoria_SaveEdit",
				ViewName = "Convocatoria",
				AreaName = "convocatoria",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_APPLY_EDIT CONVOCATORIA]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_APPLY_EDIT CONVOCATORIA]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class ConvocatoriaDocumValidateTickets : RequestDocumValidateTickets
		{
			public Convocatoria_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsConvocatoria([FromBody] ConvocatoriaDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
