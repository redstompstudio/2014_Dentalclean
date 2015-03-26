using UnityEngine;
using System.Collections;

public class NewCatalogFiosFitasPanel : NewBasePanel
{
	public NewBaseButton backButton;
	public UITweener[] tweens;
	
	protected override void Awake ()
	{
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
		
		base.Show ();
	}
	
	public override void Hide ()
	{
		NewUIManager.Instance.EnablePanel("Panel_CatalogSelection");
		
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
	
	public void OnFinishedShowing()
	{
	}
	
	public void OnFinishedHiding()
	{
		panelGO.SetActive(false);
		panelImage.enabled = false;
	}
}
