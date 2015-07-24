using UnityEngine;
using System.Collections;
using Vuforia;

public class NewMainMenuPanel : NewBasePanel 
{
	public NewBaseButton dentalCleanButton;
	public NewBaseButton helpButton;
	public NewBaseButton catalogButton;

	public UnityEngine.UI.Text textMainMenu;

	protected override void Awake ()
	{
		dentalCleanButton.GetAsButton().onClick.AddListener(OnClickedDentalCleanButton);
		helpButton.GetAsButton().onClick.AddListener(OnClickedAjudaButton);
		catalogButton.GetAsButton().onClick.AddListener(OnClickedCatalogoButton);

		base.Awake ();

		if(enableOnStart)
			NewUIManager.Instance.EnablePanel("Panel_MainMenu");
	}

	public override void Show ()
	{
		panelGO.SetActive(true);
		panelImage.enabled = true;

		NewUIManager.Instance.AddBackButtonDelegate(OnClickBackButton);

		textMainMenu.text = "<color=#ED1C24>CLIQUE NOS BOTÕES ABAIXO</color> PARA MAIS INFORMAÇÕES\n OU <color=#ED1C24>APONTE A CÂMERA PARA ALGUM PRODUTO DENTALCLEAN.</color>";

		base.Show ();
	}

	public override void OnClickBackButton()
	{
#if UNITY_EDITOR
		Debug.Log("EXIT!!!!!!!!!!!!!!!!!");
#endif
		Application.Quit();
	}

	public override void Hide ()
	{
		base.Hide ();
	}

	private void CheckButtons()
	{
		if(dentalCleanButton == null)
			dentalCleanButton = NewUIManager.Instance.GetButton("Button_DentalClean");

		if(helpButton == null)
			helpButton = NewUIManager.Instance.GetButton("Button_Ajuda");

		if(catalogButton == null)
			catalogButton = NewUIManager.Instance.GetButton("Button_Catalogo");
	}

	private void OnClickedDentalCleanButton()
	{
		NewUIManager.Instance.EnablePanel("Panel_AboutDentalClean");
		textMainMenu.text = "<color=#E40613>CUIDAMOS BEM DO QUE TE FAZ BEM!</color>";
		Hide();
	}

	private void OnClickedAjudaButton()
	{
		NewUIManager.Instance.EnablePanel("Panel_Help");
		textMainMenu.text = "SAIBA COMO UTILIZAR O SEU APLICATIVO E AUXILIAR SUAS VENDAS.";
		Hide();
	}

	private void OnClickedCatalogoButton()
	{
		NewUIManager.Instance.EnablePanel("Panel_CatalogSelection");
		textMainMenu.text = "SELECIONE A LINHA DE PRODUTOS QUE DESEJA CONSULTAR.";
		Hide();
	}
}
