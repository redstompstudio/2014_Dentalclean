using UnityEngine;
using System.Collections;

public class Catalog_Antissepticos : NewBasePanel
{
	public NewBaseButton backButton;
	public UITweener[] tweens;
	
	public NewBaseButton adultoButton;
	public NewBaseButton infantilButton;
	public NewBaseButton sprayBucalButton;
	
	protected override void Awake ()
	{
		base.Awake ();
		
		adultoButton.AddOnClickListener(OnClickAdultoButton);
		infantilButton.AddOnClickListener(OnClickInfantilButton);
		sprayBucalButton.AddOnClickListener(OnClickSprayBucalButton);
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
	
	public void OnClickAdultoButton()
	{
		Debug.Log("Antissepticos/Adulto");
		NewUIManager.Instance.EnablePanel("Panel_Antisseptico_Adulto");
		Hide();
	}
	
	public void OnClickInfantilButton()
	{
		Debug.Log("Antissepticos/Infantil");
		NewUIManager.Instance.EnablePanel("Panel_Antisseptico_Infantil");
		Hide();
	}
	
	public void OnClickSprayBucalButton()
	{
		Debug.Log("Antissepticos/SprayBucal");
		NewUIManager.Instance.EnablePanel("Panel_Antisseptico_Spray");
		Hide();
	}
}
