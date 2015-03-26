using UnityEngine;
using System.Collections;

public class Catalog_Escovas_Adulto : NewBasePanel
{
	public NewBaseButton backButton;
	public UITweener[] tweens;
	
	public NewBaseButton premiumButton;
	public NewBaseButton valorButton;
	public NewBaseButton popularButton;
	public NewBaseButton promocionalButton;
	
	protected override void Awake ()
	{
		base.Awake ();
		
		premiumButton.AddOnClickListener(OnClickPremiumButton);
		valorButton.AddOnClickListener(OnClickValorButton);
		popularButton.AddOnClickListener(OnClickPopularButton);
		promocionalButton.AddOnClickListener(OnClickPromocionalButton);
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
		NewUIManager.Instance.AddBackButtonDelegate(OnClickBackButton);

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
		NewUIManager.Instance.EnablePanel("Panel_Escovas_AdultoInfantil");
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
		NewUIManager.Instance.EnablePanel("Panel_Escovas_Premium_Adulto");
	}
	
	public void OnClickValorButton()
	{
		Hide();
		NewUIManager.Instance.EnablePanel("Panel_Escovas_Valor_Adulto");
	}
	
	public void OnClickPopularButton()
	{
		Hide();
		NewUIManager.Instance.EnablePanel("Panel_Escovas_Popular_Adulto");
	}
	
	public void OnClickPromocionalButton()
	{
		Hide();
		NewUIManager.Instance.EnablePanel("Panel_Escovas_Promocional_Adulto");
	}
}
