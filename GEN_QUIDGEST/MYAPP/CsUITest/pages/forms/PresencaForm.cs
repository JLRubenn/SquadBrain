using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class PresencaForm : Form
{
	/// <summary>
	/// Data
	/// </summary>
	public LookupControl TreinoData => new LookupControl(driver, ContainerLocator, "container-PRESENCA__TREINO__DATA");
	public SeeMorePage TreinoDataSeeMorePage => new SeeMorePage(driver, "PRESENCA", "PRESENCA__TREINO__DATA");

	/// <summary>
	/// Nome
	/// </summary>
	public LookupControl JogadorNome => new LookupControl(driver, ContainerLocator, "container-PRESENCA__JOGADOR__NOME");
	public SeeMorePage JogadorNomeSeeMorePage => new SeeMorePage(driver, "PRESENCA", "PRESENCA__JOGADOR__NOME");

	/// <summary>
	/// Estado
	/// </summary>
	public EnumControl PresencaEstado => new EnumControl(driver, ContainerLocator, "container-PRESENCA__PRESENCA__ESTADO");

	/// <summary>
	/// 
	/// </summary>
	public ListControl PseudPresenca => new ListControl(driver, ContainerLocator, "#PRESENCAPSEUDPRESENCA");

	public PresencaForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "PRESENCA", containerLocator: containerLocator) { }
}
