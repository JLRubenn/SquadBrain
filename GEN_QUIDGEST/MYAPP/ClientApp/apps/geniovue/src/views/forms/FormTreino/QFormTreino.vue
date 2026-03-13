<template>
	<teleport
		v-if="formModalIsReady && showFormHeader"
		:to="`#${uiContainersId.header}`"
		:disabled="!isPopup || isNested">
		<div
			ref="formHeader"
			:class="{ 'c-sticky-header': isStickyHeader, 'sticky-top': isStickyTop }">
			<div
				v-if="showFormHeader"
				class="c-action-bar">
				<h1
					v-if="formControl.uiComponents.header && formInfo.designation"
					:id="formTitleId"
					class="form-header">
					{{ formInfo.designation }}
				</h1>

				<div class="c-action-bar__menu">
					<template
						v-for="(section, sectionId) in formButtonSections"
						:key="sectionId">
						<span
							v-if="showHeadingSep(sectionId)"
							class="main-title-sep" />

						<q-toggle-group
							v-if="formControl.uiComponents.headerButtons"
							borderless>
							<template
								v-for="btn in section"
								:key="btn.id">
								<q-toggle-group-item
									v-if="showFormHeaderButton(btn)"
									:model-value="btn.isSelected"
									:id="`top-${btn.id}`"
									:title="btn.text"
									:label="btn.label"
									:disabled="btn.disabled"
									@click="btn.action">
									<template v-if="btn.icon">
										<q-badge-indicator
											:enabled="btn.badge?.isVisible ?? false"
											:color="btn.badge?.color">
											<q-icon v-bind="btn.icon" />
										</q-badge-indicator>
									</template>
								</q-toggle-group-item>
							</template>
						</q-toggle-group>
					</template>
				</div>
			</div>

			<q-anchor-container-horizontal
				v-if="$app.layout.FormAnchorsPosition === 'form-header' && visibleGroups.length > 0"
				:anchors="anchorGroups"
				:controls="visibleControls"
				@focus-control="focusControl" />
		</div>
	</teleport>

	<teleport
		v-if="formModalIsReady && showFormBody"
		:to="`#${uiContainersId.body}`"
		:disabled="!isPopup || isNested">
		<q-validation-summary
			:messages="validationErrors"
			@error-clicked="focusField" />

		<div :class="[`float-${actionsPlacement}`, 'c-action-bar']">
			<q-button-group borderless>
				<template
					v-for="btn in formButtons"
					:key="btn.id">
					<q-button
						v-if="btn.isActive && btn.isVisible && btn.showInHeading"
						:id="`heading-${btn.id}`"
						:label="btn.text"
						:color="btn.color"
						:variant="btn.variant"
						:disabled="btn.disabled"
						:icon-pos="btn.iconPos"
						:class="btn.classes"
						@click="btn.action(); btn.emitAction ? $emit(btn.emitAction.name, btn.emitAction.params) : null">
						<q-icon
							v-if="btn.icon"
							v-bind="btn.icon" />
					</q-button>
				</template>
			</q-button-group>
		</div>

		<q-container
			fluid
			data-key="TREINO"
			:data-loading="!formInitialDataLoaded || !isActiveForm">
			<template v-if="formControl.initialized && showFormBody">
				<q-row v-if="controls.TREINO__PSEUDNEWGRP01.isVisible">
					<q-col v-if="controls.TREINO__PSEUDNEWGRP01.isVisible">
						<q-group-box-container
							v-if="controls.TREINO__PSEUDNEWGRP01.isVisible"
							id="TREINO__PSEUDNEWGRP01"
							v-bind="controls.TREINO__PSEUDNEWGRP01"
							:is-visible="controls.TREINO__PSEUDNEWGRP01.isVisible">
							<!-- Start TREINO__PSEUDNEWGRP01 -->
							<q-row v-if="controls.TREINO__TREINO__NUMTREINO.isVisible || controls.TREINO__TREINO__NUMJOGADORES.isVisible || controls.TREINO__TREINO__MICROCICLO.isVisible || controls.TREINO__TREINO__MESOCICLOS.isVisible || controls.TREINO__TREINO__DATA.isVisible || controls.TREINO__TREINADOR__NOME.isVisible">
								<q-col
									v-if="controls.TREINO__TREINO__NUMTREINO.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.TREINO__TREINO__NUMTREINO.isVisible"
										class="i-text"
										v-bind="controls.TREINO__TREINO__NUMTREINO"
										v-on="controls.TREINO__TREINO__NUMTREINO.handlers"
										:loading="controls.TREINO__TREINO__NUMTREINO.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.TREINO__TREINO__NUMTREINO.isVisible"
											v-bind="controls.TREINO__TREINO__NUMTREINO.props"
											@update:model-value="model.ValNumtreino.fnUpdateValue" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.TREINO__TREINO__NUMJOGADORES.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.TREINO__TREINO__NUMJOGADORES.isVisible"
										class="i-text"
										v-bind="controls.TREINO__TREINO__NUMJOGADORES"
										v-on="controls.TREINO__TREINO__NUMJOGADORES.handlers"
										:loading="controls.TREINO__TREINO__NUMJOGADORES.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.TREINO__TREINO__NUMJOGADORES.isVisible"
											v-bind="controls.TREINO__TREINO__NUMJOGADORES.props"
											@update:model-value="model.ValNumjogadores.fnUpdateValue" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.TREINO__TREINO__MICROCICLO.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.TREINO__TREINO__MICROCICLO.isVisible"
										class="i-text"
										v-bind="controls.TREINO__TREINO__MICROCICLO"
										v-on="controls.TREINO__TREINO__MICROCICLO.handlers"
										:loading="controls.TREINO__TREINO__MICROCICLO.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.TREINO__TREINO__MICROCICLO.isVisible"
											v-bind="controls.TREINO__TREINO__MICROCICLO.props"
											@update:model-value="model.ValMicrociclo.fnUpdateValue" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.TREINO__TREINO__MESOCICLOS.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.TREINO__TREINO__MESOCICLOS.isVisible"
										class="i-text"
										v-bind="controls.TREINO__TREINO__MESOCICLOS"
										v-on="controls.TREINO__TREINO__MESOCICLOS.handlers"
										:loading="controls.TREINO__TREINO__MESOCICLOS.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.TREINO__TREINO__MESOCICLOS.isVisible"
											v-bind="controls.TREINO__TREINO__MESOCICLOS.props"
											@update:model-value="model.ValMesociclos.fnUpdateValue" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.TREINO__TREINO__DATA.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.TREINO__TREINO__DATA.isVisible"
										class="i-text"
										v-bind="controls.TREINO__TREINO__DATA"
										v-on="controls.TREINO__TREINO__DATA.handlers"
										:loading="controls.TREINO__TREINO__DATA.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.TREINO__TREINO__DATA.isVisible"
											v-bind="controls.TREINO__TREINO__DATA.props"
											:model-value="model.ValData.value"
											@reset-icon-click="model.ValData.fnUpdateValue(model.ValData.originalValue ?? new Date())"
											@update:model-value="model.ValData.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.TREINO__TREINADOR__NOME.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.TREINO__TREINADOR__NOME.isVisible"
										class="i-text"
										v-bind="controls.TREINO__TREINADOR__NOME"
										v-on="controls.TREINO__TREINADOR__NOME.handlers"
										:loading="controls.TREINO__TREINADOR__NOME.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.TREINO__TREINADOR__NOME.isVisible"
											v-bind="controls.TREINO__TREINADOR__NOME.props"
											v-on="controls.TREINO__TREINADOR__NOME.handlers" />
										<q-see-more-treino-treinador-nome
											v-if="controls.TREINO__TREINADOR__NOME.seeMoreIsVisible"
											v-bind="controls.TREINO__TREINADOR__NOME.seeMoreParams"
											v-on="controls.TREINO__TREINADOR__NOME.handlers" />
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End TREINO__PSEUDNEWGRP01 -->
						</q-group-box-container>
					</q-col>
				</q-row>
				<q-row v-if="controls.TREINO__PSEUDNEWGRP02.isVisible">
					<q-col v-if="controls.TREINO__PSEUDNEWGRP02.isVisible">
						<q-group-box-container
							v-if="controls.TREINO__PSEUDNEWGRP02.isVisible"
							id="TREINO__PSEUDNEWGRP02"
							v-bind="controls.TREINO__PSEUDNEWGRP02"
							:is-visible="controls.TREINO__PSEUDNEWGRP02.isVisible">
							<!-- Start TREINO__PSEUDNEWGRP02 -->
							<q-row v-if="controls.TREINO__TREINO__OBJETIVO.isVisible || controls.TREINO__TREINO__MATERIAL.isVisible">
								<q-col
									v-if="controls.TREINO__TREINO__OBJETIVO.isVisible || controls.TREINO__TREINO__MATERIAL.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.TREINO__TREINO__OBJETIVO.isVisible"
										class="i-textarea"
										v-bind="controls.TREINO__TREINO__OBJETIVO"
										v-on="controls.TREINO__TREINO__OBJETIVO.handlers"
										:loading="controls.TREINO__TREINO__OBJETIVO.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-area
											v-if="controls.TREINO__TREINO__OBJETIVO.isVisible"
											v-bind="controls.TREINO__TREINO__OBJETIVO.props"
											v-on="controls.TREINO__TREINO__OBJETIVO.handlers" />
									</base-input-structure>
									<base-input-structure
										v-if="controls.TREINO__TREINO__MATERIAL.isVisible"
										class="i-textarea"
										v-bind="controls.TREINO__TREINO__MATERIAL"
										v-on="controls.TREINO__TREINO__MATERIAL.handlers"
										:loading="controls.TREINO__TREINO__MATERIAL.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-area
											v-if="controls.TREINO__TREINO__MATERIAL.isVisible"
											v-bind="controls.TREINO__TREINO__MATERIAL.props"
											v-on="controls.TREINO__TREINO__MATERIAL.handlers" />
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End TREINO__PSEUDNEWGRP02 -->
						</q-group-box-container>
					</q-col>
				</q-row>
				<q-row v-if="controls.TREINO__PSEUD__EXERCICIO.isVisible">
					<q-col v-if="controls.TREINO__PSEUD__EXERCICIO.isVisible">
						<q-table
							v-if="controls.TREINO__PSEUD__EXERCICIO.isVisible"
							v-bind="controls.TREINO__PSEUD__EXERCICIO"
							v-on="controls.TREINO__PSEUD__EXERCICIO.handlers">
							<template #header>
								<q-table-config
									:table-ctrl="controls.TREINO__PSEUD__EXERCICIO"
									v-on="controls.TREINO__PSEUD__EXERCICIO.handlers" />
							</template>
							<!-- USE /[MANUAL SQB CUSTOM_TABLE TREINO__PSEUD__EXERCICIO]/ -->
						</q-table>
					</q-col>
				</q-row>
			</template>
		</q-container>
	</teleport>

	<q-divider v-if="!isPopup && showFormFooter" />

	<teleport
		v-if="formModalIsReady && showFormFooter"
		:to="`#${uiContainersId.footer}`"
		:disabled="!isPopup || isNested">
		<q-row v-if="showFormFooter">
			<div id="footer-action-btns">
				<template
					v-for="btn in formButtons"
					:key="btn.id">
					<q-button
						v-if="btn.isActive && btn.isVisible && btn.showInFooter"
						:id="`bottom-${btn.id}`"
						:label="btn.text"
						:color="btn.color"
						:variant="btn.variant"
						:disabled="btn.disabled"
						:icon-pos="btn.iconPos"
						:class="btn.classes"
						@click="btn.action(); btn.emitAction ? $emit(btn.emitAction.name, btn.emitAction.params) : null">
						<q-icon
							v-if="btn.icon"
							v-bind="btn.icon" />
					</q-button>
				</template>
			</div>
		</q-row>
	</teleport>
</template>

<script>
	/* eslint-disable @typescript-eslint/no-unused-vars */
	import { computed, defineAsyncComponent, readonly } from 'vue'
	import { useRoute } from 'vue-router'

	import FormHandlers from '@/mixins/formHandlers.js'
	import formFunctions from '@/mixins/formFunctions.js'
	import genericFunctions from '@quidgest/clientapp/utils/genericFunctions'
	import listFunctions from '@/mixins/listFunctions.js'
	import listColumnTypes from '@/mixins/listColumnTypes.js'
	import modelFieldType from '@quidgest/clientapp/models/fields'
	import fieldControlClass from '@/mixins/fieldControl.js'
	import qEnums from '@quidgest/clientapp/constants/enums'
	import { resetProgressBar, setProgressBar } from '@/utils/layout.js'

	import hardcodedTexts from '@/hardcodedTexts.js'
	import netAPI from '@quidgest/clientapp/network'
	import asyncProcM from '@quidgest/clientapp/composables/async'
	import qApi from '@/api/genio/quidgestFunctions.js'
	import qFunctions from '@/api/genio/projectFunctions.js'
	import qProjArrays from '@/api/genio/projectArrays.js'
	/* eslint-enable @typescript-eslint/no-unused-vars */

	import FormViewModel from './QFormTreinoViewModel.js'

	const requiredTextResources = ['QFormTreino', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL SQB FORM_INCLUDEJS TREINO]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormTreino',

		components: {
			QSeeMoreTreinoTreinadorNome: defineAsyncComponent(() => import('@/views/forms/FormTreino/dbedits/TreinoTreinadorNomeSeeMore.vue')),
		},

		mixins: [
			FormHandlers
		],

		props: {
			/**
			 * Parameters passed in case the form is nested.
			 */
			nestedRouteParams: {
				type: Object,
				default: () => ({
					name: 'TREINO',
					location: 'form-TREINO',
					params: {
						isNested: true
					}
				})
			}
		},

		expose: [
			'cancel',
			'initFormProperties',
			'navigationId'
		],

		setup(props)
		{
			const route = useRoute()

			return {
				/*
				 * As properties are reactive, when using $route.params, then when we exit it updates cached components.
				 * Properties have no value and this creates an error in new versions of vue-router.
				 * That's why the value has to be copied to a local property to be used in the router-link tag.
				 */
				currentRouteParams: props.isNested ? {} : route.params
			}
		},

		data()
		{
			// eslint-disable-next-line
			const vm = this
			return {
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormTreino', false),

				interfaceMetadata: {
					id: 'QFormTreino', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'TREINO',
					route: 'form-TREINO',
					area: 'TREINO',
					primaryKey: 'ValCodtreino',
					designation: computed(() => this.Resources.PLANO_DE_TREINO27299),
					identifier: '', // Unique identifier received by route (when it's nested).
					mode: '',
					availableAgents: [],
				},

				formButtons: {
					changeToShow: {
						id: 'change-to-show-btn',
						icon: {
							icon: 'view',
							type: 'svg'
						},
						type: 'form-mode',
						text: computed(() => vm.Resources[hardcodedTexts.view]),
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.show === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && [vm.formModes.show, vm.formModes.edit, vm.formModes.delete].includes(vm.formInfo.mode)),
						action: vm.changeToShowMode
					},
					changeToEdit: {
						id: 'change-to-edit-btn',
						icon: {
							icon: 'pencil',
							type: 'svg'
						},
						type: 'form-mode',
						text: computed(() => vm.Resources[hardcodedTexts.edit]),
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.edit === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && [vm.formModes.show, vm.formModes.edit, vm.formModes.delete].includes(vm.formInfo.mode)),
						action: vm.changeToEditMode
					},
					changeToDuplicate: {
						id: 'change-to-dup-btn',
						icon: {
							icon: 'duplicate',
							type: 'svg'
						},
						type: 'form-mode',
						text: computed(() => vm.Resources[hardcodedTexts.duplicate]),
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.duplicate === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && vm.formModes.new !== vm.formInfo.mode),
						action: vm.changeToDupMode
					},
					changeToDelete: {
						id: 'change-to-delete-btn',
						icon: {
							icon: 'delete',
							type: 'svg'
						},
						type: 'form-mode',
						text: computed(() => vm.Resources[hardcodedTexts.delete]),
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.delete === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && [vm.formModes.show, vm.formModes.edit, vm.formModes.delete].includes(vm.formInfo.mode)),
						action: vm.changeToDeleteMode
					},
					changeToInsert: {
						id: 'change-to-insert-btn',
						icon: {
							icon: 'add',
							type: 'svg'
						},
						type: 'form-insert',
						text: computed(() => vm.Resources[hardcodedTexts.insert]),
						label: computed(() => vm.Resources[hardcodedTexts.insert]),
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isSelected: computed(() => vm.formModes.new === vm.formInfo.mode),
						isVisible: computed(() => vm.authData.isAllowed && vm.formModes.duplicate !== vm.formInfo.mode),
						action: vm.changeToInsertMode
					},
					repeatInsertBtn: {
						id: 'repeat-insert-btn',
						icon: {
							icon: 'save-new',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[hardcodedTexts.repeatInsert]),
						variant: 'bold',
						showInHeader: true,
						showInFooter: true,
						isActive: false,
						isVisible: computed(() => vm.authData.isAllowed && vm.formInfo.mode === vm.formModes.new),
						action: () => vm.saveForm(true)
					},
					saveBtn: {
						id: 'save-btn',
						icon: {
							icon: 'save',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources.GRAVAR45301),
						variant: 'bold',
						showInHeader: true,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => vm.authData.isAllowed && vm.isEditable),
						action: vm.saveForm,
						badge: {
							isVisible: computed(() => vm.model?.isDirty === true),
							color: 'highlight'
						}
					},
					confirmBtn: {
						id: 'confirm-btn',
						icon: {
							icon: 'check',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[vm.isNested ? hardcodedTexts.delete : hardcodedTexts.confirm]),
						variant: 'bold',
						showInHeader: true,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => vm.authData.isAllowed && (vm.formInfo.mode === vm.formModes.delete || vm.isNested)),
						action: vm.deleteRecord
					},
					cancelBtn: {
						id: 'cancel-btn',
						icon: {
							icon: 'cancel',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources.CANCELAR49513),
						showInHeader: true,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => vm.authData.isAllowed && vm.isEditable),
						action: vm.leaveForm
					},
					resetCancelBtn: {
						id: 'reset-cancel-btn',
						icon: {
							icon: 'cancel',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[hardcodedTexts.cancel]),
						showInHeader: true,
						showInFooter: true,
						isActive: false,
						isVisible: computed(() => vm.authData.isAllowed && vm.isEditable),
						action: () => vm.model.resetValues(),
						emitAction: {
							name: 'deselect',
							params: {}
						}
					},
					editBtn: {
						id: 'edit-btn',
						icon: {
							icon: 'pencil',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[hardcodedTexts.edit]),
						variant: 'bold',
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isVisible: computed(() => vm.authData.isAllowed && vm.parentFormMode !== vm.formModes.show && vm.parentFormMode !== vm.formModes.delete),
						action: () => {},
						emitAction: {
							name: 'edit',
							params: {}
						}
					},
					deleteQuickBtn: {
						id: 'delete-btn',
						icon: {
							icon: 'bin',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.Resources[hardcodedTexts.delete]),
						variant: 'bold',
						showInHeader: true,
						showInFooter: false,
						isActive: false,
						isVisible: computed(() => vm.authData.isAllowed && vm.parentFormMode !== vm.formModes.show && (typeof vm.permissions.canDelete === 'boolean' ? vm.permissions.canDelete : true)),
						action: vm.deleteRecord
					},
					backBtn: {
						id: 'back-btn',
						icon: {
							icon: 'back',
							type: 'svg'
						},
						type: 'form-action',
						text: computed(() => vm.isPopup ? vm.Resources[hardcodedTexts.close] : vm.Resources[hardcodedTexts.goBack]),
						showInHeader: true,
						showInFooter: true,
						isActive: true,
						isVisible: computed(() => !vm.authData.isAllowed || !vm.isEditable),
						action: vm.leaveForm
					}
				},

				controls: {
					TREINO__PSEUDNEWGRP01: new fieldControlClass.GroupControl({
						id: 'TREINO__PSEUDNEWGRP01',
						name: 'NEWGRP01',
						size: 'block',
						label: computed(() => this.Resources.DADOS_DO_TREINO62459),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['TREINO__TREINO__NUMTREINO', 'TREINO__TREINO__NUMJOGADORES', 'TREINO__TREINO__MICROCICLO', 'TREINO__TREINO__MESOCICLOS', 'TREINO__TREINO__DATA', 'TREINO__TREINADOR__NOME'],
						controlLimits: [
						],
					}, this),
					TREINO__TREINO__NUMTREINO: new fieldControlClass.NumberControl({
						modelField: 'ValNumtreino',
						valueChangeEvent: 'fieldChange:treino.numtreino',
						id: 'TREINO__TREINO__NUMTREINO',
						name: 'NUMTREINO',
						size: 'small',
						label: computed(() => this.Resources.TREINO_NO29135),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'TREINO__PSEUDNEWGRP01',
						maxIntegers: 3,
						maxDecimals: 0,
						isSequencial: true,
						controlLimits: [
						],
					}, this),
					TREINO__TREINO__NUMJOGADORES: new fieldControlClass.NumberControl({
						modelField: 'ValNumjogadores',
						valueChangeEvent: 'fieldChange:treino.numjogadores',
						id: 'TREINO__TREINO__NUMJOGADORES',
						name: 'NUMJOGADORES',
						size: 'small',
						label: computed(() => this.Resources.NUMERO_JOGADORES22289),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'TREINO__PSEUDNEWGRP01',
						maxIntegers: 3,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					TREINO__TREINO__MICROCICLO: new fieldControlClass.NumberControl({
						modelField: 'ValMicrociclo',
						valueChangeEvent: 'fieldChange:treino.microciclo',
						id: 'TREINO__TREINO__MICROCICLO',
						name: 'MICROCICLO',
						size: 'small',
						label: computed(() => this.Resources.MICROCICLO36882),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'TREINO__PSEUDNEWGRP01',
						maxIntegers: 3,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					TREINO__TREINO__MESOCICLOS: new fieldControlClass.NumberControl({
						modelField: 'ValMesociclos',
						valueChangeEvent: 'fieldChange:treino.mesociclos',
						id: 'TREINO__TREINO__MESOCICLOS',
						name: 'MESOCICLOS',
						size: 'small',
						label: computed(() => this.Resources.MESOCICLOS42559),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'TREINO__PSEUDNEWGRP01',
						maxIntegers: 3,
						maxDecimals: 0,
						controlLimits: [
						],
					}, this),
					TREINO__TREINO__DATA: new fieldControlClass.DateControl({
						modelField: 'ValData',
						valueChangeEvent: 'fieldChange:treino.data',
						id: 'TREINO__TREINO__DATA',
						name: 'DATA',
						size: 'small',
						label: computed(() => this.Resources.DATA18071),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'TREINO__PSEUDNEWGRP01',
						dateTimeType: 'dateTime',
						controlLimits: [
						],
					}, this),
					TREINO__TREINADOR__NOME: new fieldControlClass.LookupControl({
						modelField: 'TableTreinadorNome',
						valueChangeEvent: 'fieldChange:treinador.nome',
						id: 'TREINO__TREINADOR__NOME',
						name: 'NOME',
						size: 'medium',
						label: computed(() => this.Resources.FEITO_POR___22778),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'TREINO__PSEUDNEWGRP01',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValCodtreinador',
							dependencyEvent: 'fieldChange:treino.codtreinador'
						},
						dependentFields: () => ({
							set 'treinador.codtreinador'(value) { vm.model.ValCodtreinador.updateValue(value) },
							set 'treinador.nome'(value) { vm.model.TableTreinadorNome.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					TREINO__PSEUDNEWGRP02: new fieldControlClass.GroupControl({
						id: 'TREINO__PSEUDNEWGRP02',
						name: 'NEWGRP02',
						size: 'block',
						label: computed(() => this.Resources.DETALHES_DO_TREINO06280),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['TREINO__TREINO__OBJETIVO', 'TREINO__TREINO__MATERIAL'],
						controlLimits: [
						],
					}, this),
					TREINO__TREINO__OBJETIVO: new fieldControlClass.MultilineStringControl({
						modelField: 'ValObjetivo',
						valueChangeEvent: 'fieldChange:treino.objetivo',
						id: 'TREINO__TREINO__OBJETIVO',
						name: 'OBJETIVO',
						size: 'xxlarge',
						label: computed(() => this.Resources.OBJETIVO56787),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'TREINO__PSEUDNEWGRP02',
						rows: 0,
						cols: 50,
						controlLimits: [
						],
					}, this),
					TREINO__TREINO__MATERIAL: new fieldControlClass.MultilineStringControl({
						modelField: 'ValMaterial',
						valueChangeEvent: 'fieldChange:treino.material',
						id: 'TREINO__TREINO__MATERIAL',
						name: 'MATERIAL',
						size: 'xxlarge',
						label: computed(() => this.Resources.MATERIAL33877),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'TREINO__PSEUDNEWGRP02',
						rows: 0,
						cols: 50,
						controlLimits: [
						],
					}, this),
					TREINO__PSEUD__EXERCICIO: new fieldControlClass.TableSpecialRenderingControl({
						id: 'TREINO__PSEUD__EXERCICIO',
						name: 'EXERCICIO',
						size: 'block',
						label: computed(() => this.Resources.EXERCICIOS14912),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						controller: 'TREINO',
						action: 'Treino_ValExercicio',
						hasDependencies: false,
						isInCollapsible: false,
						columnsOriginal: [
							new listColumnTypes.TextColumn({
								order: 1,
								name: 'ValTitulo',
								area: 'EXERCICIO',
								field: 'TITULO',
								label: computed(() => this.Resources.TITULO23260),
								dataLength: 50,
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.ImageColumn({
								order: 2,
								name: 'ValFoto',
								area: 'EXERCICIO',
								field: 'FOTO',
								label: computed(() => this.Resources.FOTO19492),
								dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR58591, vm.Resources.FOTO19492)),
								scrollData: 3,
								isVisible: false,
								sortable: false,
								searchable: false,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 3,
								name: 'ValDescricao',
								area: 'EXERCICIO',
								field: 'DESCRICAO',
								label: computed(() => this.Resources.DESCRICAO07528),
								scrollData: 30,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 4,
								name: 'ValObjetivo',
								area: 'EXERCICIO',
								field: 'OBJETIVO',
								label: computed(() => this.Resources.OBJETIVO56787),
								scrollData: 30,
								isVisible: false,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 5,
								name: 'ValTempo',
								area: 'EXERCICIO',
								field: 'TEMPO',
								label: computed(() => this.Resources.TEMPO__M_37967),
								scrollData: 3,
								maxDigits: 3,
								decimalPlaces: 0,
								isVisible: false,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.NumericColumn({
								order: 6,
								name: 'ValNumjogador',
								area: 'EXERCICIO',
								field: 'NUMJOGADOR',
								label: computed(() => this.Resources.NUMERO_DE_JOGADOES35633),
								scrollData: 3,
								maxDigits: 3,
								decimalPlaces: 0,
								isVisible: false,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.TextColumn({
								order: 7,
								name: 'ValEspaco',
								area: 'EXERCICIO',
								field: 'ESPACO',
								label: computed(() => this.Resources.ESPACO13353),
								dataLength: 50,
								scrollData: 30,
								isVisible: false,
								export: 1,
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
							new listColumnTypes.DateColumn({
								order: 8,
								name: 'Treino.ValData',
								area: 'TREINO',
								field: 'DATA',
								label: computed(() => this.Resources.DATA18071),
								scrollData: 16,
								dateTimeType: 'dateTime',
								isVisible: false,
								export: 1,
								pkColumn: 'ValCodtreino',
							}, computed(() => vm.model), computed(() => vm.internalEvents)),
						],
						config: {
							name: 'ValExercicio',
							serverMode: true,
							pkColumn: 'ValCodexercicio',
							tableAlias: 'EXERCICIO',
							tableNamePlural: computed(() => this.Resources.EXERCICIOS14912),
							viewManagement: '',
							showLimitsInfo: true,
							tableTitle: computed(() => this.Resources.EXERCICIOS14912),
							showAlternatePagination: true,
							permissions: {
							},
							searchBarConfig: {
								visibility: false
							},
							allowColumnFilters: false,
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
										formName: 'EXERCICIO',
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
									isInReadOnly: false,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'EXERCICIO',
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
									isInReadOnly: false,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'EXERCICIO',
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
									isInReadOnly: false,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'EXERCICIO',
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
									isInReadOnly: false,
									params: {
										action: vm.openFormAction,
										type: 'form',
										formName: 'EXERCICIO',
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
								id: 'RCA__EXERCICIO',
								name: '_EXERCICIO',
								title: '',
								isInReadOnly: true,
								params: {
									isRoute: true,
									action: vm.openFormAction,
									type: 'form',
									formName: 'EXERCICIO',
									mode: 'SHOW',
									isControlled: true
								}
							},
							formsDefinition: {
								'EXERCICIO': {
									fnKeySelector: (row) => row.Fields.ValCodexercicio,
									isPopup: true
								},
							},
							defaultSearchColumnName: 'Treino.ValData',
							defaultSearchColumnNameOriginal: 'Treino.ValData',
							defaultColumnSorting: {
								columnName: '',
								sortOrder: 'asc'
							}
						},
						globalEvents: ['changed-EXERCICIO', 'changed-TREINO'],
						uuid: 'Treino_ValExercicio',
						allSelectedRows: 'false',
						viewModes: [
							{
								id: 'CARDS',
								type: 'cards',
								subtype: 'card',
								label: computed(() => this.Resources.CARTOES27587),
								order: 1,
								mappingVariables: readonly({
									title: {
										allowsMultiple: false,
										sources: [
											'EXERCICIO.TITULO',
										]
									},
									text: {
										allowsMultiple: true,
										sources: [
											'EXERCICIO.TEMPO',
											'EXERCICIO.NUMJOGADOR',
											'EXERCICIO.ESPACO',
											'EXERCICIO.DESCRICAO',
											'EXERCICIO.OBJETIVO',
										]
									},
									image: {
										allowsMultiple: false,
										sources: [
											'EXERCICIO.FOTO',
										]
									},
								}),
								styleVariables: {
									actionsAlignment: {
										rawValue: 'left',
										isMapped: false
									},
									actionsPlacement: {
										rawValue: 'footer',
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
									contentAlignment: {
										rawValue: 'left',
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
									imageShape: {
										rawValue: 'rectangular',
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
						controlLimits: [
							{
								identifier: ['id', 'treino'],
								dependencyEvents: ['fieldChange:treino.codtreino'],
								dependencyField: 'TREINO.CODTREINO',
								fnValueSelector: (model) => model.ValCodtreino.value
							},
						],
					}, this),
				},

				model: new FormViewModel(this, {
					callbacks: {
						onUpdate: this.onUpdate,
						setFormKey: this.setFormKey
					}
				}),

				groupFields: readonly([
					'TREINO__PSEUDNEWGRP01',
					'TREINO__PSEUDNEWGRP02',
				]),

				tableFields: readonly([
					'TREINO__PSEUD__EXERCICIO',
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Treinador: {
						get ValNome() { return vm.model.TableTreinadorNome.value },
						set ValNome(value) { vm.model.TableTreinadorNome.updateValue(value) },
					},
					Treino: {
						get ValCodclube() { return vm.model.ValCodclube.value },
						set ValCodclube(value) { vm.model.ValCodclube.updateValue(value) },
						get ValCodjogador() { return vm.model.ValCodjogador.value },
						set ValCodjogador(value) { vm.model.ValCodjogador.updateValue(value) },
						get ValCodtreinador() { return vm.model.ValCodtreinador.value },
						set ValCodtreinador(value) { vm.model.ValCodtreinador.updateValue(value) },
						get ValData() { return vm.model.ValData.value },
						set ValData(value) { vm.model.ValData.updateValue(value) },
						get ValMaterial() { return vm.model.ValMaterial.value },
						set ValMaterial(value) { vm.model.ValMaterial.updateValue(value) },
						get ValMesociclos() { return vm.model.ValMesociclos.value },
						set ValMesociclos(value) { vm.model.ValMesociclos.updateValue(value) },
						get ValMicrociclo() { return vm.model.ValMicrociclo.value },
						set ValMicrociclo(value) { vm.model.ValMicrociclo.updateValue(value) },
						get ValNumjogadores() { return vm.model.ValNumjogadores.value },
						set ValNumjogadores(value) { vm.model.ValNumjogadores.updateValue(value) },
						get ValNumtreino() { return vm.model.ValNumtreino.value },
						set ValNumtreino(value) { vm.model.ValNumtreino.updateValue(value) },
						get ValObjetivo() { return vm.model.ValObjetivo.value },
						set ValObjetivo(value) { vm.model.ValObjetivo.updateValue(value) },
					},
					keys: {
						/** The primary key of the TREINO table */
						get treino() { return vm.model.ValCodtreino },
						/** The foreign key to the TREINADOR table */
						get treinador() { return vm.model.ValCodtreinador },
						/** The foreign key to the CLUBE table */
						get clube() { return vm.model.ValCodclube },
						/** The foreign key to the JOGADOR table */
						get jogador() { return vm.model.ValCodjogador },
					},
					get extraProperties() { return vm.model.extraProperties },
				},
			}
		},

		beforeRouteEnter(to, _, next)
		{
			// Called before the route that renders this component is confirmed.
			// Does NOT have access to `this` component instance, because
			// it has not been created yet when this guard is called!

			next((vm) => {
				vm.initFormProperties(to)
			})
		},

		beforeRouteLeave(to, _, next)
		{
			if (to.params.isControlled === 'true')
			{
				genericFunctions.setNavigationState(false)
				next()
			}
			else
				this.cancel(next)
		},

		beforeRouteUpdate(to, _, next)
		{
			if (to.params.isControlled === 'true')
				next()
			else
				this.cancel(next)
		},

		mounted()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL SQB FORM_CODEJS TREINO]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL SQB COMPONENT_BEFORE_UNMOUNT TREINO]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		methods: {
			/**
			 * Called before form init.
			 */
			async beforeLoad()
			{
				// Execute the "Before init" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.beforeInit)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('before-load-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL SQB BEFORE_LOAD_JS TREINO]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return true
			},

			/**
			 * Called after form init.
			 */
			async afterLoad()
			{
				// Execute the "After init" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterInit)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-load-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL SQB FORM_LOADED_JS TREINO]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
			},

			/**
			 * Called before an apply action is performed.
			 */
			async beforeApply()
			{
				let applyForm = true // Set to 'false' to cancel form apply.

				// Execute the "Before apply" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.beforeApply)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				const ticketsPromise = this.model.updateFilesTickets(true)
				this.addBusy(ticketsPromise, this.Resources[hardcodedTexts.processing])
				const canSetDocums = await ticketsPromise

				if (canSetDocums)
				{
					let results
					const changesPromise = this.model.setDocumentChanges()
					this.addBusy(changesPromise, this.Resources[hardcodedTexts.processing])
					applyForm = await changesPromise

					if (applyForm)
					{
						const insertsPromise = this.model.saveDocuments()
						this.addBusy(insertsPromise, this.Resources[hardcodedTexts.processing])
						results = await insertsPromise
						applyForm = results.every((e) => e === true)
					}

					if (!changesPromise || (results && !results.every((e) => e === true)))
					{
						this.validationErrors = {
							Erro: this.Resources.OCORREU_UM_ERRO_AO_T51884
						}
					}
				}

				this.emitEvent('before-apply-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL SQB BEFORE_APPLY_JS TREINO]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return applyForm
			},

			/**
			 * Called after an apply action is performed.
			 */
			async afterApply()
			{
				// Execute the "After apply" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterApply)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-apply-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL SQB AFTER_APPLY_JS TREINO]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
			},

			/**
			 * Called before the record is saved.
			 */
			async beforeSave()
			{
				let saveForm = true // Set to 'false' to cancel form saving.

				// Execute the "Before save" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.beforeSave)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				const ticketsPromise = this.model.updateFilesTickets()
				this.addBusy(ticketsPromise, this.Resources[hardcodedTexts.processing])
				const canSetDocums = await ticketsPromise

				if (canSetDocums)
				{
					let results
					const changesPromise = this.model.setDocumentChanges()
					this.addBusy(changesPromise, this.Resources[hardcodedTexts.processing])
					saveForm = await changesPromise

					if (saveForm)
					{
						const insertsPromise = this.model.saveDocuments()
						this.addBusy(insertsPromise, this.Resources[hardcodedTexts.processing])
						results = await insertsPromise
						saveForm = results.every((e) => e === true)
					}

					if (!changesPromise || (results && !results.every((e) => e === true)))
					{
						this.validationErrors = {
							Erro: this.Resources.OCORREU_UM_ERRO_AO_T51884
						}
					}
				}

				this.emitEvent('before-save-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL SQB BEFORE_SAVE_JS TREINO]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return saveForm
			},

			/**
			 * Called after the record is saved.
			 */
			async afterSave()
			{
				// Execute the "After save" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterSave)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-save-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL SQB AFTER_SAVE_JS TREINO]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return true
			},

			/**
			 * Called before the record is deleted.
			 */
			async beforeDel()
			{
				this.emitEvent('before-delete-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL SQB BEFORE_DEL_JS TREINO]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return true
			},

			/**
			 * Called after the record is deleted.
			 */
			async afterDel()
			{
				this.emitEvent('after-delete-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL SQB AFTER_DEL_JS TREINO]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return true
			},

			/**
			 * Called before leaving the form.
			 */
			async beforeExit()
			{
				// Execute the "Before exit" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.beforeExit)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('before-exit-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL SQB BEFORE_EXIT_JS TREINO]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				return true
			},

			/**
			 * Called after leaving the form.
			 */
			async afterExit()
			{
				// Execute the "After exit" triggers.
				const triggers = this.getTriggers(qEnums.triggerEvents.afterExit)
				for (const trigger of triggers)
					await formFunctions.executeTriggerAction(trigger)

				this.emitEvent('after-exit-form')

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL SQB AFTER_EXIT_JS TREINO]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
			},

			/**
			 * Called whenever a field's value is updated.
			 * @param {string} fieldName The name of the field in the format [table].[field] (ex: 'person.name')
			 * @param {object} fieldObject The object representing the field in the model
			 * @param {any} fieldValue The value of the field
			 * @param {any} oldFieldValue The previous value of the field
			 */
			// eslint-disable-next-line
			onUpdate(fieldName, fieldObject, fieldValue, oldFieldValue)
			{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL SQB DLGUPDT TREINO]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterFieldUpdate(fieldName, fieldObject)
			},

			/**
			 * Called whenever a field is unfocused.
			 * @param {*} fieldObject The object representing the field in the model
			 * @param {*} fieldValue The value of the field
			 */
			// eslint-disable-next-line
			onBlur(fieldObject, fieldValue)
			{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL SQB CTRLBLR TREINO]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterFieldUnfocus(fieldObject, fieldValue)
			},

			/**
			 * Called whenever a control's value is updated.
			 * @param {string} controlField The name of the field in the controls that will be updated
			 * @param {object} control The object representing the field in the controls
			 * @param {any} fieldValue The value of the field
			 */
			// eslint-disable-next-line
			onControlUpdate(controlField, control, fieldValue)
			{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL SQB CTRLUPD TREINO]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL SQB FUNCTIONS_JS TREINO]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
