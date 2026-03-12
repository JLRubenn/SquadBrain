
 
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
	/// Treino
	/// </summary>
	public class CSGenioAtreino : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAtreino(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL SQB CONSTRUTOR TREINO]/
		}

		public CSGenioAtreino(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codtreino", FieldType.KEY_INT);
			Qfield.FieldDescription = "";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codclube", FieldType.KEY_INT);
			Qfield.FieldDescription = "Clube";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "CLUBE52443";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "data", FieldType.DATETIME);
			Qfield.FieldDescription = "Data";
			Qfield.FieldSize =  16;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "DATA18071";

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
			Qfield = new Field(info.Alias, "numjogadores", FieldType.NUMERIC);
			Qfield.FieldDescription = "Numero Jogadores";
			Qfield.FieldSize =  3;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 3;
			Qfield.CavDesignation = "NUMERO_JOGADORES22289";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "microciclo", FieldType.NUMERIC);
			Qfield.FieldDescription = "Microciclo";
			Qfield.FieldSize =  3;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 3;
			Qfield.CavDesignation = "MICROCICLO36882";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "mesociclos", FieldType.NUMERIC);
			Qfield.FieldDescription = "Mesociclos";
			Qfield.FieldSize =  3;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 3;
			Qfield.CavDesignation = "MESOCICLOS42559";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "material", FieldType.MEMO);
			Qfield.FieldDescription = "Material";
			Qfield.FieldSize =  300;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "MATERIAL33877";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codjogador", FieldType.KEY_INT);
			Qfield.FieldDescription = "JOGADOR";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "JOGADOR55167";

			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "codtreinador", FieldType.KEY_INT);
			Qfield.FieldDescription = "Treinador";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "TREINADOR19936";

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
			info.ChildTable = new ChildRelation[2];
			info.ChildTable[0]= new ChildRelation("exercicio", new String[] {"codtreino"}, DeleteProc.NA);
			info.ChildTable[1]= new ChildRelation("presenca", new String[] {"codtreino"}, DeleteProc.NA);

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
			info.ParentTables.Add("clube", new Relation("SQB", "sqbtreino", "treino", "codtreino", "codclube", "SQB", "sqbclube", "clube", "codclube", "codclube"));
			info.ParentTables.Add("jogador", new Relation("SQB", "sqbtreino", "treino", "codtreino", "codjogador", "SQB", "sqbjogador", "jogador", "codjogador", "codjogador"));
			info.ParentTables.Add("treinador", new Relation("SQB", "sqbtreino", "treino", "codtreino", "codtreinador", "SQB", "sqbtreinador", "treinador", "codtreinador", "codtreinador"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(3);
			info.Pathways.Add("clube","clube");
			info.Pathways.Add("treinador","treinador");
			info.Pathways.Add("jogador","jogador");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------



			//Actualiza as seguintes rotinas de ultimo Qvalue:
			info.LastValueArgs = new List<LastValueArgument>();
			info.LastValueArgs.Add( new LastValueArgument("treinador",
				new string [] {"lasttreinocriado"},
				new string [] {"data"},
				"data",
				null,

				null, false));







			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAtreino()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="SQB";
			info.TableName="sqbtreino";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codtreino";
			info.HumanKeyName="data,".TrimEnd(',');
			info.Alias="treino";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Treino";
			info.AreaPluralDesignation="Treinos";
			info.DescriptionCav="TREINO06086";

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
		public static FieldRef FldCodtreino { get { return m_fldCodtreino; } }
		private static FieldRef m_fldCodtreino = new FieldRef("treino", "codtreino");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodtreino
		{
			get { return (string)returnValueField(FldCodtreino); }
			set { insertNameValueField(FldCodtreino, value); }
		}

		/// <summary>Field : "Clube" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodclube { get { return m_fldCodclube; } }
		private static FieldRef m_fldCodclube = new FieldRef("treino", "codclube");

		/// <summary>Field : "Clube" Tipo: "CE" Formula:  ""</summary>
		public string ValCodclube
		{
			get { return (string)returnValueField(FldCodclube); }
			set { insertNameValueField(FldCodclube, value); }
		}

		/// <summary>Field : "Data" Tipo: "DT" Formula:  ""</summary>
		public static FieldRef FldData { get { return m_fldData; } }
		private static FieldRef m_fldData = new FieldRef("treino", "data");

		/// <summary>Field : "Data" Tipo: "DT" Formula:  ""</summary>
		public DateTime ValData
		{
			get { return (DateTime)returnValueField(FldData); }
			set { insertNameValueField(FldData, value); }
		}

		/// <summary>Field : "Objetivo" Tipo: "MO" Formula:  ""</summary>
		public static FieldRef FldObjetivo { get { return m_fldObjetivo; } }
		private static FieldRef m_fldObjetivo = new FieldRef("treino", "objetivo");

		/// <summary>Field : "Objetivo" Tipo: "MO" Formula:  ""</summary>
		public string ValObjetivo
		{
			get { return (string)returnValueField(FldObjetivo); }
			set { insertNameValueField(FldObjetivo, value); }
		}

		/// <summary>Field : "Numero Jogadores" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldNumjogadores { get { return m_fldNumjogadores; } }
		private static FieldRef m_fldNumjogadores = new FieldRef("treino", "numjogadores");

		/// <summary>Field : "Numero Jogadores" Tipo: "N" Formula:  ""</summary>
		public decimal ValNumjogadores
		{
			get { return (decimal)returnValueField(FldNumjogadores); }
			set { insertNameValueField(FldNumjogadores, value); }
		}

		/// <summary>Field : "Microciclo" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldMicrociclo { get { return m_fldMicrociclo; } }
		private static FieldRef m_fldMicrociclo = new FieldRef("treino", "microciclo");

		/// <summary>Field : "Microciclo" Tipo: "N" Formula:  ""</summary>
		public decimal ValMicrociclo
		{
			get { return (decimal)returnValueField(FldMicrociclo); }
			set { insertNameValueField(FldMicrociclo, value); }
		}

		/// <summary>Field : "Mesociclos" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldMesociclos { get { return m_fldMesociclos; } }
		private static FieldRef m_fldMesociclos = new FieldRef("treino", "mesociclos");

		/// <summary>Field : "Mesociclos" Tipo: "N" Formula:  ""</summary>
		public decimal ValMesociclos
		{
			get { return (decimal)returnValueField(FldMesociclos); }
			set { insertNameValueField(FldMesociclos, value); }
		}

		/// <summary>Field : "Material" Tipo: "MO" Formula:  ""</summary>
		public static FieldRef FldMaterial { get { return m_fldMaterial; } }
		private static FieldRef m_fldMaterial = new FieldRef("treino", "material");

		/// <summary>Field : "Material" Tipo: "MO" Formula:  ""</summary>
		public string ValMaterial
		{
			get { return (string)returnValueField(FldMaterial); }
			set { insertNameValueField(FldMaterial, value); }
		}

		/// <summary>Field : "JOGADOR" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodjogador { get { return m_fldCodjogador; } }
		private static FieldRef m_fldCodjogador = new FieldRef("treino", "codjogador");

		/// <summary>Field : "JOGADOR" Tipo: "CE" Formula:  ""</summary>
		public string ValCodjogador
		{
			get { return (string)returnValueField(FldCodjogador); }
			set { insertNameValueField(FldCodjogador, value); }
		}

		/// <summary>Field : "Treinador" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodtreinador { get { return m_fldCodtreinador; } }
		private static FieldRef m_fldCodtreinador = new FieldRef("treino", "codtreinador");

		/// <summary>Field : "Treinador" Tipo: "CE" Formula:  ""</summary>
		public string ValCodtreinador
		{
			get { return (string)returnValueField(FldCodtreinador); }
			set { insertNameValueField(FldCodtreinador, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("treino", "zzstate");



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
        public static CSGenioAtreino search(PersistentSupport sp, string key, User user, string[] fields = null, bool forUpdate = false)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAtreino area = new CSGenioAtreino(user, user.CurrentModule);

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
        public static List<CSGenioAtreino> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAtreino>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAtreino> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAtreino>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);








		// USE /[MANUAL SQB TABAUX TREINO]/

 
           

	}
}
