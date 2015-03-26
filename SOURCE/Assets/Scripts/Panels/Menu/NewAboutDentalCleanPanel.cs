using UnityEngine;
using System.Collections;

public class NewAboutDentalCleanPanel : NewBasePanel
{
	public NewBaseButton backButton;
	public UITweener[] tweens;

	protected override void Awake ()
	{
		backButton.GetAsButton().onClick.AddListener(Hide);
		backButton.DisableButton();
		base.Awake ();
	}

	public override void Show ()
	{
		panelGO.SetActive(true);
		backButton.EnableButton();
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
		NewUIManager.Instance.GetButton("Button_MM_Catalog").DisableButton();

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
		NewUIManager.Instance.GetButton("Button_MM_Catalog").EnableButton();
		NewUIManager.Instance.EnablePanel("Panel_MainMenu");

		base.Hide ();
	}

	public void OnFinishedShowing()
	{
	}
	
	public void OnFinishedHiding()
	{
		panelGO.SetActive(false);
		panelImage.enabled = false;
	}
}
