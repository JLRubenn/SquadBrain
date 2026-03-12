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
	public class Exercicio : ModelBase
	{
		[JsonIgnore]
		public CSGenioAexercicio klass { get { return baseklass as CSGenioAexercicio; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Exercicio.ValCodexercicio")]
		public string ValCodexercicio { get { return klass.ValCodexercicio; } set { klass.ValCodexercicio = value; } }

		[DisplayName("Treino")]
		/// <summary>Field : "Treino" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Exercicio.ValCodtreino")]
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

		[DisplayName("Titulo")]
		/// <summary>Field : "Titulo" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Exercicio.ValTitulo")]
		public string ValTitulo { get { return klass.ValTitulo; } set { klass.ValTitulo = value; } }

		[DisplayName("Descrição")]
		/// <summary>Field : "Descrição" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Exercicio.ValDescricao")]
		[DataType(DataType.MultilineText)]
		public string ValDescricao { get { return klass.ValDescricao; } set { klass.ValDescricao = value; } }

		[DisplayName("Foto")]
		/// <summary>Field : "Foto" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Exercicio.ValFoto")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValFoto { get { return new ImageModel(klass.ValFoto) { Ticket = ValFotoQTicket }; } set { klass.ValFoto = value; } }
		[JsonIgnore]
		public string ValFotoQTicket = null;

		[DisplayName("Tempo (m)")]
		/// <summary>Field : "Tempo (m)" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Exercicio.ValTempo")]
		[NumericAttribute(0)]
		public decimal? ValTempo { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValTempo, 0)); } set { klass.ValTempo = Convert.ToDecimal(value); } }

		[DisplayName("Numero de Jogadoes")]
		/// <summary>Field : "Numero de Jogadoes" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Exercicio.ValNumjogador")]
		[NumericAttribute(0)]
		public decimal? ValNumjogador { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValNumjogador, 0)); } set { klass.ValNumjogador = Convert.ToDecimal(value); } }

		[DisplayName("Espaço")]
		/// <summary>Field : "Espaço" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Exercicio.ValEspaco")]
		public string ValEspaco { get { return klass.ValEspaco; } set { klass.ValEspaco = value; } }

		[DisplayName("Objetivo")]
		/// <summary>Field : "Objetivo" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Exercicio.ValObjetivo")]
		[DataType(DataType.MultilineText)]
		public string ValObjetivo { get { return klass.ValObjetivo; } set { klass.ValObjetivo = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Exercicio.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Exercicio(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAexercicio(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Exercicio(UserContext userContext, CSGenioAexercicio val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAexercicio csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
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
		public static Exercicio Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAexercicio>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Exercicio(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Exercicio> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAexercicio>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Exercicio>((r) => new Exercicio(userCtx, r));
		}

// USE /[MANUAL SQB MODEL EXERCICIO]/
	}
}
