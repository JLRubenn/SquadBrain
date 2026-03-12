using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array Posicao (Posicao)
	/// </summary>
	public class ArrayPosicao : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayPosicao _instance = new ArrayPosicao();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayPosicao Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Guarda-Redes
		/// </summary>
		public const string E_GR_1 = "GR";
		/// <summary>
		/// Defesa
		/// </summary>
		public const string E_DEF_2 = "DEF";
		/// <summary>
		/// Medio
		/// </summary>
		public const string E_MD_3 = "MD";
		/// <summary>
		/// Atacante
		/// </summary>
		public const string E_AT_4 = "AT";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayPosicao"/> class from being created.
		/// </summary>
		private ArrayPosicao() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_GR_1, new ArrayElement() { ResourceId = "GUARDA_REDES05920", HelpId = "", Group = "" } },
				{ E_DEF_2, new ArrayElement() { ResourceId = "DEFESA24828", HelpId = "", Group = "" } },
				{ E_MD_3, new ArrayElement() { ResourceId = "MEDIO16290", HelpId = "", Group = "" } },
				{ E_AT_4, new ArrayElement() { ResourceId = "ATACANTE03785", HelpId = "", Group = "" } },
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
