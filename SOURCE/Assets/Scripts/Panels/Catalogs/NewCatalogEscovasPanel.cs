using UnityEngine;
using System.Collections;

public class NewCatalogEscovasPanel : NewBasePanel
{
	public NewBaseButton backButton;
	public UITweener[] tweens;

	public NewBaseButton premiumButton;
	public NewBaseButton valorButton;
	public NewBaseButton popularButton;
	public NewBaseButton promocionalButton;
	public NewBaseButton licenciadasButton;
	
	protected override void Awake ()
	{
		base.Awake ();

		premiumButton.AddOnClickListener(OnClickPremiumButton);
		valorButton.AddOnClickListener(OnClickValorButton);
		popularButton.AddOnClickListener(OnClickPopularButton);
		promocionalButton.AddOnClickListener(OnClickPromocionalButton);
		licenciadasButton.AddOnClickListener(OnClickLicenciadasButton);
	}
	
	public override void Show ()
	{
		panelGO.SetActive(true);

		backButton.EnableButton();
		backButton.GetAsButton().onClick.RemoveAllListeners();
		backButton.GetAsButton().onClick.AddListener(OnClickBackButton);

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
		
		base.Show ();
	}
	
	public override void Hide ()
	{
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
		
		base.Hide ();
	}

	public void OnClickBackButton()
	{
		NewUIManager.Instance.EnablePanel("Panel_CatalogSelection");
		Hide();
	}
	
	public void OnFinishedShowing()
	{
	}
	
	public void OnFinishedHiding()
	{
		panelGO.SetActive(false);
		panelImage.enabled = false;
	}

	public void OnClickPremiumButton()
	{
		Hide();
		NewUIManager.Instance.EnablePanel("Panel_Catalog_Escovas_Premium");
	}

	public void OnClickValorButton()
	{
		Debug.Log("Valor");
	}

	public void OnClickPopularButton()
	{
		Debug.Log("Popular");
	}

	public void OnClickPromocionalButton()
	{
		Debug.Log("Promocional");
	}

	public void OnClickLicenciadasButton()
	{
		Debug.Log("Licenciadas");
	}

}
