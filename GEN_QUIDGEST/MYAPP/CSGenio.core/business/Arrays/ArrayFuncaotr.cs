using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array funcaoTR (funcaoTR)
	/// </summary>
	public class ArrayFuncaotr : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayFuncaotr _instance = new ArrayFuncaotr();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayFuncaotr Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Principal
		/// </summary>
		public const string E_PR_1 = "PR";
		/// <summary>
		/// Adjunto
		/// </summary>
		public const string E_ADJ_2 = "ADJ";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayFuncaotr"/> class from being created.
		/// </summary>
		private ArrayFuncaotr() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_PR_1, new ArrayElement() { ResourceId = "PRINCIPAL25927", HelpId = "", Group = "" } },
				{ E_ADJ_2, new ArrayElement() { ResourceId = "ADJUNTO08880", HelpId = "", Group = "" } },
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
