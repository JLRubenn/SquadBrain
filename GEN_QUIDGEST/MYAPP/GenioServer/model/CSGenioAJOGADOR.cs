
 
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
	/// Jogador
	/// </summary>
	public class CSGenioAjogador : DbArea
	{
		/// <summary>
		/// Meta-information on this area
		/// </summary>
		protected readonly static AreaInfo informacao = InicializaAreaInfo();

		public CSGenioAjogador(User user, string module)
		{
            this.user = user;
            this.module = module;
			// USE /[MANUAL SQB CONSTRUTOR JOGADOR]/
		}

		public CSGenioAjogador(User user) : this(user, user.CurrentModule)
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
			Qfield = new Field(info.Alias, "codjogador", FieldType.KEY_INT);
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
			Qfield = new Field(info.Alias, "nome", FieldType.TEXT);
			Qfield.FieldDescription = "Nome";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "NOME47814";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "datanascimento", FieldType.DATE);
			Qfield.FieldDescription = "Data Nascimento";
			Qfield.FieldSize =  8;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "DATA_NASCIMENTO26850";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "posicao", FieldType.ARRAY_TEXT);
			Qfield.FieldDescription = "Posição";
			Qfield.FieldSize =  3;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "POSICAO07486";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
            Qfield.ArrayName = "dbo.GetValArrayCposicao";
            Qfield.ArrayClassName = "Posicao";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "numerocamisola", FieldType.NUMERIC);
			Qfield.FieldDescription = "Numero Camisola";
			Qfield.FieldSize =  2;
			Qfield.MQueue = false;
			Qfield.IntegerDigits = 2;
			Qfield.CavDesignation = "NUMERO_CAMISOLA34511";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
            Qfield.NotDup = true;
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "posicaosegundaria", FieldType.ARRAY_TEXT);
			Qfield.FieldDescription = "Posição Segundaria";
			Qfield.FieldSize =  3;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "POSICAO_SEGUNDARIA49537";

			Qfield.Dupmsg = "";
            Qfield.ArrayName = "dbo.GetValArrayCposicao";
            Qfield.ArrayClassName = "Posicao";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "pedominante", FieldType.ARRAY_TEXT);
			Qfield.FieldDescription = "Pé Dominante";
			Qfield.FieldSize =  3;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "PE_DOMINANTE49350";

            Qfield.NotNull = true;
			Qfield.Dupmsg = "";
            Qfield.ArrayName = "dbo.GetValArrayCpe";
            Qfield.ArrayClassName = "Pe";
			info.RegisterFieldDB(Qfield);

			//- - - - - - - - - - - - - - - - - - -
			Qfield = new Field(info.Alias, "equipaanterior", FieldType.TEXT);
			Qfield.FieldDescription = "Equipa Anterior";
			Qfield.FieldSize =  50;
			Qfield.MQueue = false;
			Qfield.CavDesignation = "EQUIPA_ANTERIOR39393";

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
			info.ChildTable[0]= new ChildRelation("convocatoria", new String[] {"codjogador"}, DeleteProc.NA);
			info.ChildTable[1]= new ChildRelation("presenca", new String[] {"codjogador"}, DeleteProc.NA);

			// Mother Relations
			//------------------------------
			info.ParentTables = new Dictionary<string, Relation>();
			info.ParentTables.Add("clube", new Relation("SQB", "sqbjogador", "jogador", "codjogador", "codclube", "SQB", "sqbclube", "clube", "codclube", "codclube"));
		}

		/// <summary>
		/// Initializes metadata for indirect paths to other areas
		/// </summary>
		private static void InicializaCaminhos(AreaInfo info)
		{
			// Pathways
			//------------------------------
			info.Pathways = new Dictionary<string, string>(1);
			info.Pathways.Add("clube","clube");
		}

		/// <summary>
		/// Initializes metadata for triggers and formula arguments
		/// </summary>
		private static void InicializaFormulas(AreaInfo info)
		{
			// Formulas
			//------------------------------








			//Write conditions
			List<ConditionFormula> conditions = new List<ConditionFormula>();
			info.WriteConditions = conditions.Where(c=> c.IsWriteCondition()).ToList();
			info.CrudConditions = conditions.Where(c=> c.IsCrudCondition()).ToList();

		}

		/// <summary>
		/// static CSGenioAjogador()
		/// </summary>
		private static AreaInfo InicializaAreaInfo()
		{
			AreaInfo info = new AreaInfo();

			// Area meta-information
			info.QSystem="SQB";
			info.TableName="sqbjogador";
			info.ShadowTabName="";
			info.ShadowTabKeyName="";

			info.PrimaryKeyName="codjogador";
			info.HumanKeyName="nome,".TrimEnd(',');
			info.Alias="jogador";
			info.IsDomain = true;
			info.PersistenceType = PersistenceType.Database;
			info.AreaDesignation="Jogador";
			info.AreaPluralDesignation="Jogadores";
			info.DescriptionCav="JOGADOR34905";

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
		public static FieldRef FldCodjogador { get { return m_fldCodjogador; } }
		private static FieldRef m_fldCodjogador = new FieldRef("jogador", "codjogador");

		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		public string ValCodjogador
		{
			get { return (string)returnValueField(FldCodjogador); }
			set { insertNameValueField(FldCodjogador, value); }
		}

		/// <summary>Field : "Clube" Tipo: "CE" Formula:  ""</summary>
		public static FieldRef FldCodclube { get { return m_fldCodclube; } }
		private static FieldRef m_fldCodclube = new FieldRef("jogador", "codclube");

		/// <summary>Field : "Clube" Tipo: "CE" Formula:  ""</summary>
		public string ValCodclube
		{
			get { return (string)returnValueField(FldCodclube); }
			set { insertNameValueField(FldCodclube, value); }
		}

		/// <summary>Field : "Nome" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldNome { get { return m_fldNome; } }
		private static FieldRef m_fldNome = new FieldRef("jogador", "nome");

		/// <summary>Field : "Nome" Tipo: "C" Formula:  ""</summary>
		public string ValNome
		{
			get { return (string)returnValueField(FldNome); }
			set { insertNameValueField(FldNome, value); }
		}

		/// <summary>Field : "Data Nascimento" Tipo: "D" Formula:  ""</summary>
		public static FieldRef FldDatanascimento { get { return m_fldDatanascimento; } }
		private static FieldRef m_fldDatanascimento = new FieldRef("jogador", "datanascimento");

		/// <summary>Field : "Data Nascimento" Tipo: "D" Formula:  ""</summary>
		public DateTime ValDatanascimento
		{
			get { return (DateTime)returnValueField(FldDatanascimento); }
			set { insertNameValueField(FldDatanascimento, value); }
		}

		/// <summary>Field : "Posição" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldPosicao { get { return m_fldPosicao; } }
		private static FieldRef m_fldPosicao = new FieldRef("jogador", "posicao");

		/// <summary>Field : "Posição" Tipo: "AC" Formula:  ""</summary>
		public string ValPosicao
		{
			get { return (string)returnValueField(FldPosicao); }
			set { insertNameValueField(FldPosicao, value); }
		}

		/// <summary>Field : "Numero Camisola" Tipo: "N" Formula:  ""</summary>
		public static FieldRef FldNumerocamisola { get { return m_fldNumerocamisola; } }
		private static FieldRef m_fldNumerocamisola = new FieldRef("jogador", "numerocamisola");

		/// <summary>Field : "Numero Camisola" Tipo: "N" Formula:  ""</summary>
		public decimal ValNumerocamisola
		{
			get { return (decimal)returnValueField(FldNumerocamisola); }
			set { insertNameValueField(FldNumerocamisola, value); }
		}

		/// <summary>Field : "Posição Segundaria" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldPosicaosegundaria { get { return m_fldPosicaosegundaria; } }
		private static FieldRef m_fldPosicaosegundaria = new FieldRef("jogador", "posicaosegundaria");

		/// <summary>Field : "Posição Segundaria" Tipo: "AC" Formula:  ""</summary>
		public string ValPosicaosegundaria
		{
			get { return (string)returnValueField(FldPosicaosegundaria); }
			set { insertNameValueField(FldPosicaosegundaria, value); }
		}

		/// <summary>Field : "Pé Dominante" Tipo: "AC" Formula:  ""</summary>
		public static FieldRef FldPedominante { get { return m_fldPedominante; } }
		private static FieldRef m_fldPedominante = new FieldRef("jogador", "pedominante");

		/// <summary>Field : "Pé Dominante" Tipo: "AC" Formula:  ""</summary>
		public string ValPedominante
		{
			get { return (string)returnValueField(FldPedominante); }
			set { insertNameValueField(FldPedominante, value); }
		}

		/// <summary>Field : "Equipa Anterior" Tipo: "C" Formula:  ""</summary>
		public static FieldRef FldEquipaanterior { get { return m_fldEquipaanterior; } }
		private static FieldRef m_fldEquipaanterior = new FieldRef("jogador", "equipaanterior");

		/// <summary>Field : "Equipa Anterior" Tipo: "C" Formula:  ""</summary>
		public string ValEquipaanterior
		{
			get { return (string)returnValueField(FldEquipaanterior); }
			set { insertNameValueField(FldEquipaanterior, value); }
		}

		/// <summary>Field : "Foto" Tipo: "IJ" Formula:  ""</summary>
		public static FieldRef FldFoto { get { return m_fldFoto; } }
		private static FieldRef m_fldFoto = new FieldRef("jogador", "foto");

		/// <summary>Field : "Foto" Tipo: "IJ" Formula:  ""</summary>
		public byte[] ValFoto
		{
			get { return (byte[])returnValueField(FldFoto); }
			set { insertNameValueField(FldFoto, value); }
		}

		/// <summary>Field : "ZZSTATE" Type: "INT" Formula:  ""</summary>
		public static FieldRef FldZzstate { get { return m_fldZzstate; } }
		private static FieldRef m_fldZzstate = new FieldRef("jogador", "zzstate");



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
        public static CSGenioAjogador search(PersistentSupport sp, string key, User user, string[] fields = null, bool forUpdate = false)
        {
			if (string.IsNullOrEmpty(key))
				return null;

		    CSGenioAjogador area = new CSGenioAjogador(user, user.CurrentModule);

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
        public static List<CSGenioAjogador> searchList(PersistentSupport sp, User user, CriteriaSet where, string[] fields = null, bool distinct = false, bool noLock = false)
        {
				return sp.searchListWhere<CSGenioAjogador>(where, user, fields, distinct, noLock);
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
        public static void searchListAdvancedWhere(PersistentSupport sp, User user, CriteriaSet where, ListingMVC<CSGenioAjogador> listing)
        {
			sp.searchListAdvancedWhere<CSGenioAjogador>(where, listing);
        }




		/// <summary>
		/// Check if a record exist
		/// </summary>
		/// <param name="key">Record key</param>
		/// <param name="sp">DB conecntion</param>
		/// <returns>True if the record exist</returns>
		public static bool RecordExist(string key, PersistentSupport sp) => DbArea.RecordExist(key, informacao, sp);








		// USE /[MANUAL SQB TABAUX JOGADOR]/

 
           

	}
}
