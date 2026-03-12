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
	public class Jogador : ModelBase
	{
		[JsonIgnore]
		public CSGenioAjogador klass { get { return baseklass as CSGenioAjogador; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Jogador.ValCodjogador")]
		public string ValCodjogador { get { return klass.ValCodjogador; } set { klass.ValCodjogador = value; } }

		[DisplayName("Clube")]
		/// <summary>Field : "Clube" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Jogador.ValCodclube")]
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
		[ShouldSerialize("Jogador.ValNome")]
		public string ValNome { get { return klass.ValNome; } set { klass.ValNome = value; } }

		[DisplayName("Data Nascimento")]
		/// <summary>Field : "Data Nascimento" Tipo: "D" Formula:  ""</summary>
		[ShouldSerialize("Jogador.ValDatanascimento")]
		[DataType(DataType.Date)]
		[DateAttribute("D")]
		public DateTime? ValDatanascimento { get { return klass.ValDatanascimento; } set { klass.ValDatanascimento = value ?? DateTime.MinValue; } }

		[DisplayName("Posição")]
		/// <summary>Field : "Posição" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Jogador.ValPosicao")]
		[DataArray("Posicao", GenioMVC.Helpers.ArrayType.Character)]
		public string ValPosicao { get { return klass.ValPosicao; } set { klass.ValPosicao = value; } }
		[JsonIgnore]
		public SelectList ArrayValposicao { get { return new SelectList(CSGenio.business.ArrayPosicao.GetDictionary(), "Key", "Value", ValPosicao); } set { ValPosicao = value.SelectedValue as string; } }

		[DisplayName("Numero Camisola")]
		/// <summary>Field : "Numero Camisola" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Jogador.ValNumerocamisola")]
		[NumericAttribute(0)]
		public decimal? ValNumerocamisola { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValNumerocamisola, 0)); } set { klass.ValNumerocamisola = Convert.ToDecimal(value); } }

		[DisplayName("Posição Segundaria")]
		/// <summary>Field : "Posição Segundaria" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Jogador.ValPosicaosegundaria")]
		[DataArray("Posicao", GenioMVC.Helpers.ArrayType.Character)]
		public string ValPosicaosegundaria { get { return klass.ValPosicaosegundaria; } set { klass.ValPosicaosegundaria = value; } }
		[JsonIgnore]
		public SelectList ArrayValposicaosegundaria { get { return new SelectList(CSGenio.business.ArrayPosicao.GetDictionary(), "Key", "Value", ValPosicaosegundaria); } set { ValPosicaosegundaria = value.SelectedValue as string; } }

		[DisplayName("Pé Dominante")]
		/// <summary>Field : "Pé Dominante" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Jogador.ValPedominante")]
		[DataArray("Pe", GenioMVC.Helpers.ArrayType.Character)]
		public string ValPedominante { get { return klass.ValPedominante; } set { klass.ValPedominante = value; } }
		[JsonIgnore]
		public SelectList ArrayValpedominante { get { return new SelectList(CSGenio.business.ArrayPe.GetDictionary(), "Key", "Value", ValPedominante); } set { ValPedominante = value.SelectedValue as string; } }

		[DisplayName("Equipa Anterior")]
		/// <summary>Field : "Equipa Anterior" Tipo: "C" Formula:  ""</summary>
		[ShouldSerialize("Jogador.ValEquipaanterior")]
		public string ValEquipaanterior { get { return klass.ValEquipaanterior; } set { klass.ValEquipaanterior = value; } }

		[DisplayName("Foto")]
		/// <summary>Field : "Foto" Tipo: "IJ" Formula:  ""</summary>
		[ShouldSerialize("Jogador.ValFoto")]
		[ImageThumbnailJsonConverter(75, 75)]
		public ImageModel ValFoto { get { return new ImageModel(klass.ValFoto) { Ticket = ValFotoQTicket }; } set { klass.ValFoto = value; } }
		[JsonIgnore]
		public string ValFotoQTicket = null;

		[DisplayName("Especificação Posição")]
		/// <summary>Field : "Especificação Posição" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Jogador.ValSpposicaomedio")]
		[DataArray("Spposicaomedio", GenioMVC.Helpers.ArrayType.Character)]
		public string ValSpposicaomedio { get { return klass.ValSpposicaomedio; } set { klass.ValSpposicaomedio = value; } }
		[JsonIgnore]
		public SelectList ArrayValspposicaomedio { get { return new SelectList(CSGenio.business.ArraySpposicaomedio.GetDictionary(), "Key", "Value", ValSpposicaomedio); } set { ValSpposicaomedio = value.SelectedValue as string; } }

		[DisplayName("Especificação Posição")]
		/// <summary>Field : "Especificação Posição" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Jogador.ValSpposicaoat")]
		[DataArray("Spposicao", GenioMVC.Helpers.ArrayType.Character)]
		public string ValSpposicaoat { get { return klass.ValSpposicaoat; } set { klass.ValSpposicaoat = value; } }
		[JsonIgnore]
		public SelectList ArrayValspposicaoat { get { return new SelectList(CSGenio.business.ArraySpposicao.GetDictionary(), "Key", "Value", ValSpposicaoat); } set { ValSpposicaoat = value.SelectedValue as string; } }

		[DisplayName("Especificação Posição")]
		/// <summary>Field : "Especificação Posição" Tipo: "AC" Formula:  ""</summary>
		[ShouldSerialize("Jogador.ValSpposicaodef")]
		[DataArray("Spposicao", GenioMVC.Helpers.ArrayType.Character)]
		public string ValSpposicaodef { get { return klass.ValSpposicaodef; } set { klass.ValSpposicaodef = value; } }
		[JsonIgnore]
		public SelectList ArrayValspposicaodef { get { return new SelectList(CSGenio.business.ArraySpposicao.GetDictionary(), "Key", "Value", ValSpposicaodef); } set { ValSpposicaodef = value.SelectedValue as string; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Jogador.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Jogador(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAjogador(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Jogador(UserContext userContext, CSGenioAjogador val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAjogador csgenioa)
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
		public static Jogador Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAjogador>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Jogador(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Jogador> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAjogador>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Jogador>((r) => new Jogador(userCtx, r));
		}

// USE /[MANUAL SQB MODEL JOGADOR]/
	}
}
