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
			name: 'JOGO',
			area: 'JOGO',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Jogo',
				updateFilesTickets: 'UpdateFilesTicketsJogo',
				setFile: 'SetFileJogo'
			}
		})

		/** The primary key. */
		this.ValCodjogo = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodjogo',
			originId: 'ValCodjogo',
			area: 'JOGO',
			field: 'CODJOGO',
			description: '',
		}).cloneFrom(values?.ValCodjogo))
		this.stopWatchers.push(watch(() => this.ValCodjogo.value, (newValue, oldValue) => this.onUpdate('jogo.codjogo', this.ValCodjogo, newValue, oldValue)))

		/** The hidden foreign keys. */
		this.ValCodclube = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodclube',
			originId: 'ValCodclube',
			area: 'JOGO',
			field: 'CODCLUBE',
			relatedArea: 'CLUBE',
			isFixed: true,
			description: computed(() => this.Resources.CODCLUBE53411),
		}).cloneFrom(values?.ValCodclube))
		this.stopWatchers.push(watch(() => this.ValCodclube.value, (newValue, oldValue) => this.onUpdate('jogo.codclube', this.ValCodclube, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValTitulo = reactive(new modelFieldType.String({
			id: 'ValTitulo',
			originId: 'ValTitulo',
			area: 'JOGO',
			field: 'TITULO',
			maxLength: 50,
			description: computed(() => this.Resources.TITULO23260),
		}).cloneFrom(values?.ValTitulo))
		this.stopWatchers.push(watch(() => this.ValTitulo.value, (newValue, oldValue) => this.onUpdate('jogo.titulo', this.ValTitulo, newValue, oldValue)))

		this.ValData = reactive(new modelFieldType.Date({
			id: 'ValData',
			originId: 'ValData',
			area: 'JOGO',
			field: 'DATA',
			description: computed(() => this.Resources.DATA18071),
		}).cloneFrom(values?.ValData))
		this.stopWatchers.push(watch(() => this.ValData.value, (newValue, oldValue) => this.onUpdate('jogo.data', this.ValData, newValue, oldValue)))

		this.ValLocal = reactive(new modelFieldType.String({
			id: 'ValLocal',
			originId: 'ValLocal',
			area: 'JOGO',
			field: 'LOCAL',
			maxLength: 50,
			description: computed(() => this.Resources.LOCAL02842),
		}).cloneFrom(values?.ValLocal))
		this.stopWatchers.push(watch(() => this.ValLocal.value, (newValue, oldValue) => this.onUpdate('jogo.local', this.ValLocal, newValue, oldValue)))

		this.ValEquipaadversaria = reactive(new modelFieldType.String({
			id: 'ValEquipaadversaria',
			originId: 'ValEquipaadversaria',
			area: 'JOGO',
			field: 'EQUIPAADVERSARIA',
			maxLength: 50,
			description: computed(() => this.Resources.EQUIPA_ADVERSARIA15813),
		}).cloneFrom(values?.ValEquipaadversaria))
		this.stopWatchers.push(watch(() => this.ValEquipaadversaria.value, (newValue, oldValue) => this.onUpdate('jogo.equipaadversaria', this.ValEquipaadversaria, newValue, oldValue)))

		this.ValResultado = reactive(new modelFieldType.String({
			id: 'ValResultado',
			originId: 'ValResultado',
			area: 'JOGO',
			field: 'RESULTADO',
			maxLength: 50,
			description: computed(() => this.Resources.RESULTADO50955),
		}).cloneFrom(values?.ValResultado))
		this.stopWatchers.push(watch(() => this.ValResultado.value, (newValue, oldValue) => this.onUpdate('jogo.resultado', this.ValResultado, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormJogoViewModel instance.
	 * @returns {QFormJogoViewModel} A new instance of QFormJogoViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodjogo'

	get QPrimaryKey() { return this.ValCodjogo.value }
	set QPrimaryKey(value) { this.ValCodjogo.updateValue(value) }
}
