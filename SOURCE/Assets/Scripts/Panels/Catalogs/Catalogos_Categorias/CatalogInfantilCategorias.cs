using UnityEngine;
using System.Collections;

public class CatalogInfantilCategorias : NewBasePanel
{
	public NewBaseButton backButton;
	public UITweener[] tweens;
	
	public NewBaseButton batmanButton;
	public NewBaseButton garfieldButton;
	public NewBaseButton scoobyDooButton;
	public NewBaseButton peppaPigButton;
	
	protected override void Awake ()
	{
		base.Awake ();
		
		batmanButton.AddOnClickListener(OnClickBatmanButton);
		garfieldButton.AddOnClickListener(OnClickGarfieldButton);
		scoobyDooButton.AddOnClickListener(OnClickScoobyDooButton);
		peppaPigButton.AddOnClickListener(OnClickPeppaPigButton);
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
		Hide();
		NewUIManager.Instance.EnablePanel("Panel_Escovas_Infantil");
	}
	
	public void OnFinishedShowing()
	{

	}
	
	public void OnFinishedHiding()
	{
		panelGO.SetActive(false);
		panelImage.enabled = false;
	}
	
	public void OnClickBatmanButton()
	{
		NewUIManager.Instance.EnablePanel("Panel_Escovas_Infantil_Licenciadas_Batman");
		Hide();
	}
	
	public void OnClickGarfieldButton()
	{
		NewUIManager.Instance.EnablePanel("Panel_Escovas_Infantil_Licenciadas_Garfield");
		Hide();
	}

	public void OnClickScoobyDooButton()
	{
		NewUIManager.Instance.EnablePanel("Panel_Escovas_Infantil_Licenciadas_ScoobyDoo");
		Hide();
	}

	public void OnClickPeppaPigButton()
	{
		NewUIManager.Instance.EnablePanel("Panel_Escovas_Infantil_Licenciadas_PeppaPig");
		Hide();
	}
}
