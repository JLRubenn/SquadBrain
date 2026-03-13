<template>
	<teleport
		v-if="menuModalIsReady"
		:to="`#${uiContainersId.body}`"
		:disabled="!menuInfo.isPopup">
		<form
			class="form-horizontal"
			@submit.prevent>
			<q-row-container>
				<q-table
					v-bind="controls.menu"
					v-on="controls.menu.handlers">
					<template #header>
						<q-table-config
							:table-ctrl="controls.menu"
							v-on="controls.menu.handlers" />
					</template>
					<!-- USE /[MANUAL SQB CUSTOM_TABLE SQB_Menu_31]/ -->
				</q-table>
			</q-row-container>
		</form>
	</teleport>

	<teleport
		v-if="menuModalIsReady && hasButtons"
		:to="`#${uiContainersId.footer}`"
		:disabled="!menuInfo.isPopup">
		<q-row-container>
			<div id="footer-action-btns">
				<template
					v-for="btn in menuButtons"
					:key="btn.id">
					<q-button
						v-if="btn.isVisible"
						:id="btn.id"
						:label="btn.text"
						:variant="btn.variant"
						:disabled="btn.disabled"
						:icon-pos="btn.iconPos"
						:class="btn.classes"
						@click="btn.action">
						<q-icon
							v-if="btn.icon"
							v-bind="btn.icon" />
					</q-button>
				</template>
			</div>
		</q-row-container>
	</teleport>
</template>

<script>
	/* eslint-disable @typescript-eslint/no-unused-vars */
	import asyncProcM from '@quidgest/clientapp/composables/async'
	import qEnums from '@quidgest/clientapp/constants/enums'
	import netAPI from '@quidgest/clientapp/network'
	import openQSign from '@quidgest/clientapp/plugins/qSign'
	import genericFunctions from '@quidgest/clientapp/utils/genericFunctions'
	import { computed, readonly } from 'vue'

	import MenuHandlers from '@/mixins/menuHandlers.js'
	import controlClass from '@/mixins/fieldControl.js'
	import listFunctions from '@/mixins/listFunctions.js'
	import listColumnTypes from '@/mixins/listColumnTypes.js'
	import { resetProgressBar, setProgressBar } from '@/utils/layout.js'

	import { loadResources } from '@/plugins/i18n.js'

	import hardcodedTexts from '@/hardcodedTexts'
	import qApi from '@/api/genio/quidgestFunctions.js'
	import qFunctions from '@/api/genio/projectFunctions.js'
	import qProjArrays from '@/api/genio/projectArrays.js'
	/* eslint-enable @typescript-eslint/no-unused-vars */

	import MenuViewModel from './QMenuSQB_31ViewModel.js'

	const requiredTextResources = ['QMenuSQB_31', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL SQB FORM_INCLUDEJS SQB_MENU_31]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuSqb31',

		mixins: [
			MenuHandlers
		],

		inheritAttrs: false,

		props: {
			/**
			 * Whether or not the menu is used as a homepage.
			 */
			isHomePage: {
				type: Boolean,
				default: false
			}
		},

		expose: [
			'navigationId',
			'onBeforeRouteLeave',
			'updateMenuNavigation'
		],

		data()
		{
			// eslint-disable-next-line
			const vm = this
			return {
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuSQB_31', false),

				interfaceMetadata: {
					id: 'QMenuSQB_31', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: '31',
					isMenuList: true,
					designation: computed(() => this.Resources.JOGADORES08991),
					acronym: 'SQB_31',
					name: 'JOGADOR',
					route: 'menu-SQB_31',
					order: '31',
					controller: 'JOGADOR',
					action: 'SQB_Menu_31',
					isPopup: false
				},

				model: new MenuViewModel(this),

				controls: {
					menu: new controlClass.TableSpecialRenderingControl({
						fnHydrateViewModel: (data) => vm.model.hydrate(data),
						id: 'SQB_Menu_31',
						controller: 'JOGADOR',
						action: 'SQB_Menu_31',
						hasDependencies: false,
						isInCollapsible: false,
						tableModeClasses: [
							'q-table--full-height',
							'page-full-height'
						],
						columnsOriginal: [
							new listColumnTypes.ImageColumn({
								order: 1,
								name: 'ValFoto',
								area: 'JOGADOR',
								field: 'FOTO',
								label: computed(() => this.Resources.FOTO19492),
								dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR58591, vm.Resources.FOTO19492)),
								scrollData: 3,
								sortable: false,
								searchable: false,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValNome',
								area: 'JOGADOR',
								field: 'NOME',
								label: computed(() => this.Resources.NOME47814),
								dataLength: 50,
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 3,
								name: 'ValNumerocamisola',
								area: 'JOGADOR',
								field: 'NUMEROCAMISOLA',
								label: computed(() => this.Resources.NUMERO_CAMISOLA34511),
								scrollData: 2,
								maxDigits: 2,
								decimalPlaces: 0,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 4,
								name: 'ValDatanascimento',
								area: 'JOGADOR',
								field: 'DATANASCIMENTO',
								label: computed(() => this.Resources.DATA_NASCIMENTO26850),
								scrollData: 8,
								dateTimeType: 'date',
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ArrayColumn({
								order: 5,
								name: 'ValPedominante',
								area: 'JOGADOR',
								field: 'PEDOMINANTE',
								label: computed(() => this.Resources.PE_DOMINANTE49350),
								dataLength: 3,
								scrollData: 3,
								export: 1,
								array: computed(() => new qProjArrays.QArrayPe(vm.$getResource).elements),
								arrayType: qProjArrays.QArrayPe.type,
								arrayDisplayMode: 'D',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ArrayColumn({
								order: 6,
								name: 'ValPosicao',
								area: 'JOGADOR',
								field: 'POSICAO',
								label: computed(() => this.Resources.POSICAO07486),
								dataLength: 3,
								scrollData: 3,
								export: 1,
								array: computed(() => new qProjArrays.QArrayPosicao(vm.$getResource).elements),
								arrayType: qProjArrays.QArrayPosicao.type,
								arrayDisplayMode: 'D',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ArrayColumn({
								order: 7,
								name: 'ValPosicaosegundaria',
								area: 'JOGADOR',
								field: 'POSICAOSEGUNDARIA',
								label: computed(() => this.Resources.POSICAO_SEGUNDARIA49537),
								dataLength: 3,
								scrollData: 3,
								export: 1,
								array: computed(() => new qProjArrays.QArrayPosicao(vm.$getResource).elements),
								arrayType: qProjArrays.QArrayPosicao.type,
								arrayDisplayMode: 'D',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 8,
								name: 'Clube.ValNome',
								area: 'CLUBE',
								field: 'NOME',
								label: computed(() => this.Resources.EQUIPA_ATUAL12425),
								dataLength: 50,
								scrollData: 30,
								export: 1,
								pkColumn: 'ValCodclube',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 9,
								name: 'ValEquipaanterior',
								area: 'JOGADOR',
								field: 'EQUIPAANTERIOR',
								label: computed(() => this.Resources.EQUIPA_ANTERIOR39393),
								dataLength: 50,
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'SQB_Menu_31',
							serverMode: true,
							pkColumn: 'ValCodjogador',
							tableAlias: 'JOGADOR',
							tableNamePlural: computed(() => this.Resources.JOGADORES08991),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.JOGADORES08991),
							showAlternatePagination: true,
							permissions: {
							},
							searchBarConfig: {
								visibility: true
							},
							allowColumnFilters: true,
							allowColumnSort: true,
							crudActions: [
								{
									id: 'show',
									name: 'show',
									title: computed(() => this.Resources.CONSULTAR57388),
									icon: {
										icon: 'view'
									},
									isInReadOnly: true,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'JOGADOR',
										mode: 'SHOW',
										isControlled: true
									}
								},
								{
									id: 'edit',
									name: 'edit',
									title: computed(() => this.Resources.EDITAR11616),
									icon: {
										icon: 'pencil'
									},
									isInReadOnly: true,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'JOGADOR',
										mode: 'EDIT',
										isControlled: true
									}
								},
								{
									id: 'duplicate',
									name: 'duplicate',
									title: computed(() => this.Resources.DUPLICAR09748),
									icon: {
										icon: 'duplicate'
									},
									isInReadOnly: true,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'JOGADOR',
										mode: 'DUPLICATE',
										isControlled: true
									}
								},
								{
									id: 'delete',
									name: 'delete',
									title: computed(() => this.Resources.ELIMINAR21155),
									icon: {
										icon: 'delete'
									},
									isInReadOnly: true,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'JOGADOR',
										mode: 'DELETE',
										isControlled: true
									}
								}
							],
							generalActions: [
								{
									id: 'insert',
									name: 'insert',
									title: computed(() => this.Resources.INSERIR43365),
									icon: {
										icon: 'add'
									},
									isInReadOnly: true,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'JOGADOR',
										mode: 'NEW',
										repeatInsertion: false,
										isControlled: true
									}
								},
							],
							generalCustomActions: [
							],
							groupActions: [
							],
							customActions: [
							],
							MCActions: [
							],
							rowClickAction: {
								id: 'RCA_SQB_311',
								name: 'form-JOGADOR',
								isVisible: true,
								params: {
									isRoute: true,
									limits: [
										{
											identifier: 'id',
											fnValueSelector: (row) => row.ValCodjogador
										},
									],
									isControlled: true,
									action: vm.openFormAction, type: 'form', mode: 'SHOW', formName: 'JOGADOR'
								}
							},
							formsDefinition: {
								'JOGADOR': {
									fnKeySelector: (row) => row.Fields.ValCodjogador,
									isPopup: false
								},
							},
							allowFileExport: true,
							allowFileImport: true,
							defaultSearchColumnName: 'ValNome',
							defaultSearchColumnNameOriginal: 'ValNome',
							defaultColumnSorting: {
								columnName: 'Clube.ValNome',
								sortOrder: 'asc'
							}
						},
						groupFilters: [
							{
								id: 'filter_SQB_Menu_31_TYPEFILTER',
								isMultiple: false,
								items: [
									{
										id: 'filter_SQB_Menu_31_TYPEFILTER_1',
										value: computed(() => this.Resources.TODOS59977),
										key: '1'
									},
									{
										id: 'filter_SQB_Menu_31_TYPEFILTER_2',
										value: computed(() => this.Resources.GUARDA_REDES05920),
										key: '2'
									},
									{
										id: 'filter_SQB_Menu_31_TYPEFILTER_3',
										value: computed(() => this.Resources.DEFESAS04709),
										key: '3'
									},
									{
										id: 'filter_SQB_Menu_31_TYPEFILTER_4',
										value: computed(() => this.Resources.MEDIOS52631),
										key: '4'
									},
									{
										id: 'filter_SQB_Menu_31_TYPEFILTER_5',
										value: computed(() => this.Resources.ATACANTES25618),
										key: '5'
									},
								],
								selected: undefined,
								default: undefined
							},
						],
						globalEvents: ['changed-JOGADOR', 'changed-CLUBE'],
						uuid: '952b6b6f-99bd-4342-a146-b6c0e1e1ee45',
						allSelectedRows: 'false',
						viewModes: [
							{
								id: 'CARDS',
								type: 'cards',
								subtype: 'card-horizontal',
								label: computed(() => this.Resources.CARTOES27587),
								order: 1,
								mappingVariables: readonly({
									title: {
										allowsMultiple: false,
										sources: [
											'JOGADOR.NOME',
										]
									},
									subtitle: {
										allowsMultiple: false,
										sources: [
											'JOGADOR.NUMEROCAMISOLA',
										]
									},
									text: {
										allowsMultiple: true,
										sources: [
											'JOGADOR.PEDOMINANTE',
											'JOGADOR.POSICAO',
										]
									},
									image: {
										allowsMultiple: false,
										sources: [
											'JOGADOR.FOTO',
										]
									},
								}),
								styleVariables: {
									actionsAlignment: {
										rawValue: 'left',
										isMapped: false
									},
									actionsStyle: {
										rawValue: 'dropdown',
										isMapped: false
									},
									backgroundColor: {
										rawValue: 'auto',
										isMapped: false
									},
									customFollowupDefaultTarget: {
										rawValue: 'blank',
										isMapped: false
									},
									customInsertCard: {
										rawValue: false,
										isMapped: false
									},
									customInsertCardStyle: {
										rawValue: 'secondary',
										isMapped: false
									},
									displayMode: {
										rawValue: 'grid',
										isMapped: false
									},
									gridMode: {
										rawValue: 'fixed',
										isMapped: false
									},
									containerAlignment: {
										rawValue: 'left',
										isMapped: false
									},
									hoverScaleAmount: {
										rawValue: '1.00',
										isMapped: false
									},
									showColumnTitles: {
										rawValue: false,
										isMapped: false
									},
									showEmptyColumnTitles: {
										rawValue: true,
										isMapped: false
									},
									size: {
										rawValue: 'regular',
										isMapped: false
									},
								},
								groups: {
								}
							},
						],
						headerLevel: 1,
						isActiveControl: computed(() => this.isActiveMenu)
					}, this),
				}
			}
		},

		beforeRouteEnter(to, _, next)
		{
			// called before the route that renders this component is confirmed.
			// does NOT have access to `this` component instance,
			// because it has not been created yet when this guard is called!

			next((vm) => vm.updateMenuNavigation(to))
		},

		beforeRouteLeave(to, _, next)
		{
			this.onBeforeRouteLeave(next)
		},

		mounted()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL SQB FORM_CODEJS SQB_MENU_31]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL SQB COMPONENT_BEFORE_UNMOUNT SQB_MENU_31]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL SQB FUNCTIONS_JS SQB_31]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL SQB LISTING_CODEJS SQB_MENU_31]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
