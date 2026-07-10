<template>
	<teleport
		v-if="menuModalIsReady"
		:to="`#${uiContainersId.body}`"
		:disabled="!menuInfo.isPopup">
		<form
			class="form-horizontal"
			@submit.prevent>
			<div class="attendance-panel">
				<h3>Presencas por treino</h3>
				<div class="attendance-toolbar">
					<select
						v-model="attendanceSelectedTrainingId"
						class="form-control">
						<option value="">Escolher treino</option>
						<option
							v-for="training in attendanceTrainings"
							:key="training.Id"
							:value="training.Id">
							{{ training.Label }}
						</option>
					</select>
					<select
						v-model="attendanceSelectedClubId"
						class="form-control">
						<option value="">Todos os clubes</option>
						<option
							v-for="club in attendanceClubs"
							:key="club.Id"
							:value="club.Id">
							{{ club.Name }}
						</option>
					</select>
					<button
						type="button"
						class="btn btn-primary"
						:disabled="attendanceLoading"
						@click="loadSquadAttendance">
						{{ attendanceLoading ? 'A carregar...' : 'Carregar plantel' }}
					</button>
					<button
						type="button"
						class="btn btn-success"
						:disabled="attendanceSaving || attendancePlayers.length === 0"
						@click="saveSquadAttendance">
						{{ attendanceSaving ? 'A guardar...' : 'Guardar presencas' }}
					</button>
				</div>
				<p
					v-if="attendanceError"
					class="attendance-message attendance-message--error">
					{{ attendanceError }}
				</p>
				<p
					v-if="attendanceSuccess"
					class="attendance-message attendance-message--success">
					{{ attendanceSuccess }}
				</p>
				<div
					v-if="attendancePlayers.length > 0"
					class="attendance-summary">
					<strong>{{ attendanceTrainingLabel }}</strong>
					<span>{{ attendancePlayers.length }} jogadores</span>
					<span>Presentes: {{ attendanceSummary.P }}</span>
					<span>Faltas: {{ attendanceSummary.F + attendanceSummary.FJ + attendanceSummary.FI }}</span>
					<span>Atrasos: {{ attendanceSummary.A }}</span>
					<span>Lesoes: {{ attendanceSummary.L }}</span>
				</div>
				<div
					v-if="attendancePlayers.length > 0"
					class="attendance-grid">
					<div
						v-for="player in attendancePlayers"
						:key="player.PlayerId"
						class="attendance-card">
						<div class="attendance-card__top">
							<div>
								<h4>{{ player.Name }}</h4>
								<p>{{ positionLabel(player.Position) }}</p>
								<p v-if="player.ClubName">{{ player.ClubName }}</p>
							</div>
							<span
								v-if="player.Number"
								class="attendance-card__number">
								{{ player.Number }}
							</span>
						</div>
						<div class="attendance-state-buttons">
							<button
								v-for="state in attendanceStates"
								:key="`${player.PlayerId}-${state.key}`"
								type="button"
								class="btn btn-sm"
								:class="player.State === state.key ? state.activeClass : 'btn-outline-secondary'"
								@click="player.State = state.key">
								{{ state.label }}
							</button>
						</div>
					</div>
				</div>
				<div class="attendance-history">
					<div class="attendance-history__header">
						<h3>Presencas guardadas</h3>
						<button
							type="button"
							class="btn btn-sm btn-outline-secondary"
							:disabled="attendanceHistoryLoading"
							@click="loadAttendanceHistory">
							Atualizar
						</button>
					</div>
					<p
						v-if="attendanceHistoryError"
						class="attendance-message attendance-message--error">
						{{ attendanceHistoryError }}
					</p>
					<p
						v-else-if="attendanceHistory.length === 0"
						class="attendance-history__empty">
						Ainda nao existem presencas guardadas.
					</p>
					<div
						v-else
						class="attendance-history__list">
						<button
							v-for="training in attendanceHistory"
							:key="training.Id"
							type="button"
							class="attendance-history__item"
							:class="{ 'attendance-history__item--active': selectedHistoryTrainingId === training.Id }"
							@click="loadSavedAttendance(training.Id)">
							<span>{{ training.Label }}</span>
							<small>
								{{ training.Total }} jogadores - Presentes: {{ training.Present }} - Faltas: {{ training.Missing }}
							</small>
						</button>
					</div>
					<div
						v-if="savedAttendancePlayers.length > 0"
						class="attendance-closed">
						<h4>{{ savedAttendanceTrainingLabel }}</h4>
						<div
							v-for="player in savedAttendancePlayers"
							:key="`saved-${player.PlayerId}`"
							class="attendance-closed__row">
							<div>
								<strong>{{ player.Name }}</strong>
								<span>{{ positionLabel(player.Position) }}</span>
							</div>
							<span
								class="attendance-state-label"
								:class="stateLabelClass(player.State)">
								{{ stateLabel(player.State) }}
							</span>
						</div>
					</div>
				</div>
			</div>
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

	import MenuViewModel from './QMenuSQB_421ViewModel.js'

	const requiredTextResources = ['QMenuSQB_421', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL SQB FORM_INCLUDEJS SQB_MENU_421]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QMenuSqb421',

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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QMenuSQB_421', false),
				attendanceTrainings: [],
				attendanceClubs: [],
				attendanceSelectedTrainingId: '',
				attendanceSelectedClubId: '',
				attendanceTrainingLabel: '',
				attendancePlayers: [],
				attendanceHistory: [],
				attendanceHistoryLoading: false,
				attendanceHistoryError: '',
				selectedHistoryTrainingId: '',
				savedAttendanceTrainingLabel: '',
				savedAttendancePlayers: [],
				attendanceLoading: false,
				attendanceSaving: false,
				attendanceError: '',
				attendanceSuccess: '',

				interfaceMetadata: {
					id: 'QMenuSQB_421', // Used for resources
					requiredTextResources
				},

				menuInfo: {
					id: '421',
					isMenuList: true,
					designation: computed(() => this.Resources.PRESENCAS23345),
					acronym: 'SQB_421',
					name: 'PRESENCA',
					route: 'menu-SQB_421',
					order: '421',
					controller: 'PRESENCA',
					action: 'SQB_Menu_421',
					isPopup: false
				},

				model: new MenuViewModel(this),

				controls: {
					menu: new controlClass.TableListControl({
						fnHydrateViewModel: (data) => vm.model.hydrate(data),
						id: 'SQB_Menu_421',
						controller: 'PRESENCA',
						action: 'SQB_Menu_421',
						hasDependencies: false,
						isInCollapsible: false,
						tableModeClasses: [
							'q-table--full-height',
							'page-full-height'
						],
						columnsOriginal: [
							new listColumnTypes.DateColumn({
								order: 1,
								name: 'Treino.ValData',
								area: 'TREINO',
								field: 'DATA',
								label: computed(() => this.Resources.DATA18071),
								scrollData: 16,
								dateTimeType: 'dateTime',
								export: 1,
								pkColumn: 'ValCodtreino',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 2,
								name: 'Jogador.ValNome',
								area: 'JOGADOR',
								field: 'NOME',
								label: computed(() => this.Resources.NOME47814),
								dataLength: 50,
								scrollData: 30,
								export: 1,
								pkColumn: 'ValCodjogador',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ArrayColumn({
								order: 3,
								name: 'ValEstado',
								area: 'PRESENCA',
								field: 'ESTADO',
								label: computed(() => this.Resources.ESTADO07788),
								dataLength: 2,
								scrollData: 2,
								export: 1,
								array: computed(() => new qProjArrays.QArrayEstado_presenca(vm.$getResource).elements),
								arrayType: qProjArrays.QArrayEstado_presenca.type,
								arrayDisplayMode: 'D',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'SQB_Menu_421',
							serverMode: true,
							pkColumn: 'ValCodpresenca',
							tableAlias: 'PRESENCA',
							tableNamePlural: computed(() => this.Resources.PRESENCAS23345),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.PRESENCAS23345),
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
										formName: 'PRESENCA',
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
										formName: 'PRESENCA',
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
										formName: 'PRESENCA',
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
										formName: 'PRESENCA',
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
										formName: 'PRESENCA',
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
								id: 'RCA_SQB_4211',
								name: 'form-PRESENCA',
								isVisible: true,
								params: {
									isRoute: true,
									limits: [
										{
											identifier: 'id',
											fnValueSelector: (row) => row.ValCodpresenca
										},
									],
									isControlled: true,
									action: vm.openFormAction, type: 'form', mode: 'SHOW', formName: 'PRESENCA'
								}
							},
							formsDefinition: {
								'PRESENCA': {
									fnKeySelector: (row) => row.Fields.ValCodpresenca,
									isPopup: false
								},
							},
							defaultSearchColumnName: '',
							defaultSearchColumnNameOriginal: '',
							defaultColumnSorting: {
								columnName: '',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-PRESENCA', 'changed-TREINO', 'changed-JOGADOR'],
						uuid: '5f5fbc25-85cb-40bf-ac6f-c482b7dfff34',
						allSelectedRows: 'false',
						headerLevel: 1,
						isActiveControl: computed(() => this.isActiveMenu)
					}, this),
				}
			}
		},
		computed: {
			attendanceStates()
			{
				return [
					{ key: 'P', label: 'Presente', activeClass: 'btn-success' },
					{ key: 'F', label: 'Falta', activeClass: 'btn-danger' },
					{ key: 'FJ', label: 'Justificada', activeClass: 'btn-warning' },
					{ key: 'FI', label: 'Injustificada', activeClass: 'btn-danger' },
					{ key: 'A', label: 'Atraso', activeClass: 'btn-info' },
					{ key: 'L', label: 'Lesao', activeClass: 'btn-secondary' },
					{ key: 'O', label: 'Outros', activeClass: 'btn-dark' }
				]
			},

			attendanceSummary()
			{
				return this.attendancePlayers.reduce((summary, player) => {
					const state = player.State || 'P'
					summary[state] = (summary[state] || 0) + 1
					return summary
				}, { P: 0, F: 0, FJ: 0, FI: 0, A: 0, L: 0, O: 0 })
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
			this.loadAttendanceOptions()
			this.loadAttendanceHistory()
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL SQB FORM_CODEJS SQB_MENU_421]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL SQB COMPONENT_BEFORE_UNMOUNT SQB_MENU_421]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
			loadAttendanceOptions()
			{
				netAPI.fetchData('PRESENCA', 'AttendanceOptions', {}, (data) => {
					this.attendanceTrainings = data?.Trainings || []
					this.attendanceClubs = data?.Clubs || []
				}, (error) => {
					this.attendanceError = error?.message || 'Nao foi possivel carregar os treinos.'
				})
			},

			loadAttendanceHistory()
			{
				this.attendanceHistoryLoading = true
				this.attendanceHistoryError = ''

				netAPI.fetchData('PRESENCA', 'AttendanceHistory', {}, (data) => {
					this.attendanceHistory = data?.Trainings || []
					this.attendanceHistoryLoading = false
				}, (error) => {
					this.attendanceHistoryLoading = false
					this.attendanceHistoryError = error?.message || 'Nao foi possivel carregar as presencas guardadas.'
				})
			},

			loadSavedAttendance(trainingId)
			{
				if (!trainingId)
					return

				this.selectedHistoryTrainingId = trainingId
				this.attendanceHistoryError = ''

				netAPI.fetchData('PRESENCA', 'SavedAttendance', { trainingId }, (data) => {
					this.savedAttendanceTrainingLabel = data?.Training?.Label || ''
					this.savedAttendancePlayers = data?.Players || []
				}, (error) => {
					this.savedAttendancePlayers = []
					this.savedAttendanceTrainingLabel = ''
					this.attendanceHistoryError = error?.message || 'Nao foi possivel consultar as presencas guardadas.'
				})
			},

			loadSquadAttendance()
			{
				if (!this.attendanceSelectedTrainingId)
				{
					this.attendanceError = 'Escolhe primeiro um treino.'
					return
				}

				this.attendanceLoading = true
				this.attendanceError = ''
				this.attendanceSuccess = ''

				netAPI.fetchData('PRESENCA', 'SquadAttendance', {
					trainingId: this.attendanceSelectedTrainingId,
					clubId: this.attendanceSelectedClubId
				}, (data) => {
					this.attendanceTrainingLabel = data?.Training?.Label || ''
					this.attendancePlayers = (data?.Players || []).map((player) => ({
						...player,
						State: player.State || 'P'
					}))
					this.attendanceLoading = false
					if (this.attendancePlayers.length === 0)
						this.attendanceError = 'Nao existem jogadores para estes filtros.'
				}, (error) => {
					this.attendanceLoading = false
					this.attendanceError = error?.message || 'Nao foi possivel carregar o plantel.'
				})
			},

			saveSquadAttendance()
			{
				if (!this.attendanceSelectedTrainingId || this.attendancePlayers.length === 0)
				{
					this.attendanceError = 'Carrega primeiro um plantel para este treino.'
					return
				}

				this.attendanceSaving = true
				this.attendanceError = ''
				this.attendanceSuccess = ''

				netAPI.postData('PRESENCA', 'SaveSquadAttendance', {
					TrainingId: this.attendanceSelectedTrainingId,
					Players: this.attendancePlayers.map((player) => ({
						PlayerId: player.PlayerId,
						State: player.State || 'P'
					}))
				}, (data) => {
					this.attendanceSaving = false
					this.attendancePlayers = this.attendancePlayers.map((player) => ({ ...player, Exists: true }))
					this.attendanceSuccess = `Presencas guardadas: ${data?.Created || 0} novas, ${data?.Updated || 0} atualizadas.`
					this.loadAttendanceHistory()
					this.loadSavedAttendance(this.attendanceSelectedTrainingId)
					this.controls.menu?.reload?.()
				}, (error) => {
					this.attendanceSaving = false
					this.attendanceError = error?.message || 'Nao foi possivel guardar as presencas.'
				})
			},

			stateLabel(state)
			{
				const current = this.attendanceStates.find((item) => item.key === state)
				return current?.label || 'Presente'
			},

			stateLabelClass(state)
			{
				return `attendance-state-label--${state || 'P'}`
			},

			positionLabel(position)
			{
				const labels = {
					GR: 'Guarda-Redes',
					DEF: 'Defesa',
					MD: 'Medio',
					AT: 'Avancado'
				}
				return labels[position] || position || 'Sem posicao'
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL SQB FUNCTIONS_JS SQB_421]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL SQB LISTING_CODEJS SQB_MENU_421]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		}
	}
</script>
<style scoped>
	.attendance-panel {
		margin: 0 0 1rem;
		width: 100%;
		box-sizing: border-box;
		padding: 1rem;
		border: 1px solid #d4dde5;
		background: #f8fafc;
	}

	.attendance-panel h3 {
		margin: 0 0 .75rem;
		font-size: 1.1rem;
		font-weight: 700;
	}

	.attendance-toolbar {
		display: grid;
		grid-template-columns: minmax(14rem, 1fr) minmax(12rem, .7fr) auto auto;
		gap: .5rem;
		align-items: center;
	}

	.attendance-message {
		margin: .75rem 0 0;
	}

	.attendance-message--error {
		color: #dc3545;
	}

	.attendance-message--success {
		color: #198754;
	}

	.attendance-summary {
		display: flex;
		flex-wrap: wrap;
		gap: .5rem 1rem;
		margin-top: .85rem;
		color: #526170;
	}

	.attendance-grid {
		display: grid;
		grid-template-columns: repeat(auto-fill, minmax(18rem, 1fr));
		gap: .75rem;
		margin-top: .85rem;
	}

	.attendance-card {
		border: 1px solid #ccd6df;
		background: #fff;
		padding: .85rem;
	}

	.attendance-card__top {
		display: flex;
		justify-content: space-between;
		gap: .75rem;
		margin-bottom: .75rem;
	}

	.attendance-card h4 {
		margin: 0 0 .2rem;
		font-size: 1rem;
		color: #00834b;
	}

	.attendance-card p {
		margin: 0;
		color: #526170;
	}

	.attendance-card__number {
		min-width: 2.25rem;
		height: 2.25rem;
		border-radius: 50%;
		display: inline-flex;
		align-items: center;
		justify-content: center;
		background: #eef4f0;
		color: #00834b;
		font-weight: 700;
	}

	.attendance-state-buttons {
		display: flex;
		flex-wrap: wrap;
		gap: .35rem;
	}

	.attendance-history {
		margin-top: 1rem;
		padding-top: 1rem;
		border-top: 1px solid #d4dde5;
	}

	.attendance-history__header {
		display: flex;
		align-items: center;
		justify-content: space-between;
		gap: .75rem;
		margin-bottom: .75rem;
	}

	.attendance-history__header h3 {
		margin: 0;
		font-size: 1.05rem;
	}

	.attendance-history__empty {
		margin: 0;
		color: #526170;
	}

	.attendance-history__list {
		display: grid;
		grid-template-columns: repeat(auto-fill, minmax(16rem, 1fr));
		gap: .5rem;
	}

	.attendance-history__item {
		display: flex;
		flex-direction: column;
		align-items: flex-start;
		gap: .2rem;
		padding: .65rem .75rem;
		border: 1px solid #ccd6df;
		background: #fff;
		color: #1f2933;
		text-align: left;
	}

	.attendance-history__item--active {
		border-color: #00834b;
		box-shadow: inset 3px 0 0 #00834b;
	}

	.attendance-history__item small {
		color: #526170;
	}

	.attendance-closed {
		margin-top: 1rem;
		border: 1px solid #ccd6df;
		background: #fff;
	}

	.attendance-closed h4 {
		margin: 0;
		padding: .75rem;
		border-bottom: 1px solid #e2e8ef;
		font-size: 1rem;
	}

	.attendance-closed__row {
		display: flex;
		align-items: center;
		justify-content: space-between;
		gap: 1rem;
		padding: .65rem .75rem;
		border-bottom: 1px solid #edf2f7;
	}

	.attendance-closed__row:last-child {
		border-bottom: 0;
	}

	.attendance-closed__row div {
		display: flex;
		flex-direction: column;
		gap: .1rem;
	}

	.attendance-closed__row span {
		color: #526170;
	}

	.attendance-state-label {
		min-width: 6.5rem;
		padding: .25rem .5rem;
		border-radius: 4px;
		text-align: center;
		font-weight: 700;
	}

	.attendance-state-label--P {
		background: #e7f5ee;
		color: #087a42;
	}

	.attendance-state-label--F,
	.attendance-state-label--FI {
		background: #fdecec;
		color: #b42318;
	}

	.attendance-state-label--FJ,
	.attendance-state-label--A {
		background: #fff4db;
		color: #946200;
	}

	.attendance-state-label--L,
	.attendance-state-label--O {
		background: #eef2f6;
		color: #465564;
	}
	@media (max-width: 900px) {
		.attendance-toolbar {
			grid-template-columns: 1fr;
		}
	}
</style>