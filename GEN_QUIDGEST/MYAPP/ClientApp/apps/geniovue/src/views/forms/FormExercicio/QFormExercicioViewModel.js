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
			name: 'EXERCICIO',
			area: 'EXERCICIO',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Exercicio',
				updateFilesTickets: 'UpdateFilesTicketsExercicio',
				setFile: 'SetFileExercicio'
			}
		})

		/** The primary key. */
		this.ValCodexercicio = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodexercicio',
			originId: 'ValCodexercicio',
			area: 'EXERCICIO',
			field: 'CODEXERCICIO',
			description: '',
		}).cloneFrom(values?.ValCodexercicio))
		this.stopWatchers.push(watch(() => this.ValCodexercicio.value, (newValue, oldValue) => this.onUpdate('exercicio.codexercicio', this.ValCodexercicio, newValue, oldValue)))

		/** The hidden foreign keys. */
		this.ValCodtreino = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodtreino',
			originId: 'ValCodtreino',
			area: 'EXERCICIO',
			field: 'CODTREINO',
			relatedArea: 'TREINO',
			isFixed: true,
			description: computed(() => this.Resources.TREINO06086),
		}).cloneFrom(values?.ValCodtreino))
		this.stopWatchers.push(watch(() => this.ValCodtreino.value, (newValue, oldValue) => this.onUpdate('exercicio.codtreino', this.ValCodtreino, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValTitulo = reactive(new modelFieldType.String({
			id: 'ValTitulo',
			originId: 'ValTitulo',
			area: 'EXERCICIO',
			field: 'TITULO',
			maxLength: 50,
			description: computed(() => this.Resources.TITULO23260),
		}).cloneFrom(values?.ValTitulo))
		this.stopWatchers.push(watch(() => this.ValTitulo.value, (newValue, oldValue) => this.onUpdate('exercicio.titulo', this.ValTitulo, newValue, oldValue)))

		this.ValFoto = reactive(new modelFieldType.Image({
			id: 'ValFoto',
			originId: 'ValFoto',
			area: 'EXERCICIO',
			field: 'FOTO',
			description: computed(() => this.Resources.FOTO19492),
		}).cloneFrom(values?.ValFoto))
		this.stopWatchers.push(watch(() => this.ValFoto.value, (newValue, oldValue) => this.onUpdate('exercicio.foto', this.ValFoto, newValue, oldValue)))

		this.ValTempo = reactive(new modelFieldType.Number({
			id: 'ValTempo',
			originId: 'ValTempo',
			area: 'EXERCICIO',
			field: 'TEMPO',
			maxDigits: 3,
			decimalDigits: 0,
			description: computed(() => this.Resources.TEMPO__M_37967),
		}).cloneFrom(values?.ValTempo))
		this.stopWatchers.push(watch(() => this.ValTempo.value, (newValue, oldValue) => this.onUpdate('exercicio.tempo', this.ValTempo, newValue, oldValue)))

		this.ValNumjogador = reactive(new modelFieldType.Number({
			id: 'ValNumjogador',
			originId: 'ValNumjogador',
			area: 'EXERCICIO',
			field: 'NUMJOGADOR',
			maxDigits: 3,
			decimalDigits: 0,
			description: computed(() => this.Resources.NUMERO_DE_JOGADOES35633),
		}).cloneFrom(values?.ValNumjogador))
		this.stopWatchers.push(watch(() => this.ValNumjogador.value, (newValue, oldValue) => this.onUpdate('exercicio.numjogador', this.ValNumjogador, newValue, oldValue)))

		this.ValEspaco = reactive(new modelFieldType.String({
			id: 'ValEspaco',
			originId: 'ValEspaco',
			area: 'EXERCICIO',
			field: 'ESPACO',
			maxLength: 50,
			description: computed(() => this.Resources.ESPACO13353),
		}).cloneFrom(values?.ValEspaco))
		this.stopWatchers.push(watch(() => this.ValEspaco.value, (newValue, oldValue) => this.onUpdate('exercicio.espaco', this.ValEspaco, newValue, oldValue)))

		this.ValObjetivo = reactive(new modelFieldType.MultiLineString({
			id: 'ValObjetivo',
			originId: 'ValObjetivo',
			area: 'EXERCICIO',
			field: 'OBJETIVO',
			description: computed(() => this.Resources.OBJETIVO56787),
		}).cloneFrom(values?.ValObjetivo))
		this.stopWatchers.push(watch(() => this.ValObjetivo.value, (newValue, oldValue) => this.onUpdate('exercicio.objetivo', this.ValObjetivo, newValue, oldValue)))

		this.ValDescricao = reactive(new modelFieldType.MultiLineString({
			id: 'ValDescricao',
			originId: 'ValDescricao',
			area: 'EXERCICIO',
			field: 'DESCRICAO',
			description: computed(() => this.Resources.DESCRICAO07528),
		}).cloneFrom(values?.ValDescricao))
		this.stopWatchers.push(watch(() => this.ValDescricao.value, (newValue, oldValue) => this.onUpdate('exercicio.descricao', this.ValDescricao, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormExercicioViewModel instance.
	 * @returns {QFormExercicioViewModel} A new instance of QFormExercicioViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodexercicio'

	get QPrimaryKey() { return this.ValCodexercicio.value }
	set QPrimaryKey(value) { this.ValCodexercicio.updateValue(value) }
}
