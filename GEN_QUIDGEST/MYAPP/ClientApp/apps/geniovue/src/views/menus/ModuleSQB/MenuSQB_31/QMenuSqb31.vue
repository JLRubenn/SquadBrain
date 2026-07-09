<template>
	<teleport
		v-if="menuModalIsReady"
		:to="`#${uiContainersId.body}`"
		:disabled="!menuInfo.isPopup">
		<form
			class="form-horizontal"
			@submit.prevent>
			<div class="zerozero-squad-block" style="margin-bottom: 1rem; padding: 0.75rem; border: 1px solid #dee2e6; border-radius: 4px; background: #f8f9fa;">
				<strong style="display: block; margin-bottom: 0.5rem;">Plantel ZeroZero</strong>
				<div style="display: flex; flex-wrap: wrap; gap: 0.5rem; align-items: center; margin-bottom: 0.75rem;">
					<input
						v-model="zerozeroTeamQuery"
						class="form-control"
						style="max-width: 22rem;"
						placeholder="Nome da equipa ou URL do ZeroZero"
						@keyup.enter="fetchZeroZeroSquad" />
					<button
						type="button"
						class="btn btn-primary"
						:disabled="zerozeroLoading"
						@click="fetchZeroZeroSquad">
						{{ zerozeroLoading ? 'A carregar...' : 'Carregar plantel' }}
					</button>
					<button
						v-if="zerozeroSquad.length > 0"
						type="button"
						class="btn btn-success"
						:disabled="zerozeroImporting"
						@click="importZeroZeroSquad">
						{{ zerozeroImporting ? 'A importar...' : 'Importar plantel' }}
					</button>
				</div>
				<span v-if="zerozeroError" style="color: #dc3545; display: block; margin-bottom: 0.5rem;">{{ zerozeroError }}</span>
				<span v-if="zerozeroSuccess" style="color: #198754; display: block; margin-bottom: 0.5rem;">{{ zerozeroSuccess }}</span>
				<div v-if="zerozeroSquad.length > 0">
					<div style="display: flex; flex-wrap: wrap; gap: 0.75rem; align-items: center; margin-bottom: 0.75rem; color: #6c757d;">
						<span>{{ zerozeroResolvedTeam || zerozeroTeamQuery }}</span>
						<a v-if="zerozeroTeamUrl" :href="zerozeroTeamUrl" target="_blank" rel="noopener noreferrer">abrir no ZeroZero</a>
						<span>{{ filteredZeroZeroSquad.length }} / {{ zerozeroSquad.length }} jogadores</span>
					</div>
					<div style="display: flex; flex-wrap: wrap; gap: 0.5rem; margin-bottom: 0.75rem;">
						<button
							v-for="filter in zerozeroPositionFilters"
							:key="filter.key"
							type="button"
							class="btn btn-sm"
							:class="zerozeroPositionFilter === filter.key ? 'btn-primary' : 'btn-outline-primary'"
							@click="zerozeroPositionFilter = filter.key">
							{{ filter.label }}
						</button>
					</div>
					<div style="display: grid; grid-template-columns: repeat(auto-fill, minmax(260px, 1fr)); gap: 0.75rem;">
						<div
							v-for="player in filteredZeroZeroSquad"
							:key="player.ProfileLink || player.Name"
							style="display: grid; grid-template-columns: 86px 1fr; gap: 0.75rem; min-height: 132px; padding: 0.75rem; border: 1px solid #ced4da; border-radius: 4px; background: #fff;">
							<div style="width: 86px; height: 86px; border-radius: 4px; background: #d9d9d9; overflow: hidden; display: flex; align-items: center; justify-content: center; color: #6c757d;">
								<img
									v-if="player.PhotoUrl"
									:src="player.PhotoUrl"
									:alt="player.Name"
									style="width: 100%; height: 100%; object-fit: cover;" />
								<span v-else>foto</span>
							</div>
							<div style="min-width: 0;">
								<a v-if="player.ProfileLink" :href="player.ProfileLink" target="_blank" rel="noopener noreferrer" style="font-weight: 700; font-size: 1rem; color: #007f4e; text-decoration: none;">
									{{ player.Name }}
								</a>
								<strong v-else style="display: block; font-size: 1rem;">{{ player.Name }}</strong>
								<div v-if="player.Age" style="color: #007f4e; margin-top: 0.25rem;">{{ player.Age }} anos</div>
								<div style="margin-top: 0.5rem;">Posição:</div>
								<div>{{ player.PositionLabel || positionLabel(player.Position) }}</div>
								<div v-if="player.Number" style="margin-top: 0.35rem; color: #6c757d;">N.º {{ player.Number }}</div>
							</div>
						</div>
					</div>
				</div>
				<span v-else style="color: #6c757d;">Escreve uma equipa e carrega o plantel quando precisares.</span>
			</div>
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

				zerozeroTeamQuery: '',
				zerozeroSquad: [],
				zerozeroLoading: false,
				zerozeroError: null,
				zerozeroSuccess: '',
				zerozeroImporting: false,
				zerozeroPositionFilter: 'ALL',
				zerozeroResolvedTeam: '',
				zerozeroTeamUrl: '',

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
								columnName: 'ValNumerocamisola',
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
								selected: '1',
								default: '1'
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
										rawValue: true,
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

		computed: {
			zerozeroPositionFilters()
			{
				return [
					{ key: 'ALL', label: 'Todos' },
					{ key: 'GR', label: 'Guarda-Redes' },
					{ key: 'DEF', label: 'Defesas' },
					{ key: 'MD', label: 'Médios' },
					{ key: 'AT', label: 'Atacantes' }
				]
			},

			filteredZeroZeroSquad()
			{
				if (this.zerozeroPositionFilter === 'ALL')
					return this.zerozeroSquad

				return this.zerozeroSquad.filter((player) => player.Position === this.zerozeroPositionFilter)
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
			this.restoreZeroZeroSquad()
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
			async fetchZeroZeroSquad()
			{
				const team = (this.zerozeroTeamQuery || '').trim()
				if (!team)
				{
					this.zerozeroError = 'Indica o nome da equipa.'
					return
				}

				this.zerozeroLoading = true
				this.zerozeroError = null
				this.zerozeroSquad = []
				this.zerozeroResolvedTeam = ''
				this.zerozeroTeamUrl = ''

				try
				{
					await netAPI.fetchData(
						'ZeroZero',
						'Squad',
						{ team },
						(data, response) => {
							if (response?.data?.Success === false)
							{
								this.zerozeroError = response.data.Message || 'Nao foi possivel carregar o plantel.'
								return
							}

							this.zerozeroResolvedTeam = data?.Team || team
							this.zerozeroTeamUrl = data?.TeamUrl || ''
							this.zerozeroSquad = data?.Players || []

							if (this.zerozeroSquad.length === 0)
								this.zerozeroError = 'Plantel nao encontrado para esta equipa.'
						},
						() => {
							this.zerozeroError = 'Nao foi possivel carregar o plantel.'
						}
					)
				}
				catch
				{
					this.zerozeroError = 'Nao foi possivel carregar o plantel.'
				}
				finally
				{
					this.zerozeroLoading = false
				}
			},

			saveZeroZeroSquad()
			{
				const state = {
					teamQuery: this.zerozeroTeamQuery,
					team: this.zerozeroResolvedTeam,
					teamUrl: this.zerozeroTeamUrl,
					players: this.zerozeroSquad
				}
				sessionStorage.setItem('zerozero-squad-preview', JSON.stringify(state))
			},

			restoreZeroZeroSquad()
			{
				try
				{
					const saved = JSON.parse(sessionStorage.getItem('zerozero-squad-preview') || 'null')
					if (!saved?.players?.length)
						return

					this.zerozeroTeamQuery = saved.teamQuery || saved.team || ''
					this.zerozeroResolvedTeam = saved.team || ''
					this.zerozeroTeamUrl = saved.teamUrl || ''
					this.zerozeroSquad = saved.players || []
				}
				catch
				{
					sessionStorage.removeItem('zerozero-squad-preview')
				}
			},

			positionLabel(position)
			{
				return this.zerozeroPositionFilters.find((filter) => filter.key === position)?.label || 'Atacante'
			},

			async importZeroZeroSquad()
			{
				if (this.zerozeroSquad.length === 0)
					return

				this.zerozeroImporting = true
				this.zerozeroError = null
				this.zerozeroSuccess = ''

				try
				{
					await netAPI.postData(
						'ZeroZero',
						'ImportSquad',
						{
							Team: this.zerozeroResolvedTeam || this.zerozeroTeamQuery,
							TeamUrl: this.zerozeroTeamUrl,
							Players: this.zerozeroSquad
						},
						(data, response) => {
							if (response?.data?.Success === false)
							{
								this.zerozeroError = response.data.Message || 'Nao foi possivel importar o plantel.'
								return
							}

							this.zerozeroSuccess = `Importados ${data?.Created || 0} jogadores para ${data?.ClubName || 'o clube'}. Ignorados ${data?.Skipped || 0} duplicados.`
						},
						() => {
							this.zerozeroError = 'Nao foi possivel importar o plantel.'
						}
					)
				}
				catch
				{
					this.zerozeroError = 'Nao foi possivel importar o plantel.'
				}
				finally
				{
					this.zerozeroImporting = false
				}
			},/* eslint-disable indent, vue/html-indent, vue/script-indent */
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
