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
			data-key="CLUBE"
			:data-loading="!formInitialDataLoaded || !isActiveForm">
			<template v-if="formControl.initialized && showFormBody">
				<q-row v-if="controls.CLUBE___CLUBEFOTO____.isVisible">
					<q-col v-if="controls.CLUBE___CLUBEFOTO____.isVisible">
						<base-input-structure
							v-if="controls.CLUBE___CLUBEFOTO____.isVisible"
							class="q-image"
							v-bind="controls.CLUBE___CLUBEFOTO____"
							v-on="controls.CLUBE___CLUBEFOTO____.handlers"
							:loading="controls.CLUBE___CLUBEFOTO____.props.loading"
							:reporting-mode-on="reportingModeCAV"
							:suggestion-mode-on="suggestionModeOn">
							<q-image
								v-if="controls.CLUBE___CLUBEFOTO____.isVisible"
								v-bind="controls.CLUBE___CLUBEFOTO____.props"
								v-on="controls.CLUBE___CLUBEFOTO____.handlers" />
						</base-input-structure>
					</q-col>
				</q-row>
				<q-row v-if="controls.CLUBE___PSEUDNEWGRP01.isVisible">
					<q-col v-if="controls.CLUBE___PSEUDNEWGRP01.isVisible">
						<q-group-collapsible
							v-if="controls.CLUBE___PSEUDNEWGRP01.isVisible"
							id="CLUBE___PSEUDNEWGRP01"
							v-bind="controls.CLUBE___PSEUDNEWGRP01"
							v-on="controls.CLUBE___PSEUDNEWGRP01.handlers">
							<!-- Start CLUBE___PSEUDNEWGRP01 -->
							<q-row v-if="controls.CLUBE___CLUBENOME____.isVisible">
								<q-col
									v-if="controls.CLUBE___CLUBENOME____.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.CLUBE___CLUBENOME____.isVisible"
										class="i-text"
										v-bind="controls.CLUBE___CLUBENOME____"
										v-on="controls.CLUBE___CLUBENOME____.handlers"
										:loading="controls.CLUBE___CLUBENOME____.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.CLUBE___CLUBENOME____.props"
											@blur="onBlur(controls.CLUBE___CLUBENOME____, model.ValNome.value)"
											@change="model.ValNome.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.CLUBE___CLUBEESCALAO_.isVisible">
								<q-col
									v-if="controls.CLUBE___CLUBEESCALAO_.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.CLUBE___CLUBEESCALAO_.isVisible"
										class="i-text"
										v-bind="controls.CLUBE___CLUBEESCALAO_"
										v-on="controls.CLUBE___CLUBEESCALAO_.handlers"
										:loading="controls.CLUBE___CLUBEESCALAO_.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.CLUBE___CLUBEESCALAO_.props"
											@blur="onBlur(controls.CLUBE___CLUBEESCALAO_, model.ValEscalao.value)"
											@change="model.ValEscalao.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.CLUBE___CLUBEEPOCA___.isVisible">
								<q-col
									v-if="controls.CLUBE___CLUBEEPOCA___.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.CLUBE___CLUBEEPOCA___.isVisible"
										class="i-text"
										v-bind="controls.CLUBE___CLUBEEPOCA___"
										v-on="controls.CLUBE___CLUBEEPOCA___.handlers"
										:loading="controls.CLUBE___CLUBEEPOCA___.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.CLUBE___CLUBEEPOCA___.props"
											@blur="onBlur(controls.CLUBE___CLUBEEPOCA___, model.ValEpoca.value)"
											@change="model.ValEpoca.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.CLUBE__CLUBE__VALORMERCADOEQUIPA.isVisible">
								<q-col
									v-if="controls.CLUBE__CLUBE__VALORMERCADOEQUIPA.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.CLUBE__CLUBE__VALORMERCADOEQUIPA.isVisible"
										class="i-text"
										v-bind="controls.CLUBE__CLUBE__VALORMERCADOEQUIPA"
										v-on="controls.CLUBE__CLUBE__VALORMERCADOEQUIPA.handlers"
										:loading="controls.CLUBE__CLUBE__VALORMERCADOEQUIPA.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-numeric-input
											v-if="controls.CLUBE__CLUBE__VALORMERCADOEQUIPA.isVisible"
											v-bind="controls.CLUBE__CLUBE__VALORMERCADOEQUIPA.props"
											@update:model-value="model.ValValormercadoequipa.fnUpdateValue" />
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End CLUBE___PSEUDNEWGRP01 -->
						</q-group-collapsible>
					</q-col>
				</q-row>
				<q-row v-if="controls.CLUBE___PSEUDNEWGRP02.isVisible">
					<q-col v-if="controls.CLUBE___PSEUDNEWGRP02.isVisible">
						<q-group-collapsible
							v-if="controls.CLUBE___PSEUDNEWGRP02.isVisible"
							id="CLUBE___PSEUDNEWGRP02"
							v-bind="controls.CLUBE___PSEUDNEWGRP02"
							v-on="controls.CLUBE___PSEUDNEWGRP02.handlers">
							<!-- Start CLUBE___PSEUDNEWGRP02 -->
							<q-row v-if="controls.CLUBE__CLUBE__PRESIDENTE.isVisible">
								<q-col
									v-if="controls.CLUBE__CLUBE__PRESIDENTE.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.CLUBE__CLUBE__PRESIDENTE.isVisible"
										class="i-text"
										v-bind="controls.CLUBE__CLUBE__PRESIDENTE"
										v-on="controls.CLUBE__CLUBE__PRESIDENTE.handlers"
										:loading="controls.CLUBE__CLUBE__PRESIDENTE.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.CLUBE__CLUBE__PRESIDENTE.props"
											@blur="onBlur(controls.CLUBE__CLUBE__PRESIDENTE, model.ValPresidente.value)"
											@change="model.ValPresidente.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.CLUBE__CLUBE__COORDTECN.isVisible">
								<q-col
									v-if="controls.CLUBE__CLUBE__COORDTECN.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.CLUBE__CLUBE__COORDTECN.isVisible"
										class="i-text"
										v-bind="controls.CLUBE__CLUBE__COORDTECN"
										v-on="controls.CLUBE__CLUBE__COORDTECN.handlers"
										:loading="controls.CLUBE__CLUBE__COORDTECN.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.CLUBE__CLUBE__COORDTECN.props"
											@blur="onBlur(controls.CLUBE__CLUBE__COORDTECN, model.ValCoordtecn.value)"
											@change="model.ValCoordtecn.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.CLUBE__CLUBE__COORDFORM.isVisible">
								<q-col
									v-if="controls.CLUBE__CLUBE__COORDFORM.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.CLUBE__CLUBE__COORDFORM.isVisible"
										class="i-text"
										v-bind="controls.CLUBE__CLUBE__COORDFORM"
										v-on="controls.CLUBE__CLUBE__COORDFORM.handlers"
										:loading="controls.CLUBE__CLUBE__COORDFORM.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.CLUBE__CLUBE__COORDFORM.props"
											@blur="onBlur(controls.CLUBE__CLUBE__COORDFORM, model.ValCoordform.value)"
											@change="model.ValCoordform.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End CLUBE___PSEUDNEWGRP02 -->
						</q-group-collapsible>
					</q-col>
				</q-row>
				<q-row v-if="controls.CLUBE___PSEUDNEWGRP03.isVisible">
					<q-col v-if="controls.CLUBE___PSEUDNEWGRP03.isVisible">
						<q-group-collapsible
							v-if="controls.CLUBE___PSEUDNEWGRP03.isVisible"
							id="CLUBE___PSEUDNEWGRP03"
							v-bind="controls.CLUBE___PSEUDNEWGRP03"
							v-on="controls.CLUBE___PSEUDNEWGRP03.handlers">
							<!-- Start CLUBE___PSEUDNEWGRP03 -->
							<q-row v-if="controls.CLUBE__CLUBE__TREINADORPRINCIPAL.isVisible">
								<q-col
									v-if="controls.CLUBE__CLUBE__TREINADORPRINCIPAL.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.CLUBE__CLUBE__TREINADORPRINCIPAL.isVisible"
										class="i-text"
										v-bind="controls.CLUBE__CLUBE__TREINADORPRINCIPAL"
										v-on="controls.CLUBE__CLUBE__TREINADORPRINCIPAL.handlers"
										:loading="controls.CLUBE__CLUBE__TREINADORPRINCIPAL.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.CLUBE__CLUBE__TREINADORPRINCIPAL.props"
											@blur="onBlur(controls.CLUBE__CLUBE__TREINADORPRINCIPAL, model.ValTreinadorprincipal.value)"
											@change="model.ValTreinadorprincipal.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
							</q-row>
							<q-row v-if="controls.CLUBE__CLUBE__TREINADORADJUNTO.isVisible">
								<q-col
									v-if="controls.CLUBE__CLUBE__TREINADORADJUNTO.isVisible"
									cols="auto">
									<base-input-structure
										v-if="controls.CLUBE__CLUBE__TREINADORADJUNTO.isVisible"
										class="i-text"
										v-bind="controls.CLUBE__CLUBE__TREINADORADJUNTO"
										v-on="controls.CLUBE__CLUBE__TREINADORADJUNTO.handlers"
										:loading="controls.CLUBE__CLUBE__TREINADORADJUNTO.props.loading"
										:reporting-mode-on="reportingModeCAV"
										:suggestion-mode-on="suggestionModeOn">
										<q-text-field
											v-bind="controls.CLUBE__CLUBE__TREINADORADJUNTO.props"
											@blur="onBlur(controls.CLUBE__CLUBE__TREINADORADJUNTO, model.ValTreinadoradjunto.value)"
											@change="model.ValTreinadoradjunto.fnUpdateValueOnChange" />
									</base-input-structure>
								</q-col>
							</q-row>
							<!-- End CLUBE___PSEUDNEWGRP03 -->
						</q-group-collapsible>
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

	import FormViewModel from './QFormClubeViewModel.js'

	const requiredTextResources = ['QFormClube', 'hardcoded', 'messages']

/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL SQB FORM_INCLUDEJS CLUBE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

	export default {
		name: 'QFormClube',

		components: {
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
					name: 'CLUBE',
					location: 'form-CLUBE',
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
				componentOnLoadProc: asyncProcM.getProcListMonitor('QFormClube', false),

				interfaceMetadata: {
					id: 'QFormClube', // Used for resources
					requiredTextResources
				},

				formInfo: {
					type: 'normal',
					name: 'CLUBE',
					route: 'form-CLUBE',
					area: 'CLUBE',
					primaryKey: 'ValCodclube',
					designation: computed(() => this.Resources.CLUBE52443),
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
					CLUBE___CLUBEFOTO____: new fieldControlClass.ImageControl({
						modelField: 'ValFoto',
						valueChangeEvent: 'fieldChange:clube.foto',
						id: 'CLUBE___CLUBEFOTO____',
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
					CLUBE___PSEUDNEWGRP01: new fieldControlClass.GroupControl({
						id: 'CLUBE___PSEUDNEWGRP01',
						name: 'NEWGRP01',
						size: 'block',
						label: computed(() => this.Resources.INFORMACOES_DO_CLUBE41671),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						startsExpanded: false,
						isCollapsible: true,
						anchored: false,
						directChildren: ['CLUBE___CLUBENOME____', 'CLUBE___CLUBEESCALAO_', 'CLUBE___CLUBEEPOCA___', 'CLUBE__CLUBE__VALORMERCADOEQUIPA'],
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					CLUBE___CLUBENOME____: new fieldControlClass.StringControl({
						modelField: 'ValNome',
						valueChangeEvent: 'fieldChange:clube.nome',
						id: 'CLUBE___CLUBENOME____',
						name: 'NOME',
						size: 'xxlarge',
						label: computed(() => this.Resources.NOME47814),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'CLUBE___PSEUDNEWGRP01',
						maxLength: 50,
						mustBeFilled: true,
						controlLimits: [
						],
					}, this),
					CLUBE___CLUBEESCALAO_: new fieldControlClass.StringControl({
						modelField: 'ValEscalao',
						valueChangeEvent: 'fieldChange:clube.escalao',
						id: 'CLUBE___CLUBEESCALAO_',
						name: 'ESCALAO',
						size: 'xxlarge',
						label: computed(() => this.Resources.ESCALAO14935),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'CLUBE___PSEUDNEWGRP01',
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					CLUBE___CLUBEEPOCA___: new fieldControlClass.StringControl({
						modelField: 'ValEpoca',
						valueChangeEvent: 'fieldChange:clube.epoca',
						id: 'CLUBE___CLUBEEPOCA___',
						name: 'EPOCA',
						size: 'xxlarge',
						label: computed(() => this.Resources.EPOCA21186),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'CLUBE___PSEUDNEWGRP01',
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					CLUBE__CLUBE__VALORMERCADOEQUIPA: new fieldControlClass.CurrencyControl({
						modelField: 'ValValormercadoequipa',
						valueChangeEvent: 'fieldChange:clube.valormercadoequipa',
						id: 'CLUBE__CLUBE__VALORMERCADOEQUIPA',
						name: 'VALORMERCADOEQUIPA',
						size: 'large',
						label: computed(() => this.Resources.VALOR_MERCADO_EQUIPA38351),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'CLUBE___PSEUDNEWGRP01',
						isFormulaBlocked: true,
						maxIntegers: 12,
						maxDecimals: 2,
						controlLimits: [
						],
					}, this),
					CLUBE___PSEUDNEWGRP02: new fieldControlClass.GroupControl({
						id: 'CLUBE___PSEUDNEWGRP02',
						name: 'NEWGRP02',
						size: 'block',
						label: computed(() => this.Resources.RESPONSAVEIS_DO_CLUB28910),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						startsExpanded: false,
						isCollapsible: true,
						anchored: false,
						directChildren: ['CLUBE__CLUBE__PRESIDENTE', 'CLUBE__CLUBE__COORDTECN', 'CLUBE__CLUBE__COORDFORM'],
						controlLimits: [
						],
					}, this),
					CLUBE__CLUBE__PRESIDENTE: new fieldControlClass.StringControl({
						modelField: 'ValPresidente',
						valueChangeEvent: 'fieldChange:clube.presidente',
						id: 'CLUBE__CLUBE__PRESIDENTE',
						name: 'PRESIDENTE',
						size: 'xxlarge',
						label: computed(() => this.Resources.PRESIDENTE51745),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'CLUBE___PSEUDNEWGRP02',
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					CLUBE__CLUBE__COORDTECN: new fieldControlClass.StringControl({
						modelField: 'ValCoordtecn',
						valueChangeEvent: 'fieldChange:clube.coordtecn',
						id: 'CLUBE__CLUBE__COORDTECN',
						name: 'COORDTECN',
						size: 'xxlarge',
						label: computed(() => this.Resources.COORDENADOR_TECNICO51290),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'CLUBE___PSEUDNEWGRP02',
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					CLUBE__CLUBE__COORDFORM: new fieldControlClass.StringControl({
						modelField: 'ValCoordform',
						valueChangeEvent: 'fieldChange:clube.coordform',
						id: 'CLUBE__CLUBE__COORDFORM',
						name: 'COORDFORM',
						size: 'xxlarge',
						label: computed(() => this.Resources.COORDENADOR_FORMACAO06004),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'CLUBE___PSEUDNEWGRP02',
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					CLUBE___PSEUDNEWGRP03: new fieldControlClass.GroupControl({
						id: 'CLUBE___PSEUDNEWGRP03',
						name: 'NEWGRP03',
						size: 'block',
						label: computed(() => this.Resources.EQUIPA_TECNICA24280),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						startsExpanded: false,
						isCollapsible: true,
						anchored: false,
						directChildren: ['CLUBE__CLUBE__TREINADORPRINCIPAL', 'CLUBE__CLUBE__TREINADORADJUNTO'],
						controlLimits: [
						],
					}, this),
					CLUBE__CLUBE__TREINADORPRINCIPAL: new fieldControlClass.StringControl({
						modelField: 'ValTreinadorprincipal',
						valueChangeEvent: 'fieldChange:clube.treinadorprincipal',
						id: 'CLUBE__CLUBE__TREINADORPRINCIPAL',
						name: 'TREINADORPRINCIPAL',
						size: 'xxlarge',
						label: computed(() => this.Resources.TREINADOR_PRINCIPAL45661),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'CLUBE___PSEUDNEWGRP03',
						maxLength: 50,
						controlLimits: [
						],
					}, this),
					CLUBE__CLUBE__TREINADORADJUNTO: new fieldControlClass.StringControl({
						modelField: 'ValTreinadoradjunto',
						valueChangeEvent: 'fieldChange:clube.treinadoradjunto',
						id: 'CLUBE__CLUBE__TREINADORADJUNTO',
						name: 'TREINADORADJUNTO',
						size: 'xxlarge',
						label: computed(() => this.Resources.TREINADOR_ADJUNTO05329),
						placeholder: '',
						labelPosition: computed(() => this.labelAlignment.topleft),
						container: 'CLUBE___PSEUDNEWGRP03',
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
					'CLUBE___PSEUDNEWGRP01',
					'CLUBE___PSEUDNEWGRP02',
					'CLUBE___PSEUDNEWGRP03',
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
						get ValCoordform() { return vm.model.ValCoordform.value },
						set ValCoordform(value) { vm.model.ValCoordform.updateValue(value) },
						get ValCoordtecn() { return vm.model.ValCoordtecn.value },
						set ValCoordtecn(value) { vm.model.ValCoordtecn.updateValue(value) },
						get ValEpoca() { return vm.model.ValEpoca.value },
						set ValEpoca(value) { vm.model.ValEpoca.updateValue(value) },
						get ValEscalao() { return vm.model.ValEscalao.value },
						set ValEscalao(value) { vm.model.ValEscalao.updateValue(value) },
						get ValFoto() { return vm.model.ValFoto.value },
						set ValFoto(value) { vm.model.ValFoto.updateValue(value) },
						get ValNome() { return vm.model.ValNome.value },
						set ValNome(value) { vm.model.ValNome.updateValue(value) },
						get ValPresidente() { return vm.model.ValPresidente.value },
						set ValPresidente(value) { vm.model.ValPresidente.updateValue(value) },
						get ValTreinadoradjunto() { return vm.model.ValTreinadoradjunto.value },
						set ValTreinadoradjunto(value) { vm.model.ValTreinadoradjunto.updateValue(value) },
						get ValTreinadorprincipal() { return vm.model.ValTreinadorprincipal.value },
						set ValTreinadorprincipal(value) { vm.model.ValTreinadorprincipal.updateValue(value) },
						get ValValormercadoequipa() { return vm.model.ValValormercadoequipa.value },
						set ValValormercadoequipa(value) { vm.model.ValValormercadoequipa.updateValue(value) },
					},
					keys: {
						/** The primary key of the CLUBE table */
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
// USE /[MANUAL SQB FORM_CODEJS CLUBE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		beforeUnmount()
		{
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL SQB COMPONENT_BEFORE_UNMOUNT CLUBE]/
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
// USE /[MANUAL SQB BEFORE_LOAD_JS CLUBE]/
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
// USE /[MANUAL SQB FORM_LOADED_JS CLUBE]/
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
// USE /[MANUAL SQB BEFORE_APPLY_JS CLUBE]/
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
// USE /[MANUAL SQB AFTER_APPLY_JS CLUBE]/
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
// USE /[MANUAL SQB BEFORE_SAVE_JS CLUBE]/
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
// USE /[MANUAL SQB AFTER_SAVE_JS CLUBE]/
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
// USE /[MANUAL SQB BEFORE_DEL_JS CLUBE]/
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
// USE /[MANUAL SQB AFTER_DEL_JS CLUBE]/
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
// USE /[MANUAL SQB BEFORE_EXIT_JS CLUBE]/
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
// USE /[MANUAL SQB AFTER_EXIT_JS CLUBE]/
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
// USE /[MANUAL SQB DLGUPDT CLUBE]/
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
// USE /[MANUAL SQB CTRLBLR CLUBE]/
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
// USE /[MANUAL SQB CTRLUPD CLUBE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */

				this.afterControlUpdate(controlField, fieldValue)
			},
/* eslint-disable indent, vue/html-indent, vue/script-indent */
// USE /[MANUAL SQB FUNCTIONS_JS CLUBE]/
// eslint-disable-next-line
/* eslint-enable indent, vue/html-indent, vue/script-indent */
		},

		watch: {
		}
	}
</script>
