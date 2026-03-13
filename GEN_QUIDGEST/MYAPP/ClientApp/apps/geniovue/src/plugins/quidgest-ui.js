import { createFramework } from '@quidgest/ui/framework'

const framework = createFramework({
	themes: {
		defaultTheme: 'Light',
		themes: [
			{
				name: 'Light',
				mode: 'light',
				colors: {
					secondary: '#051b10',
					primaryLight: '#A3CFBA',
					primary: '#198754',
					primaryDark: '#0f5132',
					highlight: '#6f42c1',
				}
			}
		]
	},
	defaults: {
		QIconSvg: {
			bundle: 'Content/svgbundle.svg?v=17'
		},
		QCollapsible: {
			icons: {
				chevron: {
					icon: 'expand'
				}
			}
		},
		QListItem: {
			icons: {
				check: {
					icon: 'ok'
				},
				description: {
					icon: 'help'
				}
			}
		},
		QSelect: {
			itemValue: 'key',
			itemLabel: 'value',
			icons: {
				clear: {
					icon: 'close'
				},
				chevron: {
					icon: 'expand'
				}
			}
		},
		QCombobox: {
			itemValue: 'key',
			itemLabel: 'value',
			icons: {
				clear: {
					icon: 'close'
				},
				chevron: {
					icon: 'expand'
				}
			}
		},
		QPropertyList: {
			icons: {
				open: {
					icon: 'square-minus',
				},
				close: {
					icon: 'square-plus',
				}
			}
		},
		QCheckbox: {
			icons: {
				checked: {
					icon: 'ok'
				},
				indeterminate: {
					icon: 'minus'
				}
			}
		},
		QCarousel: {
			icons: {
				back: {
					icon: 'step-back'
				},
				forward: {
					icon: 'step-forward'
				}
			}
		}
	}
})

export default framework
