
 
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;
using CSGenio.framework;
using CSGenio.persistence;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;
using System.Linq;

namespace CSGenio.business
{
	/// <summary>
	/// Clube
	/// </summary>
	public class CSGenioAclube : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAclube(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL SQB CONSTRUTOR CLUBE]/
		}

		public CSGenioAclube(User user) : this(user, user.CurrentModule)
		{
		}

		/// <summary>
		/// Initializes the metadata relative to the fields of this area
		/// </summary>
		private static void InicializaCampos(AreaInfo info)
		{
			Field Qfield = null;
#pragma warning disable CS0168, S1481 // Variable is declared but never used
			List<ByAreaArguments> argumentsListByArea;
#pragma warning restore CS0168, S1481 // Variable is declared but never used
			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codclube", FieldType.KEY_INT);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "foto", FieldType.IMAGE);
			Qfield.FieldDescription = "Foto";
			Qfield.FieldSize =  3;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "FOTO19492";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "nome", FieldType.TEXT);
			Qfield.FieldDescription = "Nome";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "NOME47814";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "escalao", FieldType.TEXT);
			Qfield.FieldDescription = "Escalão";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "ESCALAO14935";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "epoca", FieldType.TEXT);
			Qfield.FieldDescription = "Época";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "EPOCA21186";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "presidente", FieldType.TEXT);
			Qfield.FieldDescription = "Presidente";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "PRESIDENTE51745";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "coordtecn", FieldType.TEXT);
			Qfield.FieldDescription = "Coordenador Técnico";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "COORDENADOR_TECNICO51290";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "coordform", FieldType.TEXT);
			Qfield.FieldDescription = "Coordenador Formação";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "COORDENADOR_FORMACAO06004";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "treinadorprincipal", FieldType.TEXT);
			Qfield.FieldDescription = "Treinador Principal";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "TREINADOR_PRINCIPAL45661";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "treinadoradjunto", FieldType.TEXT);
			Qfield.FieldDescription = "Treinador Adjunto";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "TREINADOR_ADJUNTO05329";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "valormercadoequipa", FieldType.CURRENCY);
			Qfield.FieldDescription = "Valor Mercado Equipa (M)";
			Qfield.FieldSize =  15;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 12;
			Qfield.Decimals = 2;
			Qfield.CavDesignation = "VALOR_MERCADO_EQUIPA38351";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "zzstate", FieldType.INTEGER);
			Qfield.FieldDescription = "Estado da ficha";
			info.RegisterFieldDB(Qfield);

		}

		/// <summary>
		/// Initializes metadata for paths direct to other areas
		/// </summary>
		private static void InicializaRelacoes(AreaInfo info)
		{
			// Daughters Relations
			//------------------------------
			info.ChildTable = new ChildRelation[3];
			info.ChildTable[0]= new ChildRelation("jogo", new String[] {"codclube"}, DeleteProc.NA);
			info.ChildTable[1]= new ChildRelation("treinador", new String[] {"codclube"}, DeleteProc.NA);
			info.ChildTable[2]= new ChildRelation("jogador", new String[] {"codclube"}, DeleteProc.NA);

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(0);
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------




			info.RelatedSumFields = new string[] {
			 "valormercadoequipa"
			};





			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAclube()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="SQB";
			info.TableName="sqbclube";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codclube";
			info.HumanKeyName="nome,".TrimEnd(',');
			info.Alias="clube";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Clube";
			info.AreaPluralDesignation="Clubes";
			info.DescriptionCav="CLUBE52443";

			//sincronização
			info.SyncIncrementalDateStart = TimeSpan.FromHours(8);
			info.SyncIncrementalDateEnd = TimeSpan.FromHours(23);
			info.SyncCompleteHour = TimeSpan.FromHours(0.5);
			info.SyncIncrementalPeriod = TimeSpan.FromHours(1);
			info.BatchSync = 100;
			info.SyncType = SyncType.Central;
            info.SolrList = new List<string>();
        	info.QueuesList = new List<GenioServer.business.QueueGenio>();





			//RS 22.03.2011 I separated in submetodos due to performance problems with the JIT in 64bits
			// that in very large projects took 2 minutes on the first call.
			// After a Microsoft analysis of the JIT algortimo it was revealed that it has a
			// complexity O(n*m) where n are the lines of code and m the number of variables of a function.
			// Tests have revealed that splitting into subfunctions cuts the JIT time by more than half by 64-bit.
			//------------------------------
			InicializaCampos(info);

			//------------------------------
			InicializaRelacoes(info);

			//------------------------------
			InicializaCaminhos(info);

			//------------------------------
			InicializaFormulas(info);

			// Automatic audit stamps in BD
            //------------------------------

            // Documents in DB
            //------------------------------

            // Historics
            //------------------------------

			// Duplication
			//------------------------------

			// Ephs
			//------------------------------
			info.Ephs=new Hashtable();

			// Table minimum roles and access levels
			//------------------------------
            info.QLevel = new QLevel();
            info.QLevel.Query = Role.AUTHORIZED;
            info.QLevel.Create = Role.AUTHORIZED;
            info.QLevel.AlterAlways = Role.AUTHORIZED;
            info.QLevel.RemoveAlways = Role.AUTHORIZED;

      		return info;
		}

		/// <summary>
		/// Meta-information about this area
		/// </summary>
		public override AreaInfo Information
		{
			get { return informacao; }
		}
		/// <summary>
		/// Meta-information about this area
		/// </summary>
		public static AreaInfo GetInformation()
		{
			return informacao;
		}

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public static FieldRef FldCodclube { get { return m_fldCodclube; } }
		private static FieldRef m_fldCodclube = new FieldRef("clube", "codclube");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodclube
		{
			get { return (string)returnValueField(FldCodclube); }
			set { insertNameValueField(FldCodclube, value); }
		}

		/// <summary>Field : "Foto" Tipo: "IJ" Formula:  ""</summary>
		public static FieldRef FldFoto { get { return m_fldFoto; } }
		private static FieldRef m_fldFoto = new FieldRef("clube", "foto");

		/// <summary>Field : "Foto" Tipo: "IJ" Formula:  ""</summary>
		public byte[] ValFoto
		{
			get { return (byte[])returnValueField(FldFoto); }
			set { insertNameValueField(FldFoto, value); }
		}

		/// <summary>Field : "Nome" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldNome { get { return m_fldNome; } }
		private static FieldRef m_fldNome = new FieldRef("clube", "nome");

		/// <summary>Field : "Nome" Tipo: "C" Formula:  ""</summary>
		public string ValNome
		{
			get { return (string)returnValueField(FldNome); }
			set { insertNameValueField(FldNome, value); }
		}

		/// <summary>Field : "Escalão" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldEscalao { get { return m_fldEscalao; } }
		private static FieldRef m_fldEscalao = new FieldRef("clube", "escalao");

		/// <summary>Field : "Escalão" Tipo: "C" Formula:  ""</summary>
		public string ValEscalao
		{
			get { return (string)returnValueField(FldEscalao); }
			set { insertNameValueField(FldEscalao, value); }
		}

		/// <summary>Field : "Época" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldEpoca { get { return m_fldEpoca; } }
		private static FieldRef m_fldEpoca = new FieldRef("clube", "epoca");

		/// <summary>Field : "Época" Tipo: "C" Formula:  ""</summary>
		public string ValEpoca
		{
			get { return (string)returnValueField(FldEpoca); }
			set { insertNameValueField(FldEpoca, value); }
		}

		/// <summary>Field : "Presidente" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldPresidente { get { return m_fldPresidente; } }
		private static FieldRef m_fldPresidente = new FieldRef("clube", "presidente");

		/// <summary>Field : "Presidente" Tipo: "C" Formula:  ""</summary>
		public string ValPresidente
		{
			get { return (string)returnValueField(FldPresidente); }
			set { insertNameValueField(FldPresidente, value); }
		}

		/// <summary>Field : "Coordenador Técnico" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldCoordtecn { get { return m_fldCoordtecn; } }
		private static FieldRef m_fldCoordtecn = new FieldRef("clube", "coordtecn");

		/// <summary>Field : "Coordenador Técnico" Tipo: "C" Formula:  ""</summary>
		public string ValCoordtecn
		{
			get { return (string)returnValueField(FldCoordtecn); }
			set { insertNameValueField(FldCoordtecn, value); }
		}

		/// <summary>Field : "Coordenador Formação" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldCoordform { get { return m_fldCoordform; } }
		private static FieldRef m_fldCoordform = new FieldRef("clube", "coordform");

		/// <summary>Field : "Coordenador Formação" Tipo: "C" Formula:  ""</summary>
		public string ValCoordform
		{
			get { return (string)returnValueField(FldCoordform); }
			set { insertNameValueField(FldCoordform, value); }
		}

		/// <summary>Field : "Treinador Principal" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldTreinadorprincipal { get { return m_fldTreinadorprincipal; } }
		private static FieldRef m_fldTreinadorprincipal = new FieldRef("clube", "treinadorprincipal");

		/// <summary>Field : "Treinador Principal" Tipo: "C" Formula:  ""</summary>
		public string ValTreinadorprincipal
		{
			get { return (string)returnValueField(FldTreinadorprincipal); }
			set { insertNameValueField(FldTreinadorprincipal, value); }
		}

		/// <summary>Field : "Treinador Adjunto" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldTreinadoradjunto { get { return m_fldTreinadoradjunto; } }
		private static FieldRef m_fldTreinadoradjunto = new FieldRef("clube", "treinadoradjunto");

		/// <summary>Field : "Treinador Adjunto" Tipo: "C" Formula:  ""</summary>
		public string ValTreinadoradjunto
		{
			get { return (string)returnValueField(FldTreinadoradjunto); }
			set { insertNameValueField(FldTreinadoradjunto, value); }
		}

		/// <summary>Field : "Valor Mercado Equipa (M)" Tipo: "$" Formula: SR "[JOGADOR->VALORMERCADO]"</summary>
		public static FieldRef FldValormercadoequipa { get { return m_fldValormercadoequipa; } }
		private static FieldRef m_fldValormercadoequipa = new FieldRef("clube", "valormercadoequipa");

		/// <summary>Field : "Valor Mercado Equipa (M)" Tipo: "$" Formula: SR "[JOGADOR->VALORMERCADO]"</summary>
		public decimal ValValormercadoequipa
		{
			get { return (decimal)returnValueField(FldValormercadoequipa); }
			set { insertNameValueField(FldValormercadoequipa, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("clube", "zzstate");



		/// <summary>Field : "ZZSTATE" Type: "INT"</summary>
		public int ValZzstate
		{
			get { return (int)returnValueField(FldZzstate); }
			set { insertNameValueField(FldZzstate, value); }
		}

        /// <summary>
        /// Obtains a partially populated area with the record corresponding to a primary key
        /// </summary>
        /// <param name="sp">Persistent support from where to get the registration</param>
        /// <param name="key">The value of the primary key</param>
        /// <param name="user">The context of the user</param>
        /// <param name="fields">The fields to be filled in the area</param>
		/// <param name="forUpdate">True if you are preparing to update this record, false otherwise</param>
        /// <returns>An area with the fields requests of the record read or null if the key does not exist</returns>
        /// <remarks>Persistence operations should not be used on a partially positioned register</remarks>
        public static CSGenioAclube search(PersistentSupport sp, string key, User user, string[] fields = null, bool forUpdate = false)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAclube area = new CSGenioAclube(user, user.CurrentModule);

            if (sp.getRecord(area, key, fields, forUpdate))
                return area;
			return null;
        }


		public static string GetkeyFromControlledRecord(PersistentSupport sp, string ID, User user)
		{
			if (informacao.ControlledRecords != null)
				return informacao.ControlledRecords.GetPrimaryKeyFromControlledRecord(sp, user, ID);
			return String.Empty;
		}


        /// <summary>
        /// Search for all records of this area that comply with a condition
        /// </summary>
        /// <param name="sp">Persistent support from where to get the list</param>
        /// <param name="user">The context of the user</param>
        /// <param name="where">The search condition for the records. Use null to get all records</param>
        /// <param name="fields">The fields to be filled in the area</param>
        /// <param name="distinct">Get distinct from fields</param>
        /// <param name="noLock">NOLOCK</param>
        /// <returns>A list of area records with all fields populated</returns>
        /// <remarks>Persistence operations should not be used on a partially positioned register</remarks>
        public static List<CSGenioAclube> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAclube>(where, user, fields, distinct, noLock);
        }



       	/// <summary>
        /// Search for all records of this area that comply with a condition
        /// </summary>
        /// <param name="sp">Persistent support from where to get the list</param>
        /// <param name="user">The context of the user</param>
        /// <param name="where">The search condition for the records. Use null to get all records</param>
        /// <param name="listing">List configuration</param>
        /// <returns>A list of area records with all fields populated</returns>
        /// <remarks>Persistence operations should not be used on a partially positioned register</remarks>
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAclube> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAclube>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);








		// USE /[MANUAL SQB TABAUX CLUBE]/

 
            

	}
}
