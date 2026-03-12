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
using GenioMVC.ViewModels.Clube;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL SQB INCLUDE_CONTROLLER CLUBE]/

namespace GenioMVC.Controllers
{
	public partial class ClubeController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_CLUBE_CANCEL = new("CLUBE52443", "Clube_Cancel", "Clube") { vueRouteName = "form-CLUBE", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_CLUBE_SHOW = new("CLUBE52443", "Clube_Show", "Clube") { vueRouteName = "form-CLUBE", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_CLUBE_NEW = new("CLUBE52443", "Clube_New", "Clube") { vueRouteName = "form-CLUBE", mode = "NEW" };
		private static readonly NavigationLocation ACTION_CLUBE_EDIT = new("CLUBE52443", "Clube_Edit", "Clube") { vueRouteName = "form-CLUBE", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_CLUBE_DUPLICATE = new("CLUBE52443", "Clube_Duplicate", "Clube") { vueRouteName = "form-CLUBE", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_CLUBE_DELETE = new("CLUBE52443", "Clube_Delete", "Clube") { vueRouteName = "form-CLUBE", mode = "DELETE" };

		#endregion

		#region Clube private

		private void FormHistoryLimits_Clube()
		{

		}

		#endregion

		#region Clube_Show

// USE /[MANUAL SQB CONTROLLER_SHOW CLUBE]/

		[HttpPost]
		public ActionResult Clube_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Clube_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Clube_Show_GET",
				AreaName = "clube",
				Location = ACTION_CLUBE_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Clube();
// USE /[MANUAL SQB BEFORE_LOAD_SHOW CLUBE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_SHOW CLUBE]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Clube_New

// USE /[MANUAL SQB CONTROLLER_NEW_GET CLUBE]/
		[HttpPost]
		public ActionResult Clube_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Clube_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Clube_New_GET",
				AreaName = "clube",
				FormName = "CLUBE",
				Location = ACTION_CLUBE_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Clube();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_NEW CLUBE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_NEW CLUBE]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Clube/Clube_New
// USE /[MANUAL SQB CONTROLLER_NEW_POST CLUBE]/
		[HttpPost]
		public ActionResult Clube_New([FromBody]Clube_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Clube_New",
				ViewName = "Clube",
				AreaName = "clube",
				Location = ACTION_CLUBE_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_SAVE_NEW CLUBE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_SAVE_NEW CLUBE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_NEW_EX CLUBE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_NEW_EX CLUBE]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Clube_Edit

// USE /[MANUAL SQB CONTROLLER_EDIT_GET CLUBE]/
		[HttpPost]
		public ActionResult Clube_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Clube_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Clube_Edit_GET",
				AreaName = "clube",
				FormName = "CLUBE",
				Location = ACTION_CLUBE_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Clube();
// USE /[MANUAL SQB BEFORE_LOAD_EDIT CLUBE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_EDIT CLUBE]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Clube/Clube_Edit
// USE /[MANUAL SQB CONTROLLER_EDIT_POST CLUBE]/
		[HttpPost]
		public ActionResult Clube_Edit([FromBody]Clube_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Clube_Edit",
				ViewName = "Clube",
				AreaName = "clube",
				Location = ACTION_CLUBE_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_SAVE_EDIT CLUBE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_SAVE_EDIT CLUBE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_EDIT_EX CLUBE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_EDIT_EX CLUBE]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Clube_Delete

// USE /[MANUAL SQB CONTROLLER_DELETE_GET CLUBE]/
		[HttpPost]
		public ActionResult Clube_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Clube_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Clube_Delete_GET",
				AreaName = "clube",
				FormName = "CLUBE",
				Location = ACTION_CLUBE_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Clube();
// USE /[MANUAL SQB BEFORE_LOAD_DELETE CLUBE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_DELETE CLUBE]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Clube/Clube_Delete
// USE /[MANUAL SQB CONTROLLER_DELETE_POST CLUBE]/
		[HttpPost]
		public ActionResult Clube_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Clube_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Clube_Delete",
				ViewName = "Clube",
				AreaName = "clube",
				Location = ACTION_CLUBE_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_DESTROY_DELETE CLUBE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_DESTROY_DELETE CLUBE]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Clube_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("CLUBE");
		}

		#endregion

		#region Clube_Duplicate

// USE /[MANUAL SQB CONTROLLER_DUPLICATE_GET CLUBE]/

		[HttpPost]
		public ActionResult Clube_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Clube_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Clube_Duplicate_GET",
				AreaName = "clube",
				FormName = "CLUBE",
				Location = ACTION_CLUBE_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_DUPLICATE CLUBE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_DUPLICATE CLUBE]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Clube/Clube_Duplicate
// USE /[MANUAL SQB CONTROLLER_DUPLICATE_POST CLUBE]/
		[HttpPost]
		public ActionResult Clube_Duplicate([FromBody]Clube_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Clube_Duplicate",
				ViewName = "Clube",
				AreaName = "clube",
				Location = ACTION_CLUBE_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_SAVE_DUPLICATE CLUBE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_SAVE_DUPLICATE CLUBE]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_DUPLICATE_EX CLUBE]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_DUPLICATE_EX CLUBE]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Clube_Cancel

		//
		// GET: /Clube/Clube_Cancel
// USE /[MANUAL SQB CONTROLLER_CANCEL_GET CLUBE]/
		public ActionResult Clube_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Clube model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("clube");

// USE /[MANUAL SQB BEFORE_CANCEL CLUBE]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL SQB AFTER_CANCEL CLUBE]/

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

				Navigation.SetValue("ForcePrimaryRead_clube", "true", true);
			}

			Navigation.ClearValue("clube");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		// POST: /Clube/Clube_SaveEdit
		[HttpPost]
		public ActionResult Clube_SaveEdit([FromBody] Clube_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Clube_SaveEdit",
				ViewName = "Clube",
				AreaName = "clube",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_APPLY_EDIT CLUBE]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_APPLY_EDIT CLUBE]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class ClubeDocumValidateTickets : RequestDocumValidateTickets
		{
			public Clube_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsClube([FromBody] ClubeDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
