/* eslint-disable @typescript-eslint/no-unused-vars */
import { computed, reactive, watch } from 'vue'
import _merge from 'lodash-es/merge'

import FormViewModelBase from '@/mixins/formViewModelBase.js'
import genericFunctions from '@quidgest/clientapp/utils/genericFunctions'
import modelFieldType from '@quidgest/clientapp/models/fields'

import hardcodedTexts from '@/hardcodedTexts.js'
import netAPI from '@quidgest/clientapp/network'
import qApi from '@/api/genio/quidgestFunctions.js'
import qFunctions from '@/api/genio/projectFunctions.js'
import qProjArrays from '@/api/genio/projectArrays.js'
/* eslint-enable @typescript-eslint/no-unused-vars */

/**
 * Represents a ViewModel class.
 * @extends FormViewModelBase
 */
export default class ViewModel extends FormViewModelBase
{
	/**
	 * Creates a new instance of the ViewModel.
	 * @param {object} vueContext - The Vue context
	 * @param {object} options - The options for the ViewModel
	 * @param {object} values - A ViewModel instance to copy values from
	 */
	// eslint-disable-next-line @typescript-eslint/no-unused-vars
	constructor(vueContext, options, values)
	{
		super(vueContext, options)
		// eslint-disable-next-line @typescript-eslint/no-unused-vars
		const vm = this.vueContext

		// The view model metadata
		_merge(this.modelInfo, {
			name: 'JOGADOR',
			area: 'JOGADOR',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Jogador',
				updateFilesTickets: 'UpdateFilesTicketsJogador',
				setFile: 'SetFileJogador'
			}
		})

		/** The primary key. */
		this.ValCodjogador = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodjogador',
			originId: 'ValCodjogador',
			area: 'JOGADOR',
			field: 'CODJOGADOR',
			description: '',
		}).cloneFrom(values?.ValCodjogador))
		this.stopWatchers.push(watch(() => this.ValCodjogador.value, (newValue, oldValue) => this.onUpdate('jogador.codjogador', this.ValCodjogador, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodclube = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodclube',
			originId: 'ValCodclube',
			area: 'JOGADOR',
			field: 'CODCLUBE',
			relatedArea: 'CLUBE',
			description: computed(() => this.Resources.CLUBE52443),
		}).cloneFrom(values?.ValCodclube))
		this.stopWatchers.push(watch(() => this.ValCodclube.value, (newValue, oldValue) => this.onUpdate('jogador.codclube', this.ValCodclube, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValFoto = reactive(new modelFieldType.Image({
			id: 'ValFoto',
			originId: 'ValFoto',
			area: 'JOGADOR',
			field: 'FOTO',
			description: computed(() => this.Resources.FOTO19492),
		}).cloneFrom(values?.ValFoto))
		this.stopWatchers.push(watch(() => this.ValFoto.value, (newValue, oldValue) => this.onUpdate('jogador.foto', this.ValFoto, newValue, oldValue)))

		this.TableClubeNome = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableClubeNome',
			originId: 'ValNome',
			area: 'CLUBE',
			field: 'NOME',
			maxLength: 50,
			description: computed(() => this.Resources.NOME47814),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TableClubeNome))
		this.stopWatchers.push(watch(() => this.TableClubeNome.value, (newValue, oldValue) => this.onUpdate('clube.nome', this.TableClubeNome, newValue, oldValue)))

		this.ValNumerocamisola = reactive(new modelFieldType.Number({
			id: 'ValNumerocamisola',
			originId: 'ValNumerocamisola',
			area: 'JOGADOR',
			field: 'NUMEROCAMISOLA',
			maxDigits: 2,
			decimalDigits: 0,
			description: computed(() => this.Resources.NUMERO_CAMISOLA34511),
		}).cloneFrom(values?.ValNumerocamisola))
		this.stopWatchers.push(watch(() => this.ValNumerocamisola.value, (newValue, oldValue) => this.onUpdate('jogador.numerocamisola', this.ValNumerocamisola, newValue, oldValue)))

		this.ValNome = reactive(new modelFieldType.String({
			id: 'ValNome',
			originId: 'ValNome',
			area: 'JOGADOR',
			field: 'NOME',
			maxLength: 50,
			description: computed(() => this.Resources.NOME47814),
		}).cloneFrom(values?.ValNome))
		this.stopWatchers.push(watch(() => this.ValNome.value, (newValue, oldValue) => this.onUpdate('jogador.nome', this.ValNome, newValue, oldValue)))

		this.ValNationalidade = reactive(new modelFieldType.String({
			id: 'ValNationalidade',
			originId: 'ValNationalidade',
			area: 'JOGADOR',
			field: 'NATIONALIDADE',
			maxLength: 50,
			description: computed(() => this.Resources.NATIONALIDADE48376),
		}).cloneFrom(values?.ValNationalidade))
		this.stopWatchers.push(watch(() => this.ValNationalidade.value, (newValue, oldValue) => this.onUpdate('jogador.nationalidade', this.ValNationalidade, newValue, oldValue)))

		this.ValDatanascimento = reactive(new modelFieldType.Date({
			id: 'ValDatanascimento',
			originId: 'ValDatanascimento',
			area: 'JOGADOR',
			field: 'DATANASCIMENTO',
			description: computed(() => this.Resources.DATA_NASCIMENTO26850),
		}).cloneFrom(values?.ValDatanascimento))
		this.stopWatchers.push(watch(() => this.ValDatanascimento.value, (newValue, oldValue) => this.onUpdate('jogador.datanascimento', this.ValDatanascimento, newValue, oldValue)))

		this.ValIdadejogador = reactive(new modelFieldType.Number({
			id: 'ValIdadejogador',
			originId: 'ValIdadejogador',
			area: 'JOGADOR',
			field: 'IDADEJOGADOR',
			maxDigits: 3,
			decimalDigits: 0,
			isFixed: true,
			valueFormula: {
				stopRecalcCondition() { return false },
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
				fnFormula(params)
				{
					// Formula: floor(DateDiffPart([JOGADOR->DATANASCIMENTO], [Today], "D")/365))
					return qApi.Floor(qApi.DateDiffPart(this.ValDatanascimento.value,qApi.Today(),"D")/365)
				},
				dependencyEvents: ['fieldChange:jogador.datanascimento'],
				isServerRecalc: false,
				isEmpty: qApi.emptyN,
			},
			description: computed(() => this.Resources.IDADE29819),
		}).cloneFrom(values?.ValIdadejogador))
		this.stopWatchers.push(watch(() => this.ValIdadejogador.value, (newValue, oldValue) => this.onUpdate('jogador.idadejogador', this.ValIdadejogador, newValue, oldValue)))

		this.ValPedominante = reactive(new modelFieldType.String({
			id: 'ValPedominante',
			originId: 'ValPedominante',
			area: 'JOGADOR',
			field: 'PEDOMINANTE',
			maxLength: 3,
			arrayOptions: computed(() => new qProjArrays.QArrayPe(vm.$getResource).elements),
			description: computed(() => this.Resources.PE_DOMINANTE49350),
		}).cloneFrom(values?.ValPedominante))
		this.stopWatchers.push(watch(() => this.ValPedominante.value, (newValue, oldValue) => this.onUpdate('jogador.pedominante', this.ValPedominante, newValue, oldValue)))

		this.ValPosicao = reactive(new modelFieldType.String({
			id: 'ValPosicao',
			originId: 'ValPosicao',
			area: 'JOGADOR',
			field: 'POSICAO',
			maxLength: 3,
			arrayOptions: computed(() => new qProjArrays.QArrayPosicao(vm.$getResource).elements),
			description: computed(() => this.Resources.POSICAO07486),
		}).cloneFrom(values?.ValPosicao))
		this.stopWatchers.push(watch(() => this.ValPosicao.value, (newValue, oldValue) => this.onUpdate('jogador.posicao', this.ValPosicao, newValue, oldValue)))

		this.ValSpposicaomedio = reactive(new modelFieldType.String({
			id: 'ValSpposicaomedio',
			originId: 'ValSpposicaomedio',
			area: 'JOGADOR',
			field: 'SPPOSICAOMEDIO',
			maxLength: 3,
			showWhen: {
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
				fnFormula(params)
				{
					// Formula: [JOGADOR->POSICAO] == "MD"
					return this.ValPosicao.value==="MD"
				},
				dependencyEvents: ['fieldChange:jogador.posicao'],
				isServerRecalc: false,
				isEmpty: qApi.emptyC,
			},
			arrayOptions: computed(() => new qProjArrays.QArraySpposicaomedio(vm.$getResource).elements),
			description: computed(() => this.Resources.ESPECIFICACAO_POSICA24622),
		}).cloneFrom(values?.ValSpposicaomedio))
		this.stopWatchers.push(watch(() => this.ValSpposicaomedio.value, (newValue, oldValue) => this.onUpdate('jogador.spposicaomedio', this.ValSpposicaomedio, newValue, oldValue)))

		this.ValSpposicaoat = reactive(new modelFieldType.String({
			id: 'ValSpposicaoat',
			originId: 'ValSpposicaoat',
			area: 'JOGADOR',
			field: 'SPPOSICAOAT',
			maxLength: 1,
			showWhen: {
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
				fnFormula(params)
				{
					// Formula: [JOGADOR->POSICAO] == "AT"
					return this.ValPosicao.value==="AT"
				},
				dependencyEvents: ['fieldChange:jogador.posicao'],
				isServerRecalc: false,
				isEmpty: qApi.emptyC,
			},
			arrayOptions: computed(() => new qProjArrays.QArraySpposicao(vm.$getResource).elements),
			description: computed(() => this.Resources.ESPECIFICACAO_POSICA24622),
		}).cloneFrom(values?.ValSpposicaoat))
		this.stopWatchers.push(watch(() => this.ValSpposicaoat.value, (newValue, oldValue) => this.onUpdate('jogador.spposicaoat', this.ValSpposicaoat, newValue, oldValue)))

		this.ValSpposicaodef = reactive(new modelFieldType.String({
			id: 'ValSpposicaodef',
			originId: 'ValSpposicaodef',
			area: 'JOGADOR',
			field: 'SPPOSICAODEF',
			maxLength: 1,
			showWhen: {
				// eslint-disable-next-line @typescript-eslint/no-unused-vars
				fnFormula(params)
				{
					// Formula: [JOGADOR->POSICAO] == "DEF"
					return this.ValPosicao.value==="DEF"
				},
				dependencyEvents: ['fieldChange:jogador.posicao'],
				isServerRecalc: false,
				isEmpty: qApi.emptyC,
			},
			arrayOptions: computed(() => new qProjArrays.QArraySpposicao(vm.$getResource).elements),
			description: computed(() => this.Resources.ESPECIFICACAO_POSICA24622),
		}).cloneFrom(values?.ValSpposicaodef))
		this.stopWatchers.push(watch(() => this.ValSpposicaodef.value, (newValue, oldValue) => this.onUpdate('jogador.spposicaodef', this.ValSpposicaodef, newValue, oldValue)))

		this.ValPosicaosegundaria = reactive(new modelFieldType.String({
			id: 'ValPosicaosegundaria',
			originId: 'ValPosicaosegundaria',
			area: 'JOGADOR',
			field: 'POSICAOSEGUNDARIA',
			maxLength: 3,
			arrayOptions: computed(() => new qProjArrays.QArrayPosicao(vm.$getResource).elements),
			description: computed(() => this.Resources.POSICAO_SEGUNDARIA49537),
		}).cloneFrom(values?.ValPosicaosegundaria))
		this.stopWatchers.push(watch(() => this.ValPosicaosegundaria.value, (newValue, oldValue) => this.onUpdate('jogador.posicaosegundaria', this.ValPosicaosegundaria, newValue, oldValue)))

		this.ValEquipaanterior = reactive(new modelFieldType.String({
			id: 'ValEquipaanterior',
			originId: 'ValEquipaanterior',
			area: 'JOGADOR',
			field: 'EQUIPAANTERIOR',
			maxLength: 50,
			description: computed(() => this.Resources.EQUIPA_ANTERIOR39393),
		}).cloneFrom(values?.ValEquipaanterior))
		this.stopWatchers.push(watch(() => this.ValEquipaanterior.value, (newValue, oldValue) => this.onUpdate('jogador.equipaanterior', this.ValEquipaanterior, newValue, oldValue)))

		this.ValValormercado = reactive(new modelFieldType.Number({
			id: 'ValValormercado',
			originId: 'ValValormercado',
			area: 'JOGADOR',
			field: 'VALORMERCADO',
			maxDigits: 12,
			decimalDigits: 2,
			description: computed(() => this.Resources.VALOR_MERCADO__M_33616),
		}).cloneFrom(values?.ValValormercado))
		this.stopWatchers.push(watch(() => this.ValValormercado.value, (newValue, oldValue) => this.onUpdate('jogador.valormercado', this.ValValormercado, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormJogadorViewModel instance.
	 * @returns {QFormJogadorViewModel} A new instance of QFormJogadorViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodjogador'

	get QPrimaryKey() { return this.ValCodjogador.value }
	set QPrimaryKey(value) { this.ValCodjogador.updateValue(value) }
}
