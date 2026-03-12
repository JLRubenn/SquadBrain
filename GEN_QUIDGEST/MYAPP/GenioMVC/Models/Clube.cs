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
	public class Clube : ModelBase
	{
		[JsonIgnore]
		public CSGenioAclube klass { get { return baseklass as CSGenioAclube; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Clube.ValCodclube")]
		public string ValCodclube { get { return klass.ValCodclube; } set { klass.ValCodclube = value; } }

		[DisplayName("Foto")]
		/// <summary>Field : "Foto" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Clube.ValFoto")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValFoto { get { return new ImageModel(klass.ValFoto) { Ticket = ValFotoQTicket }; } set { klass.ValFoto = value; } }
		[JsonIgnore]
		public string ValFotoQTicket = null;

		[DisplayName("Nome")]
		/// <summary>Field : "Nome" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Clube.ValNome")]
		public string ValNome { get { return klass.ValNome; } set { klass.ValNome = value; } }

		[DisplayName("Escalão")]
		/// <summary>Field : "Escalão" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Clube.ValEscalao")]
		public string ValEscalao { get { return klass.ValEscalao; } set { klass.ValEscalao = value; } }

		[DisplayName("Época")]
		/// <summary>Field : "Época" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Clube.ValEpoca")]
		public string ValEpoca { get { return klass.ValEpoca; } set { klass.ValEpoca = value; } }

		[DisplayName("Presidente")]
		/// <summary>Field : "Presidente" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Clube.ValPresidente")]
		public string ValPresidente { get { return klass.ValPresidente; } set { klass.ValPresidente = value; } }

		[DisplayName("Coordenador Técnico")]
		/// <summary>Field : "Coordenador Técnico" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Clube.ValCoordtecn")]
		public string ValCoordtecn { get { return klass.ValCoordtecn; } set { klass.ValCoordtecn = value; } }

		[DisplayName("Coordenador Formação")]
		/// <summary>Field : "Coordenador Formação" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Clube.ValCoordform")]
		public string ValCoordform { get { return klass.ValCoordform; } set { klass.ValCoordform = value; } }

		[DisplayName("Treinador Principal")]
		/// <summary>Field : "Treinador Principal" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Clube.ValTreinadorprincipal")]
		public string ValTreinadorprincipal { get { return klass.ValTreinadorprincipal; } set { klass.ValTreinadorprincipal = value; } }

		[DisplayName("Treinador Adjunto")]
		/// <summary>Field : "Treinador Adjunto" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Clube.ValTreinadoradjunto")]
		public string ValTreinadoradjunto { get { return klass.ValTreinadoradjunto; } set { klass.ValTreinadoradjunto = value; } }

		[DisplayName("Valor Mercado Equipa (M)")]
		/// <summary>Field : "Valor Mercado Equipa (M)" Tipo: "$" Formula: SR "[JOGADOR->VALORMERCADO]"</summary>
		[ShouldSerialize("Clube.ValValormercadoequipa")]
		[CurrencyAttribute("EUR", 2)]
		public decimal? ValValormercadoequipa { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValValormercadoequipa, 2)); } set { klass.ValValormercadoequipa = Convert.ToDecimal(value); } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Clube.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Clube(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAclube(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Clube(UserContext userContext, CSGenioAclube val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAclube csgenioa)
		{
			if (csgenioa == null)
				return;

			foreach (RequestedField Qfield in csgenioa.Fields.Values)
			{
				switch (Qfield.Area)
				{
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
		public static Clube Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAclube>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Clube(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Clube> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAclube>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Clube>((r) => new Clube(userCtx, r));
		}

// USE /[MANUAL SQB MODEL CLUBE]/
	}
}
