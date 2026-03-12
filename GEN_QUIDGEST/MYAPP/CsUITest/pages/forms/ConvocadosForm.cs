using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ConvocadosForm : Form
{
	/// <summary>
	/// Nome
	/// </summary>
	public LookupControl JogadorNome => new LookupControl(driver, ContainerLocator, "container-CONVOCADOS__JOGADOR__NOME");
	public SeeMorePage JogadorNomeSeeMorePage => new SeeMorePage(driver, "CONVOCADOS", "CONVOCADOS__JOGADOR__NOME");

	/// <summary>
	/// Numero Camisola
	/// </summary>
	public BaseInputControl JogadorNumerocamisola => new BaseInputControl(driver, ContainerLocator, "container-CONVOCADOS__JOGADOR__NUMEROCAMISOLA", "#CONVOCADOS__JOGADOR__NUMEROCAMISOLA");

	/// <summary>
	/// Posição
	/// </summary>
	public BaseInputControl JogadorPosicao => new BaseInputControl(driver, ContainerLocator, "container-CONVOCADOS__JOGADOR__POSICAO", "#CONVOCADOS__JOGADOR__POSICAO");

	/// <summary>
	/// Posição Segundaria
	/// </summary>
	public BaseInputControl JogadorPosicaosegundaria => new BaseInputControl(driver, ContainerLocator, "container-CONVOCADOS__JOGADOR__POSICAOSEGUNDARIA", "#CONVOCADOS__JOGADOR__POSICAOSEGUNDARIA");

	public ConvocadosForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "CONVOCADOS", containerLocator: containerLocator) { }
}
