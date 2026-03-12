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

namespace GenioMVC.ViewModels.Convocatoria
{
	public class Convocados_ViewModel : FormViewModel<Models.Convocatoria>, IPreparableForSerialization
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
		public string ValCodjogador { get; set; }
		/// <summary>
		/// Title: "" | Type: "CE"
		/// </summary>
		[ValidateSetAccess]
		public string ValCodjogo { get; set; }

		#endregion
		/// <summary>
		/// Title: "Nome" | Type: "C"
		/// </summary>
		[ValidateSetAccess]
		public TableDBEdit<GenioMVC.Models.Jogador> TableJogadorNome { get; set; }
		/// <summary>
		/// Title: "Numero Camisola" | Type: "N"
		/// </summary>
		[ValidateSetAccess]
		public decimal? JogadorValNumerocamisola
		{
			get
			{
				return funcJogadorValNumerocamisola != null ? funcJogadorValNumerocamisola() : _auxJogadorValNumerocamisola;
			}
			set { funcJogadorValNumerocamisola = () => value; }
		}

		[JsonIgnore]
		public Func<decimal?> funcJogadorValNumerocamisola { get; set; }

		private decimal? _auxJogadorValNumerocamisola { get; set; }
		/// <summary>
		/// Title: "Posição" | Type: "AC"
		/// </summary>
		[ValidateSetAccess]
		public string JogadorValPosicao
		{
			get
			{
				return funcJogadorValPosicao != null ? funcJogadorValPosicao() : _auxJogadorValPosicao;
			}
			set { funcJogadorValPosicao = () => value; }
		}

		[JsonIgnore]
		public Func<string> funcJogadorValPosicao { get; set; }

		private string _auxJogadorValPosicao { get; set; }
		/// <summary>
		/// Title: "Posição Segundaria" | Type: "AC"
		/// </summary>
		[ValidateSetAccess]
		public string JogadorValPosicaosegundaria
		{
			get
			{
				return funcJogadorValPosicaosegundaria != null ? funcJogadorValPosicaosegundaria() : _auxJogadorValPosicaosegundaria;
			}
			set { funcJogadorValPosicaosegundaria = () => value; }
		}

		[JsonIgnore]
		public Func<string> funcJogadorValPosicaosegundaria { get; set; }

		private string _auxJogadorValPosicaosegundaria { get; set; }

		#region Navigations
		#endregion

		#region Auxiliar Keys for Image controls



		#endregion

		#region Extra database fields



		#endregion

		#region Fields for formulas


		#endregion

		public string ValCodconvocatoria { get; set; }


		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// A call to Init() needs to be manually invoked after this constructor
		/// </summary>
		[Obsolete("For deserialization only")]
		public Convocados_ViewModel() : base(null!) { }

		public Convocados_ViewModel(UserContext userContext, bool nestedForm = false) : base(userContext, "FCONVOCADOS", nestedForm) { }

		public Convocados_ViewModel(UserContext userContext, Models.Convocatoria row, bool nestedForm = false) : base(userContext, "FCONVOCADOS", row, nestedForm) { }

		public Convocados_ViewModel(UserContext userContext, string id, bool nestedForm = false, string[]? fieldsToLoad = null) : this(userContext, nestedForm)
		{
			this.Navigation.SetValue("convocatoria", id);
			Model = Models.Convocatoria.Find(id, userContext, "FCONVOCADOS", fieldsToQuery: fieldsToLoad);
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
			Models.Convocatoria model = new Models.Convocatoria(userContext) { Identifier = "FCONVOCADOS" };

			var navigation = m_userContext.CurrentNavigation;
			// The "LoadKeysFromHistory" must be after the "LoadEPH" because the PHE's in the tree mark Foreign Keys to null
			// (since they cannot assign multiple values to a single field) and thus the value that comes from Navigation is lost.
			// And this makes it more like the order of loading the model when opening the form.
			model.LoadEPH("FCONVOCADOS");
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
		public override void MapFromModel(Models.Convocatoria m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map Model (Convocatoria) to ViewModel (Convocados) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				ValCodjogador = ViewModelConversion.ToString(m.ValCodjogador);
				ValCodjogo = ViewModelConversion.ToString(m.ValCodjogo);
				funcJogadorValNumerocamisola = () => ViewModelConversion.ToNumeric(m.Jogador.ValNumerocamisola);
				funcJogadorValPosicao = () => ViewModelConversion.ToString(m.Jogador.ValPosicao);
				funcJogadorValPosicaosegundaria = () => ViewModelConversion.ToString(m.Jogador.ValPosicaosegundaria);
				ValCodconvocatoria = ViewModelConversion.ToString(m.ValCodconvocatoria);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error("Map Model (Convocatoria) to ViewModel (Convocados) - Error during mapping");
				throw;
			}
		}

		/// <inheritdoc />
		public override void MapToModel()
		{
			MapToModel(this.Model);
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Convocatoria m)
		{
			if (m == null)
			{
				CSGenio.framework.Log.Error("Map ViewModel (Convocados) to Model (Convocatoria) - Model is a null reference");
				throw new ModelNotFoundException("Model not found");
			}

			try
			{
				m.ValCodjogador = ViewModelConversion.ToString(ValCodjogador);
				m.ValCodconvocatoria = ViewModelConversion.ToString(ValCodconvocatoria);

				/*
					At this moment, in the case of runtime calculation of server-side formulas, to improve performance and reduce database load,
						the values coming from the client-side will be accepted as valid, since they will not be saved and are only being used for calculation.
				*/
				if (!HasDisabledUserValuesSecurity)
					return;

				m.ValCodjogo = ViewModelConversion.ToString(ValCodjogo);
			}
			catch (Exception)
			{
				CSGenio.framework.Log.Error($"Map ViewModel (Convocados) to Model (Convocatoria) - Error during mapping. All user values: {HasDisabledUserValuesSecurity}");
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
					case "convocatoria.codjogador":
						this.ValCodjogador = ViewModelConversion.ToString(_value);
						break;
					case "convocatoria.codconvocatoria":
						this.ValCodconvocatoria = ViewModelConversion.ToString(_value);
						break;
					default:
						Log.Error($"SetViewModelValue (Convocados) - Unexpected field identifier {fullFieldName}");
						break;
				}
			}
			catch (Exception ex)
			{
				throw new FrameworkException(Resources.Resources.PEDIMOS_DESCULPA__OC63848, "SetViewModelValue (Convocados)", "Unexpected error", ex);
			}
		}

		#endregion

		/// <summary>
		/// Reads the Model from the database based on the key that is in the history or that was passed through the parameter
		/// </summary>
		/// <param name="id">The primary key of the record that needs to be read from the database. Leave NULL to use the value from the History.</param>
		public override void LoadModel(string id = null)
		{
			try { Model = Models.Convocatoria.Find(id ?? Navigation.GetStrValue("convocatoria"), m_userContext, "FCONVOCADOS"); }
			finally { Model ??= new Models.Convocatoria(m_userContext) { Identifier = "FCONVOCADOS" }; }

			base.LoadModel();
		}

		public override void Load(NameValueCollection qs, bool editable, bool ajaxRequest = false, bool lazyLoad = false)
		{
			this.editable = editable;
			CSGenio.business.Area oldvalues = null;

			// TODO: Deve ser substituido por search do CSGenioA
			try
			{
				Model = Models.Convocatoria.Find(Navigation.GetStrValue("convocatoria"), m_userContext, "FCONVOCADOS");
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

			Model.Identifier = "FCONVOCADOS";
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
		
		protected override void LoadDocumentsProperties(Models.Convocatoria row)
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
				Model = Models.Convocatoria.Find(Navigation.GetStrValue("convocatoria"), m_userContext, "FCONVOCADOS");
				if (Model == null)
				{
					Model = new Models.Convocatoria(m_userContext) { Identifier = "FCONVOCADOS" };
					Model.klass.QPrimaryKey = Navigation.GetStrValue("convocatoria");
				}
				MapToModel(Model);
				LoadDocumentsProperties(Model);
			}
			// Add characteristics
			Characs = new List<string>();

			Load_Convocados__jogador__nome(qs, lazyLoad);

// USE /[MANUAL SQB VIEWMODEL_LOADPARTIAL CONVOCADOS]/
		}

// USE /[MANUAL SQB VIEWMODEL_NEW CONVOCADOS]/

		// Preencher Qvalues default dos fields do form
		protected override void LoadDefaultValues()
		{
		}

		public override CrudViewModelValidationResult Validate()
		{
			CrudViewModelFieldValidator validator = new(m_userContext.User.Language);



			return validator.GetResult();
		}

		public override void Init(UserContext userContext)
		{
			base.Init(userContext);
		}
// USE /[MANUAL SQB VIEWMODEL_SAVE CONVOCADOS]/
		public override void Save()
		{


			base.Save();
		}

// USE /[MANUAL SQB VIEWMODEL_APPLY CONVOCADOS]/

// USE /[MANUAL SQB VIEWMODEL_DUPLICATE CONVOCADOS]/

// USE /[MANUAL SQB VIEWMODEL_DESTROY CONVOCADOS]/
		public override void Destroy(string id)
		{
			Model = Models.Convocatoria.Find(id, m_userContext, "FCONVOCADOS");
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
		/// TableJogadorNome -> (DB)
		/// </summary>
		/// <param name="qs"></param>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void Load_Convocados__jogador__nome(NameValueCollection qs, bool lazyLoad = false)
		{
			bool convocados__jogador__nomeDoLoad = true;
			CriteriaSet convocados__jogador__nomeConds = CriteriaSet.And();
			{
				object hValue = Navigation.GetValue("jogador", true);
				if (hValue != null && !(hValue is Array) && !string.IsNullOrEmpty(Convert.ToString(hValue)))
				{
					convocados__jogador__nomeConds.Equal(CSGenioAjogador.FldCodjogador, hValue);
					this.ValCodjogador = DBConversion.ToString(hValue);
				}
			}

			TableJogadorNome = new TableDBEdit<Models.Jogador>
			{
				IsLazyLoad = lazyLoad
			};

			if (lazyLoad)
			{
				if (Navigation.CurrentLevel.GetEntry("RETURN_jogador") != null)
				{
					this.ValCodjogador = Navigation.GetStrValue("RETURN_jogador");
					Navigation.CurrentLevel.SetEntry("RETURN_jogador", null);
				}
				FillDependant_ConvocadosTableJogadorNome(lazyLoad);
				return;
			}

			if (convocados__jogador__nomeDoLoad)
			{
				List<ColumnSort> sorts = [];
				ColumnSort requestedSort = GetRequestSort(TableJogadorNome, "sTableJogadorNome", "dTableJogadorNome", qs, "jogador");
				if (requestedSort != null)
					sorts.Add(requestedSort);
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAjogador.FldNome), SortOrder.Ascending));

				string query = "";
				if (!string.IsNullOrEmpty(qs["TableJogadorNome_tableFilters"]))
					TableJogadorNome.TableFilters = bool.Parse(qs["TableJogadorNome_tableFilters"]);
				else
					TableJogadorNome.TableFilters = false;

				query = qs["qTableJogadorNome"];

				//RS 26.07.2016 O preenchimento da lista de ajuda dos Dbedits passa a basear-se apenas no campo do próprio DbEdit
				// O interface de pesquisa rápida não fica coerente quando se visualiza apenas uma coluna mas a pesquisa faz matching com 5 ou 6 colunas diferentes
				//  tornando confuso to o user porque determinada row foi devolvida quando o Qresult não mostra como o matching foi feito
				CriteriaSet search_filters = CriteriaSet.And();
				if (!string.IsNullOrEmpty(query))
				{
					search_filters.Like(CSGenioAjogador.FldNome, query + "%");
				}
				convocados__jogador__nomeConds.SubSet(search_filters);

				string tryParsePage = qs["pTableJogadorNome"] != null ? qs["pTableJogadorNome"].ToString() : "1";
				int page = !string.IsNullOrEmpty(tryParsePage) ? int.Parse(tryParsePage) : 1;
				int numberItems = CSGenio.framework.Configuration.NrRegDBedit;
				int offset = (page - 1) * numberItems;

				FieldRef[] fields = [CSGenioAjogador.FldCodjogador, CSGenioAjogador.FldNome, CSGenioAjogador.FldZzstate];

// USE /[MANUAL SQB OVERRQ CONVOCADOS_JOGADORNOME]/

				// Limitation by Zzstate
				/*
					Records that are currently being inserted or duplicated will also be included.
					Client-side persistence will try to fill the "text" value of that option.
				*/
				if (Navigation.checkFormMode("jogador", FormMode.New) || Navigation.checkFormMode("jogador", FormMode.Duplicate))
					convocados__jogador__nomeConds.SubSet(CriteriaSet.Or()
						.Equal(CSGenioAjogador.FldZzstate, 0)
						.Equal(CSGenioAjogador.FldCodjogador, Navigation.GetStrValue("jogador")));
				else
					convocados__jogador__nomeConds.Criterias.Add(new Criteria(new ColumnReference(CSGenioAjogador.FldZzstate), CriteriaOperator.Equal, 0));

				FieldRef firstVisibleColumn = new FieldRef("jogador", "nome");
				ListingMVC<CSGenioAjogador> listing = Models.ModelBase.Where<CSGenioAjogador>(m_userContext, false, convocados__jogador__nomeConds, fields, offset, numberItems, sorts, "LED_CONVOCADOS__JOGADOR__NOME", true, false, firstVisibleColumn: firstVisibleColumn);

				TableJogadorNome.SetPagination(page, numberItems, listing.HasMore, listing.GetTotal, listing.TotalRecords);
				TableJogadorNome.Query = query;
				TableJogadorNome.Elements = listing.RowsForViewModel((r) => new GenioMVC.Models.Jogador(m_userContext, r, true, _fieldsToSerialize_CONVOCADOS__JOGADOR__NOME));

				//created by [ MH ] at [ 14.04.2016 ] - Foi alterada a forma de retornar a key do novo registo inserido / editado no form de apoio do DBEdit.
				//last update by [ MH ] at [ 10.05.2016 ] - Validação se key encontra-se no level atual, as chaves dos niveis anteriores devem ser ignorados.
				if (Navigation.CurrentLevel.GetEntry("RETURN_jogador") != null)
				{
					this.ValCodjogador = Navigation.GetStrValue("RETURN_jogador");
					Navigation.CurrentLevel.SetEntry("RETURN_jogador", null);
				}

				TableJogadorNome.List = new SelectList(TableJogadorNome.Elements.ToSelectList(x => x.ValNome, x => x.ValCodjogador,  x => x.ValCodjogador == this.ValCodjogador), "Value", "Text", this.ValCodjogador);
				FillDependant_ConvocadosTableJogadorNome();
			}
		}

		/// <summary>
		/// Get Dependant fields values -> TableJogadorNome (DB)
		/// </summary>
		/// <param name="PKey">Primary Key of Jogador</param>
		public ConcurrentDictionary<string, object> GetDependant_ConvocadosTableJogadorNome(string PKey)
		{
			FieldRef[] refDependantFields = [CSGenioAjogador.FldCodjogador, CSGenioAjogador.FldNome, CSGenioAjogador.FldNumerocamisola, CSGenioAjogador.FldPosicao, CSGenioAjogador.FldPosicaosegundaria];

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

			CSGenioAjogador tempArea = new(u);

			// Fields to select
			SelectQuery querySelect = new();
			querySelect.PageSize(1);
			foreach (FieldRef field in refDependantFields)
				querySelect.Select(field);

			querySelect.From(tempArea.QSystem, tempArea.TableName, tempArea.Alias)
				.Where(wherecodition.Equal(CSGenioAjogador.FldCodjogador, PKey));

			string[] dependantFields = refDependantFields.Select(f => f.FullName).ToArray();
			QueryUtils.SetInnerJoins(dependantFields, null, tempArea, querySelect);

			ArrayList values = sp.executeReaderOneRow(querySelect);
			bool useDefaults = values.Count == 0;

			if (useDefaults)
				return GetViewModelFieldValues(refDependantFields);
			return GetViewModelFieldValues(refDependantFields, values);
		}

		/// <summary>
		/// Fill Dependant fields values -> TableJogadorNome (DB)
		/// </summary>
		/// <param name="lazyLoad">Lazy loading of dropdown items</param>
		public void FillDependant_ConvocadosTableJogadorNome(bool lazyLoad = false)
		{
			var row = GetDependant_ConvocadosTableJogadorNome(this.ValCodjogador);
			try
			{
				this.funcJogadorValNumerocamisola = () => (decimal?)row["jogador.numerocamisola"];
				this.funcJogadorValPosicao = () => (string)row["jogador.posicao"];
				this.funcJogadorValPosicaosegundaria = () => (string)row["jogador.posicaosegundaria"];

				// Fill List fields
				this.ValCodjogador = ViewModelConversion.ToString(row["jogador.codjogador"]);
				TableJogadorNome.Value = (string)row["jogador.nome"];
				if (GenFunctions.emptyG(this.ValCodjogador) == 1)
				{
					this.ValCodjogador = "";
					TableJogadorNome.Value = "";
					Navigation.ClearValue("jogador");
				}
				else if (lazyLoad)
				{
					TableJogadorNome.SetPagination(1, 0, false, false, 1);
					TableJogadorNome.List = new SelectList(new List<SelectListItem>()
					{
						new SelectListItem
						{
							Value = Convert.ToString(this.ValCodjogador),
							Text = Convert.ToString(TableJogadorNome.Value),
							Selected = true
						}
					}, "Value", "Text", this.ValCodjogador);
				}

				TableJogadorNome.Selected = this.ValCodjogador;
			}
			catch (Exception ex)
			{
				CSGenio.framework.Log.Error(string.Format("FillDependant_Error (TableJogadorNome): {0}; {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : ""));
			}
		}

		private readonly string[] _fieldsToSerialize_CONVOCADOS__JOGADOR__NOME = ["Jogador", "Jogador.ValCodjogador", "Jogador.ValZzstate", "Jogador.ValNome"];

		protected override object GetViewModelValue(string identifier, object modelValue)
		{
			return identifier switch
			{
				"convocatoria.codjogador" => ViewModelConversion.ToString(modelValue),
				"convocatoria.codjogo" => ViewModelConversion.ToString(modelValue),
				"jogador.numerocamisola" => ViewModelConversion.ToNumeric(modelValue),
				"jogador.posicao" => ViewModelConversion.ToString(modelValue),
				"jogador.posicaosegundaria" => ViewModelConversion.ToString(modelValue),
				"convocatoria.codconvocatoria" => ViewModelConversion.ToString(modelValue),
				"jogador.codjogador" => ViewModelConversion.ToString(modelValue),
				"jogador.nome" => ViewModelConversion.ToString(modelValue),
				_ => modelValue
			};
		}

		#region Charts


		#endregion

		#region Custom code

// USE /[MANUAL SQB VIEWMODEL_CUSTOM CONVOCADOS]/

		#endregion
	}
}
