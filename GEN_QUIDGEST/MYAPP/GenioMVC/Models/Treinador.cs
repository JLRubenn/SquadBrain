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
	public class Treinador : ModelBase
	{
		[JsonIgnore]
		public CSGenioAtreinador klass { get { return baseklass as CSGenioAtreinador; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Treinador.ValCodtreinador")]
		public string ValCodtreinador { get { return klass.ValCodtreinador; } set { klass.ValCodtreinador = value; } }

		[DisplayName("Clube")]
		/// <summary>Field : "Clube" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Treinador.ValCodclube")]
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

		[DisplayName("Nome")]
		/// <summary>Field : "Nome" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Treinador.ValNome")]
		public string ValNome { get { return klass.ValNome; } set { klass.ValNome = value; } }

		[DisplayName("Fun")]
		/// <summary>Field : "Fun" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Treinador.ValFuncao")]
		[DataArray("Funcaotr", GenioMVC.Helpers.ArrayType.Character)]
		public string ValFuncao { get { return klass.ValFuncao; } set { klass.ValFuncao = value; } }
		[JsonIgnore]
		public SelectList ArrayValfuncao { get { return new SelectList(CSGenio.business.ArrayFuncaotr.GetDictionary(), "Key", "Value", ValFuncao); } set { ValFuncao = value.SelectedValue as string; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Treinador.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Treinador(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAtreinador(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Treinador(UserContext userContext, CSGenioAtreinador val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAtreinador csgenioa)
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
		public static Treinador Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAtreinador>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Treinador(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Treinador> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAtreinador>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Treinador>((r) => new Treinador(userCtx, r));
		}

// USE /[MANUAL SQB MODEL TREINADOR]/
	}
}
