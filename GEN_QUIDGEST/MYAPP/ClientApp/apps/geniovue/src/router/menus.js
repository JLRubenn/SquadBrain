// eslint-disable-next-line @typescript-eslint/no-unused-vars
import { updateQueryParams } from './routeUtils.js'

export default function getMenusRoutes()
{
	return [
		{
			path: '/:culture/:system/SQB/menu/SQB_411',
			name: 'menu-SQB_411',
			component: () => import('@/views/menus/ModuleSQB/MenuSQB_411/QMenuSqb411.vue'),
			meta: {
				routeType: 'menu',
				module: 'SQB',
				order: '411',
				baseArea: 'JOGO',
				hasInitialPHE: false,
				humanKeyFields: ['ValTitulo'],
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
				baseArea: 'JOGO',
				hasInitialPHE: false,
				humanKeyFields: ['ValTitulo'],
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
				baseArea: 'CLUBE',
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
				baseArea: 'TREINADOR',
				hasInitialPHE: false,
				humanKeyFields: ['ValNome'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/SQB/menu/SQB_51',
			name: 'menu-SQB_51',
			component: () => import('@/views/menus/ModuleSQB/MenuSQB_51/QMenuSqb51.vue'),
			meta: {
				routeType: 'menu',
				module: 'SQB',
				order: '51',
				baseArea: 'JOGADOR',
				hasInitialPHE: false,
				humanKeyFields: ['ValNome'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/SQB/menu/SQB_121',
			name: 'menu-SQB_121',
			component: () => import('@/views/menus/ModuleSQB/MenuSQB_121/QMenuSqb121.vue'),
			meta: {
				routeType: 'menu',
				module: 'SQB',
				order: '121',
				baseArea: 'PRESENCA',
				hasInitialPHE: false,
				humanKeyFields: ['ValCodjogador'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/SQB/menu/SQB_111',
			name: 'menu-SQB_111',
			component: () => import('@/views/menus/ModuleSQB/MenuSQB_111/QMenuSqb111.vue'),
			meta: {
				routeType: 'menu',
				module: 'SQB',
				order: '111',
				baseArea: 'TREINO',
				hasInitialPHE: false,
				humanKeyFields: ['ValData'],
				isPopup: false
			}
		},
	]
}
