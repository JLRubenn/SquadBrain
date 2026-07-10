<template>
	<div class="game-model-page">
		<div class="game-model-header">
			<div>
				<h2>Modelo de Jogo</h2>
				<p>Organiza ideias ofensivas e defensivas com imagens, titulo e descricao.</p>
			</div>
			<button
				type="button"
				class="btn btn-success"
				@click="newModel">
				Novo modelo
			</button>
		</div>

		<div class="game-model-tabs">
			<button
				v-for="type in types"
				:key="type"
				type="button"
				class="btn"
				:class="activeType === type ? 'btn-primary' : 'btn-outline-primary'"
				@click="setType(type)">
				{{ type }}
			</button>
		</div>

		<p
			v-if="message"
			class="game-model-message game-model-message--success">
			{{ message }}
		</p>
		<p
			v-if="error"
			class="game-model-message game-model-message--error">
			{{ error }}
		</p>

		<div class="game-model-layout">
			<section class="game-model-editor">
				<label>
					<span>Titulo</span>
					<input
						v-model="form.Titulo"
						class="form-control"
						maxlength="120"
						placeholder="Ex.: Saida curta a 3" />
				</label>
				<label>
					<span>Treinador</span>
					<select
						v-model="form.CodTreinador"
						class="form-control">
						<option value="">Escolher treinador</option>
						<option
							v-for="trainer in trainers"
							:key="trainer.Id"
							:value="trainer.Id">
							{{ trainer.Name }}
						</option>
					</select>
				</label>
				<label>
					<span>Descricao</span>
					<textarea
						v-model="form.Descricao"
						class="form-control"
						rows="7"
						placeholder="Descreve o comportamento, posicionamento ou ideia principal." />
				</label>
				<label class="game-model-upload">
					<span>Imagens</span>
					<input
						ref="imagesInput"
						type="file"
						accept="image/*"
						multiple
						class="form-control"
						@change="addImages" />
				</label>

				<div
					v-if="form.Imagens && form.Imagens.length > 0"
					class="game-model-image-list">
					<div
						v-for="image in form.Imagens"
						:key="image.Id"
						class="game-model-image-chip">
						<img
							:src="image.DataUrl"
							:alt="image.Name" />
						<button
							type="button"
							class="btn btn-sm btn-outline-danger"
							@click="removeImage(image.Id)">
							Remover
						</button>
					</div>
				</div>

				<div class="game-model-actions">
					<button
						type="button"
						class="btn btn-success"
						:disabled="saving"
						@click="saveModel">
						{{ saving ? 'A guardar...' : 'Guardar' }}
					</button>
					<button
						type="button"
						class="btn btn-outline-secondary"
						@click="newModel">
						Limpar
					</button>
					<button
						v-if="form.Id"
						type="button"
						class="btn btn-outline-danger"
						@click="deleteModel">
						Apagar
					</button>
				</div>
			</section>

			<section class="game-model-list">
				<div class="game-model-list__header">
					<h3>{{ activeType }}</h3>
					<span>{{ filteredItems.length }} modelos</span>
				</div>
				<p
					v-if="loading"
					class="game-model-empty">
					A carregar modelos...
				</p>
				<p
					v-else-if="filteredItems.length === 0"
					class="game-model-empty">
					Ainda nao existem modelos nesta aba.
				</p>
				<button
					v-for="item in filteredItems"
					:key="item.Id"
					type="button"
					class="game-model-card"
					:class="{ 'game-model-card--active': form.Id === item.Id }"
					@click="selectModel(item)">
					<div class="game-model-card__media">
						<img
							v-if="item.Imagens && item.Imagens.length > 0"
							:src="item.Imagens[0].DataUrl"
							:alt="item.Imagens[0].Name" />
						<span v-else>Sem imagem</span>
					</div>
					<div class="game-model-card__content">
						<h4>{{ item.Titulo }}</h4>
						<p>{{ item.TreinadorNome || 'Sem treinador' }}</p>
						<small>{{ item.Imagens?.length || 0 }} imagens</small>
					</div>
				</button>
			</section>
		</div>
	</div>
</template>

<script>
	import netAPI from '@quidgest/clientapp/network'

	export default {
		name: 'QMenuSqb61',

		data()
		{
			return {
				types: ['Ofensivo', 'Defensivo'],
				activeType: 'Ofensivo',
				trainers: [],
				items: [],
				loading: false,
				saving: false,
				message: '',
				error: '',
				form: this.emptyForm('Ofensivo')
			}
		},

		computed: {
			filteredItems()
			{
				return this.items.filter((item) => item.Tipo === this.activeType)
			}
		},

		mounted()
		{
			this.loadTrainers()
			this.loadModels()
		},

		methods: {
			emptyForm(type)
			{
				return {
					Id: '',
					Tipo: type || this.activeType || 'Ofensivo',
					Titulo: '',
					Descricao: '',
					CodTreinador: '',
					TreinadorNome: '',
					Imagens: []
				}
			},

			setType(type)
			{
				this.activeType = type
				this.newModel()
			},

			newModel()
			{
				this.message = ''
				this.error = ''
				this.form = this.emptyForm(this.activeType)
				if (this.$refs.imagesInput)
					this.$refs.imagesInput.value = ''
			},

			selectModel(item)
			{
				this.message = ''
				this.error = ''
				this.form = this.normalizeModel(item)
			},

			normalizeModel(model)
			{
				const source = model || {}
				return {
					...this.emptyForm(source.Tipo || source.tipo || this.activeType),
					Id: source.Id || source.id || '',
					Tipo: source.Tipo || source.tipo || this.activeType,
					Titulo: source.Titulo || source.titulo || '',
					Descricao: source.Descricao || source.descricao || '',
					CodTreinador: source.CodTreinador || source.codTreinador || '',
					TreinadorNome: source.TreinadorNome || source.treinadorNome || '',
					Imagens: Array.isArray(source.Imagens) ? source.Imagens : (Array.isArray(source.imagens) ? source.imagens : []),
					UpdatedAt: source.UpdatedAt || source.updatedAt || null
				}
			},

			loadTrainers()
			{
				netAPI.fetchData('ModeloJogo', 'Trainers', {}, (data) => {
					const payload = data?.Data || data?.data || data || {}
					this.trainers = payload.Trainers || payload.trainers || []
				}, (error) => {
					this.error = error?.message || 'Nao foi possivel carregar os treinadores.'
				})
			},

			loadModels()
			{
				this.loading = true
				netAPI.fetchData('ModeloJogo', 'List', {}, (data) => {
					const payload = data?.Data || data?.data || data || {}
					this.items = (payload.Items || payload.items || []).map((item) => this.normalizeModel(item))
					this.loading = false
				}, (error) => {
					this.loading = false
					this.error = error?.message || 'Nao foi possivel carregar os modelos de jogo.'
				})
			},

			addImages(event)
			{
				const files = Array.from(event.target.files || [])
				files.forEach((file) => {
					if (!file.type.startsWith('image/'))
						return

					const reader = new FileReader()
					reader.onload = () => {
						this.form.Imagens.push({
							Id: `${Date.now()}-${Math.random().toString(16).slice(2)}`,
							Name: file.name,
							ContentType: file.type,
							DataUrl: reader.result
						})
					}
					reader.readAsDataURL(file)
				})
			},

			removeImage(imageId)
			{
				this.form.Imagens = this.form.Imagens.filter((image) => image.Id !== imageId)
			},

			upsertModel(model)
			{
				const index = this.items.findIndex((item) => item.Id === model.Id)
				if (index >= 0)
					this.items.splice(index, 1, model)
				else
					this.items.unshift(model)
			},

			saveModel()
			{
				this.message = ''
				this.error = ''

				if (!this.form.Titulo?.trim())
				{
					this.error = 'Indica o titulo do modelo de jogo.'
					return
				}

				if (!this.form.CodTreinador)
				{
					this.error = 'Escolhe o treinador.'
					return
				}

				this.saving = true
				this.form.Tipo = this.activeType

				netAPI.postData('ModeloJogo', 'Save', this.form, (data, response) => {
					this.saving = false

					if (response?.data?.Success === false)
					{
						this.error = response.data.Message || 'Nao foi possivel guardar o modelo de jogo.'
						return
					}

					const savedModel = this.normalizeModel(data)
					if (!savedModel.Id)
					{
						this.error = 'O modelo foi enviado, mas a resposta veio sem identificador.'
						return
					}

					this.upsertModel(savedModel)
					this.form = savedModel
					this.message = 'Modelo de jogo guardado.'
					this.loadModels()
				}, (error) => {
					this.saving = false
					this.error = error?.message || 'Nao foi possivel guardar o modelo de jogo.'
				})
			},

			deleteModel()
			{
				if (!this.form.Id)
					return

				netAPI.postData('ModeloJogo', 'Delete', { Id: this.form.Id }, () => {
					this.message = 'Modelo de jogo apagado.'
					this.newModel()
					this.loadModels()
				}, (error) => {
					this.error = error?.message || 'Nao foi possivel apagar o modelo de jogo.'
				})
			}
		}
	}
</script>

<style scoped>
	.game-model-page {
		padding: 1rem;
		max-width: 1500px;
	}

	.game-model-header,
	.game-model-list__header,
	.game-model-actions,
	.game-model-tabs {
		display: flex;
		align-items: center;
		gap: 0.75rem;
		flex-wrap: wrap;
	}

	.game-model-header {
		justify-content: space-between;
		margin-bottom: 1rem;
	}

	.game-model-header h2,
	.game-model-list__header h3,
	.game-model-card h4 {
		margin: 0;
	}

	.game-model-header p,
	.game-model-card p,
	.game-model-empty {
		margin: 0.25rem 0 0;
		color: #4b5563;
	}

	.game-model-tabs {
		margin-bottom: 1rem;
	}

	.game-model-layout {
		display: grid;
		grid-template-columns: minmax(320px, 480px) minmax(420px, 1fr);
		gap: 1rem;
	}

	.game-model-editor,
	.game-model-list {
		border: 1px solid #cbd5e1;
		border-radius: 6px;
		background: #fff;
		padding: 1rem;
	}

	.game-model-editor {
		display: grid;
		gap: 0.9rem;
	}

	.game-model-editor label {
		display: grid;
		gap: 0.35rem;
		font-weight: 600;
	}

	.game-model-editor label span {
		color: #111827;
	}

	.game-model-image-list {
		display: grid;
		grid-template-columns: repeat(auto-fill, minmax(120px, 1fr));
		gap: 0.75rem;
	}

	.game-model-image-chip {
		border: 1px solid #d1d5db;
		border-radius: 6px;
		padding: 0.5rem;
		display: grid;
		gap: 0.5rem;
	}

	.game-model-image-chip img,
	.game-model-card__media img {
		width: 100%;
		object-fit: cover;
		border-radius: 4px;
	}

	.game-model-image-chip img {
		aspect-ratio: 4 / 3;
	}

	.game-model-list {
		display: grid;
		align-content: start;
		gap: 0.75rem;
	}

	.game-model-list__header {
		justify-content: space-between;
		border-bottom: 1px solid #e5e7eb;
		padding-bottom: 0.75rem;
	}

	.game-model-card {
		border: 1px solid #cbd5e1;
		border-radius: 6px;
		background: #fff;
		padding: 0.75rem;
		display: grid;
		grid-template-columns: 160px 1fr;
		gap: 0.85rem;
		text-align: left;
		transition: border-color 0.15s, box-shadow 0.15s;
	}

	.game-model-card:hover,
	.game-model-card--active {
		border-color: #198754;
		box-shadow: 0 0 0 2px rgba(25, 135, 84, 0.12);
	}

	.game-model-card__media {
		min-height: 110px;
		background: #f3f4f6;
		border-radius: 4px;
		display: grid;
		place-items: center;
		color: #6b7280;
		overflow: hidden;
	}

	.game-model-card__media img {
		height: 110px;
	}

	.game-model-card__content {
		display: grid;
		align-content: start;
		gap: 0.35rem;
	}

	.game-model-card small,
	.game-model-list__header span {
		color: #6b7280;
	}

	.game-model-message {
		margin: 0 0 1rem;
	}

	.game-model-message--success {
		color: #198754;
	}

	.game-model-message--error {
		color: #dc3545;
	}

	@media (max-width: 900px) {
		.game-model-layout,
		.game-model-card {
			grid-template-columns: 1fr;
		}
	}
</style>
