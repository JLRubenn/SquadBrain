using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text.Json.Serialization;

using CSGenio.business;
using CSGenio.core.di;
using CSGenio.core.framework.table;
using CSGenio.framework;
using GenioMVC.Helpers;
using GenioMVC.Models.Exception;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

namespace GenioMVC.ViewModels.Jogador
{
	public class SQB_Menu_31_ViewModel : MenuListViewModel<Models.Jogador>
	{
		/// <summary>
		/// Gets or sets the object that represents the table and its elements.
		/// </summary>
		[JsonPropertyName("table")]
		public TablePartial<SQB_Menu_31_RowViewModel> Menu { get; set; }

		/// <inheritdoc/>
		[JsonIgnore]
		public override string TableAlias => "jogador";

		/// <inheritdoc/>
		[JsonPropertyName("uuid")]
		public override string Uuid => "952b6b6f-99bd-4342-a146-b6c0e1e1ee45";

		/// <inheritdoc/>
		protected override string[] FieldsToSerialize => _fieldsToSerialize;

		/// <inheritdoc/>
		protected override List<TableSearchColumn> SearchableColumns => _searchableColumns;

		/// <summary>
		/// The context of the parent.
		/// </summary>
		[JsonIgnore]
		public Models.ModelBase ParentCtx { get; set; }

		/// <inheritdoc/>
		[JsonIgnore]
		public override CriteriaSet StaticLimits
		{
			get
			{
				CriteriaSet conditions = CriteriaSet.And();

				return conditions;
			}
		}

		/// <inheritdoc/>
		[JsonIgnore]
		public override CriteriaSet BaseConditions
		{
			get
			{
				CriteriaSet conds = CriteriaSet.And();

				return conds;
			}
		}

		/// <inheritdoc/>
		[JsonIgnore]
		public override List<Relation> Relations
		{
			get
			{
				List<Relation> relations = null;
				return relations;
			}
		}

		public override CriteriaSet GetCustomizedStaticLimits(CriteriaSet crs)
		{
// USE /[MANUAL SQB LIST_LIMITS 31]/

			return crs;
		}

		public override int GetCount(User user)
		{
			CSGenio.persistence.PersistentSupport sp = m_userContext.PersistentSupport;
			var areaBase = CSGenio.business.Area.createArea("jogador", user, "SQB");

			//gets eph conditions to be applied in listing
			CriteriaSet conditions = CSGenio.business.Listing.CalculateConditionsEphGeneric(areaBase, "ML31");
			conditions.Equal(CSGenioAjogador.FldZzstate, 0); //valid zzstate only

			// Fixed limits and relations:
			conditions.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			// Checks for foreign tables in fields and conditions
			FieldRef[] fields = new FieldRef[] { CSGenioAjogador.FldCodjogador, CSGenioAjogador.FldZzstate, CSGenioAjogador.FldFoto, CSGenioAjogador.FldNome, CSGenioAjogador.FldNumerocamisola, CSGenioAjogador.FldDatanascimento, CSGenioAjogador.FldPedominante, CSGenioAjogador.FldPosicao, CSGenioAjogador.FldPosicaosegundaria, CSGenioAjogador.FldCodclube, CSGenioAclube.FldCodclube, CSGenioAclube.FldNome, CSGenioAjogador.FldEquipaanterior };

			ListingMVC<CSGenioAjogador> listing = new(fields, null, 1, 1, false, user, true, string.Empty, false);
			SelectQuery qs = sp.getSelectQueryFromListingMVC(conditions, listing);

			// Menu relations:
			if (qs.FromTable == null)
				qs.From(areaBase.QSystem, areaBase.TableName, areaBase.Alias);



			//operation: Count menu records
			return CSGenio.persistence.DBConversion.ToInteger(sp.ExecuteScalar(CSGenio.persistence.QueryUtils.buildQueryCount(qs)));
		}

		/// <summary>
		/// FOR DESERIALIZATION ONLY
		/// </summary>
		[Obsolete("For deserialization only")]
		public SQB_Menu_31_ViewModel() : base(null!) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="SQB_Menu_31_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		public SQB_Menu_31_ViewModel(UserContext userContext) : base(userContext)
		{
			this.RoleToShow = CSGenio.framework.Role.ROLE_50;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SQB_Menu_31_ViewModel" /> class.
		/// </summary>
		/// <param name="userContext">The current user request context</param>
		/// <param name="parentCtx">The context of the parent</param>
		public SQB_Menu_31_ViewModel(UserContext userContext, Models.ModelBase parentCtx) : this(userContext)
		{
			ParentCtx = parentCtx;
		}

		/// <inheritdoc/>
		public override List<Exports.QColumn> GetColumnsToExport()
		{
			return
			[
				new Exports.QColumn(CSGenioAjogador.FldNome, FieldType.TEXT, Resources.Resources.NOME47814, 30, 0, true),
				new Exports.QColumn(CSGenioAjogador.FldNumerocamisola, FieldType.NUMERIC, Resources.Resources.NUMERO_CAMISOLA34511, 2, 0, true),
				new Exports.QColumn(CSGenioAjogador.FldDatanascimento, FieldType.DATE, Resources.Resources.DATA_NASCIMENTO26850, 8, 0, true),
				new Exports.QColumn(CSGenioAjogador.FldPedominante, FieldType.ARRAY_TEXT, Resources.Resources.PE_DOMINANTE49350, 3, 0, true, "Pe"),
				new Exports.QColumn(CSGenioAjogador.FldPosicao, FieldType.ARRAY_TEXT, Resources.Resources.POSICAO07486, 3, 0, true, "Posicao"),
				new Exports.QColumn(CSGenioAjogador.FldPosicaosegundaria, FieldType.ARRAY_TEXT, Resources.Resources.POSICAO_SEGUNDARIA49537, 3, 0, true, "Posicao"),
				new Exports.QColumn(CSGenioAclube.FldNome, FieldType.TEXT, Resources.Resources.EQUIPA_ATUAL12425, 30, 0, true),
				new Exports.QColumn(CSGenioAjogador.FldEquipaanterior, FieldType.TEXT, Resources.Resources.EQUIPA_ANTERIOR39393, 30, 0, true),
			];
		}

		public void LoadToExport(out ListingMVC<CSGenioAjogador> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();
			LoadToExport(out listing, out conditions, out columns, tableConfig, requestValues, ajaxRequest);
		}

		public void LoadToExport(out ListingMVC<CSGenioAjogador> listing, out CriteriaSet conditions, out List<Exports.QColumn> columns, CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest = false)
		{
			listing = null;
			conditions = null;
			columns = this.GetExportColumns(tableConfig.ColumnConfigurations);

			// Store number of records to reset it after loading
			int rowsPerPage = tableConfig.RowsPerPage;
			tableConfig.RowsPerPage = -1;

			Load(tableConfig, requestValues, ajaxRequest, true, ref listing, ref conditions);

			// Reset number of records to original value
			tableConfig.RowsPerPage = rowsPerPage;
		}

		/// <summary>
		/// Loads the viewmodel to export a template.
		/// </summary>
		/// <param name="columns">The columns.</param>
		public void LoadToExportTemplate(out List<Exports.QColumn> columns)
		{
			columns = new List<Exports.QColumn>()
			{
				new Exports.QColumn(CSGenioAjogador.FldNome, FieldType.TEXT, Resources.Resources.NOME47814, 50, 0, true),
				new Exports.QColumn(CSGenioAjogador.FldDatanascimento, FieldType.DATE, Resources.Resources.DATA_NASCIMENTO26850, 8, 0, true),
				new Exports.QColumn(CSGenioAjogador.FldPosicao, FieldType.ARRAY_TEXT, Resources.Resources.POSICAO07486, 3, 0, true, "Posicao"),
				new Exports.QColumn(CSGenioAjogador.FldNumerocamisola, FieldType.NUMERIC, Resources.Resources.NUMERO_CAMISOLA34511, 2, 0, true),
				new Exports.QColumn(CSGenioAjogador.FldPosicaosegundaria, FieldType.ARRAY_TEXT, Resources.Resources.POSICAO_SEGUNDARIA49537, 3, 0, true, "Posicao"),
				new Exports.QColumn(CSGenioAjogador.FldPedominante, FieldType.ARRAY_TEXT, Resources.Resources.PE_DOMINANTE49350, 3, 0, true, "Pe"),
				new Exports.QColumn(CSGenioAjogador.FldEquipaanterior, FieldType.TEXT, Resources.Resources.EQUIPA_ANTERIOR39393, 50, 0, true),
				new Exports.QColumn(CSGenioAjogador.FldFoto, FieldType.IMAGE, Resources.Resources.FOTO19492, 3, 0, true),
				new Exports.QColumn(CSGenioAjogador.FldSpposicaomedio, FieldType.ARRAY_TEXT, Resources.Resources.ESPECIFICACAO_POSICA24622, 3, 0, true, "SPposicaoMedio"),
				new Exports.QColumn(CSGenioAjogador.FldSpposicaoat, FieldType.ARRAY_TEXT, Resources.Resources.ESPECIFICACAO_POSICA24622, 1, 0, true, "SPposicao"),
				new Exports.QColumn(CSGenioAjogador.FldSpposicaodef, FieldType.ARRAY_TEXT, Resources.Resources.ESPECIFICACAO_POSICA24622, 1, 0, true, "SPposicao"),
				new Exports.QColumn(CSGenioAjogador.FldValormercado, FieldType.CURRENCY, Resources.Resources.VALOR_MERCADO__M_33616, 14, 2, true),
				new Exports.QColumn(CSGenioAjogador.FldNationalidade, FieldType.TEXT, Resources.Resources.NATIONALIDADE48376, 50, 0, true),
				new Exports.QColumn(CSGenioAjogador.FldSp2posicaomedio, FieldType.ARRAY_TEXT, Resources.Resources.ESPECIFICACAO_POSICA18874, 3, 0, true, "SPposicaoMedio"),
				new Exports.QColumn(CSGenioAjogador.FldSp2posicaoat, FieldType.ARRAY_TEXT, Resources.Resources.ESPECIFICACAO_POSICA18874, 1, 0, true, "SPposicao"),
				new Exports.QColumn(CSGenioAjogador.FldSp2posicaodef, FieldType.ARRAY_TEXT, Resources.Resources.ESPECIFICACAO_POSICA18874, 1, 0, true, "SPposicao"),
				new Exports.QColumn(CSGenioAclube.FldNome, FieldType.TEXT, Resources.Resources.EQUIPA_ATUAL12425, 30, 0, true),
			};
		}

		/// <inheritdoc/>
		public override CriteriaSet BuildCriteriaSet(NameValueCollection requestValues, out bool tableReload, CriteriaSet crs = null, bool isToExport = false)
		{
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();
			return BuildCriteriaSet(tableConfig, requestValues, out tableReload, crs, isToExport);
		}

		/// <inheritdoc/>
		public override CriteriaSet BuildCriteriaSet(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, out bool tableReload, CriteriaSet crs = null, bool isToExport = false)
		{
			User u = m_userContext.User;
			tableReload = true;

			crs ??= CriteriaSet.And();

			Menu ??= new TablePartial<SQB_Menu_31_RowViewModel>();
			// Set table name (used in getting searchable column names)
			Menu.TableName = TableAlias;

			Menu.SetFilters(false, true);

			crs.SubSets.Add(ProcessSearchFilters(Menu, GetSearchColumns(tableConfig.ColumnConfigurations), tableConfig));


			//Subfilters
			CriteriaSet subfilters = CriteriaSet.And();

			if (!tableConfig.GroupFilters.ContainsKey("filter_SQB_Menu_31_TYPEFILTER"))
			{
				string defaultValue = "1";
				tableConfig.Filters.Add(new GroupFilter { Key = "filter_SQB_Menu_31_TYPEFILTER", Value = defaultValue });
			}

			{
				var groupFilters = CriteriaSet.Or();
				bool filter_SQB_Menu_31_TYPEFILTER_1 = false;
				if (tableConfig.GroupFilters.ContainsKey("filter_SQB_Menu_31_TYPEFILTER"))
					filter_SQB_Menu_31_TYPEFILTER_1 = tableConfig.GroupFilters["filter_SQB_Menu_31_TYPEFILTER"].Contains("1");
				else if (!tableConfig.GroupFilters.ContainsKey("filter_SQB_Menu_31_TYPEFILTER"))
					filter_SQB_Menu_31_TYPEFILTER_1 = true;
				if (filter_SQB_Menu_31_TYPEFILTER_1)
				{

				}

				bool filter_SQB_Menu_31_TYPEFILTER_2 = false;
				if (tableConfig.GroupFilters.ContainsKey("filter_SQB_Menu_31_TYPEFILTER"))
					filter_SQB_Menu_31_TYPEFILTER_2 = tableConfig.GroupFilters["filter_SQB_Menu_31_TYPEFILTER"].Contains("2");
				if (filter_SQB_Menu_31_TYPEFILTER_2)
				{
					groupFilters.Equal(CSGenioAjogador.FldPosicao, "GR");

				}

				bool filter_SQB_Menu_31_TYPEFILTER_3 = false;
				if (tableConfig.GroupFilters.ContainsKey("filter_SQB_Menu_31_TYPEFILTER"))
					filter_SQB_Menu_31_TYPEFILTER_3 = tableConfig.GroupFilters["filter_SQB_Menu_31_TYPEFILTER"].Contains("3");
				if (filter_SQB_Menu_31_TYPEFILTER_3)
				{
					groupFilters.Equal(CSGenioAjogador.FldPosicao, "DEF");

				}

				bool filter_SQB_Menu_31_TYPEFILTER_4 = false;
				if (tableConfig.GroupFilters.ContainsKey("filter_SQB_Menu_31_TYPEFILTER"))
					filter_SQB_Menu_31_TYPEFILTER_4 = tableConfig.GroupFilters["filter_SQB_Menu_31_TYPEFILTER"].Contains("4");
				if (filter_SQB_Menu_31_TYPEFILTER_4)
				{
					groupFilters.Equal(CSGenioAjogador.FldPosicao, "MD");

				}

				bool filter_SQB_Menu_31_TYPEFILTER_5 = false;
				if (tableConfig.GroupFilters.ContainsKey("filter_SQB_Menu_31_TYPEFILTER"))
					filter_SQB_Menu_31_TYPEFILTER_5 = tableConfig.GroupFilters["filter_SQB_Menu_31_TYPEFILTER"].Contains("5");
				if (filter_SQB_Menu_31_TYPEFILTER_5)
				{
					groupFilters.Equal(CSGenioAjogador.FldPosicao, "AT");

				}

				subfilters.SubSets.Add(groupFilters);
			}

			crs.SubSets.Add(subfilters);

			// Form field filters
			crs.SubSets.Add(ProcessFieldFilters(tableConfig.GlobalFilters));

			crs.SubSets.Add(GetCustomizedStaticLimits(StaticLimits));

			if (isToExport)
			{
				// EPH
				crs = Models.Jogador.AddEPH<CSGenioAjogador>(ref u, crs, "ML31");

				// Export only records with ZZState == 0
				crs.Equal(CSGenioAjogador.FldZzstate, 0);

				return crs;
			}

			// Limitation by Zzstate
			if (!Navigation.checkFormMode("JOGADOR", FormMode.New)) // TODO: Check in Duplicate mode
				crs = extendWithZzstateCondition(crs, CSGenioAjogador.FldZzstate, null);


			if (tableReload)
			{
				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_jogador");
				Navigation.DestroyEntry("QMVC_POS_RECORD_jogador");
				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
					crs.Equals(Models.Jogador.AddEPH<CSGenioAjogador>(ref u, null, "ML31"));
			}

			return crs;
		}

		/// <summary>
		/// Loads the list with the specified number of rows.
		/// </summary>
		/// <param name="numberListItems">The number of rows to load.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		public void Load(int numberListItems, bool ajaxRequest = false)
		{
			Load(numberListItems, new NameValueCollection(), ajaxRequest);
		}

		/// <summary>
		/// Loads the list with the specified number of rows.
		/// </summary>
		/// <param name="numberListItems">The number of rows to load.</param>
		/// <param name="requestValues">The request values.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		/// <param name="conditions">The conditions.</param>
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest = false, CriteriaSet conditions = null)
		{
			ListingMVC<CSGenioAjogador> listing = null;

			Load(numberListItems, requestValues, ajaxRequest, false, ref listing, ref conditions);
		}

		/// <summary>
		/// Loads the list with the specified number of rows.
		/// </summary>
		/// <param name="numberListItems">The number of rows to load.</param>
		/// <param name="requestValues">The request values.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		/// <param name="isToExport">Whether the list is being loaded to be exported</param>
		/// <param name="Qlisting">The rows.</param>
		/// <param name="conditions">The conditions.</param>
		public void Load(int numberListItems, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAjogador> Qlisting, ref CriteriaSet conditions)
		{
			CSGenio.core.framework.table.TableConfiguration tableConfig = new();

			tableConfig.RowsPerPage = numberListItems;

			Load(tableConfig, requestValues, ajaxRequest, isToExport, ref Qlisting, ref conditions);
		}

		/// <summary>
		/// Loads the table with the specified configuration.
		/// </summary>
		/// <param name="tableConfig">The table configuration object</param>
		/// <param name="requestValues">The request values.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		/// <param name="isToExport">Whether the list is being loaded to be exported</param>
		/// <param name="conditions">The conditions.</param>
		public void Load(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport = false, CriteriaSet conditions = null)
		{
			ListingMVC<CSGenioAjogador> listing = null;

			Load(tableConfig, requestValues, ajaxRequest, isToExport, ref listing, ref conditions);
		}

		/// <summary>
		/// Loads the table with the specified configuration.
		/// </summary>
		/// <param name="tableConfig">The table configuration object</param>
		/// <param name="requestValues">The request values.</param>
		/// <param name="ajaxRequest">Whether the request was initiated via AJAX.</param>
		/// <param name="isToExport">Whether the list is being loaded to be exported</param>
		/// <param name="Qlisting">The rows.</param>
		/// <param name="conditions">The conditions.</param>
		public void Load(CSGenio.core.framework.table.TableConfiguration tableConfig, NameValueCollection requestValues, bool ajaxRequest, bool isToExport, ref ListingMVC<CSGenioAjogador> Qlisting, ref CriteriaSet conditions)
		{
			User u = m_userContext.User;
			Menu = new TablePartial<SQB_Menu_31_RowViewModel>();

			CriteriaSet sqb_menu_31Conds = CriteriaSet.And();
			bool tableReload = true;

			//FOR: MENU LIST SORTING
			Dictionary<string, OrderedDictionary> allSortOrders = new Dictionary<string, OrderedDictionary>();
			allSortOrders.Add("JOGADOR.NUMEROCAMISOLA", new OrderedDictionary());
			allSortOrders["JOGADOR.NUMEROCAMISOLA"].Add("JOGADOR.NUMEROCAMISOLA", "A");


			int numberListItems = tableConfig.RowsPerPage;
			var pageNumber = ajaxRequest ? tableConfig.Page : 1;

			// Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
			if (pageNumber < 1)
				pageNumber = 1;

			List<ColumnSort> sorts = GetRequestSorts(this.Menu, tableConfig, "jogador", allSortOrders);

			if (sorts == null || sorts.Count == 0)
			{
				sorts = new List<ColumnSort>();
				sorts.Add(new ColumnSort(new ColumnReference(CSGenioAjogador.FldNumerocamisola), SortOrder.Ascending));

			}

			FieldRef[] fields = new FieldRef[] { CSGenioAjogador.FldCodjogador, CSGenioAjogador.FldZzstate, CSGenioAjogador.FldFoto, CSGenioAjogador.FldNome, CSGenioAjogador.FldNumerocamisola, CSGenioAjogador.FldDatanascimento, CSGenioAjogador.FldPedominante, CSGenioAjogador.FldPosicao, CSGenioAjogador.FldPosicaosegundaria, CSGenioAjogador.FldCodclube, CSGenioAclube.FldCodclube, CSGenioAclube.FldNome, CSGenioAjogador.FldEquipaanterior };


			// Totalizers
			List<FieldRef> fieldsWithTotalizers = fields.Where(field => tableConfig.TotalizerColumns.Contains(field.FullName)).ToList();

			FieldRef firstVisibleColumn = null;

			if (sorts.Count == 0)
			{
				firstVisibleColumn = tableConfig?.GetFirstVisibleColumn(TableAlias);

				firstVisibleColumn ??= new FieldRef("jogador", "foto");
			}
			// Limitations
			this.TableLimits ??= [];
			// Comparer to check if limit is already present in TableLimits
			LimitComparer limitComparer = new();

			//Tooltip for EPHs affecting this viewmodel list
			{
				Limit limit = new Limit();
				limit.TipoLimite = LimitType.EPH;
				CSGenioAjogador model_limit_area = new CSGenioAjogador(m_userContext.User);
				List<Limit> area_EPH_limits = EPH_Limit_Filler(ref limit, model_limit_area, "ML31");
				if (area_EPH_limits.Count > 0)
					this.TableLimits.AddRange(area_EPH_limits);
			}


			if (conditions == null)
				conditions = CriteriaSet.And();

			conditions.SubSets.Add(sqb_menu_31Conds);
			sqb_menu_31Conds = BuildCriteriaSet(tableConfig, requestValues, out bool hasAllRequiredLimits, conditions, isToExport);
			tableReload &= hasAllRequiredLimits;

// USE /[MANUAL SQB OVERRQ 31]/

			bool distinct = false;

			if (isToExport)
			{
				if (!tableReload)
					return;

				var exportColumns = GetExportColumns(tableConfig.ColumnConfigurations);
				var exportFieldRefs = exportColumns.Select(eCol => eCol.Field).Where(fldRef => fldRef != null).ToArray();

				Qlisting = Models.ModelBase.BuildListingForExport<CSGenioAjogador>(m_userContext, false, ref sqb_menu_31Conds, exportFieldRefs, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML31", true, firstVisibleColumn: firstVisibleColumn);

// USE /[MANUAL SQB OVERRQLSTEXP 31]/

				return;
			}

			if (tableReload)
			{
// USE /[MANUAL SQB OVERRQLIST 31]/

				string QMVC_POS_RECORD = Navigation.GetStrValue("QMVC_POS_RECORD_jogador");
				Navigation.DestroyEntry("QMVC_POS_RECORD_jogador");
				CriteriaSet m_PagingPosEPHs = null;

				if (!string.IsNullOrEmpty(QMVC_POS_RECORD))
				{
					var m_iCurPag = m_userContext.PersistentSupport.getPagingPos(CSGenioAjogador.GetInformation(), QMVC_POS_RECORD, sorts, sqb_menu_31Conds, m_PagingPosEPHs, firstVisibleColumn: firstVisibleColumn);
					if (m_iCurPag != -1)
						pageNumber = ((m_iCurPag - 1) / numberListItems) + 1;
				}

				ListingMVC<CSGenioAjogador> listing = Models.ModelBase.Where<CSGenioAjogador>(m_userContext, distinct, sqb_menu_31Conds, fields, (pageNumber - 1) * numberListItems, numberListItems, sorts, "ML31", true, false, QMVC_POS_RECORD, m_PagingPosEPHs, firstVisibleColumn, fieldsWithTotalizers, tableConfig.SelectedRows);

				if (listing.CurrentPage > 0)
					pageNumber = listing.CurrentPage;

				//Added to avoid 0 or -1 pages when setting number of records to -1 to disable pagination
				if (pageNumber < 1)
					pageNumber = 1;

				//Set document field values to objects
				SetDocumentFields(listing);

				Menu.Elements = MapSQB_Menu_31(listing);

				Menu.Identifier = "ML31";
				Menu.Slots = new Dictionary<string, List<object>>();

				// Last updated by [CJP] at [2015.02.03]
				// Adds the identifier to each element
				foreach (var element in Menu.Elements)
					element.Identifier = "ML31";

				Menu.SetPagination(pageNumber, listing.NumRegs, listing.HasMore, listing.GetTotal, listing.TotalRecords);

				// Set table totalizers
				if (listing.Totalizers != null && listing.Totalizers.Count > 0)
					Menu.SetTotalizers(listing.Totalizers);
			}

			// Set table limits display property
			FillTableLimitsDisplayData();

			// Store table configuration so it gets sent to the client-side to be processed
			CurrentTableConfig = tableConfig;

			// Load the user table configuration names and default name
			LoadUserTableConfigNameProperties();
		}

		private List<SQB_Menu_31_RowViewModel> MapSQB_Menu_31(ListingMVC<CSGenioAjogador> Qlisting)
		{
			List<SQB_Menu_31_RowViewModel> Elements = [];
			int i = 0;

			if (Qlisting.Rows != null)
			{
				foreach (var row in Qlisting.Rows)
				{
					if (Qlisting.NumRegs > 0 && i >= Qlisting.NumRegs) // Copiado da versão antiga do RowsToViewModels
						break;
					Elements.Add(MapSQB_Menu_31(row));
					i++;
				}
			}

			return Elements;
		}

		/// <summary>
		/// Maps a single CSGenioAjogador row
		/// to a SQB_Menu_31_RowViewModel object.
		/// </summary>
		/// <param name="row">The row.</param>
		private SQB_Menu_31_RowViewModel MapSQB_Menu_31(CSGenioAjogador row)
		{
			var model = new SQB_Menu_31_RowViewModel(m_userContext, true, _fieldsToSerialize);
			if (row == null)
				return model;

			foreach (RequestedField Qfield in row.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "jogador":
						model.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					case "clube":
						model.Clube.klass.insertNameValueField(Qfield.FullName, Qfield.Value); break;
					default:
						break;
				}
			}

			model.InitRowData();

			SetTicketToImageFields(model);
			return model;
		}

		/// <summary>
		/// Checks the loaded model for pending rows (zzsttate not 0).
		/// </summary>
		public bool CheckForZzstate()
		{
			if (Menu?.Elements == null)
				return false;

			return Menu.Elements.Any(row => row.ValZzstate != 0);
		}

		/// <summary>
		/// Sets the document field values to objects.
		/// </summary>
		/// <param name="listing">The rows</param>
		private void SetDocumentFields(ListingMVC<CSGenioAjogador> listing)
		{
		}

		#region Mapper

		/// <inheritdoc />
		public override void MapFromModel(Models.Jogador m)
		{
		}

		/// <inheritdoc />
		public override void MapToModel(Models.Jogador m)
		{
		}

		#endregion

		#region Custom code

// USE /[MANUAL SQB VIEWMODEL_CUSTOM SQB_MENU_31]/

		#endregion

		private static readonly string[] _fieldsToSerialize =
		[
			"Jogador", "Jogador.ValCodjogador", "Jogador.ValZzstate", "Jogador.ValFoto", "Jogador.ValNome", "Jogador.ValNumerocamisola", "Jogador.ValDatanascimento", "Jogador.ValPedominante", "Jogador.ValPosicao", "Jogador.ValPosicaosegundaria", "Clube", "Clube.ValNome", "Jogador.ValEquipaanterior", "Jogador.ValCodclube"
		];

		private static readonly List<TableSearchColumn> _searchableColumns =
		[
			new TableSearchColumn("ValNome", CSGenioAjogador.FldNome, typeof(string), defaultSearch : true),
			new TableSearchColumn("ValNumerocamisola", CSGenioAjogador.FldNumerocamisola, typeof(decimal?)),
			new TableSearchColumn("ValDatanascimento", CSGenioAjogador.FldDatanascimento, typeof(DateTime?)),
			new TableSearchColumn("ValPedominante", CSGenioAjogador.FldPedominante, typeof(string), array : "Pe"),
			new TableSearchColumn("ValPosicao", CSGenioAjogador.FldPosicao, typeof(string), array : "Posicao"),
			new TableSearchColumn("ValPosicaosegundaria", CSGenioAjogador.FldPosicaosegundaria, typeof(string), array : "Posicao"),
			new TableSearchColumn("Clube_ValNome", CSGenioAclube.FldNome, typeof(string)),
			new TableSearchColumn("ValEquipaanterior", CSGenioAjogador.FldEquipaanterior, typeof(string)),
		];
		protected void SetTicketToImageFields(Models.Jogador row)
		{
			if (row == null)
				return;

			row.ValFotoQTicket = Helpers.Helpers.GetFileTicket(m_userContext.User, CSGenio.business.Area.AreaJOGADOR, CSGenioAjogador.FldFoto.Field, null, row.ValCodjogador);
		}
	}
}
