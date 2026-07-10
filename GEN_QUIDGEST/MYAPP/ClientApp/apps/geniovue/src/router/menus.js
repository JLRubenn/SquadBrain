// eslint-disable-next-line @typescript-eslint/no-unused-vars
import { updateQueryParams } from './routeUtils.js'

export default function getMenusRoutes()
{
	return [
		{
			path: '/:culture/:system/SQB/menu/SQB_511',
			name: 'menu-SQB_511',
			component: () => import('@/views/menus/ModuleSQB/MenuSQB_511/QMenuSqb511.vue'),
			meta: {
				routeType: 'menu',
				module: 'SQB',
				order: '511',
				baseArea: 'JOGO',
				hasInitialPHE: false,
				humanKeyFields: ['ValTitulo'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/SQB/menu/SQB_521',
			name: 'menu-SQB_521',
			component: () => import('@/views/menus/ModuleSQB/MenuSQB_521/QMenuSqb521.vue'),
			meta: {
				routeType: 'menu',
				module: 'SQB',
				order: '521',
				baseArea: 'JOGO',
				hasInitialPHE: false,
				humanKeyFields: ['ValTitulo'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/SQB/menu/SQB_11',
			name: 'menu-SQB_11',
			component: () => import('@/views/menus/ModuleSQB/MenuSQB_11/QMenuSqb11.vue'),
			meta: {
				routeType: 'menu',
				module: 'SQB',
				order: '11',
				baseArea: 'CLUBE',
				hasInitialPHE: false,
				humanKeyFields: ['ValNome'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/SQB/menu/SQB_21',
			name: 'menu-SQB_21',
			component: () => import('@/views/menus/ModuleSQB/MenuSQB_21/QMenuSqb21.vue'),
			meta: {
				routeType: 'menu',
				module: 'SQB',
				order: '21',
				baseArea: 'TREINADOR',
				hasInitialPHE: false,
				humanKeyFields: ['ValNome'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/SQB/menu/SQB_431',
			name: 'menu-SQB_431',
			component: () => import('@/views/menus/ModuleSQB/MenuSQB_431/QMenuSqb431.vue'),
			meta: {
				routeType: 'menu',
				module: 'SQB',
				order: '431',
				baseArea: 'TREINADOR',
				hasInitialPHE: false,
				humanKeyFields: ['ValNome'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/SQB/menu/SQB_31',
			name: 'menu-SQB_31',
			component: () => import('@/views/menus/ModuleSQB/MenuSQB_31/QMenuSqb31.vue'),
			meta: {
				routeType: 'menu',
				module: 'SQB',
				order: '31',
				baseArea: 'JOGADOR',
				hasInitialPHE: false,
				humanKeyFields: ['ValNome'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/SQB/menu/SQB_421',
			name: 'menu-SQB_421',
			component: () => import('@/views/menus/ModuleSQB/MenuSQB_421/QMenuSqb421.vue'),
			meta: {
				routeType: 'menu',
				module: 'SQB',
				order: '421',
				baseArea: 'PRESENCA',
				hasInitialPHE: false,
				humanKeyFields: ['ValCodjogador'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/SQB/menu/SQB_411',
			name: 'menu-SQB_411',
			component: () => import('@/views/menus/ModuleSQB/MenuSQB_411/QMenuSqb411.vue'),
			meta: {
				routeType: 'menu',
				module: 'SQB',
				order: '411',
				baseArea: 'TREINO',
				hasInitialPHE: false,
				humanKeyFields: ['ValData'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/SQB/menu/SQB_61',
			name: 'menu-SQB_61',
			component: () => import('@/views/menus/ModuleSQB/MenuSQB_61/QMenuSqb61.vue'),
			meta: {
				routeType: 'menu',
				module: 'SQB',
				order: '61',
				baseArea: 'TREINADOR',
				hasInitialPHE: false,
				humanKeyFields: ['Titulo'],
				isPopup: false
			}
		},		{
			path: '/:culture/:system/SQB/menu/SQB_4311',
			name: 'menu-SQB_4311',
			component: () => import('@/views/menus/ModuleSQB/MenuSQB_4311/QMenuSqb4311.vue'),
			beforeEnter: [updateQueryParams],
			meta: {
				routeType: 'menu',
				module: 'SQB',
				order: '4311',
				baseArea: 'TREINO',
				hasInitialPHE: false,
				humanKeyFields: ['ValData'],
				limitations: ['treinador' /* DB */],
				isPopup: false
			}
		},
	]
}
