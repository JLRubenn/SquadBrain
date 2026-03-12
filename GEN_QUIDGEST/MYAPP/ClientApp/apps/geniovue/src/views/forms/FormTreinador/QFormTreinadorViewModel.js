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
			name: 'TREINADOR',
			area: 'TREINADOR',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Treinador',
				updateFilesTickets: 'UpdateFilesTicketsTreinador',
				setFile: 'SetFileTreinador'
			}
		})

		/** The primary key. */
		this.ValCodtreinador = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodtreinador',
			originId: 'ValCodtreinador',
			area: 'TREINADOR',
			field: 'CODTREINADOR',
			description: '',
		}).cloneFrom(values?.ValCodtreinador))
		this.stopWatchers.push(watch(() => this.ValCodtreinador.value, (newValue, oldValue) => this.onUpdate('treinador.codtreinador', this.ValCodtreinador, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodclube = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodclube',
			originId: 'ValCodclube',
			area: 'TREINADOR',
			field: 'CODCLUBE',
			relatedArea: 'CLUBE',
			description: computed(() => this.Resources.CLUBE52443),
		}).cloneFrom(values?.ValCodclube))
		this.stopWatchers.push(watch(() => this.ValCodclube.value, (newValue, oldValue) => this.onUpdate('treinador.codclube', this.ValCodclube, newValue, oldValue)))

		/** The remaining form fields. */
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

		this.ValNome = reactive(new modelFieldType.String({
			id: 'ValNome',
			originId: 'ValNome',
			area: 'TREINADOR',
			field: 'NOME',
			maxLength: 50,
			description: computed(() => this.Resources.NOME47814),
		}).cloneFrom(values?.ValNome))
		this.stopWatchers.push(watch(() => this.ValNome.value, (newValue, oldValue) => this.onUpdate('treinador.nome', this.ValNome, newValue, oldValue)))

		this.ValFuncao = reactive(new modelFieldType.String({
			id: 'ValFuncao',
			originId: 'ValFuncao',
			area: 'TREINADOR',
			field: 'FUNCAO',
			maxLength: 3,
			arrayOptions: computed(() => new qProjArrays.QArrayFuncaotr(vm.$getResource).elements),
			description: computed(() => this.Resources.FUN01176),
		}).cloneFrom(values?.ValFuncao))
		this.stopWatchers.push(watch(() => this.ValFuncao.value, (newValue, oldValue) => this.onUpdate('treinador.funcao', this.ValFuncao, newValue, oldValue)))

		this.ValLasttreinocriado = reactive(new modelFieldType.String({
			id: 'ValLasttreinocriado',
			originId: 'ValLasttreinocriado',
			area: 'TREINADOR',
			field: 'LASTTREINOCRIADO',
			maxLength: 50,
			isFixed: true,
			description: computed(() => this.Resources.LASTTREINOCRIADO36042),
		}).cloneFrom(values?.ValLasttreinocriado))
		this.stopWatchers.push(watch(() => this.ValLasttreinocriado.value, (newValue, oldValue) => this.onUpdate('treinador.lasttreinocriado', this.ValLasttreinocriado, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormTreinadorViewModel instance.
	 * @returns {QFormTreinadorViewModel} A new instance of QFormTreinadorViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodtreinador'

	get QPrimaryKey() { return this.ValCodtreinador.value }
	set QPrimaryKey(value) { this.ValCodtreinador.updateValue(value) }
}
