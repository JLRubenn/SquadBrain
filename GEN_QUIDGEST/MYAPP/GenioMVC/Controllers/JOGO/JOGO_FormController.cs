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
using GenioMVC.ViewModels.Jogo;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL SQB INCLUDE_CONTROLLER JOGO]/

namespace GenioMVC.Controllers
{
	public partial class JogoController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_JOGO_CANCEL = new("JOGO37147", "Jogo_Cancel", "Jogo") { vueRouteName = "form-JOGO", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_JOGO_SHOW = new("JOGO37147", "Jogo_Show", "Jogo") { vueRouteName = "form-JOGO", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_JOGO_NEW = new("JOGO37147", "Jogo_New", "Jogo") { vueRouteName = "form-JOGO", mode = "NEW" };
		private static readonly NavigationLocation ACTION_JOGO_EDIT = new("JOGO37147", "Jogo_Edit", "Jogo") { vueRouteName = "form-JOGO", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_JOGO_DUPLICATE = new("JOGO37147", "Jogo_Duplicate", "Jogo") { vueRouteName = "form-JOGO", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_JOGO_DELETE = new("JOGO37147", "Jogo_Delete", "Jogo") { vueRouteName = "form-JOGO", mode = "DELETE" };

		#endregion

		#region Jogo private

		private void FormHistoryLimits_Jogo()
		{

		}

		#endregion

		#region Jogo_Show

// USE /[MANUAL SQB CONTROLLER_SHOW JOGO]/

		[HttpPost]
		public ActionResult Jogo_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Jogo_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Jogo_Show_GET",
				AreaName = "jogo",
				Location = ACTION_JOGO_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Jogo();
// USE /[MANUAL SQB BEFORE_LOAD_SHOW JOGO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_SHOW JOGO]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Jogo_New

// USE /[MANUAL SQB CONTROLLER_NEW_GET JOGO]/
		[HttpPost]
		public ActionResult Jogo_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Jogo_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Jogo_New_GET",
				AreaName = "jogo",
				FormName = "JOGO",
				Location = ACTION_JOGO_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Jogo();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_NEW JOGO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_NEW JOGO]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Jogo/Jogo_New
// USE /[MANUAL SQB CONTROLLER_NEW_POST JOGO]/
		[HttpPost]
		public ActionResult Jogo_New([FromBody]Jogo_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Jogo_New",
				ViewName = "Jogo",
				AreaName = "jogo",
				Location = ACTION_JOGO_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_SAVE_NEW JOGO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_SAVE_NEW JOGO]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_NEW_EX JOGO]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_NEW_EX JOGO]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Jogo_Edit

// USE /[MANUAL SQB CONTROLLER_EDIT_GET JOGO]/
		[HttpPost]
		public ActionResult Jogo_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Jogo_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Jogo_Edit_GET",
				AreaName = "jogo",
				FormName = "JOGO",
				Location = ACTION_JOGO_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Jogo();
// USE /[MANUAL SQB BEFORE_LOAD_EDIT JOGO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_EDIT JOGO]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Jogo/Jogo_Edit
// USE /[MANUAL SQB CONTROLLER_EDIT_POST JOGO]/
		[HttpPost]
		public ActionResult Jogo_Edit([FromBody]Jogo_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Jogo_Edit",
				ViewName = "Jogo",
				AreaName = "jogo",
				Location = ACTION_JOGO_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_SAVE_EDIT JOGO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_SAVE_EDIT JOGO]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_EDIT_EX JOGO]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_EDIT_EX JOGO]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Jogo_Delete

// USE /[MANUAL SQB CONTROLLER_DELETE_GET JOGO]/
		[HttpPost]
		public ActionResult Jogo_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Jogo_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Jogo_Delete_GET",
				AreaName = "jogo",
				FormName = "JOGO",
				Location = ACTION_JOGO_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Jogo();
// USE /[MANUAL SQB BEFORE_LOAD_DELETE JOGO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_DELETE JOGO]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Jogo/Jogo_Delete
// USE /[MANUAL SQB CONTROLLER_DELETE_POST JOGO]/
		[HttpPost]
		public ActionResult Jogo_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Jogo_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Jogo_Delete",
				ViewName = "Jogo",
				AreaName = "jogo",
				Location = ACTION_JOGO_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_DESTROY_DELETE JOGO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_DESTROY_DELETE JOGO]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Jogo_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("JOGO");
		}

		#endregion

		#region Jogo_Duplicate

// USE /[MANUAL SQB CONTROLLER_DUPLICATE_GET JOGO]/

		[HttpPost]
		public ActionResult Jogo_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Jogo_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Jogo_Duplicate_GET",
				AreaName = "jogo",
				FormName = "JOGO",
				Location = ACTION_JOGO_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_DUPLICATE JOGO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_DUPLICATE JOGO]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Jogo/Jogo_Duplicate
// USE /[MANUAL SQB CONTROLLER_DUPLICATE_POST JOGO]/
		[HttpPost]
		public ActionResult Jogo_Duplicate([FromBody]Jogo_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Jogo_Duplicate",
				ViewName = "Jogo",
				AreaName = "jogo",
				Location = ACTION_JOGO_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_SAVE_DUPLICATE JOGO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_SAVE_DUPLICATE JOGO]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_DUPLICATE_EX JOGO]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_DUPLICATE_EX JOGO]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Jogo_Cancel

		//
		// GET: /Jogo/Jogo_Cancel
// USE /[MANUAL SQB CONTROLLER_CANCEL_GET JOGO]/
		public ActionResult Jogo_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Jogo model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("jogo");

// USE /[MANUAL SQB BEFORE_CANCEL JOGO]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL SQB AFTER_CANCEL JOGO]/

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

				Navigation.SetValue("ForcePrimaryRead_jogo", "true", true);
			}

			Navigation.ClearValue("jogo");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		// POST: /Jogo/Jogo_SaveEdit
		[HttpPost]
		public ActionResult Jogo_SaveEdit([FromBody] Jogo_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Jogo_SaveEdit",
				ViewName = "Jogo",
				AreaName = "jogo",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_APPLY_EDIT JOGO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_APPLY_EDIT JOGO]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class JogoDocumValidateTickets : RequestDocumValidateTickets
		{
			public Jogo_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsJogo([FromBody] JogoDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
