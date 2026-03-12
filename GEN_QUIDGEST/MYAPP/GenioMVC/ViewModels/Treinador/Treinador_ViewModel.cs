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

namespace GenioMVC.ViewModels.Treinador
{
	public class Treinador_ViewModel : FormViewModel<Models.Treinador>, IPreparableForSerialization
	{
		[JsonIgnore]
		public override bool HasWriteConditions { get => false; }

		/// <summary>
		/// Reference for the Models MsqActive property
		/// </summary>
		[JsonIgnore]
		public bool MsqActive { get; set; } = false;

		#region Foreign keys
		/// <summary>
		/// Title: "Nome" | Type: "CE"
		/// </summary>
		public string ValCodclube { get; set; }

		#endregion
		/// <summary>
		/// Title: "Nome" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Clube> TableClubeNome { get; set; }
		/// <summary>
		/// Title: "Nome" | Type: "C"
		/// </summary>
		public string ValNome { get; set; }
		/// <summary>
		/// Title: "Fun" | Type: "AC"
		/// </summary>
		public string ValFuncao { get; set; }
		/// <summary>
		/// Title: "LASTTREINOCRIADO" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public string ValLasttreinocriado { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodtreinador { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Treinador_ViewModel() : base(null!) { }

		public Treinador_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FTREINADOR", nestedForm) { }

		public Treinador_ViewModel(UserContext userContext, Models.Treinador row, bool nestedForm = false) : base(userContext, "FTREINADOR", row, nestedForm) { }

		public Treinador_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("treinador", id);
			Model = Models.Treinador.Find(id, userContext, "FTREINADOR", fieldsToQuery: fieldsToLoad);
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
			Models.Treinador model = new Models.Treinador(userContext) { Identifier = "FTREINADOR" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FTREINADOR");
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
		public override void MapFromModel(Models.Treinador m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Treinador) to ViewModel (Treinador) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodclube = ViewModelConversion.ToString(m.ValCodclube);
				ValNome = ViewModelConversion.ToString(m.ValNome);
				ValFuncao = ViewModelConversion.ToString(m.ValFuncao);
				ValLasttreinocriado = ViewModelConversion.ToString(m.ValLasttreinocriado);
				ValCodtreinador = ViewModelConversion.ToString(m.ValCodtreinador);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Treinador) to ViewModel (Treinador) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Treinador m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Treinador) to Model (Treinador) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodclube = ViewModelConversion.ToString(ValCodclube);
				m.ValNome = ViewModelConversion.ToString(ValNome);
				m.ValFuncao = ViewModelConversion.ToString(ValFuncao);
				m.ValCodtreinador = ViewModelConversion.ToString(ValCodtreinador);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValLasttreinocriado = ViewModelConversion.ToString(ValLasttreinocriado);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Treinador) to Model (Treinador) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "treinador.codclube":
						this.ValCodclube = ViewModelConversion.ToString(_value);
						break;
					case "treinador.nome":
						this.ValNome = ViewModelConversion.ToString(_value);
						break;
					case "treinador.funcao":
						this.ValFuncao = ViewModelConversion.ToString(_value);
						break;
					case "treinador.codtreinador":
						this.ValCodtreinador = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Treinador) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Treinador)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Treinador.Find(id ?? Navigation.GetStrValue("treinador"), m_userContext, "FTREINADOR"); }
			finally { Model ??= new Models.Treinador(m_userContext) { Identifier = "FTREINADOR" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Treinador.Find(Navigation.GetStrValue("treinador"), m_userContext, "FTREINADOR");
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

			Model.Identifier = "FTREINADOR";
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
		
		protected override void LoadDocumentsProperties(Models.Treinador row)
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
				Model = Models.Treinador.Find(Navigation.GetStrValue("treinador"), m_userContext, "FTREINADOR");
				if (Model == null)
				{
					Model = new Models.Treinador(m_userContext) { Identifier = "FTREINADOR" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("treinador");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Treinador__clube__nome(qs, lazyLoad);

// USE /[MANUAL SQB VIEWMODEL_LOADPARTIAL TREINADOR]/
		}

// USE /[MANUAL SQB VIEWMODEL_NEW TREINADOR]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);

			validator.StringLength("ValNome", Resources.Resources.NOME47814, ValNome, 50);
			validator.StringLength("ValLasttreinocriado", Resources.Resources.LASTTREINOCRIADO36042, ValLasttreinocriado, 50);


			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL SQB VIEWMODEL_SAVE TREINADOR]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL SQB VIEWMODEL_APPLY TREINADOR]/

// USE /[MANUAL SQB VIEWMODEL_DUPLICATE TREINADOR]/

// USE /[MANUAL SQB VIEWMODEL_DESTROY TREINADOR]/
		public override void Destroy(string id)
		{
			Model = Models.Treinador.Find(id, m_userContext, "FTREINADOR");
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

		/// <summary>
		/// TableClubeNome -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Treinador__clube__nome(NameValueCollection qs, bool lazyLoad = false)
		{
			bool treinador__clube__nomeDoLoad = true;
			CriteriaSet treinador__clube__nomeConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("clube", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					treinador__clube__nomeConds.Equal(CSGenioAclube.FldCodclube, hValue);
					this.ValCodclube = DBConversion.ToString(hValue);
				}
			}

			TableClubeNome = new TableDBEdit<Models.Clube>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_clube") != null)
				{
					this.ValCodclube = Navigation.GetStrValue("RETURN_clube");
					Navigation.CurrentLevel.SetEntry("RETURN_clube", null);
				}
				FillDependant_TreinadorTableClubeNome(lazyLoad);
				return;
			}

			if (treinador__clube__nomeDoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableClubeNome, "sTableClubeNome", "dTableClubeNome", qs, "clube");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAclube.FldNome), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableClubeNome_tableFilters"]))
					TableClubeNome.TableFilters = bool.Parse(qs["TableClubeNome_tableFilters"]);
				else
					TableClubeNome.TableFilters = false;

				query = qs["qTableClubeNome"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAclube.FldNome, query + "%");
				}
				treinador__clube__nomeConds.SubSet(search_filters);

				string tryParsePage = qs["pTableClubeNome"] != null ? qs["pTableClubeNome"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAclube.FldCodclube, CSGenioAclube.FldNome, CSGenioAclube.FldZzstate];

// USE /[MANUAL SQB OVERRQ TREINADOR_CLUBENOME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("clube", FormMode.New) || Navigation.checkFormMode("clube", FormMode.Duplicate))
					treinador__clube__nomeConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAclube.FldZzstate, 0)
						.Equal(CSGenioAclube.FldCodclube, Navigation.GetStrValue("clube")));
				else
					treinador__clube__nomeConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAclube.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("clube", "nome");
				ListingMVC<CSGenioAclube> listing = Models.ModelBase.Where<CSGenioAclube>(m_userContext, false, treinador__clube__nomeConds, fields, offset, numberItems, sorts, "LED_TREINADOR__CLUBE__NOME", true, false, firstVisibleColumn: firstVisibleColumn);

				TableClubeNome.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableClubeNome.Query = query;
				TableClubeNome.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Clube(m_userContext, r, true, _fieldsToSerialize_TREINADOR__CLUBE__NOME));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_clube") != null)
				{
					this.ValCodclube = Navigation.GetStrValue("RETURN_clube");
					Navigation.CurrentLevel.SetEntry("RETURN_clube", null);
				}

				TableClubeNome.List = new SelectList(TableClubeNome.Elements.ToSelectList(x => x.ValNome, x => x.ValCodclube,  x => x.ValCodclube == this.ValCodclube), "Value", "Text", this.ValCodclube);
				FillDependant_TreinadorTableClubeNome();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableClubeNome (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Clube</param>
		public ConcurrentDictionary<string, object> GetDependant_TreinadorTableClubeNome(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAclube.FldCodclube, CSGenioAclube.FldNome];

			var returnEmptyDependants = false;
			CriteriaSet wherecodition = CriteriaSet.And();

			// Return default values
			if (GenFunctions.emptyG(PKey) == 1)
				returnEmptyDependants = true;

			// Check if the limit(s) is filled if exists
			// - - - - - - - - - - - - - - - - - - - - -

			if (returnEmptyDependants)
				return GetViewModelFieldValues(refDependantFields);

			PersistentSupport sp = m_userContext.PersistentSupport;
			User u = m_userContext.User;

			CSGenioAclube tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAclube.FldCodclube, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableClubeNome (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_TreinadorTableClubeNome(bool lazyLoad = false)
		{
			var row = GetDependant_TreinadorTableClubeNome(this.ValCodclube);
			try
			{

				// Fill List fields
				this.ValCodclube = ViewModelConversion.ToString(row["clube.codclube"]);
				TableClubeNome.Value = (string)row["clube.nome"];
				if (GenFunctions.emptyG(this.ValCodclube) == 1)
				{
					this.ValCodclube = "";
					TableClubeNome.Value = "";
					Navigation.ClearValue("clube");
				}
				else if (lazyLoad)
				{
					TableClubeNome.SetPagination(1, 0, false, false, 1);
					TableClubeNome.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodclube),
							Text = Convert.ToString(TableClubeNome.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodclube);
				}

				TableClubeNome.Selected = this.ValCodclube;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableClubeNome): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_TREINADOR__CLUBE__NOME = ["Clube", "Clube.ValCodclube", "Clube.ValZzstate", "Clube.ValNome"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"treinador.codclube" => ViewModelConversion.ToString(modelValue),
				"treinador.nome" => ViewModelConversion.ToString(modelValue),
				"treinador.funcao" => ViewModelConversion.ToString(modelValue),
				"treinador.lasttreinocriado" => ViewModelConversion.ToString(modelValue),
				"treinador.codtreinador" => ViewModelConversion.ToString(modelValue),
				"clube.codclube" => ViewModelConversion.ToString(modelValue),
				"clube.nome" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL SQB VIEWMODEL_CUSTOM TREINADOR]/

		#endregion
	}
}
