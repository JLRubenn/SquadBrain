using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class TreinadorForm : Form
{
	/// <summary>
	/// Nome
	/// </summary>
	public LookupControl ClubeNome => new LookupControl(driver, ContainerLocator, "container-TREINADOR__CLUBE__NOME");
	public SeeMorePage ClubeNomeSeeMorePage => new SeeMorePage(driver, "TREINADOR", "TREINADOR__CLUBE__NOME");

	/// <summary>
	/// Nome
	/// </summary>
	public BaseInputControl TreinadorNome => new BaseInputControl(driver, ContainerLocator, "container-TREINADOR__TREINADOR__NOME", "#TREINADOR__TREINADOR__NOME");

	/// <summary>
	/// Fun
	/// </summary>
	public EnumControl TreinadorFuncao => new EnumControl(driver, ContainerLocator, "container-TREINADOR__TREINADOR__FUNCAO");

	/// <summary>
	/// LASTTREINOCRIADO
	/// </summary>
	public BaseInputControl TreinadorLasttreinocriado => new BaseInputControl(driver, ContainerLocator, "container-TREINADOR__TREINADOR__LASTTREINOCRIADO", "#TREINADOR__TREINADOR__LASTTREINOCRIADO");

	public TreinadorForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "TREINADOR", containerLocator: containerLocator) { }
}
