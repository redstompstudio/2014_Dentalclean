using UnityEngine;
using System.Collections;

public class NewCatalogPanel : NewBasePanel
{
	public NewBaseButton backButton;
	public UITweener[] tweens;

	public NewBaseButton button_Escovas;
	public NewBaseButton button_FiosFitas;
	public NewBaseButton button_Antissepticos;
	public NewBaseButton button_Complementos;
	public NewBaseButton button_CremeGel;
	public NewBaseButton button_LinhaPRO;

	protected override void Awake ()
	{
//		backButton.GetAsButton().onClick.AddListener(Hide);
//		backButton.DisableButton();

		button_Escovas.GetAsButton().onClick.AddListener(OnClickCatalogEscovas);
		button_FiosFitas.GetAsButton().onClick.AddListener(OnClickCatalogFiosFitas);
		button_Antissepticos.GetAsButton().onClick.AddListener(OnClickCatalogAntissepticos);
		button_Complementos.GetAsButton().onClick.AddListener(OnClickCatalogComplementos);
		button_CremeGel.AddOnClickListener(OnClickCatalogCremeGel);
		button_LinhaPRO.GetAsButton().onClick.AddListener(OnClickCatalogLinhaPro);


		base.Awake ();
	}
	
	public override void Show ()
	{
		panelGO.SetActive(true);

		backButton.EnableButton();
		backButton.GetAsButton().onClick.RemoveAllListeners();
		backButton.GetAsButton().onClick.AddListener(Hide);

		panelImage.enabled = true;

		if(tweens != null && tweens.Length > 0)
		{
			for(int i = 0; i < tweens.Length; i++)
			{
				tweens[i].onFinished.Clear();
				tweens[i].AddOnFinished(OnFinishedShowing);
				tweens[i].PlayForward();
			}
		}

		NewUIManager.Instance.GetButton("Button_MM_Help").DisableButton();
		NewUIManager.Instance.GetButton("Button_MM_DC").DisableButton();

		NewUIManager.Instance.AddBackButtonDelegate(Hide);

		base.Show ();
	}
	
	public override void Hide ()
	{
		backButton.DisableButton();

		if(tweens != null && tweens.Length > 0)
		{
			for(int i = 0; i < tweens.Length; i++)
			{
				tweens[i].onFinished.Clear();
				tweens[i].AddOnFinished(OnFinishedHiding);
				tweens[i].PlayReverse();
			}
		}

		NewUIManager.Instance.GetButton("Button_MM_Help").EnableButton();
		NewUIManager.Instance.GetButton("Button_MM_DC").EnableButton();
		NewUIManager.Instance.EnablePanel("Panel_MainMenu");

		base.Hide ();
	}
	
	public void OnFinishedShowing()
	{
//		NewUIManager.Instance.GetButton("Button_MM_Help").DisableButton();
//		NewUIManager.Instance.GetButton("Button_MM_DC").DisableButton();
	}
	
	public void OnFinishedHiding()
	{
		panelGO.SetActive(false);
		panelImage.enabled = false;
	}

	#region CATALOG OPTIONS
	public void OnClickCatalogEscovas()
	{
		Hide();
		NewUIManager.Instance.EnablePanel("Panel_Escovas_AdultoInfantil");
	}

	public void OnClickCatalogFiosFitas()
	{
		Hide();
		NewUIManager.Instance.EnablePanel("Panel_FiosFitas");
	}

	public void OnClickCatalogAntissepticos()
	{
		Hide();
		NewUIManager.Instance.EnablePanel("Panel_Antissepticos");
	}

	public void OnClickCatalogComplementos()
	{
		Hide();
		NewUIManager.Instance.EnablePanel("Panel_Complementos");
	}

	public void OnClickCatalogLinhaPro()
	{
		Hide();
		NewUIManager.Instance.EnablePanel("Panel_LinhaProfissional");
	}

	public void OnClickCatalogCremeGel()
	{
		Hide();
		NewUIManager.Instance.EnablePanel("Panel_CremeGel");
	}
	#endregion
}
