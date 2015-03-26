using UnityEngine;
using System.Collections;

public class NewHelpPanel : NewBasePanel
{
	public NewBaseButton backButton;
	public NewBaseButton catalogButton;
	public NewBaseButton ARButton;

	public GameObject panelHelpCatalogo;
	public GameObject panelHelpRA;

	public UITweener[] tweens;

	protected override void Awake ()
	{
		backButton.GetAsButton().onClick.AddListener(Hide);	
		backButton.DisableButton();

		catalogButton.GetAsButton().onClick.AddListener(OnClickCatalogButton);
		ARButton.GetAsButton().onClick.AddListener(OnClickARButton);

		base.Awake ();
	}

	public override void Show ()
	{
		panelGO.SetActive(true);
		backButton.EnableButton();
		panelImage.enabled = true;

		OnClickCatalogButton();

		if(tweens != null && tweens.Length > 0)
		{
			for(int i = 0; i < tweens.Length; i++)
			{
				tweens[i].onFinished.Clear();
				tweens[i].AddOnFinished(OnFinishedShowing);
				tweens[i].PlayForward();
			}
		}

		NewUIManager.Instance.GetButton("Button_MM_Catalog").DisableButton();
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

		NewUIManager.Instance.GetButton("Button_MM_Catalog").EnableButton();
		NewUIManager.Instance.GetButton("Button_MM_DC").EnableButton();
		NewUIManager.Instance.EnablePanel("Panel_MainMenu");

		base.Hide ();
	}

   #region BUTTONS
	public void OnClickCatalogButton()
	{
		panelHelpCatalogo.SetActive(true);
		panelHelpRA.SetActive(false);

		catalogButton.ChangeToOriginalColor();
		ARButton.ChangeButtonColor(Color.grey);
	}

	public void OnClickARButton()
	{
		panelHelpCatalogo.SetActive(false);
		panelHelpRA.SetActive(true);

		catalogButton.ChangeButtonColor(Color.grey);
		ARButton.ChangeToOriginalColor();
	}
	#endregion

	public void OnFinishedShowing()
	{
	}

	public void OnFinishedHiding()
	{
		panelGO.SetActive(false);
		panelImage.enabled = false;
	}
}
