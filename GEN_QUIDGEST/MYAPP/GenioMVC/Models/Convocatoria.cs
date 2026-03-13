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
	public class Convocatoria : ModelBase
	{
		[JsonIgnore]
		public CSGenioAconvocatoria klass { get { return baseklass as CSGenioAconvocatoria; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Convocatoria.ValCodconvocatoria")]
		public string ValCodconvocatoria { get { return klass.ValCodconvocatoria; } set { klass.ValCodconvocatoria = value; } }

		[DisplayName("Jogador")]
		/// <summary>Field : "Jogador" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Convocatoria.ValCodjogador")]
		public string ValCodjogador { get { return klass.ValCodjogador; } set { klass.ValCodjogador = value; } }

		private Jogador _jogador;
		[DisplayName("Jogador")]
		[ShouldSerialize("Jogador")]
		public virtual Jogador Jogador
		{
			get
			{
				if (!isEmptyModel && (_jogador == null || (!string.IsNullOrEmpty(ValCodjogador) && (_jogador.isEmptyModel || _jogador.klass.QPrimaryKey != ValCodjogador))))
					_jogador = Models.Jogador.Find(ValCodjogador, m_userContext, Identifier, _fieldsToSerialize);
				_jogador ??= new Models.Jogador(m_userContext, true, _fieldsToSerialize);
				return _jogador;
			}
			set { _jogador = value; }
		}

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Convocatoria.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Convocatoria(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAconvocatoria(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Convocatoria(UserContext userContext, CSGenioAconvocatoria val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAconvocatoria csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
					case "jogador":
						_jogador ??= new Jogador(m_userContext, true, _fieldsToSerialize);
						_jogador.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Convocatoria Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAconvocatoria>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Convocatoria(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Convocatoria> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAconvocatoria>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Convocatoria>((r) => new Convocatoria(userCtx, r));
		}

// USE /[MANUAL SQB MODEL CONVOCATORIA]/
	}
}
