using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array estado_presenca (estado presenca)
	/// </summary>
	public class ArrayEstado_presenca : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayEstado_presenca _instance = new ArrayEstado_presenca();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayEstado_presenca Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Presente
		/// </summary>
		public const string E_P_1 = "P";
		/// <summary>
		/// Falta
		/// </summary>
		public const string E_F_2 = "F";
		/// <summary>
		/// Lesão
		/// </summary>
		public const string E_L_3 = "L";
		/// <summary>
		/// Falta Justificada
		/// </summary>
		public const string E_FJ_4 = "FJ";
		/// <summary>
		/// Falta Injustificada
		/// </summary>
		public const string E_FI_5 = "FI";
		/// <summary>
		/// Outros
		/// </summary>
		public const string E_O_6 = "O";
		/// <summary>
		/// Atraso
		/// </summary>
		public const string E_A_7 = "A";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayEstado_presenca"/> class from being created.
		/// </summary>
		private ArrayEstado_presenca() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_P_1, new ArrayElement() { ResourceId = "PRESENTE06127", HelpId = "", Group = "" } },
				{ E_F_2, new ArrayElement() { ResourceId = "FALTA38383", HelpId = "", Group = "" } },
				{ E_L_3, new ArrayElement() { ResourceId = "LESAO00772", HelpId = "", Group = "" } },
				{ E_FJ_4, new ArrayElement() { ResourceId = "FALTA_JUSTIFICADA27443", HelpId = "", Group = "" } },
				{ E_FI_5, new ArrayElement() { ResourceId = "FALTA_INJUSTIFICADA60425", HelpId = "", Group = "" } },
				{ E_O_6, new ArrayElement() { ResourceId = "OUTROS19682", HelpId = "", Group = "" } },
				{ E_A_7, new ArrayElement() { ResourceId = "ATRASO01697", HelpId = "", Group = "" } },
			};
		}

		/// <summary>
		/// Gets the element's description.
		/// </summary>
		/// <param name="cod">The cod.</param>
		/// <returns></returns>
		public static string CodToDescricao(string cod)
		{
			return Instance.CodToDescricaoImpl(cod);
		}

		/// <summary>
		/// Gets the elements.
		/// </summary>
		/// <returns></returns>
		public static List<string> GetElements()
		{
			return Instance.GetElementsImpl();
		}

		/// <summary>
		/// Gets the element.
		/// </summary>
		/// <param name="cod">The cod.</param>
		/// <returns></returns>
		public static ArrayElement GetElement(string cod)
		{
            return Instance.GetElementImpl(cod);
        }

		/// <summary>
		/// Gets the dictionary.
		/// </summary>
		/// <returns></returns>
		public static IDictionary<string, string> GetDictionary()
		{
			return Instance.GetDictionaryImpl();
		}

		/// <summary>
		/// Gets the help identifier.
		/// </summary>
		/// <param name="cod">The cod.</param>
		/// <returns></returns>
		public static string GetHelpId(string cod)
		{
			return Instance.GetHelpIdImpl(cod);
		}
	}
}
