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
using GenioMVC.ViewModels.Exercicio;
using Quidgest.Persistence.GenericQuery;

// USE /[MANUAL SQB INCLUDE_CONTROLLER EXERCICIO]/

namespace GenioMVC.Controllers
{
	public partial class ExercicioController : ControllerBase
	{
		#region NavigationLocation Names

		private static readonly NavigationLocation ACTION_EXERCICIO_CANCEL = new("EXERCICIO05075", "Exercicio_Cancel", "Exercicio") { vueRouteName = "form-EXERCICIO", mode = "CANCEL" };
		private static readonly NavigationLocation ACTION_EXERCICIO_SHOW = new("EXERCICIO05075", "Exercicio_Show", "Exercicio") { vueRouteName = "form-EXERCICIO", mode = "SHOW" };
		private static readonly NavigationLocation ACTION_EXERCICIO_NEW = new("EXERCICIO05075", "Exercicio_New", "Exercicio") { vueRouteName = "form-EXERCICIO", mode = "NEW" };
		private static readonly NavigationLocation ACTION_EXERCICIO_EDIT = new("EXERCICIO05075", "Exercicio_Edit", "Exercicio") { vueRouteName = "form-EXERCICIO", mode = "EDIT" };
		private static readonly NavigationLocation ACTION_EXERCICIO_DUPLICATE = new("EXERCICIO05075", "Exercicio_Duplicate", "Exercicio") { vueRouteName = "form-EXERCICIO", mode = "DUPLICATE" };
		private static readonly NavigationLocation ACTION_EXERCICIO_DELETE = new("EXERCICIO05075", "Exercicio_Delete", "Exercicio") { vueRouteName = "form-EXERCICIO", mode = "DELETE" };

		#endregion

		#region Exercicio private

		private void FormHistoryLimits_Exercicio()
		{

		}

		#endregion

		#region Exercicio_Show

// USE /[MANUAL SQB CONTROLLER_SHOW EXERCICIO]/

		[HttpPost]
		public ActionResult Exercicio_Show_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Exercicio_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Exercicio_Show_GET",
				AreaName = "exercicio",
				Location = ACTION_EXERCICIO_SHOW,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Exercicio();
// USE /[MANUAL SQB BEFORE_LOAD_SHOW EXERCICIO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_SHOW EXERCICIO]/
				}
			};

			return GenericHandleGetFormShow(eventSink, model, id);
		}

		#endregion

		#region Exercicio_New

// USE /[MANUAL SQB CONTROLLER_NEW_GET EXERCICIO]/
		[HttpPost]
		public ActionResult Exercicio_New_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;
			var prefillValues = requestModel.PrefillValues;

			Exercicio_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Exercicio_New_GET",
				AreaName = "exercicio",
				FormName = "EXERCICIO",
				Location = ACTION_EXERCICIO_NEW,
				BeforeAll = (sink, sp) =>
				{
					FormHistoryLimits_Exercicio();
				},
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_NEW EXERCICIO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_NEW EXERCICIO]/
				}
			};

			return GenericHandleGetFormNew(eventSink, model, id, isNewLocation, prefillValues);
		}

		//
		// POST: /Exercicio/Exercicio_New
// USE /[MANUAL SQB CONTROLLER_NEW_POST EXERCICIO]/
		[HttpPost]
		public ActionResult Exercicio_New([FromBody]Exercicio_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Exercicio_New",
				ViewName = "Exercicio",
				AreaName = "exercicio",
				Location = ACTION_EXERCICIO_NEW,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_SAVE_NEW EXERCICIO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_SAVE_NEW EXERCICIO]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_NEW_EX EXERCICIO]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_NEW_EX EXERCICIO]/
				}
			};

			return GenericHandlePostFormNew(eventSink, model);
		}

		#endregion

		#region Exercicio_Edit

// USE /[MANUAL SQB CONTROLLER_EDIT_GET EXERCICIO]/
		[HttpPost]
		public ActionResult Exercicio_Edit_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Exercicio_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Exercicio_Edit_GET",
				AreaName = "exercicio",
				FormName = "EXERCICIO",
				Location = ACTION_EXERCICIO_EDIT,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Exercicio();
// USE /[MANUAL SQB BEFORE_LOAD_EDIT EXERCICIO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_EDIT EXERCICIO]/
				}
			};

			return GenericHandleGetFormEdit(eventSink, model, id);
		}

		//
		// POST: /Exercicio/Exercicio_Edit
// USE /[MANUAL SQB CONTROLLER_EDIT_POST EXERCICIO]/
		[HttpPost]
		public ActionResult Exercicio_Edit([FromBody]Exercicio_ViewModel model, [FromQuery]bool redirect)
		{
			EventSink eventSink = new()
			{
				MethodName = "Exercicio_Edit",
				ViewName = "Exercicio",
				AreaName = "exercicio",
				Location = ACTION_EXERCICIO_EDIT,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_SAVE_EDIT EXERCICIO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_SAVE_EDIT EXERCICIO]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_EDIT_EX EXERCICIO]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_EDIT_EX EXERCICIO]/
				}
			};

			return GenericHandlePostFormEdit(eventSink, model);
		}

		#endregion

		#region Exercicio_Delete

// USE /[MANUAL SQB CONTROLLER_DELETE_GET EXERCICIO]/
		[HttpPost]
		public ActionResult Exercicio_Delete_GET([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Exercicio_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Exercicio_Delete_GET",
				AreaName = "exercicio",
				FormName = "EXERCICIO",
				Location = ACTION_EXERCICIO_DELETE,
				BeforeOp = (sink, sp) =>
				{
					FormHistoryLimits_Exercicio();
// USE /[MANUAL SQB BEFORE_LOAD_DELETE EXERCICIO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_DELETE EXERCICIO]/
				}
			};

			return GenericHandleGetFormDelete(eventSink, model, id);
		}

		//
		// POST: /Exercicio/Exercicio_Delete
// USE /[MANUAL SQB CONTROLLER_DELETE_POST EXERCICIO]/
		[HttpPost]
		public ActionResult Exercicio_Delete([FromBody] RequestIdModel requestModel)
		{
			string id = requestModel.Id;
			Exercicio_ViewModel model = new(UserContext.Current, id);
			model.MapFromModel();

			EventSink eventSink = new()
			{
				MethodName = "Exercicio_Delete",
				ViewName = "Exercicio",
				AreaName = "exercicio",
				Location = ACTION_EXERCICIO_DELETE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_DESTROY_DELETE EXERCICIO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_DESTROY_DELETE EXERCICIO]/
				}
			};

			return GenericHandlePostFormDelete(eventSink, model);
		}

		public ActionResult Exercicio_Delete_Redirect()
		{
			//FOR: FORM MENU GO BACK
			return RedirectToFormMenuGoBack("EXERCICIO");
		}

		#endregion

		#region Exercicio_Duplicate

// USE /[MANUAL SQB CONTROLLER_DUPLICATE_GET EXERCICIO]/

		[HttpPost]
		public ActionResult Exercicio_Duplicate_GET([FromBody] RequestNewGetModel requestModel)
		{
			string id = requestModel.Id;
			bool isNewLocation = requestModel.IsNewLocation;

			Exercicio_ViewModel model = new(UserContext.Current);
			EventSink eventSink = new()
			{
				MethodName = "Exercicio_Duplicate_GET",
				AreaName = "exercicio",
				FormName = "EXERCICIO",
				Location = ACTION_EXERCICIO_DUPLICATE,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_DUPLICATE EXERCICIO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_DUPLICATE EXERCICIO]/
				}
			};

			return GenericHandleGetFormDuplicate(eventSink, model, id, isNewLocation);
		}

		//
		// POST: /Exercicio/Exercicio_Duplicate
// USE /[MANUAL SQB CONTROLLER_DUPLICATE_POST EXERCICIO]/
		[HttpPost]
		public ActionResult Exercicio_Duplicate([FromBody]Exercicio_ViewModel model, [FromQuery]bool redirect = true)
		{
			EventSink eventSink = new()
			{
				MethodName = "Exercicio_Duplicate",
				ViewName = "Exercicio",
				AreaName = "exercicio",
				Location = ACTION_EXERCICIO_DUPLICATE,
				Redirect = redirect,
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_SAVE_DUPLICATE EXERCICIO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_SAVE_DUPLICATE EXERCICIO]/
				},
				BeforeException = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_LOAD_DUPLICATE_EX EXERCICIO]/
				},
				AfterException = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_LOAD_DUPLICATE_EX EXERCICIO]/
				}
			};

			return GenericHandlePostFormDuplicate(eventSink, model);
		}

		#endregion

		#region Exercicio_Cancel

		//
		// GET: /Exercicio/Exercicio_Cancel
// USE /[MANUAL SQB CONTROLLER_CANCEL_GET EXERCICIO]/
		public ActionResult Exercicio_Cancel()
		{
			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				PersistentSupport sp = UserContext.Current.PersistentSupport;
				try
				{
					GenioMVC.Models.Exercicio model = new(UserContext.Current);
					model.klass.QPrimaryKey = Navigation.GetStrValue("exercicio");

// USE /[MANUAL SQB BEFORE_CANCEL EXERCICIO]/

					sp.openTransaction();
					model.Destroy();
					sp.closeTransaction();

// USE /[MANUAL SQB AFTER_CANCEL EXERCICIO]/

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

				Navigation.SetValue("ForcePrimaryRead_exercicio", "true", true);
			}

			Navigation.ClearValue("exercicio");

			return JsonOK(new { Success = true, currentNavigationLevel = Navigation.CurrentLevel.Level });
		}

		#endregion


		// POST: /Exercicio/Exercicio_SaveEdit
		[HttpPost]
		public ActionResult Exercicio_SaveEdit([FromBody] Exercicio_ViewModel model)
		{
			EventSink eventSink = new()
			{
				MethodName = "Exercicio_SaveEdit",
				ViewName = "Exercicio",
				AreaName = "exercicio",
				BeforeOp = (sink, sp) =>
				{
// USE /[MANUAL SQB BEFORE_APPLY_EDIT EXERCICIO]/
				},
				AfterOp = (sink, sp) =>
				{
// USE /[MANUAL SQB AFTER_APPLY_EDIT EXERCICIO]/
				}
			};

			return GenericHandlePostFormApply(eventSink, model);
		}

		public class ExercicioDocumValidateTickets : RequestDocumValidateTickets
		{
			public Exercicio_ViewModel Model { get; set; }
		}

		/// <summary>
		/// Checks if the model is valid and, if so, updates the specified tickets with write permissions
		/// </summary>
		/// <param name="requestModel">The request model with a list of tickets and the form model</param>
		/// <returns>A JSON response with the result of the operation</returns>
		public ActionResult UpdateFilesTicketsExercicio([FromBody] ExercicioDocumValidateTickets requestModel)
		{
			requestModel.Model.Init(UserContext.Current);
			return UpdateFilesTickets(requestModel.Tickets, requestModel.Model, requestModel.IsApply);
		}
	}
}
