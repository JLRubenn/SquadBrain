using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ExercicioForm : PopupForm
{
	/// <summary>
	/// Titulo
	/// </summary>
	public BaseInputControl ExercicioTitulo => new BaseInputControl(driver, ContainerLocator, "container-EXERCICIO__EXERCICIO__TITULO", "#EXERCICIO__EXERCICIO__TITULO");

	/// <summary>
	/// 
	/// </summary>
	public BaseInputControl ExercicioFoto => new BaseInputControl(driver, ContainerLocator, "container-EXERCICIO__EXERCICIO__FOTO", "#EXERCICIO__EXERCICIO__FOTO");

	/// <summary>
	/// Tempo
	/// </summary>
	public BaseInputControl ExercicioTempo => new BaseInputControl(driver, ContainerLocator, "container-EXERCICIO__EXERCICIO__TEMPO", "#EXERCICIO__EXERCICIO__TEMPO");

	/// <summary>
	/// Numero de Jogadoes
	/// </summary>
	public BaseInputControl ExercicioNumjogador => new BaseInputControl(driver, ContainerLocator, "container-EXERCICIO__EXERCICIO__NUMJOGADOR", "#EXERCICIO__EXERCICIO__NUMJOGADOR");

	/// <summary>
	/// Espaço
	/// </summary>
	public BaseInputControl ExercicioEspaco => new BaseInputControl(driver, ContainerLocator, "container-EXERCICIO__EXERCICIO__ESPACO", "#EXERCICIO__EXERCICIO__ESPACO");

	/// <summary>
	/// Objetivo
	/// </summary>
	public BaseInputControl ExercicioObjetivo => new BaseInputControl(driver, ContainerLocator, "container-EXERCICIO__EXERCICIO__OBJETIVO", "#EXERCICIO__EXERCICIO__OBJETIVO");

	/// <summary>
	/// Descrição
	/// </summary>
	public BaseInputControl ExercicioDescricao => new BaseInputControl(driver, ContainerLocator, "container-EXERCICIO__EXERCICIO__DESCRICAO", "#EXERCICIO__EXERCICIO__DESCRICAO");

	public ExercicioForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "EXERCICIO") { }
}
