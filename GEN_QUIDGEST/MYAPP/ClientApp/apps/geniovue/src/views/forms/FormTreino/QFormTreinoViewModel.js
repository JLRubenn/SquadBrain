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
			name: 'TREINO',
			area: 'TREINO',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Treino',
				updateFilesTickets: 'UpdateFilesTicketsTreino',
				setFile: 'SetFileTreino'
			}
		})

		/** The primary key. */
		this.ValCodtreino = reactive(new modelFieldType.PrimaryKey({
			id: 'ValCodtreino',
			originId: 'ValCodtreino',
			area: 'TREINO',
			field: 'CODTREINO',
			description: '',
		}).cloneFrom(values?.ValCodtreino))
		this.stopWatchers.push(watch(() => this.ValCodtreino.value, (newValue, oldValue) => this.onUpdate('treino.codtreino', this.ValCodtreino, newValue, oldValue)))

		/** The hidden foreign keys. */
		this.ValCodclube = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodclube',
			originId: 'ValCodclube',
			area: 'TREINO',
			field: 'CODCLUBE',
			relatedArea: 'CLUBE',
			isFixed: true,
			description: computed(() => this.Resources.CLUBE52443),
		}).cloneFrom(values?.ValCodclube))
		this.stopWatchers.push(watch(() => this.ValCodclube.value, (newValue, oldValue) => this.onUpdate('treino.codclube', this.ValCodclube, newValue, oldValue)))

		this.ValCodjogador = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodjogador',
			originId: 'ValCodjogador',
			area: 'TREINO',
			field: 'CODJOGADOR',
			relatedArea: 'JOGADOR',
			isFixed: true,
			description: computed(() => this.Resources.JOGADOR55167),
		}).cloneFrom(values?.ValCodjogador))
		this.stopWatchers.push(watch(() => this.ValCodjogador.value, (newValue, oldValue) => this.onUpdate('treino.codjogador', this.ValCodjogador, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodtreinador = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodtreinador',
			originId: 'ValCodtreinador',
			area: 'TREINO',
			field: 'CODTREINADOR',
			relatedArea: 'TREINADOR',
			description: computed(() => this.Resources.TREINADOR19936),
		}).cloneFrom(values?.ValCodtreinador))
		this.stopWatchers.push(watch(() => this.ValCodtreinador.value, (newValue, oldValue) => this.onUpdate('treino.codtreinador', this.ValCodtreinador, newValue, oldValue)))

		/** The remaining form fields. */
		this.ValNumjogadores = reactive(new modelFieldType.Number({
			id: 'ValNumjogadores',
			originId: 'ValNumjogadores',
			area: 'TREINO',
			field: 'NUMJOGADORES',
			maxDigits: 3,
			decimalDigits: 0,
			description: computed(() => this.Resources.NUMERO_JOGADORES22289),
		}).cloneFrom(values?.ValNumjogadores))
		this.stopWatchers.push(watch(() => this.ValNumjogadores.value, (newValue, oldValue) => this.onUpdate('treino.numjogadores', this.ValNumjogadores, newValue, oldValue)))

		this.ValMicrociclo = reactive(new modelFieldType.Number({
			id: 'ValMicrociclo',
			originId: 'ValMicrociclo',
			area: 'TREINO',
			field: 'MICROCICLO',
			maxDigits: 3,
			decimalDigits: 0,
			description: computed(() => this.Resources.MICROCICLO36882),
		}).cloneFrom(values?.ValMicrociclo))
		this.stopWatchers.push(watch(() => this.ValMicrociclo.value, (newValue, oldValue) => this.onUpdate('treino.microciclo', this.ValMicrociclo, newValue, oldValue)))

		this.ValMesociclos = reactive(new modelFieldType.Number({
			id: 'ValMesociclos',
			originId: 'ValMesociclos',
			area: 'TREINO',
			field: 'MESOCICLOS',
			maxDigits: 3,
			decimalDigits: 0,
			description: computed(() => this.Resources.MESOCICLOS42559),
		}).cloneFrom(values?.ValMesociclos))
		this.stopWatchers.push(watch(() => this.ValMesociclos.value, (newValue, oldValue) => this.onUpdate('treino.mesociclos', this.ValMesociclos, newValue, oldValue)))

		this.ValData = reactive(new modelFieldType.DateTime({
			id: 'ValData',
			originId: 'ValData',
			area: 'TREINO',
			field: 'DATA',
			description: computed(() => this.Resources.DATA18071),
		}).cloneFrom(values?.ValData))
		this.stopWatchers.push(watch(() => this.ValData.value, (newValue, oldValue) => this.onUpdate('treino.data', this.ValData, newValue, oldValue)))

		this.TableTreinadorNome = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableTreinadorNome',
			originId: 'ValNome',
			area: 'TREINADOR',
			field: 'NOME',
			maxLength: 50,
			description: computed(() => this.Resources.NOME47814),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TableTreinadorNome))
		this.stopWatchers.push(watch(() => this.TableTreinadorNome.value, (newValue, oldValue) => this.onUpdate('treinador.nome', this.TableTreinadorNome, newValue, oldValue)))

		this.ValObjetivo = reactive(new modelFieldType.MultiLineString({
			id: 'ValObjetivo',
			originId: 'ValObjetivo',
			area: 'TREINO',
			field: 'OBJETIVO',
			description: computed(() => this.Resources.OBJETIVO56787),
		}).cloneFrom(values?.ValObjetivo))
		this.stopWatchers.push(watch(() => this.ValObjetivo.value, (newValue, oldValue) => this.onUpdate('treino.objetivo', this.ValObjetivo, newValue, oldValue)))

		this.ValMaterial = reactive(new modelFieldType.MultiLineString({
			id: 'ValMaterial',
			originId: 'ValMaterial',
			area: 'TREINO',
			field: 'MATERIAL',
			description: computed(() => this.Resources.MATERIAL33877),
		}).cloneFrom(values?.ValMaterial))
		this.stopWatchers.push(watch(() => this.ValMaterial.value, (newValue, oldValue) => this.onUpdate('treino.material', this.ValMaterial, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormTreinoViewModel instance.
	 * @returns {QFormTreinoViewModel} A new instance of QFormTreinoViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodtreino'

	get QPrimaryKey() { return this.ValCodtreino.value }
	set QPrimaryKey(value) { this.ValCodtreino.updateValue(value) }
}
