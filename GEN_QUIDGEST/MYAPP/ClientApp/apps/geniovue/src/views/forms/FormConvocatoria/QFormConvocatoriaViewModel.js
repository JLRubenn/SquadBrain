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
			name: 'CONVOCATORIA',
			area: 'CONVOCATORIA',
			actions: {
				recalculateFormulas: 'RecalculateFormulas_Convocatoria',
				updateFilesTickets: 'UpdateFilesTicketsConvocatoria',
				setFile: 'SetFileConvocatoria'
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

		/** The hidden foreign keys. */
		this.ValCodjogador = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodjogador',
			originId: 'ValCodjogador',
			area: 'CONVOCATORIA',
			field: 'CODJOGADOR',
			relatedArea: 'JOGADOR',
			isFixed: true,
			description: computed(() => this.Resources.JOGADOR34905),
		}).cloneFrom(values?.ValCodjogador))
		this.stopWatchers.push(watch(() => this.ValCodjogador.value, (newValue, oldValue) => this.onUpdate('convocatoria.codjogador', this.ValCodjogador, newValue, oldValue)))

		/** The used foreign keys. */
		this.ValCodjogo = reactive(new modelFieldType.ForeignKey({
			id: 'ValCodjogo',
			originId: 'ValCodjogo',
			area: 'CONVOCATORIA',
			field: 'CODJOGO',
			relatedArea: 'JOGO',
			description: computed(() => this.Resources.JOGO37147),
		}).cloneFrom(values?.ValCodjogo))
		this.stopWatchers.push(watch(() => this.ValCodjogo.value, (newValue, oldValue) => this.onUpdate('convocatoria.codjogo', this.ValCodjogo, newValue, oldValue)))

		/** The remaining form fields. */
		this.TableJogoTitulo = reactive(new modelFieldType.String({
			type: 'Lookup',
			id: 'TableJogoTitulo',
			originId: 'ValTitulo',
			area: 'JOGO',
			field: 'TITULO',
			maxLength: 50,
			description: computed(() => this.Resources.TITULO23260),
			ignoreFldSubmit: true,
		}).cloneFrom(values?.TableJogoTitulo))
		this.stopWatchers.push(watch(() => this.TableJogoTitulo.value, (newValue, oldValue) => this.onUpdate('jogo.titulo', this.TableJogoTitulo, newValue, oldValue)))

		this.JogoValLocal = reactive(new modelFieldType.String({
			id: 'JogoValLocal',
			originId: 'ValLocal',
			area: 'JOGO',
			field: 'LOCAL',
			maxLength: 50,
			isFixed: true,
			description: computed(() => this.Resources.LOCAL02842),
		}).cloneFrom(values?.JogoValLocal))
		this.stopWatchers.push(watch(() => this.JogoValLocal.value, (newValue, oldValue) => this.onUpdate('jogo.local', this.JogoValLocal, newValue, oldValue)))

		this.JogoValData = reactive(new modelFieldType.Date({
			id: 'JogoValData',
			originId: 'ValData',
			area: 'JOGO',
			field: 'DATA',
			isFixed: true,
			description: computed(() => this.Resources.DATA18071),
		}).cloneFrom(values?.JogoValData))
		this.stopWatchers.push(watch(() => this.JogoValData.value, (newValue, oldValue) => this.onUpdate('jogo.data', this.JogoValData, newValue, oldValue)))

		this.JogoValEquipaadversaria = reactive(new modelFieldType.String({
			id: 'JogoValEquipaadversaria',
			originId: 'ValEquipaadversaria',
			area: 'JOGO',
			field: 'EQUIPAADVERSARIA',
			maxLength: 50,
			isFixed: true,
			description: computed(() => this.Resources.EQUIPA_ADVERSARIA15813),
		}).cloneFrom(values?.JogoValEquipaadversaria))
		this.stopWatchers.push(watch(() => this.JogoValEquipaadversaria.value, (newValue, oldValue) => this.onUpdate('jogo.equipaadversaria', this.JogoValEquipaadversaria, newValue, oldValue)))
	}

	/**
	 * Creates a clone of the current QFormConvocatoriaViewModel instance.
	 * @returns {QFormConvocatoriaViewModel} A new instance of QFormConvocatoriaViewModel
	 */
	clone()
	{
		return new ViewModel(this.vueContext, { callbacks: this.externalCallbacks }, this)
	}

	static QPrimaryKeyName = 'ValCodconvocatoria'

	get QPrimaryKey() { return this.ValCodconvocatoria.value }
	set QPrimaryKey(value) { this.ValCodconvocatoria.updateValue(value) }
}
