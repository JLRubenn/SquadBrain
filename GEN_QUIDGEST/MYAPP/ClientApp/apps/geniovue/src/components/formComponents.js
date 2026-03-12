import { defineAsyncComponent } from 'vue'

export default {
	install: (app) => {
		app.component('QFormAccountInfo', defineAsyncComponent(() => import('@/views/shared/AccountInfo.vue')))
		app.component('QFormClube', defineAsyncComponent(() => import('@/views/forms/FormClube/QFormClube.vue')))
		app.component('QFormConvocatoria', defineAsyncComponent(() => import('@/views/forms/FormConvocatoria/QFormConvocatoria.vue')))
		app.component('QFormExercicio', defineAsyncComponent(() => import('@/views/forms/FormExercicio/QFormExercicio.vue')))
		app.component('QFormJogador', defineAsyncComponent(() => import('@/views/forms/FormJogador/QFormJogador.vue')))
		app.component('QFormPresenca', defineAsyncComponent(() => import('@/views/forms/FormPresenca/QFormPresenca.vue')))
		app.component('QFormTreino', defineAsyncComponent(() => import('@/views/forms/FormTreino/QFormTreino.vue')))
	}
}
