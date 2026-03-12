using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class TreinoForm : Form
{
	/// <summary>
	/// dados do treino
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp01 => new CollapsibleZoneControl(driver, ContainerLocator, "#TREINO__PSEUDNEWGRP01-container");

	/// <summary>
	/// Numero Jogadores
	/// </summary>
	public BaseInputControl TreinoNumjogadores => new BaseInputControl(driver, ContainerLocator, "container-TREINO__TREINO__NUMJOGADORES", "#TREINO__TREINO__NUMJOGADORES");

	/// <summary>
	/// Microciclo
	/// </summary>
	public BaseInputControl TreinoMicrociclo => new BaseInputControl(driver, ContainerLocator, "container-TREINO__TREINO__MICROCICLO", "#TREINO__TREINO__MICROCICLO");

	/// <summary>
	/// Mesociclos
	/// </summary>
	public BaseInputControl TreinoMesociclos => new BaseInputControl(driver, ContainerLocator, "container-TREINO__TREINO__MESOCICLOS", "#TREINO__TREINO__MESOCICLOS");

	/// <summary>
	/// Data
	/// </summary>
	public DateInputControl TreinoData => new DateInputControl(driver, ContainerLocator, "#TREINO__TREINO__DATA", "dd/MM/yyyy HH:mm");

	/// <summary>
	/// detalhes do treino
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp02 => new CollapsibleZoneControl(driver, ContainerLocator, "#TREINO__PSEUDNEWGRP02-container");

	/// <summary>
	/// Objetivo
	/// </summary>
	public BaseInputControl TreinoObjetivo => new BaseInputControl(driver, ContainerLocator, "container-TREINO__TREINO__OBJETIVO", "#TREINO__TREINO__OBJETIVO");

	/// <summary>
	/// Material
	/// </summary>
	public BaseInputControl TreinoMaterial => new BaseInputControl(driver, ContainerLocator, "container-TREINO__TREINO__MATERIAL", "#TREINO__TREINO__MATERIAL");

	/// <summary>
	/// Exercicios
	/// </summary>
	public ListControl PseudExercicio => new ListControl(driver, ContainerLocator, "#TREINO__PSEUD__EXERCICIO");

	public TreinoForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "TREINO", containerLocator: containerLocator) { }
}
