using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using CSGenio.business;
using CSGenio.framework;
using CSGenio.persistence;
using GenioMVC.Helpers;
using GenioMVC.Models.Navigation;
using Quidgest.Persistence;
using Quidgest.Persistence.GenericQuery;

using SelectList = Microsoft.AspNetCore.Mvc.Rendering.SelectList;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace GenioMVC.Models
{
	public class Jogo : ModelBase
	{
		[JsonIgnore]
		public CSGenioAjogo klass { get { return baseklass as CSGenioAjogo; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Jogo.ValCodjogo")]
		public string ValCodjogo { get { return klass.ValCodjogo; } set { klass.ValCodjogo = value; } }

		[DisplayName("Équipa")]
		/// <summary>Field : "Équipa" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Jogo.ValCodclube")]
		public string ValCodclube { get { return klass.ValCodclube; } set { klass.ValCodclube = value; } }

		private Clube _clube;
		[DisplayName("Clube")]
		[ShouldSerialize("Clube")]
		public virtual Clube Clube
		{
			get
			{
				if (!isEmptyModel && (_clube == null || (!string.IsNullOrEmpty(ValCodclube) && (_clube.isEmptyModel || _clube.klass.QPrimaryKey != ValCodclube))))
					_clube = Models.Clube.Find(ValCodclube, m_userContext, Identifier, _fieldsToSerialize);
				_clube ??= new Models.Clube(m_userContext, true, _fieldsToSerialize);
				return _clube;
			}
			set { _clube = value; }
		}

		[DisplayName("Data")]
		/// <summary>Field : "Data" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Jogo.ValData")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValData { get { return klass.ValData; } set { klass.ValData = value ?? DateTime.MinValue; } }

		[DisplayName("Local")]
		/// <summary>Field : "Local" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Jogo.ValLocal")]
		public string ValLocal { get { return klass.ValLocal; } set { klass.ValLocal = value; } }

		[DisplayName("Resultado")]
		/// <summary>Field : "Resultado" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Jogo.ValResultado")]
		public string ValResultado { get { return klass.ValResultado; } set { klass.ValResultado = value; } }

		[DisplayName("Équipa Adversaria")]
		/// <summary>Field : "Équipa Adversaria" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Jogo.ValEquipaadversaria")]
		public string ValEquipaadversaria { get { return klass.ValEquipaadversaria; } set { klass.ValEquipaadversaria = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Jogo.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Jogo(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAjogo(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Jogo(UserContext userContext, CSGenioAjogo val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAjogo csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "clube":
						_clube ??= new Clube(m_userContext, true, _fieldsToSerialize);
						_clube.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
						break;
					default:
						break;
				}
			}
		}

		/// <summary>
		/// Search the row by key.
		/// </summary>
		/// <param name="id">The primary key.</param>
		/// <param name="userCtx">The user context.</param>
		/// <param name="identifier">The identifier.</param>
		/// <param name="fieldsToSerialize">The fields to serialize.</param>
		/// <param name="fieldsToQuery">The fields to query.</param>
		/// <returns>Model or NULL</returns>
		public static Jogo Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAjogo>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Jogo(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Jogo> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAjogo>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Jogo>((r) => new Jogo(userCtx, r));
		}

// USE /[MANUAL SQB MODEL JOGO]/
	}
}
