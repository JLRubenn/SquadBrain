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
	public class Presenca : ModelBase
	{
		[JsonIgnore]
		public CSGenioApresenca klass { get { return baseklass as CSGenioApresenca; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Presenca.ValCodpresenca")]
		public string ValCodpresenca { get { return klass.ValCodpresenca; } set { klass.ValCodpresenca = value; } }

		[DisplayName("Jogador")]
		/// <summary>Field : "Jogador" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Presenca.ValCodjogador")]
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

		[DisplayName("Treino")]
		/// <summary>Field : "Treino" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Presenca.ValCodtreino")]
		public string ValCodtreino { get { return klass.ValCodtreino; } set { klass.ValCodtreino = value; } }

		private Treino _treino;
		[DisplayName("Treino")]
		[ShouldSerialize("Treino")]
		public virtual Treino Treino
		{
			get
			{
				if (!isEmptyModel && (_treino == null || (!string.IsNullOrEmpty(ValCodtreino) && (_treino.isEmptyModel || _treino.klass.QPrimaryKey != ValCodtreino))))
					_treino = Models.Treino.Find(ValCodtreino, m_userContext, Identifier, _fieldsToSerialize);
				_treino ??= new Models.Treino(m_userContext, true, _fieldsToSerialize);
				return _treino;
			}
			set { _treino = value; }
		}

		[DisplayName("Estado")]
		/// <summary>Field : "Estado" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Presenca.ValEstado")]
		[DataArray("Estado_presenca", GenioMVC.Helpers.ArrayType.Character)]
		public string ValEstado { get { return klass.ValEstado; } set { klass.ValEstado = value; } }
		[JsonIgnore]
		public SelectList ArrayValestado { get { return new SelectList(CSGenio.business.ArrayEstado_presenca.GetDictionary(), "Key", "Value", ValEstado); } set { ValEstado = value.SelectedValue as string; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Presenca.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Presenca(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioApresenca(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Presenca(UserContext userContext, CSGenioApresenca val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioApresenca csgenioa)
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
					case "treino":
						_treino ??= new Treino(m_userContext, true, _fieldsToSerialize);
						_treino.klass.insertNameValueField(Qfield.FullName, Qfield.Value);
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
		public static Presenca Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioApresenca>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Presenca(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Presenca> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioApresenca>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Presenca>((r) => new Presenca(userCtx, r));
		}

// USE /[MANUAL SQB MODEL PRESENCA]/
	}
}
