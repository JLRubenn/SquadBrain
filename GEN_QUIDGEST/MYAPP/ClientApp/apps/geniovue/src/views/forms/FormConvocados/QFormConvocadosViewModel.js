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
			name: 'CONVOCADOS',
			area: 'CONVOCATORIA',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Convocados',
				updateFilesTickets: 'UpdateFilesTicketsConvocados',
				setFile: 'SetFileConvocados'
			}
		})

		/** The primary key. */
		this.ValCodconvocatoria = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodconvocatoria',
			originId: 'ValCodconvocatoria',
			area: 'CONVOCATORIA',
			field: 'CODCONVOCATORIA',
			description: '',
		}).cloneFrom(values?.ValCodconvocatoria))
		this.stopWatchers.push(watch(() => this.ValCodconvocatoria.value, (newValue, oldValue) => this.onUpdate('convocatoria.codconvocatoria', this.ValCodconvocatoria, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodjogador = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodjogador',
			originId: 'ValCodjogador',
			area: 'CONVOCATORIA',
			field: 'CODJOGADOR',
			relatedArea: 'JOGADOR',
			description: computed(() => this.Resources.JOGADOR34905),
		}).cloneFrom(values?.ValCodjogador))
		this.stopWatchers.push(watch(() => this.ValCodjogador.value, (newValue, oldValue) => this.onUpdate('convocatoria.codjogador', this.ValCodjogador, newValue, oldValue)))

		/** The remaining form fields. */
		this.TableJogadorNome = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableJogadorNome',
			originId: 'ValNome',
			area: 'JOGADOR',
			field: 'NOME',
			maxLength: 50,
			description: computed(() => this.Resources.NOME47814),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TableJogadorNome))
		this.stopWatchers.push(watch(() => this.TableJogadorNome.value, (newValue, oldValue) => this.onUpdate('jogador.nome', this.TableJogadorNome, newValue, oldValue)))

		this.JogadorValNumerocamisola = reactive(new modelFieldType.Number({
			id: 'JogadorValNumerocamisola',
			originId: 'ValNumerocamisola',
			area: 'JOGADOR',
			field: 'NUMEROCAMISOLA',
			maxDigits: 2,
			decimalDigits: 0,
			isFixed: true,
			description: computed(() => this.Resources.NUMERO_CAMISOLA34511),
		}).cloneFrom(values?.JogadorValNumerocamisola))
		this.stopWatchers.push(watch(() => this.JogadorValNumerocamisola.value, (newValue, oldValue) => this.onUpdate('jogador.numerocamisola', this.JogadorValNumerocamisola, newValue, oldValue)))

		this.JogadorValPosicao = reactive(new modelFieldType.String({
			id: 'JogadorValPosicao',
			originId: 'ValPosicao',
			area: 'JOGADOR',
			field: 'POSICAO',
			maxLength: 3,
			isFixed: true,
			arrayOptions: computed(() => new qProjArrays.QArrayPosicao(vm.$getResource).elements),
			description: computed(() => this.Resources.POSICAO07486),
		}).cloneFrom(values?.JogadorValPosicao))
		this.stopWatchers.push(watch(() => this.JogadorValPosicao.value, (newValue, oldValue) => this.onUpdate('jogador.posicao', this.JogadorValPosicao, newValue, oldValue)))

		this.JogadorValPosicaosegundaria = reactive(new modelFieldType.String({
			id: 'JogadorValPosicaosegundaria',
			originId: 'ValPosicaosegundaria',
			area: 'JOGADOR',
			field: 'POSICAOSEGUNDARIA',
			maxLength: 3,
			isFixed: true,
			arrayOptions: computed(() => new qProjArrays.QArrayPosicao(vm.$getResource).elements),
			description: computed(() => this.Resources.POSICAO_SEGUNDARIA49537),
		}).cloneFrom(values?.JogadorValPosicaosegundaria))
		this.stopWatchers.push(watch(() => this.JogadorValPosicaosegundaria.value, (newValue, oldValue) => this.onUpdate('jogador.posicaosegundaria', this.JogadorValPosicaosegundaria, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormConvocadosViewModel instance.
	 * @returns {QFormConvocadosViewModel} A new instance of QFormConvocadosViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodconvocatoria'

	get QPrimaryKey() { return this.ValCodconvocatoria.value }
	set QPrimaryKey(value) { this.ValCodconvocatoria.updateValue(value) }
}
