using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class JogoForm : Form
{
	/// <summary>
	/// Titulo
	/// </summary>
	public BaseInputControl JogoTitulo => new BaseInputControl(driver, ContainerLocator, "container-JOGO____JOGO_TITULO__", "#JOGO____JOGO_TITULO__");

	/// <summary>
	/// Data
	/// </summary>
	public DateInputControl JogoData => new DateInputControl(driver, ContainerLocator, "#JOGO____JOGO_DATA____");

	/// <summary>
	/// Local
	/// </summary>
	public BaseInputControl JogoLocal => new BaseInputControl(driver, ContainerLocator, "container-JOGO____JOGO_LOCAL___", "#JOGO____JOGO_LOCAL___");

	/// <summary>
	/// Équipa Adversaria
	/// </summary>
	public BaseInputControl JogoEquipaadversaria => new BaseInputControl(driver, ContainerLocator, "container-JOGO__JOGO__EQUIPAADVERSARIA", "#JOGO__JOGO__EQUIPAADVERSARIA");

	/// <summary>
	/// Resultado
	/// </summary>
	public BaseInputControl JogoResultado => new BaseInputControl(driver, ContainerLocator, "container-JOGO__JOGO__RESULTADO", "#JOGO__JOGO__RESULTADO");

	public JogoForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "JOGO", containerLocator: containerLocator) { }
}
