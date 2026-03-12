using quidgest.uitests.pages.forms.core;

#nullable enable

namespace quidgest.uitests.pages.forms;

[System.CodeDom.Compiler.GeneratedCode("Genio", "")]
public class JogadorForm : Form
{
	/// <summary>
	/// Foto
	/// </summary>
	public BaseInputControl JogadorFoto => new BaseInputControl(driver, ContainerLocator, "container-JOGADOR__JOGADOR__FOTO", "#JOGADOR__JOGADOR__FOTO");

	/// <summary>
	/// Ficha Individual
	/// </summary>
	public CollapsibleZoneControl PseudNewgrp01 => new CollapsibleZoneControl(driver, ContainerLocator, "#JOGADOR_PSEUDNEWGRP01-container");

	/// <summary>
	/// Clube
	/// </summary>
	public LookupControl ClubeNome => new LookupControl(driver, ContainerLocator, "container-JOGADOR_CLUBENOME____");
	public SeeMorePage ClubeNomeSeeMorePage => new SeeMorePage(driver, "JOGADOR", "JOGADOR_CLUBENOME____");

	/// <summary>
	/// Numero Camisola
	/// </summary>
	public BaseInputControl JogadorNumerocamisola => new BaseInputControl(driver, ContainerLocator, "container-JOGADOR__JOGADOR__NUMEROCAMISOLA", "#JOGADOR__JOGADOR__NUMEROCAMISOLA");

	/// <summary>
	/// Nome
	/// </summary>
	public BaseInputControl JogadorNome => new BaseInputControl(driver, ContainerLocator, "container-JOGADOR__JOGADOR__NOME", "#JOGADOR__JOGADOR__NOME");

	/// <summary>
	/// Data Nascimento
	/// </summary>
	public DateInputControl JogadorDatanascimento => new DateInputControl(driver, ContainerLocator, "#JOGADOR__JOGADOR__DATANASCIMENTO");

	/// <summary>
	/// Pé Dominante
	/// </summary>
	public EnumControl JogadorPedominante => new EnumControl(driver, ContainerLocator, "container-JOGADOR__JOGADOR__PEDOMINANTE");

	/// <summary>
	/// Posição Habitual
	/// </summary>
	public EnumControl JogadorPosicao => new EnumControl(driver, ContainerLocator, "container-JOGADOR__JOGADOR__POSICAO");

	/// <summary>
	/// Posição Segundaria
	/// </summary>
	public EnumControl JogadorPosicaosegundaria => new EnumControl(driver, ContainerLocator, "container-JOGADOR__JOGADOR__POSICAOSEGUNDARIA");

	/// <summary>
	/// Equipa Anterior
	/// </summary>
	public BaseInputControl JogadorEquipaanterior => new BaseInputControl(driver, ContainerLocator, "container-JOGADOR__JOGADOR__EQUIPAANTERIOR", "#JOGADOR__JOGADOR__EQUIPAANTERIOR");

	public JogadorForm(IWebDriver driver, FORM_MODE mode, By? containerLocator = null)
		: base(driver, mode, "JOGADOR", containerLocator: containerLocator) { }
}
