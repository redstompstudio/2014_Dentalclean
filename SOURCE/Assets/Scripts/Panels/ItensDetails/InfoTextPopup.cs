using UnityEngine;
using System.Collections;

public class InfoTextPopup : NewBasePanel
{
	public static InfoTextPopup instance;

	private int playintTweensCount;
	public UITweener[] tweens;

	protected override void Awake ()
	{
		instance = this;
		base.Awake ();
	}

	public void OnOpen()
	{
	}

	public override void Show ()
	{
		panelGO.SetActive(true);

		panelImage.enabled = true;
		
		if(tweens != null && tweens.Length > 0)
		{
			int index = 0;

			tweens[index].onFinished.Clear();
			tweens[index].AddOnFinished(OnFinishedShowing);
			tweens[index].PlayForward();
			
			//Background Tween...gambi...
			tweens[2].onFinished.Clear();
			tweens[2].AddOnFinished(OnFinishedShowing);
			tweens[2].PlayForward();
		}
		else
			OnFinishedShowing();
		
		NewUIManager.Instance.GetButton("Button_MM_Help").DisableButton();
		NewUIManager.Instance.GetButton("Button_MM_DC").DisableButton();

		NewUIManager.Instance.AddBackButtonDelegate(OnClickBackButton);
		
		base.Show ();
	}
	
	public override void Hide ()
	{
		if(tweens != null && tweens.Length > 0)
		{
			int index = 0;

			tweens[index].onFinished.Clear();
			tweens[index].AddOnFinished(OnFinishedHiding);
			tweens[index].PlayReverse();
			
			//Background Tween...gambi...
			tweens[2].onFinished.Clear();
			tweens[2].AddOnFinished(OnFinishedHiding);
			tweens[2].PlayReverse();
			
			playintTweensCount = 2;
		}
		else
			OnFinishedHiding();
		
		base.Hide ();
	}
	
	public void OnFinishedShowing()
	{
	}
	
	public void OnFinishedHiding()
	{
		
		playintTweensCount--;
		
		if(playintTweensCount == 0)
		{
			panelGO.SetActive(false);
			panelImage.enabled = false;
		}
	}
	
	public void OnClickBackButton()
	{
		Hide();
	}
}
