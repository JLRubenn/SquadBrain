// eslint-disable-next-line @typescript-eslint/no-unused-vars
import { updateQueryParams } from './routeUtils.js'

export default function getMenusRoutes()
{
	return [
		{
			path: '/:culture/:system/SQB/menu/SQB_21',
			name: 'menu-SQB_21',
			component: () => import('@/views/menus/ModuleSQB/MenuSQB_21/QMenuSqb21.vue'),
			meta: {
				routeType: 'menu',
				module: 'SQB',
				order: '21',
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
			path: '/:culture/:system/SQB/menu/SQB_61',
			name: 'menu-SQB_61',
			component: () => import('@/views/menus/ModuleSQB/MenuSQB_61/QMenuSqb61.vue'),
			meta: {
				routeType: 'menu',
				module: 'SQB',
				order: '61',
				baseArea: 'CONVOCATORIA',
				hasInitialPHE: false,
				humanKeyFields: ['ValCodjogo'],
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
				baseArea: 'PRESENCA',
				hasInitialPHE: false,
				humanKeyFields: ['ValCodjogador'],
				isPopup: false
			}
		},
		{
			path: '/:culture/:system/SQB/menu/SQB_41',
			name: 'menu-SQB_41',
			component: () => import('@/views/menus/ModuleSQB/MenuSQB_41/QMenuSqb41.vue'),
			meta: {
				routeType: 'menu',
				module: 'SQB',
				order: '41',
				baseArea: 'TREINO',
				hasInitialPHE: false,
				humanKeyFields: ['ValData'],
				isPopup: false
			}
		},
	]
}
