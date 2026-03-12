using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ConvocatoriaForm : Form
{
	/// <summary>
	/// Titulo
	/// </summary>
	public LookupControl JogoTitulo => new LookupControl(driver, ContainerLocator, "container-CONVOCATORIA__JOGO__TITULO");
	public SeeMorePage JogoTituloSeeMorePage => new SeeMorePage(driver, "CONVOCATORIA", "CONVOCATORIA__JOGO__TITULO");

	/// <summary>
	/// Local
	/// </summary>
	public BaseInputControl JogoLocal => new BaseInputControl(driver, ContainerLocator, "container-CONVOCATORIA__JOGO__LOCAL", "#CONVOCATORIA__JOGO__LOCAL");

	/// <summary>
	/// Data
	/// </summary>
	public DateInputControl JogoData => new DateInputControl(driver, ContainerLocator, "#CONVOCATORIA__JOGO__DATA");

	/// <summary>
	/// Équipa Adversaria
	/// </summary>
	public BaseInputControl JogoEquipaadversaria => new BaseInputControl(driver, ContainerLocator, "container-CONVOCATORIA__JOGO__EQUIPAADVERSARIA", "#CONVOCATORIA__JOGO__EQUIPAADVERSARIA");

	public ConvocatoriaForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "CONVOCATORIA", containerLocator: containerLocator) { }
}
