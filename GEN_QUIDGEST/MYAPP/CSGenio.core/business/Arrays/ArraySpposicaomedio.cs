using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array SPposicaoMedio (SPposicaoMedio)
	/// </summary>
	public class ArraySpposicaomedio : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArraySpposicaomedio _instance = new ArraySpposicaomedio();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArraySpposicaomedio Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Centro
		/// </summary>
		public const string E_C_1 = "C";
		/// <summary>
		/// Defensivo
		/// </summary>
		public const string E_D_2 = "D";
		/// <summary>
		/// Ofensivo
		/// </summary>
		public const string E_O_3 = "O";
		/// <summary>
		/// Direito
		/// </summary>
		public const string E_DTO_4 = "DTO";
		/// <summary>
		/// Esquerdo
		/// </summary>
		public const string E_ESQ_5 = "ESQ";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArraySpposicaomedio"/> class from being created.
		/// </summary>
		private ArraySpposicaomedio() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_C_1, new ArrayElement() { ResourceId = "CENTRO49814", HelpId = "", Group = "" } },
				{ E_D_2, new ArrayElement() { ResourceId = "DEFENSIVO65066", HelpId = "", Group = "" } },
				{ E_O_3, new ArrayElement() { ResourceId = "OFENSIVO61315", HelpId = "", Group = "" } },
				{ E_DTO_4, new ArrayElement() { ResourceId = "DIREITO04521", HelpId = "", Group = "" } },
				{ E_ESQ_5, new ArrayElement() { ResourceId = "ESQUERDO47848", HelpId = "", Group = "" } },
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
