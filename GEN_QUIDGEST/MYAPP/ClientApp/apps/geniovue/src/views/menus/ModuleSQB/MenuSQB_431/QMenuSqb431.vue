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
					<!-- USE /[MANUAL SQB CUSTOM_TABLE SQB_Menu_431]/ -->
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

	import MenuViewModel from './QMenuSQB_431ViewModel.js'

	const requiredTextResources = ['QMenuSQB_431', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL SQB FORM_INCLUDEJS SQB_MENU_431]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuSqb431',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuSQB_431', false),

				interfaceMetadata: {
					id: 'QMenuSQB_431', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: '431',
					isMenuList: true,
					designation: computed(() => this.Resources.TREINADORES03133),
					acronym: 'SQB_431',
					name: 'TREINADOR',
					route: 'menu-SQB_431',
					order: '431',
					controller: 'TREINADOR',
					action: 'SQB_Menu_431',
					isPopup: false
				},

				model: new MenuViewModel(this),

				controls: {
					menu: new controlClass.TableListControl({
						fnHydrateViewModel: (data) => vm.model.hydrate(data),
						id: 'SQB_Menu_431',
						controller: 'TREINADOR',
						action: 'SQB_Menu_431',
						hasDependencies: false,
						isInCollapsible: false,
						tableModeClasses: [
							'q-table--full-height',
							'page-full-height'
						],
						columnsOriginal: [
							new listColumnTypes.ArrayColumn({
								order: 1,
								name: 'ValFuncao',
								area: 'TREINADOR',
								field: 'FUNCAO',
								label: computed(() => this.Resources.FUN01176),
								dataLength: 3,
								scrollData: 3,
								export: 1,
								array: computed(() => new qProjArrays.QArrayFuncaotr(vm.$getResource).elements),
								arrayType: qProjArrays.QArrayFuncaotr.type,
								arrayDisplayMode: 'D',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'ValNome',
								area: 'TREINADOR',
								field: 'NOME',
								label: computed(() => this.Resources.NOME47814),
								dataLength: 50,
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'Clube.ValNome',
								area: 'CLUBE',
								field: 'NOME',
								label: computed(() => this.Resources.NOME47814),
								dataLength: 50,
								scrollData: 30,
								export: 1,
								pkColumn: 'ValCodclube',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'SQB_Menu_431',
							serverMode: true,
							pkColumn: 'ValCodtreinador',
							tableAlias: 'TREINADOR',
							tableNamePlural: computed(() => this.Resources.TREINADORES03133),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.TREINADORES03133),
							showAlternatePagination: true,
							permissions: {
								canView: false,
								canEdit: false,
								canDuplicate: false,
								canDelete: false,
								canInsert: false
							},
							searchBarConfig: {
								visibility: true
							},
							allowColumnFilters: true,
							allowColumnSort: true,
							generalCustomActions: [
							],
							groupActions: [
							],
							customActions: [
							],
							MCActions: [
							],
							rowClickAction: {
								id: 'RCA_SQB_4311',
								name: 'menu-SQB_4311',
								isVisible: true,
								params: {
									isRoute: true,
									limits: [
										{
											identifier: 'treinador',
											fnValueSelector: (row) => row.ValCodtreinador
										},
									],
									action: vm.openMenuAction, type: 'menu', menuName: 'SQB_4311'
								}
							},
							formsDefinition: {
							},
							defaultSearchColumnName: 'ValNome',
							defaultSearchColumnNameOriginal: 'ValNome',
							defaultColumnSorting: {
								columnName: 'ValNome',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-CLUBE', 'changed-TREINADOR'],
						uuid: 'dc689745-4023-464c-b813-a572750e3a43',
						allSelectedRows: 'false',
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
// USE /[MANUAL SQB FORM_CODEJS SQB_MENU_431]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL SQB COMPONENT_BEFORE_UNMOUNT SQB_MENU_431]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL SQB FUNCTIONS_JS SQB_431]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL SQB LISTING_CODEJS SQB_MENU_431]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
