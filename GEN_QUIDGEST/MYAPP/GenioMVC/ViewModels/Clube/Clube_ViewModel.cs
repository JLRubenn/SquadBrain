using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Globalization;
using System.Text.Json.Serialization;

namespace GenioMVC.ViewModels.Clube
{
	public class Clube_ViewModel : FormViewModel<Models.Clube>, IPreparableForSerialization
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		#region Foreign keys

		#endregion
		/// <summary>
		/// Title: "Foto" | Type: "IJ"
		/// </summary>
		[ImageThumbnailJsonConverter(30, 50)]
		public GenioMVC.Models.ImageModel ValFoto { get; set; }
		/// <summary>
		/// Title: "Nome" | Type: "C"
		/// </summary>
		public string ValNome { get; set; }
		/// <summary>
		/// Title: "Escalão" | Type: "C"
		/// </summary>
		public string ValEscalao { get; set; }
		/// <summary>
		/// Title: "Época" | Type: "C"
		/// </summary>
		public string ValEpoca { get; set; }
		/// <summary>
		/// Title: "Valor Mercado Equipa (M)" | Type: "$"
		/// </summary>
		[ValidateSetAccess]
		public decimal? ValValormercadoequipa { get; set; }
		/// <summary>
		/// Title: "Presidente" | Type: "C"
		/// </summary>
		public string ValPresidente { get; set; }
		/// <summary>
		/// Title: "Coordenador Técnico" | Type: "C"
		/// </summary>
		public string ValCoordtecn { get; set; }
		/// <summary>
		/// Title: "Coordenador Formação" | Type: "C"
		/// </summary>
		public string ValCoordform { get; set; }
		/// <summary>
		/// Title: "Treinador Principal" | Type: "C"
		/// </summary>
		public string ValTreinadorprincipal { get; set; }
		/// <summary>
		/// Title: "Treinador Adjunto" | Type: "C"
		/// </summary>
		public string ValTreinadoradjunto { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodclube { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Clube_ViewModel() : base(null!) { }

		public Clube_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FCLUBE", nestedForm) { }

		public Clube_ViewModel(UserContext userContext, Models.Clube row, bool nestedForm = false) : base(userContext, "FCLUBE", row, nestedForm) { }

		public Clube_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("clube", id);
			Model = Models.Clube.Find(id, userContext, "FCLUBE", fieldsToQuery: fieldsToLoad);
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			InitModel();
		}

		protected override void InitLevels()
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_1;
			this.RoleToEdit = CSGenio.framework.Role.ROLE_1;
		}

		#region Form conditions

		public override StatusMessage InsertConditions()
		{
			return InsertConditions(m_userContext);
		}

		public static StatusMessage InsertConditions(UserContext userContext)
		{
			var m_userContext = userContext;
			StatusMessage result = new StatusMessage(Status.OK, "");
			Models.Clube model = new Models.Clube(userContext) { Identifier = "FCLUBE" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FCLUBE");
			if (navigation != null)
				model.LoadKeysFromHistory(navigation, navigation.CurrentLevel.Level);

			var tableResult = model.EvaluateTableConditions(ConditionType.INSERT);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage UpdateConditions()
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			var model = Model;

			var tableResult = model.EvaluateTableConditions(ConditionType.UPDATE);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage DeleteConditions()
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			var model = Model;

			var tableResult = model.EvaluateTableConditions(ConditionType.DELETE);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage ViewConditions()
		{
			var model = Model;
			StatusMessage result = model.EvaluateTableConditions(ConditionType.VIEW);
			var tableResult = model.EvaluateTableConditions(ConditionType.VIEW);
			result.MergeStatusMessage(tableResult);
			return result;
		}

		public override StatusMessage EvaluateWriteConditions(bool isApply)
		{
			StatusMessage result = new StatusMessage(Status.OK, "");
			return result;
		}

		public StatusMessage EvaluateTableConditions(ConditionType type)
		{
			return Model.EvaluateTableConditions(type);
		}

		#endregion

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Clube m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Clube) to ViewModel (Clube) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValFoto = ViewModelConversion.ToImage(m.ValFoto);
				ValNome = ViewModelConversion.ToString(m.ValNome);
				ValEscalao = ViewModelConversion.ToString(m.ValEscalao);
				ValEpoca = ViewModelConversion.ToString(m.ValEpoca);
				ValValormercadoequipa = ViewModelConversion.ToNumeric(m.ValValormercadoequipa);
				ValPresidente = ViewModelConversion.ToString(m.ValPresidente);
				ValCoordtecn = ViewModelConversion.ToString(m.ValCoordtecn);
				ValCoordform = ViewModelConversion.ToString(m.ValCoordform);
				ValTreinadorprincipal = ViewModelConversion.ToString(m.ValTreinadorprincipal);
				ValTreinadoradjunto = ViewModelConversion.ToString(m.ValTreinadoradjunto);
				ValCodclube = ViewModelConversion.ToString(m.ValCodclube);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Clube) to ViewModel (Clube) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Clube m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Clube) to Model (Clube) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				if (ValFoto == null || !ValFoto.IsThumbnail)
					m.ValFoto = ViewModelConversion.ToImage(ValFoto);
				m.ValNome = ViewModelConversion.ToString(ValNome);
				m.ValEscalao = ViewModelConversion.ToString(ValEscalao);
				m.ValEpoca = ViewModelConversion.ToString(ValEpoca);
				m.ValPresidente = ViewModelConversion.ToString(ValPresidente);
				m.ValCoordtecn = ViewModelConversion.ToString(ValCoordtecn);
				m.ValCoordform = ViewModelConversion.ToString(ValCoordform);
				m.ValTreinadorprincipal = ViewModelConversion.ToString(ValTreinadorprincipal);
				m.ValTreinadoradjunto = ViewModelConversion.ToString(ValTreinadoradjunto);
				m.ValCodclube = ViewModelConversion.ToString(ValCodclube);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValValormercadoequipa = ViewModelConversion.ToNumeric(ValValormercadoequipa);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Clube) to Model (Clube) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
				throw;
			}
		}

		/// <summary>
		/// Sets the value of a single property of the view model based on the provided table and field names.
		/// </summary>
		/// <param name="fullFieldName">The full field name in the format "table.field".</param>
		/// <param name="value">The field value.</param>
		/// <exception cref="ArgumentNullException">Thrown if <paramref name="fullFieldName"/> is null.</exception>
		public override void SetViewModelValue(string fullFieldName, object value)
		{
			try
			{
				ArgumentNullException.ThrowIfNull(fullFieldName);
				// Obtain a valid value from JsonValueKind that can come from "prefillValues" during the pre-filling of fields during insertion
				var _value = ViewModelConversion.ToRawValue(value);

				switch (fullFieldName)
				{
					case "clube.foto":
						this.ValFoto = ViewModelConversion.ToImage(_value);
						break;
					case "clube.nome":
						this.ValNome = ViewModelConversion.ToString(_value);
						break;
					case "clube.escalao":
						this.ValEscalao = ViewModelConversion.ToString(_value);
						break;
					case "clube.epoca":
						this.ValEpoca = ViewModelConversion.ToString(_value);
						break;
					case "clube.presidente":
						this.ValPresidente = ViewModelConversion.ToString(_value);
						break;
					case "clube.coordtecn":
						this.ValCoordtecn = ViewModelConversion.ToString(_value);
						break;
					case "clube.coordform":
						this.ValCoordform = ViewModelConversion.ToString(_value);
						break;
					case "clube.treinadorprincipal":
						this.ValTreinadorprincipal = ViewModelConversion.ToString(_value);
						break;
					case "clube.treinadoradjunto":
						this.ValTreinadoradjunto = ViewModelConversion.ToString(_value);
						break;
					case "clube.codclube":
						this.ValCodclube = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Clube) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Clube)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Clube.Find(id ?? Navigation.GetStrValue("clube"), m_userContext, "FCLUBE"); }
			finally { Model ??= new Models.Clube(m_userContext) { Identifier = "FCLUBE" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Clube.Find(Navigation.GetStrValue("clube"), m_userContext, "FCLUBE");
			}
			finally
			{
				if (Model == null)
					throw new ModelNotFoundException("Model not found");

				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
					LoadDefaultValues();
				else
					oldvalues = Model.klass;
			}

			Model.Identifier = "FCLUBE";
			InitModel(qs, lazyLoad);

			if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Edit || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
			{
				// MH - Voltar calcular as formulas to "atualizar" os Qvalues dos fields fixos
				// Conexão deve estar aberta de fora. Podem haver formulas que utilizam funções "manuais".
				// TODO: It needs to be analyzed whether we should disable the security of field filling here. If there is any case where the field with the block condition can only be calculated after the double calculation of the formulas.
				MapToModel(Model);

				// If it's inserting or duplicating, needs to fill the default values.
				if (Navigation.CurrentLevel.FormMode == FormMode.New || Navigation.CurrentLevel.FormMode == FormMode.Duplicate)
				{
					FunctionType funcType = Navigation.CurrentLevel.FormMode == FormMode.New
						? FunctionType.INS
						: FunctionType.DUP;

					Model.baseklass.fillValuesDefault(m_userContext.PersistentSupport, funcType);
				}

				// Preencher operações internas
				Model.klass.fillInternalOperations(m_userContext.PersistentSupport, oldvalues);
				MapFromModel(Model);
			}

			// Load just the selected row primary keys for checklists.
			// Needed for submitting forms incase checklists are in collapsible zones that have not been expanded to load the checklist data.
			LoadChecklistsSelectedIDs();
		}

		protected override void FillExtraProperties()
		{
		}
		
		protected override void LoadDocumentsProperties(Models.Clube row)
		{
		}

		/// <summary>
		/// Load Partial
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public override void LoadPartial(NameValueCollection qs, bool lazyLoad = false)
		{
			// MH [bugfix] - Quando o POST da ficha falha, ao recaregar a view os documentos na BD perdem alguma informação (ex: name do file)
			if (Model == null)
			{
				// Precisamos fazer o Find to obter as chaves dos documentos que já foram anexados
				// TODO: Conseguir passar estas chaves no POST to poder retirar o Find.
				Model = Models.Clube.Find(Navigation.GetStrValue("clube"), m_userContext, "FCLUBE");
				if (Model == null)
				{
					Model = new Models.Clube(m_userContext) { Identifier = "FCLUBE" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("clube");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();


// USE /[MANUAL SQB VIEWMODEL_LOADPARTIAL CLUBE]/
		}

// USE /[MANUAL SQB VIEWMODEL_NEW CLUBE]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValNome", Resources.Resources.NOME47814, ValNome, 50);

			validator.Required("ValNome", Resources.Resources.NOME47814, ViewModelConversion.ToString(ValNome), FieldType.TEXT.GetFormatting());
			validator.StringLength("ValEscalao", Resources.Resources.ESCALAO14935, ValEscalao, 50);
			validator.StringLength("ValEpoca", Resources.Resources.EPOCA21186, ValEpoca, 50);
			validator.StringLength("ValPresidente", Resources.Resources.PRESIDENTE51745, ValPresidente, 50);
			validator.StringLength("ValCoordtecn", Resources.Resources.COORDENADOR_TECNICO51290, ValCoordtecn, 50);
			validator.StringLength("ValCoordform", Resources.Resources.COORDENADOR_FORMACAO06004, ValCoordform, 50);
			validator.StringLength("ValTreinadorprincipal", Resources.Resources.TREINADOR_PRINCIPAL45661, ValTreinadorprincipal, 50);
			validator.StringLength("ValTreinadoradjunto", Resources.Resources.TREINADOR_ADJUNTO05329, ValTreinadoradjunto, 50);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL SQB VIEWMODEL_SAVE CLUBE]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL SQB VIEWMODEL_APPLY CLUBE]/

// USE /[MANUAL SQB VIEWMODEL_DUPLICATE CLUBE]/

// USE /[MANUAL SQB VIEWMODEL_DESTROY CLUBE]/
		public override void Destroy(string id)
		{
			Model = Models.Clube.Find(id, m_userContext, "FCLUBE");
			if (Model == null)
				throw new ModelNotFoundException("Model not found");
			this.flashMessage = Model.Destroy();
		}

		/// <summary>
		/// Load selected row primary keys for all checklists
		/// </summary>
		public void LoadChecklistsSelectedIDs()
		{
		}

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"clube.foto" => ViewModelConversion.ToImage(modelValue),
				"clube.nome" => ViewModelConversion.ToString(modelValue),
				"clube.escalao" => ViewModelConversion.ToString(modelValue),
				"clube.epoca" => ViewModelConversion.ToString(modelValue),
				"clube.valormercadoequipa" => ViewModelConversion.ToNumeric(modelValue),
				"clube.presidente" => ViewModelConversion.ToString(modelValue),
				"clube.coordtecn" => ViewModelConversion.ToString(modelValue),
				"clube.coordform" => ViewModelConversion.ToString(modelValue),
				"clube.treinadorprincipal" => ViewModelConversion.ToString(modelValue),
				"clube.treinadoradjunto" => ViewModelConversion.ToString(modelValue),
				"clube.codclube" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		/// <inheritdoc/>
		protected override void SetTicketToImageFields()
		{
			if (ValFoto != null)
				ValFoto.Ticket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaCLUBE, CSGenioAclube.FldFoto.Field, null, ValCodclube);
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL SQB VIEWMODEL_CUSTOM CLUBE]/

		#endregion
	}
}
