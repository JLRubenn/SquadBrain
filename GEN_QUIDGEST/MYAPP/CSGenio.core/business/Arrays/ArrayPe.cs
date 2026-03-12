using System.Collections.Generic;

namespace CSGenio.business
{
	/// <summary>
	/// Array Pe (Pe)
	/// </summary>
	public class ArrayPe : Array<string>
	{
		/// <summary>
		/// The instance
		/// </summary>
		private static readonly ArrayPe _instance = new ArrayPe();

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>
		/// The instance.
		/// </value>
		public static ArrayPe Instance { get => _instance; }

		/// <summary>
		/// Array code type
		/// </summary>
		public static ArrayType Type { get { return ArrayType.STRING; } }

		/// <summary>
		/// Direito
		/// </summary>
		public const string E_D_1 = "D";
		/// <summary>
		/// Esquerdo
		/// </summary>
		public const string E_E_2 = "E";
		/// <summary>
		/// Ambos
		/// </summary>
		public const string E_AMB_3 = "AMB";

		/// <summary>
		/// Prevents a default instance of the <see cref="ArrayPe"/> class from being created.
		/// </summary>
		private ArrayPe() : base() {}

		/// <summary>
        /// Loads the dictionary.
        /// </summary>
        /// <returns></returns>
		protected override Dictionary<string, ArrayElement> LoadDictionary()
		{
			return new Dictionary<string, ArrayElement>()
			{
				{ E_D_1, new ArrayElement() { ResourceId = "DIREITO04521", HelpId = "", Group = "" } },
				{ E_E_2, new ArrayElement() { ResourceId = "ESQUERDO47848", HelpId = "", Group = "" } },
				{ E_AMB_3, new ArrayElement() { ResourceId = "AMBOS22410", HelpId = "", Group = "" } },
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
