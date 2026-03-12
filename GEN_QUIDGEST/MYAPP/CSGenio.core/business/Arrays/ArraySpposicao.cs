using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array SPposicao (SPposicao)
	/// </summary>
	public class ArraySpposicao : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArraySpposicao _instance = new ArraySpposicao();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArraySpposicao Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Centro
		/// </summary>
		public const string E_C_1 = "C";
		/// <summary>
		/// Direito
		/// </summary>
		public const string E_D_2 = "D";
		/// <summary>
		/// Esquerdo
		/// </summary>
		public const string E_E_3 = "E";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArraySpposicao"/> class from being created.
		/// </summary>
		private ArraySpposicao() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_C_1, new ArrayElement() { ResourceId = "CENTRO49814", HelpId = "", Group = "" } },
				{ E_D_2, new ArrayElement() { ResourceId = "DIREITO04521", HelpId = "", Group = "" } },
				{ E_E_3, new ArrayElement() { ResourceId = "ESQUERDO47848", HelpId = "", Group = "" } },
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
