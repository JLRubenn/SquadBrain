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
			name: 'CLUBE',
			area: 'CLUBE',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Clube',
				updateFilesTickets: 'UpdateFilesTicketsClube',
				setFile: 'SetFileClube'
			}
		})

		/** The primary key. */
		this.ValCodclube = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodclube',
			originId: 'ValCodclube',
			area: 'CLUBE',
			field: 'CODCLUBE',
			description: '',
		}).cloneFrom(values?.ValCodclube))
		this.stopWatchers.push(watch(() => this.ValCodclube.value, (newValue, oldValue) => this.onUpdate('clube.codclube', this.ValCodclube, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValFoto = reactive(new modelFieldType.Image({
			id: 'ValFoto',
			originId: 'ValFoto',
			area: 'CLUBE',
			field: 'FOTO',
			description: computed(() => this.Resources.FOTO19492),
		}).cloneFrom(values?.ValFoto))
		this.stopWatchers.push(watch(() => this.ValFoto.value, (newValue, oldValue) => this.onUpdate('clube.foto', this.ValFoto, newValue, oldValue)))

		this.ValNome = reactive(new modelFieldType.String({
			id: 'ValNome',
			originId: 'ValNome',
			area: 'CLUBE',
			field: 'NOME',
			maxLength: 50,
			description: computed(() => this.Resources.NOME47814),
		}).cloneFrom(values?.ValNome))
		this.stopWatchers.push(watch(() => this.ValNome.value, (newValue, oldValue) => this.onUpdate('clube.nome', this.ValNome, newValue, oldValue)))

		this.ValEscalao = reactive(new modelFieldType.String({
			id: 'ValEscalao',
			originId: 'ValEscalao',
			area: 'CLUBE',
			field: 'ESCALAO',
			maxLength: 50,
			description: computed(() => this.Resources.ESCALAO14935),
		}).cloneFrom(values?.ValEscalao))
		this.stopWatchers.push(watch(() => this.ValEscalao.value, (newValue, oldValue) => this.onUpdate('clube.escalao', this.ValEscalao, newValue, oldValue)))

		this.ValEpoca = reactive(new modelFieldType.String({
			id: 'ValEpoca',
			originId: 'ValEpoca',
			area: 'CLUBE',
			field: 'EPOCA',
			maxLength: 50,
			description: computed(() => this.Resources.EPOCA21186),
		}).cloneFrom(values?.ValEpoca))
		this.stopWatchers.push(watch(() => this.ValEpoca.value, (newValue, oldValue) => this.onUpdate('clube.epoca', this.ValEpoca, newValue, oldValue)))

		this.ValValormercadoequipa = reactive(new modelFieldType.Number({
			id: 'ValValormercadoequipa',
			originId: 'ValValormercadoequipa',
			area: 'CLUBE',
			field: 'VALORMERCADOEQUIPA',
			maxDigits: 12,
			decimalDigits: 2,
			isFixed: true,
			description: computed(() => this.Resources.VALOR_MERCADO_EQUIPA38351),
		}).cloneFrom(values?.ValValormercadoequipa))
		this.stopWatchers.push(watch(() => this.ValValormercadoequipa.value, (newValue, oldValue) => this.onUpdate('clube.valormercadoequipa', this.ValValormercadoequipa, newValue, oldValue)))

		this.ValPresidente = reactive(new modelFieldType.String({
			id: 'ValPresidente',
			originId: 'ValPresidente',
			area: 'CLUBE',
			field: 'PRESIDENTE',
			maxLength: 50,
			description: computed(() => this.Resources.PRESIDENTE51745),
		}).cloneFrom(values?.ValPresidente))
		this.stopWatchers.push(watch(() => this.ValPresidente.value, (newValue, oldValue) => this.onUpdate('clube.presidente', this.ValPresidente, newValue, oldValue)))

		this.ValCoordtecn = reactive(new modelFieldType.String({
			id: 'ValCoordtecn',
			originId: 'ValCoordtecn',
			area: 'CLUBE',
			field: 'COORDTECN',
			maxLength: 50,
			description: computed(() => this.Resources.COORDENADOR_TECNICO51290),
		}).cloneFrom(values?.ValCoordtecn))
		this.stopWatchers.push(watch(() => this.ValCoordtecn.value, (newValue, oldValue) => this.onUpdate('clube.coordtecn', this.ValCoordtecn, newValue, oldValue)))

		this.ValCoordform = reactive(new modelFieldType.String({
			id: 'ValCoordform',
			originId: 'ValCoordform',
			area: 'CLUBE',
			field: 'COORDFORM',
			maxLength: 50,
			description: computed(() => this.Resources.COORDENADOR_FORMACAO06004),
		}).cloneFrom(values?.ValCoordform))
		this.stopWatchers.push(watch(() => this.ValCoordform.value, (newValue, oldValue) => this.onUpdate('clube.coordform', this.ValCoordform, newValue, oldValue)))

		this.ValTreinadorprincipal = reactive(new modelFieldType.String({
			id: 'ValTreinadorprincipal',
			originId: 'ValTreinadorprincipal',
			area: 'CLUBE',
			field: 'TREINADORPRINCIPAL',
			maxLength: 50,
			description: computed(() => this.Resources.TREINADOR_PRINCIPAL45661),
		}).cloneFrom(values?.ValTreinadorprincipal))
		this.stopWatchers.push(watch(() => this.ValTreinadorprincipal.value, (newValue, oldValue) => this.onUpdate('clube.treinadorprincipal', this.ValTreinadorprincipal, newValue, oldValue)))

		this.ValTreinadoradjunto = reactive(new modelFieldType.String({
			id: 'ValTreinadoradjunto',
			originId: 'ValTreinadoradjunto',
			area: 'CLUBE',
			field: 'TREINADORADJUNTO',
			maxLength: 50,
			description: computed(() => this.Resources.TREINADOR_ADJUNTO05329),
		}).cloneFrom(values?.ValTreinadoradjunto))
		this.stopWatchers.push(watch(() => this.ValTreinadoradjunto.value, (newValue, oldValue) => this.onUpdate('clube.treinadoradjunto', this.ValTreinadoradjunto, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormClubeViewModel instance.
	 * @returns {QFormClubeViewModel} A new instance of QFormClubeViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodclube'

	get QPrimaryKey() { return this.ValCodclube.value }
	set QPrimaryKey(value) { this.ValCodclube.updateValue(value) }
}
