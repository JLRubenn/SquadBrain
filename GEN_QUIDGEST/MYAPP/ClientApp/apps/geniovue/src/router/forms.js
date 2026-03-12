import { propsConverter } from './routeUtils.js'

export default function getFormsRoutes()
{
	return [
		{
			path: '/:culture/:system/:module/form/CLUBE/:mode/:id?',
			name: 'form-CLUBE',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormClube/QFormClube.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'CLUBE',
				humanKeyFields: ['ValNome'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/:module/form/CONVOCADOS/:mode/:id?',
			name: 'form-CONVOCADOS',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormConvocados/QFormConvocados.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'CONVOCATORIA',
				humanKeyFields: ['ValCodjogo'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/:module/form/CONVOCATORIA/:mode/:id?',
			name: 'form-CONVOCATORIA',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormConvocatoria/QFormConvocatoria.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'CONVOCATORIA',
				humanKeyFields: ['ValCodjogo'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/:module/form/EXERCICIO/:mode/:id?',
			name: 'form-EXERCICIO',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormExercicio/QFormExercicio.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'EXERCICIO',
				humanKeyFields: ['ValTitulo'],
				isPopup: true
			}
		},
		{
			path: '/:culture/:system/:module/form/JOGADOR/:mode/:id?',
			name: 'form-JOGADOR',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormJogador/QFormJogador.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'JOGADOR',
				humanKeyFields: ['ValNome'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/:module/form/JOGO/:mode/:id?',
			name: 'form-JOGO',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormJogo/QFormJogo.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'JOGO',
				humanKeyFields: ['ValTitulo'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/:module/form/PRESENCA/:mode/:id?',
			name: 'form-PRESENCA',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormPresenca/QFormPresenca.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'PRESENCA',
				humanKeyFields: ['ValCodjogador'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/:module/form/TREINO/:mode/:id?',
			name: 'form-TREINO',
			props: route => propsConverter(route),
			component: () => import('@/views/forms/FormTreino/QFormTreino.vue'),
			meta: {
				routeType: 'form',
				baseArea: 'TREINO',
				humanKeyFields: ['ValData'],
				isPopup: false
			}
		},
	]
}
