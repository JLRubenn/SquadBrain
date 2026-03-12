using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class PresencaForm : Form
{
	/// <summary>
	/// 
	/// </summary>
	public ListControl PseudPresenca => new ListControl(driver, ContainerLocator, "#PRESENCAPSEUDPRESENCA");

	/// <summary>
	/// Estado
	/// </summary>
	public EnumControl PresencaEstado => new EnumControl(driver, ContainerLocator, "container-PRESENCA__PRESENCA__ESTADO");

	/// <summary>
	/// Nome
	/// </summary>
	public LookupControl JogadorNome => new LookupControl(driver, ContainerLocator, "container-PRESENCA__JOGADOR__NOME");
	public SeeMorePage JogadorNomeSeeMorePage => new SeeMorePage(driver, "PRESENCA", "PRESENCA__JOGADOR__NOME");

	public PresencaForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "PRESENCA", containerLocator: containerLocator) { }
}
