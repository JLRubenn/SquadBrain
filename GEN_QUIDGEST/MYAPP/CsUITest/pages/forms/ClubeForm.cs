using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class ClubeForm : Form
{
	/// <summary>
	/// Foto
	/// </summary>
	public BaseInputControl ClubeFoto => new BaseInputControl(driver, ContainerLocator, "container-CLUBE___CLUBEFOTO____", "#CLUBE___CLUBEFOTO____");

	/// <summary>
	/// New Group
	/// </summary>
	public IWebElement PseudNewgrp04 => throw new NotImplementedException();

	/// <summary>
	/// Informações DO clube
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp01 => new CollapsibleZoneControl(driver, ContainerLocator, "#CLUBE___PSEUDNEWGRP01-container");

	/// <summary>
	/// Nome
	/// </summary>
	public BaseInputControl ClubeNome => new BaseInputControl(driver, ContainerLocator, "container-CLUBE___CLUBENOME____", "#CLUBE___CLUBENOME____");

	/// <summary>
	/// Escalão
	/// </summary>
	public BaseInputControl ClubeEscalao => new BaseInputControl(driver, ContainerLocator, "container-CLUBE___CLUBEESCALAO_", "#CLUBE___CLUBEESCALAO_");

	/// <summary>
	/// Época
	/// </summary>
	public BaseInputControl ClubeEpoca => new BaseInputControl(driver, ContainerLocator, "container-CLUBE___CLUBEEPOCA___", "#CLUBE___CLUBEEPOCA___");

	/// <summary>
	/// responsaveis do clube
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp02 => new CollapsibleZoneControl(driver, ContainerLocator, "#CLUBE___PSEUDNEWGRP02-container");

	/// <summary>
	/// Presidente
	/// </summary>
	public BaseInputControl ClubePresidente => new BaseInputControl(driver, ContainerLocator, "container-CLUBE__CLUBE__PRESIDENTE", "#CLUBE__CLUBE__PRESIDENTE");

	/// <summary>
	/// Coordenador Técnico
	/// </summary>
	public BaseInputControl ClubeCoordtecn => new BaseInputControl(driver, ContainerLocator, "container-CLUBE__CLUBE__COORDTECN", "#CLUBE__CLUBE__COORDTECN");

	/// <summary>
	/// Coordenador Formação
	/// </summary>
	public BaseInputControl ClubeCoordform => new BaseInputControl(driver, ContainerLocator, "container-CLUBE__CLUBE__COORDFORM", "#CLUBE__CLUBE__COORDFORM");

	/// <summary>
	/// Equipa Técnica
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp03 => new CollapsibleZoneControl(driver, ContainerLocator, "#CLUBE___PSEUDNEWGRP03-container");

	/// <summary>
	/// Treinador Principal
	/// </summary>
	public BaseInputControl ClubeTreinadorprincipal => new BaseInputControl(driver, ContainerLocator, "container-CLUBE__CLUBE__TREINADORPRINCIPAL", "#CLUBE__CLUBE__TREINADORPRINCIPAL");

	/// <summary>
	/// Treinador Adjunto
	/// </summary>
	public BaseInputControl ClubeTreinadoradjunto => new BaseInputControl(driver, ContainerLocator, "container-CLUBE__CLUBE__TREINADORADJUNTO", "#CLUBE__CLUBE__TREINADORADJUNTO");

	public ClubeForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "CLUBE", containerLocator: containerLocator) { }
}
