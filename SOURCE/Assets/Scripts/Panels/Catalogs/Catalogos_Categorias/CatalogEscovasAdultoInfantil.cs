﻿using UnityEngine;
using System.Collections;

public class CatalogEscovasAdultoInfantil : NewBasePanel
{
	public NewBaseButton backButton;
	public UITweener[] tweens;
	
	public NewBaseButton adultoButton;
	public NewBaseButton infantilButton;
	
	protected override void Awake ()
	{
		base.Awake ();

		adultoButton.AddOnClickListener(OnClickAdultoButton);
		infantilButton.AddOnClickListener(OnClickInfantilButton);
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
		NewUIManager.Instance.EnablePanel("Panel_CatalogSelection");
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
		NewUIManager.Instance.EnablePanel("Panel_Escovas_Adulto");
		Hide();
	}

	public void OnClickInfantilButton()
	{
		NewUIManager.Instance.EnablePanel("Panel_Escovas_Infantil");
		Hide();
	}
}
