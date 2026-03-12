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
			data-key="JOGADOR"
			:data-loading="!formInitialDataLoaded || !isActiveForm">
			<template v-if="formControl.initialized && showFormBody">
				<q-row v-if="controls.JOGADOR__JOGADOR__FOTO.isVisible">
					<q-col v-if="controls.JOGADOR__JOGADOR__FOTO.isVisible">
						<base-input-structure
							v-if="controls.JOGADOR__JOGADOR__FOTO.isVisible"
							class="q-image"
							v-bind="controls.JOGADOR__JOGADOR__FOTO"
							v-on="controls.JOGADOR__JOGADOR__FOTO.handlers"
							:loading="controls.JOGADOR__JOGADOR__FOTO.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-image
								v-if="controls.JOGADOR__JOGADOR__FOTO.isVisible"
								v-bind="controls.JOGADOR__JOGADOR__FOTO.props"
								v-on="controls.JOGADOR__JOGADOR__FOTO.handlers" />
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.JOGADOR_PSEUDNEWGRP01.isVisible">
					<q-col v-if="controls.JOGADOR_PSEUDNEWGRP01.isVisible">
						<q-group-box-container
							v-if="controls.JOGADOR_PSEUDNEWGRP01.isVisible"
							id="JOGADOR_PSEUDNEWGRP01"
							v-bind="controls.JOGADOR_PSEUDNEWGRP01"
							:is-visible="controls.JOGADOR_PSEUDNEWGRP01.isVisible">
							<!-- Start JOGADOR_PSEUDNEWGRP01 -->
							<q-row v-if="controls.JOGADOR_CLUBENOME____.isVisible">
								<q-col
									v-if="controls.JOGADOR_CLUBENOME____.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.JOGADOR_CLUBENOME____.isVisible"
										class="i-text"
										v-bind="controls.JOGADOR_CLUBENOME____"
										v-on="controls.JOGADOR_CLUBENOME____.handlers"
										:loading="controls.JOGADOR_CLUBENOME____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-lookup
											v-if="controls.JOGADOR_CLUBENOME____.isVisible"
											v-bind="controls.JOGADOR_CLUBENOME____.props"
											v-on="controls.JOGADOR_CLUBENOME____.handlers" />
										<q-see-more-jogador-clubenome
											v-if="controls.JOGADOR_CLUBENOME____.seeMoreIsVisible"
											v-bind="controls.JOGADOR_CLUBENOME____.seeMoreParams"
											v-on="controls.JOGADOR_CLUBENOME____.handlers" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.JOGADOR__JOGADOR__NUMEROCAMISOLA.isVisible">
								<q-col
									v-if="controls.JOGADOR__JOGADOR__NUMEROCAMISOLA.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.JOGADOR__JOGADOR__NUMEROCAMISOLA.isVisible"
										class="i-text"
										v-bind="controls.JOGADOR__JOGADOR__NUMEROCAMISOLA"
										v-on="controls.JOGADOR__JOGADOR__NUMEROCAMISOLA.handlers"
										:loading="controls.JOGADOR__JOGADOR__NUMEROCAMISOLA.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.JOGADOR__JOGADOR__NUMEROCAMISOLA.isVisible"
											v-bind="controls.JOGADOR__JOGADOR__NUMEROCAMISOLA.props"
											@update:model-value="model.ValNumerocamisola.fnUpdateValue" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.JOGADOR__JOGADOR__NOME.isVisible">
								<q-col
									v-if="controls.JOGADOR__JOGADOR__NOME.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.JOGADOR__JOGADOR__NOME.isVisible"
										class="i-text"
										v-bind="controls.JOGADOR__JOGADOR__NOME"
										v-on="controls.JOGADOR__JOGADOR__NOME.handlers"
										:loading="controls.JOGADOR__JOGADOR__NOME.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.JOGADOR__JOGADOR__NOME.props"
											@blur="onBlur(controls.JOGADOR__JOGADOR__NOME, model.ValNome.value)"
											@change="model.ValNome.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.JOGADOR__JOGADOR__DATANASCIMENTO.isVisible">
								<q-col
									v-if="controls.JOGADOR__JOGADOR__DATANASCIMENTO.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.JOGADOR__JOGADOR__DATANASCIMENTO.isVisible"
										class="i-text"
										v-bind="controls.JOGADOR__JOGADOR__DATANASCIMENTO"
										v-on="controls.JOGADOR__JOGADOR__DATANASCIMENTO.handlers"
										:loading="controls.JOGADOR__JOGADOR__DATANASCIMENTO.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-date-time-picker
											v-if="controls.JOGADOR__JOGADOR__DATANASCIMENTO.isVisible"
											v-bind="controls.JOGADOR__JOGADOR__DATANASCIMENTO.props"
											:model-value="model.ValDatanascimento.value"
											@reset-icon-click="model.ValDatanascimento.fnUpdateValue(model.ValDatanascimento.originalValue ?? new Date())"
											@update:model-value="model.ValDatanascimento.fnUpdateValue($event ?? '')" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.JOGADOR__JOGADOR__PEDOMINANTE.isVisible">
								<q-col
									v-if="controls.JOGADOR__JOGADOR__PEDOMINANTE.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.JOGADOR__JOGADOR__PEDOMINANTE.isVisible"
										class="i-text"
										v-bind="controls.JOGADOR__JOGADOR__PEDOMINANTE"
										v-on="controls.JOGADOR__JOGADOR__PEDOMINANTE.handlers"
										:loading="controls.JOGADOR__JOGADOR__PEDOMINANTE.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-select
											v-if="controls.JOGADOR__JOGADOR__PEDOMINANTE.isVisible"
											v-bind="controls.JOGADOR__JOGADOR__PEDOMINANTE.props"
											@update:model-value="model.ValPedominante.fnUpdateValue" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.JOGADOR__JOGADOR__POSICAO.isVisible || controls.JOGADOR__JOGADOR__SPPOSICAOMEDIO.isVisible || controls.JOGADOR__JOGADOR__SPPOSICAOAT.isVisible || controls.JOGADOR__JOGADOR__SPPOSICAODEF.isVisible">
								<q-col
									v-if="controls.JOGADOR__JOGADOR__POSICAO.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.JOGADOR__JOGADOR__POSICAO.isVisible"
										class="i-text"
										v-bind="controls.JOGADOR__JOGADOR__POSICAO"
										v-on="controls.JOGADOR__JOGADOR__POSICAO.handlers"
										:loading="controls.JOGADOR__JOGADOR__POSICAO.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-select
											v-if="controls.JOGADOR__JOGADOR__POSICAO.isVisible"
											v-bind="controls.JOGADOR__JOGADOR__POSICAO.props"
											@update:model-value="model.ValPosicao.fnUpdateValue" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.JOGADOR__JOGADOR__SPPOSICAOMEDIO.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.JOGADOR__JOGADOR__SPPOSICAOMEDIO.isVisible"
										class="i-text"
										v-bind="controls.JOGADOR__JOGADOR__SPPOSICAOMEDIO"
										v-on="controls.JOGADOR__JOGADOR__SPPOSICAOMEDIO.handlers"
										:loading="controls.JOGADOR__JOGADOR__SPPOSICAOMEDIO.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-select
											v-if="controls.JOGADOR__JOGADOR__SPPOSICAOMEDIO.isVisible"
											v-bind="controls.JOGADOR__JOGADOR__SPPOSICAOMEDIO.props"
											@update:model-value="model.ValSpposicaomedio.fnUpdateValue" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.JOGADOR__JOGADOR__SPPOSICAOAT.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.JOGADOR__JOGADOR__SPPOSICAOAT.isVisible"
										class="i-text"
										v-bind="controls.JOGADOR__JOGADOR__SPPOSICAOAT"
										v-on="controls.JOGADOR__JOGADOR__SPPOSICAOAT.handlers"
										:loading="controls.JOGADOR__JOGADOR__SPPOSICAOAT.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-select
											v-if="controls.JOGADOR__JOGADOR__SPPOSICAOAT.isVisible"
											v-bind="controls.JOGADOR__JOGADOR__SPPOSICAOAT.props"
											@update:model-value="model.ValSpposicaoat.fnUpdateValue" />
									</base-input-structure>
								</q-col>
								<q-col
									v-if="controls.JOGADOR__JOGADOR__SPPOSICAODEF.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.JOGADOR__JOGADOR__SPPOSICAODEF.isVisible"
										class="i-text"
										v-bind="controls.JOGADOR__JOGADOR__SPPOSICAODEF"
										v-on="controls.JOGADOR__JOGADOR__SPPOSICAODEF.handlers"
										:loading="controls.JOGADOR__JOGADOR__SPPOSICAODEF.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-select
											v-if="controls.JOGADOR__JOGADOR__SPPOSICAODEF.isVisible"
											v-bind="controls.JOGADOR__JOGADOR__SPPOSICAODEF.props"
											@update:model-value="model.ValSpposicaodef.fnUpdateValue" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.JOGADOR__JOGADOR__POSICAOSEGUNDARIA.isVisible">
								<q-col
									v-if="controls.JOGADOR__JOGADOR__POSICAOSEGUNDARIA.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.JOGADOR__JOGADOR__POSICAOSEGUNDARIA.isVisible"
										class="i-text"
										v-bind="controls.JOGADOR__JOGADOR__POSICAOSEGUNDARIA"
										v-on="controls.JOGADOR__JOGADOR__POSICAOSEGUNDARIA.handlers"
										:loading="controls.JOGADOR__JOGADOR__POSICAOSEGUNDARIA.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-select
											v-if="controls.JOGADOR__JOGADOR__POSICAOSEGUNDARIA.isVisible"
											v-bind="controls.JOGADOR__JOGADOR__POSICAOSEGUNDARIA.props"
											@update:model-value="model.ValPosicaosegundaria.fnUpdateValue" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.JOGADOR__JOGADOR__EQUIPAANTERIOR.isVisible">
								<q-col
									v-if="controls.JOGADOR__JOGADOR__EQUIPAANTERIOR.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.JOGADOR__JOGADOR__EQUIPAANTERIOR.isVisible"
										class="i-text"
										v-bind="controls.JOGADOR__JOGADOR__EQUIPAANTERIOR"
										v-on="controls.JOGADOR__JOGADOR__EQUIPAANTERIOR.handlers"
										:loading="controls.JOGADOR__JOGADOR__EQUIPAANTERIOR.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.JOGADOR__JOGADOR__EQUIPAANTERIOR.props"
											@blur="onBlur(controls.JOGADOR__JOGADOR__EQUIPAANTERIOR, model.ValEquipaanterior.value)"
											@change="model.ValEquipaanterior.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End JOGADOR_PSEUDNEWGRP01 -->
						</q-group-box-container>
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

	import FormViewModel from './QFormJogadorViewModel.js'

	const requiredTextResources = ['QFormJogador', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL SQB FORM_INCLUDEJS JOGADOR]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormJogador',

		components: {
			QSeeMoreJogadorClubenome: defineAsyncComponent(() => import('@/views/forms/FormJogador/dbedits/JogadorClubenomeSeeMore.vue')),
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
					name: 'JOGADOR',
					location: 'form-JOGADOR',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormJogador', false),

				interfaceMetadata: {
					id: 'QFormJogador', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'JOGADOR',
					route: 'form-JOGADOR',
					area: 'JOGADOR',
					primaryKey: 'ValCodjogador',
					designation: computed(() => this.Resources.JOGADOR34905),
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
					JOGADOR__JOGADOR__FOTO: new fieldControlClass.ImageControl({
						modelField: 'ValFoto',
						valueChangeEvent: 'fieldChange:jogador.foto',
						id: 'JOGADOR__JOGADOR__FOTO',
						name: 'FOTO',
						size: 'block',
						label: computed(() => this.Resources.FOTO19492),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						height: 50,
						width: 30,
						dataTitle: computed(() => genericFunctions.formatString(vm.Resources.IMAGEM_UTILIZADA_PAR17299, vm.Resources.FOTO19492)),
						maxFileSize: 10485760, // In bytes.
						maxFileSizeLabel: '10 MB',
						controlLimits: [
						],
					}, this),
					JOGADOR_PSEUDNEWGRP01: new fieldControlClass.GroupControl({
						id: 'JOGADOR_PSEUDNEWGRP01',
						name: 'NEWGRP01',
						size: 'block',
						label: computed(() => this.Resources.FICHA_INDIVIDUAL02409),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						isCollapsible: false,
						anchored: false,
						directChildren: ['JOGADOR_CLUBENOME____', 'JOGADOR__JOGADOR__NUMEROCAMISOLA', 'JOGADOR__JOGADOR__NOME', 'JOGADOR__JOGADOR__DATANASCIMENTO', 'JOGADOR__JOGADOR__PEDOMINANTE', 'JOGADOR__JOGADOR__POSICAO', 'JOGADOR__JOGADOR__SPPOSICAOMEDIO', 'JOGADOR__JOGADOR__SPPOSICAOAT', 'JOGADOR__JOGADOR__SPPOSICAODEF', 'JOGADOR__JOGADOR__POSICAOSEGUNDARIA', 'JOGADOR__JOGADOR__EQUIPAANTERIOR'],
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					JOGADOR_CLUBENOME____: new fieldControlClass.LookupControl({
						modelField: 'TableClubeNome',
						valueChangeEvent: 'fieldChange:clube.nome',
						id: 'JOGADOR_CLUBENOME____',
						name: 'NOME',
						size: 'xxlarge',
						label: computed(() => this.Resources.CLUBE52443),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'JOGADOR_PSEUDNEWGRP01',
						externalCallbacks: {
							getModelField: vm.getModelField,
							getModelFieldValue: vm.getModelFieldValue,
							setModelFieldValue: vm.setModelFieldValue
						},
						externalProperties: {
							modelKeys: computed(() => vm.modelKeys)
						},
						lookupKeyModelField: {
							name: 'ValCodclube',
							dependencyEvent: 'fieldChange:jogador.codclube'
						},
						dependentFields: () => ({
							set 'clube.codclube'(value) { vm.model.ValCodclube.updateValue(value) },
							set 'clube.nome'(value) { vm.model.TableClubeNome.updateValue(value) },
						}),
						controlLimits: [
						],
					}, this),
					JOGADOR__JOGADOR__NUMEROCAMISOLA: new fieldControlClass.NumberControl({
						modelField: 'ValNumerocamisola',
						valueChangeEvent: 'fieldChange:jogador.numerocamisola',
						id: 'JOGADOR__JOGADOR__NUMEROCAMISOLA',
						name: 'NUMEROCAMISOLA',
						size: 'small',
						label: computed(() => this.Resources.NUMERO_CAMISOLA34511),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'JOGADOR_PSEUDNEWGRP01',
						maxIntegers: 2,
						maxDecimals: 0,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					JOGADOR__JOGADOR__NOME: new fieldControlClass.StringControl({
						modelField: 'ValNome',
						valueChangeEvent: 'fieldChange:jogador.nome',
						id: 'JOGADOR__JOGADOR__NOME',
						name: 'NOME',
						size: 'xxlarge',
						label: computed(() => this.Resources.NOME47814),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'JOGADOR_PSEUDNEWGRP01',
						maxLength: 50,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					JOGADOR__JOGADOR__DATANASCIMENTO: new fieldControlClass.DateControl({
						modelField: 'ValDatanascimento',
						valueChangeEvent: 'fieldChange:jogador.datanascimento',
						id: 'JOGADOR__JOGADOR__DATANASCIMENTO',
						name: 'DATANASCIMENTO',
						size: 'medium',
						label: computed(() => this.Resources.DATA_NASCIMENTO26850),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'JOGADOR_PSEUDNEWGRP01',
						dateTimeType: 'date',
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					JOGADOR__JOGADOR__PEDOMINANTE: new fieldControlClass.ArrayStringControl({
						modelField: 'ValPedominante',
						valueChangeEvent: 'fieldChange:jogador.pedominante',
						id: 'JOGADOR__JOGADOR__PEDOMINANTE',
						name: 'PEDOMINANTE',
						size: 'small',
						label: computed(() => this.Resources.PE_DOMINANTE49350),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'JOGADOR_PSEUDNEWGRP01',
						maxLength: 3,
						mustBeFilled: true,
						arrayName: 'Pe',
						helpShortItem: 'None',
						helpDetailedItem: 'None',
						controlLimits: [
						],
					}, this),
					JOGADOR__JOGADOR__POSICAO: new fieldControlClass.ArrayStringControl({
						modelField: 'ValPosicao',
						valueChangeEvent: 'fieldChange:jogador.posicao',
						id: 'JOGADOR__JOGADOR__POSICAO',
						name: 'POSICAO',
						size: 'small',
						label: computed(() => this.Resources.POSICAO_HABITUAL63592),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'JOGADOR_PSEUDNEWGRP01',
						maxLength: 3,
						mustBeFilled: true,
						arrayName: 'Posicao',
						helpShortItem: 'None',
						helpDetailedItem: 'None',
						controlLimits: [
						],
					}, this),
					JOGADOR__JOGADOR__SPPOSICAOMEDIO: new fieldControlClass.ArrayStringControl({
						modelField: 'ValSpposicaomedio',
						valueChangeEvent: 'fieldChange:jogador.spposicaomedio',
						id: 'JOGADOR__JOGADOR__SPPOSICAOMEDIO',
						name: 'SPPOSICAOMEDIO',
						size: 'medium',
						label: computed(() => this.Resources.ESPECIFICACAO_POSICA24622),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'JOGADOR_PSEUDNEWGRP01',
						maxLength: 3,
						arrayName: 'SPposicaoMedio',
						helpShortItem: 'None',
						helpDetailedItem: 'None',
						controlLimits: [
						],
						showWhen: {
							// eslint-disable-next-line @typescript-eslint/no-unused-vars
							fnFormula(params)
							{
								// Formula: [JOGADOR->POSICAO] == "Medio"
								return this.ValPosicao.value==="Medio"
							},
							dependencyEvents: ['fieldChange:jogador.posicao'],
							isServerRecalc: false,
						},
					}, this),
					JOGADOR__JOGADOR__SPPOSICAOAT: new fieldControlClass.ArrayStringControl({
						modelField: 'ValSpposicaoat',
						valueChangeEvent: 'fieldChange:jogador.spposicaoat',
						id: 'JOGADOR__JOGADOR__SPPOSICAOAT',
						name: 'SPPOSICAOAT',
						size: 'medium',
						label: computed(() => this.Resources.ESPECIFICACAO_POSICA24622),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'JOGADOR_PSEUDNEWGRP01',
						maxLength: 1,
						arrayName: 'SPposicao',
						helpShortItem: 'None',
						helpDetailedItem: 'None',
						controlLimits: [
						],
						showWhen: {
							// eslint-disable-next-line @typescript-eslint/no-unused-vars
							fnFormula(params)
							{
								// Formula: [JOGADOR->POSICAO] == "Atacante"
								return this.ValPosicao.value==="Atacante"
							},
							dependencyEvents: ['fieldChange:jogador.posicao'],
							isServerRecalc: false,
						},
					}, this),
					JOGADOR__JOGADOR__SPPOSICAODEF: new fieldControlClass.ArrayStringControl({
						modelField: 'ValSpposicaodef',
						valueChangeEvent: 'fieldChange:jogador.spposicaodef',
						id: 'JOGADOR__JOGADOR__SPPOSICAODEF',
						name: 'SPPOSICAODEF',
						size: 'medium',
						label: computed(() => this.Resources.ESPECIFICACAO_POSICA24622),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'JOGADOR_PSEUDNEWGRP01',
						maxLength: 1,
						arrayName: 'SPposicao',
						helpShortItem: 'None',
						helpDetailedItem: 'None',
						controlLimits: [
						],
						showWhen: {
							// eslint-disable-next-line @typescript-eslint/no-unused-vars
							fnFormula(params)
							{
								// Formula: [JOGADOR->POSICAO] == "Defesa"
								return this.ValPosicao.value==="Defesa"
							},
							dependencyEvents: ['fieldChange:jogador.posicao'],
							isServerRecalc: false,
						},
					}, this),
					JOGADOR__JOGADOR__POSICAOSEGUNDARIA: new fieldControlClass.ArrayStringControl({
						modelField: 'ValPosicaosegundaria',
						valueChangeEvent: 'fieldChange:jogador.posicaosegundaria',
						id: 'JOGADOR__JOGADOR__POSICAOSEGUNDARIA',
						name: 'POSICAOSEGUNDARIA',
						size: 'small',
						label: computed(() => this.Resources.POSICAO_SEGUNDARIA49537),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'JOGADOR_PSEUDNEWGRP01',
						maxLength: 3,
						arrayName: 'Posicao',
						helpShortItem: 'None',
						helpDetailedItem: 'None',
						controlLimits: [
						],
					}, this),
					JOGADOR__JOGADOR__EQUIPAANTERIOR: new fieldControlClass.StringControl({
						modelField: 'ValEquipaanterior',
						valueChangeEvent: 'fieldChange:jogador.equipaanterior',
						id: 'JOGADOR__JOGADOR__EQUIPAANTERIOR',
						name: 'EQUIPAANTERIOR',
						size: 'xxlarge',
						label: computed(() => this.Resources.EQUIPA_ANTERIOR39393),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'JOGADOR_PSEUDNEWGRP01',
						maxLength: 50,
						controlLimits: [
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
					'JOGADOR_PSEUDNEWGRP01',
				]),

				tableFields: readonly([
				]),

				timelineFields: readonly([
				]),

				/**
				 * The Data API for easy access to model variables.
				 */
				dataApi: {
					Clube: {
						get ValNome() { return vm.model.TableClubeNome.value },
						set ValNome(value) { vm.model.TableClubeNome.updateValue(value) },
					},
					Jogador: {
						get ValCodclube() { return vm.model.ValCodclube.value },
						set ValCodclube(value) { vm.model.ValCodclube.updateValue(value) },
						get ValDatanascimento() { return vm.model.ValDatanascimento.value },
						set ValDatanascimento(value) { vm.model.ValDatanascimento.updateValue(value) },
						get ValEquipaanterior() { return vm.model.ValEquipaanterior.value },
						set ValEquipaanterior(value) { vm.model.ValEquipaanterior.updateValue(value) },
						get ValFoto() { return vm.model.ValFoto.value },
						set ValFoto(value) { vm.model.ValFoto.updateValue(value) },
						get ValNome() { return vm.model.ValNome.value },
						set ValNome(value) { vm.model.ValNome.updateValue(value) },
						get ValNumerocamisola() { return vm.model.ValNumerocamisola.value },
						set ValNumerocamisola(value) { vm.model.ValNumerocamisola.updateValue(value) },
						get ValPedominante() { return vm.model.ValPedominante.value },
						set ValPedominante(value) { vm.model.ValPedominante.updateValue(value) },
						get ValPosicao() { return vm.model.ValPosicao.value },
						set ValPosicao(value) { vm.model.ValPosicao.updateValue(value) },
						get ValPosicaosegundaria() { return vm.model.ValPosicaosegundaria.value },
						set ValPosicaosegundaria(value) { vm.model.ValPosicaosegundaria.updateValue(value) },
						get ValSpposicaoat() { return vm.model.ValSpposicaoat.value },
						set ValSpposicaoat(value) { vm.model.ValSpposicaoat.updateValue(value) },
						get ValSpposicaodef() { return vm.model.ValSpposicaodef.value },
						set ValSpposicaodef(value) { vm.model.ValSpposicaodef.updateValue(value) },
						get ValSpposicaomedio() { return vm.model.ValSpposicaomedio.value },
						set ValSpposicaomedio(value) { vm.model.ValSpposicaomedio.updateValue(value) },
					},
					keys: {
						/** The primary key of the JOGADOR table */
						get jogador() { return vm.model.ValCodjogador },
						/** The foreign key to the CLUBE table */
						get clube() { return vm.model.ValCodclube },
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
// USE /[MANUAL SQB FORM_CODEJS JOGADOR]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL SQB COMPONENT_BEFORE_UNMOUNT JOGADOR]/
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
// USE /[MANUAL SQB BEFORE_LOAD_JS JOGADOR]/
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
// USE /[MANUAL SQB FORM_LOADED_JS JOGADOR]/
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
// USE /[MANUAL SQB BEFORE_APPLY_JS JOGADOR]/
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
// USE /[MANUAL SQB AFTER_APPLY_JS JOGADOR]/
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
// USE /[MANUAL SQB BEFORE_SAVE_JS JOGADOR]/
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
// USE /[MANUAL SQB AFTER_SAVE_JS JOGADOR]/
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
// USE /[MANUAL SQB BEFORE_DEL_JS JOGADOR]/
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
// USE /[MANUAL SQB AFTER_DEL_JS JOGADOR]/
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
// USE /[MANUAL SQB BEFORE_EXIT_JS JOGADOR]/
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
// USE /[MANUAL SQB AFTER_EXIT_JS JOGADOR]/
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
// USE /[MANUAL SQB DLGUPDT JOGADOR]/
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
// USE /[MANUAL SQB CTRLBLR JOGADOR]/
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
// USE /[MANUAL SQB CTRLUPD JOGADOR]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL SQB FUNCTIONS_JS JOGADOR]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
