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
	public class Treino : ModelBase
	{
		[JsonIgnore]
		public CSGenioAtreino klass { get { return baseklass as CSGenioAtreino; } set { baseklass = value; } }

		[Key]
		/// <summary>Field : "" Tipo: "+" Formula:  ""</summary>
		[ShouldSerialize("Treino.ValCodtreino")]
		public string ValCodtreino { get { return klass.ValCodtreino; } set { klass.ValCodtreino = value; } }

		[DisplayName("Clube")]
		/// <summary>Field : "Clube" Tipo: "CE" Formula:  ""</summary>
		[ShouldSerialize("Treino.ValCodclube")]
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
		/// <summary>Field : "Data" Tipo: "DT" Formula:  ""</summary>
		[ShouldSerialize("Treino.ValData")]
		[DataType(DataType.Date)]
		[DateAttribute("DT")]
		public DateTime? ValData { get { return klass.ValData; } set { klass.ValData = value ?? DateTime.MinValue; } }

		[DisplayName("Objetivo")]
		/// <summary>Field : "Objetivo" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Treino.ValObjetivo")]
		[DataType(DataType.MultilineText)]
		public string ValObjetivo { get { return klass.ValObjetivo; } set { klass.ValObjetivo = value; } }

		[DisplayName("Numero Jogadores")]
		/// <summary>Field : "Numero Jogadores" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Treino.ValNumjogadores")]
		[NumericAttribute(0)]
		public decimal? ValNumjogadores { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValNumjogadores, 0)); } set { klass.ValNumjogadores = Convert.ToDecimal(value); } }

		[DisplayName("Microciclo")]
		/// <summary>Field : "Microciclo" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Treino.ValMicrociclo")]
		[NumericAttribute(0)]
		public decimal? ValMicrociclo { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValMicrociclo, 0)); } set { klass.ValMicrociclo = Convert.ToDecimal(value); } }

		[DisplayName("Mesociclos")]
		/// <summary>Field : "Mesociclos" Tipo: "N" Formula:  ""</summary>
		[ShouldSerialize("Treino.ValMesociclos")]
		[NumericAttribute(0)]
		public decimal? ValMesociclos { get { return Convert.ToDecimal(GenFunctions.RoundQG(klass.ValMesociclos, 0)); } set { klass.ValMesociclos = Convert.ToDecimal(value); } }

		[DisplayName("Material")]
		/// <summary>Field : "Material" Tipo: "MO" Formula:  ""</summary>
		[ShouldSerialize("Treino.ValMaterial")]
		[DataType(DataType.MultilineText)]
		public string ValMaterial { get { return klass.ValMaterial; } set { klass.ValMaterial = value; } }

		[DisplayName("ZZSTATE")]
		[ShouldSerialize("Treino.ValZzstate")]
		/// <summary>Field: "ZZSTATE", Type: "INT", Formula: ""</summary>
		public virtual int ValZzstate { get { return klass.ValZzstate; } set { klass.ValZzstate = value; } }

		public Treino(UserContext userContext, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = new CSGenioAtreino(userContext.User);
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
		}

		public Treino(UserContext userContext, CSGenioAtreino val, bool isEmpty = false, string[]? fieldsToSerialize = null) : base(userContext)
		{
			klass = val;
			isEmptyModel = isEmpty;
			if (fieldsToSerialize != null)
				SetFieldsToSerialize(fieldsToSerialize);
			FillRelatedAreas(val);
		}

		public void FillRelatedAreas(CSGenioAtreino csgenioa)
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
		public static Treino Find(string id, UserContext userCtx, string identifier = null, string[] fieldsToSerialize = null, string[] fieldsToQuery = null)
		{
			var record = Find<CSGenioAtreino>(id, userCtx, identifier, fieldsToQuery);
			return record == null ? null : new Treino(userCtx, record, false, fieldsToSerialize) { Identifier = identifier };
		}

		public static List<Treino> AllModel(UserContext userCtx, CriteriaSet args = null, string identifier = null)
		{
			return Where<CSGenioAtreino>(userCtx, false, args, numRegs: -1, identifier: identifier).RowsForViewModel<Treino>((r) => new Treino(userCtx, r));
		}

// USE /[MANUAL SQB MODEL TREINO]/
	}
}
