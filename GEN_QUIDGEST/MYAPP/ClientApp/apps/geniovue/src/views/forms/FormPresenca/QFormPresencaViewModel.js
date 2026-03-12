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
			name: 'PRESENCA',
			area: 'PRESENCA',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Presenca',
				updateFilesTickets: 'UpdateFilesTicketsPresenca',
				setFile: 'SetFilePresenca'
			}
		})

		/** The primary key. */
		this.ValCodpresenca = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodpresenca',
			originId: 'ValCodpresenca',
			area: 'PRESENCA',
			field: 'CODPRESENCA',
			description: '',
		}).cloneFrom(values?.ValCodpresenca))
		this.stopWatchers.push(watch(() => this.ValCodpresenca.value, (newValue, oldValue) => this.onUpdate('presenca.codpresenca', this.ValCodpresenca, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodtreino = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodtreino',
			originId: 'ValCodtreino',
			area: 'PRESENCA',
			field: 'CODTREINO',
			relatedArea: 'TREINO',
			description: computed(() => this.Resources.TREINO06086),
		}).cloneFrom(values?.ValCodtreino))
		this.stopWatchers.push(watch(() => this.ValCodtreino.value, (newValue, oldValue) => this.onUpdate('presenca.codtreino', this.ValCodtreino, newValue, oldValue)))

		this.ValCodjogador = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodjogador',
			originId: 'ValCodjogador',
			area: 'PRESENCA',
			field: 'CODJOGADOR',
			relatedArea: 'JOGADOR',
			description: computed(() => this.Resources.JOGADOR34905),
		}).cloneFrom(values?.ValCodjogador))
		this.stopWatchers.push(watch(() => this.ValCodjogador.value, (newValue, oldValue) => this.onUpdate('presenca.codjogador', this.ValCodjogador, newValue, oldValue)))

		/** The remaining form fields. */
		this.TableTreinoData = reactive(new modelFieldType.DateTime({
			type: 'Lookup',
			id: 'TableTreinoData',
			originId: 'ValData',
			area: 'TREINO',
			field: 'DATA',
			description: computed(() => this.Resources.DATA18071),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TableTreinoData))
		this.stopWatchers.push(watch(() => this.TableTreinoData.value, (newValue, oldValue) => this.onUpdate('treino.data', this.TableTreinoData, newValue, oldValue)))

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

		this.ValEstado = reactive(new modelFieldType.String({
			id: 'ValEstado',
			originId: 'ValEstado',
			area: 'PRESENCA',
			field: 'ESTADO',
			maxLength: 2,
			arrayOptions: computed(() => new qProjArrays.QArrayEstado_presenca(vm.$getResource).elements),
			description: computed(() => this.Resources.ESTADO07788),
		}).cloneFrom(values?.ValEstado))
		this.stopWatchers.push(watch(() => this.ValEstado.value, (newValue, oldValue) => this.onUpdate('presenca.estado', this.ValEstado, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormPresencaViewModel instance.
	 * @returns {QFormPresencaViewModel} A new instance of QFormPresencaViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodpresenca'

	get QPrimaryKey() { return this.ValCodpresenca.value }
	set QPrimaryKey(value) { this.ValCodpresenca.updateValue(value) }
}
