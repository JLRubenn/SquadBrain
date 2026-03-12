using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ConvocatoriaForm : Form
{
	/// <summary>
	/// Jogo
	/// </summary>
	public BaseInputControl JogoTitulo => new BaseInputControl(driver, ContainerLocator, "container-CONVOCATORIA__JOGO__TITULO", "#CONVOCATORIA__JOGO__TITULO");

	/// <summary>
	/// Convocados
	/// </summary>
	public ListControl PseudConvocados => new ListControl(driver, ContainerLocator, "#CONVOCATORIA__PSEUD__CONVOCADOS");

	/// <summary>
	/// Data
	/// </summary>
	public DateInputControl JogoData => new DateInputControl(driver, ContainerLocator, "#CONVOCATORIA__JOGO__DATA");

	/// <summary>
	/// Local
	/// </summary>
	public BaseInputControl JogoLocal => new BaseInputControl(driver, ContainerLocator, "container-CONVOCATORIA__JOGO__LOCAL", "#CONVOCATORIA__JOGO__LOCAL");

	/// <summary>
	/// Équipa Adversaria
	/// </summary>
	public BaseInputControl JogoEquipaadversaria => new BaseInputControl(driver, ContainerLocator, "container-CONVOCATORIA__JOGO__EQUIPAADVERSARIA", "#CONVOCATORIA__JOGO__EQUIPAADVERSARIA");

	public ConvocatoriaForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "CONVOCATORIA", containerLocator: containerLocator) { }
}
