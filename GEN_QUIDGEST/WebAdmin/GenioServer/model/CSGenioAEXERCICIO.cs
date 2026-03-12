
 
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
	/// Exercicio
	/// </summary>
	public class CSGenioAexercicio : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAexercicio(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL SQB CONSTRUTOR EXERCICIO]/
		}

		public CSGenioAexercicio(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codexercicio", FieldType.KEY_INT);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codtreino", FieldType.KEY_INT);
			Qfield.FieldDescription = "Treino";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "TREINO06086";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "titulo", FieldType.TEXT);
			Qfield.FieldDescription = "Titulo";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "TITULO23260";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "descricao", FieldType.MEMO);
			Qfield.FieldDescription = "Descrição";
			Qfield.FieldSize =  300;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "DESCRICAO07528";

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
			Qfield = new Field(info.Alias, "tempo", FieldType.NUMERIC);
			Qfield.FieldDescription = "Tempo";
			Qfield.FieldSize =  3;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 3;
			Qfield.CavDesignation = "TEMPO40562";

			Qfield.Dupmsg = "";
			Qfield.DefaultValue = new DefaultValue(m);
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "numjogador", FieldType.NUMERIC);
			Qfield.FieldDescription = "Numero de Jogadoes";
			Qfield.FieldSize =  3;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 3;
			Qfield.CavDesignation = "NUMERO_DE_JOGADOES35633";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "espaco", FieldType.TEXT);
			Qfield.FieldDescription = "Espaço";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "ESPACO13353";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "objetivo", FieldType.MEMO);
			Qfield.FieldDescription = "Objetivo";
			Qfield.FieldSize =  300;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "OBJETIVO56787";

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

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
			info.ParentTables.Add("treino", new Relation("SQB", "sqbexercicio", "exercicio", "codexercicio", "codtreino", "SQB", "sqbtreino", "treino", "codtreino", "codtreino"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(2);
			info.Pathways.Add("treino","treino");
			info.Pathways.Add("clube","treino");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------



			info.DefaultValues = new string[] {
			 "tempo"
			};






			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAexercicio()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="SQB";
			info.TableName="sqbexercicio";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codexercicio";
			info.HumanKeyName="titulo,".TrimEnd(',');
			info.Alias="exercicio";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Exercicio";
			info.AreaPluralDesignation="Exercicios";
			info.DescriptionCav="EXERCICIO05075";

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
		public static FieldRef FldCodexercicio { get { return m_fldCodexercicio; } }
		private static FieldRef m_fldCodexercicio = new FieldRef("exercicio", "codexercicio");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodexercicio
		{
			get { return (string)returnValueField(FldCodexercicio); }
			set { insertNameValueField(FldCodexercicio, value); }
		}

		/// <summary>Field : "Treino" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodtreino { get { return m_fldCodtreino; } }
		private static FieldRef m_fldCodtreino = new FieldRef("exercicio", "codtreino");

		/// <summary>Field : "Treino" Tipo: "CE" Formula:  ""</summary>
		public string ValCodtreino
		{
			get { return (string)returnValueField(FldCodtreino); }
			set { insertNameValueField(FldCodtreino, value); }
		}

		/// <summary>Field : "Titulo" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldTitulo { get { return m_fldTitulo; } }
		private static FieldRef m_fldTitulo = new FieldRef("exercicio", "titulo");

		/// <summary>Field : "Titulo" Tipo: "C" Formula:  ""</summary>
		public string ValTitulo
		{
			get { return (string)returnValueField(FldTitulo); }
			set { insertNameValueField(FldTitulo, value); }
		}

		/// <summary>Field : "Descrição" Tipo: "MO" Formula:  ""</summary>
		public static FieldRef FldDescricao { get { return m_fldDescricao; } }
		private static FieldRef m_fldDescricao = new FieldRef("exercicio", "descricao");

		/// <summary>Field : "Descrição" Tipo: "MO" Formula:  ""</summary>
		public string ValDescricao
		{
			get { return (string)returnValueField(FldDescricao); }
			set { insertNameValueField(FldDescricao, value); }
		}

		/// <summary>Field : "Foto" Tipo: "IJ" Formula:  ""</summary>
		public static FieldRef FldFoto { get { return m_fldFoto; } }
		private static FieldRef m_fldFoto = new FieldRef("exercicio", "foto");

		/// <summary>Field : "Foto" Tipo: "IJ" Formula:  ""</summary>
		public byte[] ValFoto
		{
			get { return (byte[])returnValueField(FldFoto); }
			set { insertNameValueField(FldFoto, value); }
		}

		/// <summary>Field : "Tempo" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldTempo { get { return m_fldTempo; } }
		private static FieldRef m_fldTempo = new FieldRef("exercicio", "tempo");

		/// <summary>Field : "Tempo" Tipo: "N" Formula:  ""</summary>
		public decimal ValTempo
		{
			get { return (decimal)returnValueField(FldTempo); }
			set { insertNameValueField(FldTempo, value); }
		}

		/// <summary>Field : "Numero de Jogadoes" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldNumjogador { get { return m_fldNumjogador; } }
		private static FieldRef m_fldNumjogador = new FieldRef("exercicio", "numjogador");

		/// <summary>Field : "Numero de Jogadoes" Tipo: "N" Formula:  ""</summary>
		public decimal ValNumjogador
		{
			get { return (decimal)returnValueField(FldNumjogador); }
			set { insertNameValueField(FldNumjogador, value); }
		}

		/// <summary>Field : "Espaço" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldEspaco { get { return m_fldEspaco; } }
		private static FieldRef m_fldEspaco = new FieldRef("exercicio", "espaco");

		/// <summary>Field : "Espaço" Tipo: "C" Formula:  ""</summary>
		public string ValEspaco
		{
			get { return (string)returnValueField(FldEspaco); }
			set { insertNameValueField(FldEspaco, value); }
		}

		/// <summary>Field : "Objetivo" Tipo: "MO" Formula:  ""</summary>
		public static FieldRef FldObjetivo { get { return m_fldObjetivo; } }
		private static FieldRef m_fldObjetivo = new FieldRef("exercicio", "objetivo");

		/// <summary>Field : "Objetivo" Tipo: "MO" Formula:  ""</summary>
		public string ValObjetivo
		{
			get { return (string)returnValueField(FldObjetivo); }
			set { insertNameValueField(FldObjetivo, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("exercicio", "zzstate");



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
        public static CSGenioAexercicio search(PersistentSupport sp, string key, User user, string[] fields = null, bool forUpdate = false)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAexercicio area = new CSGenioAexercicio(user, user.CurrentModule);

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
        public static List<CSGenioAexercicio> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAexercicio>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAexercicio> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAexercicio>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);








		// USE /[MANUAL SQB TABAUX EXERCICIO]/

 
          

	}
}
