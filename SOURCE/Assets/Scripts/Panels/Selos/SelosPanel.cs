using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelosPanel : NewBasePanel
{
	public static SelosPanel instance;

	public Text labelTitle;
	public UnityEngine.UI.Image labelIcon;
	public Text labelDescription;
	public NewBaseButton backButton;

	public Text labelTitleUso;
	public UnityEngine.UI.Image labelIconUso;
	public Text labelDescriptionUso;
	public NewBaseButton backButtonUso;

	private int playintTweensCount;
	public UITweener[] tweens;

	private SeloInfos seloInfo;

	public GameObject[] selosMaiores;

	protected override void Awake ()
	{
		instance = this;
		base.Awake ();
	}

	public void OnOpen(SeloInfos pInfo)
	{
		seloInfo = pInfo;

		if(seloInfo.category != LABEL_CATEGORY.USO_PRODUTOS)
		{
			if(labelTitle != null)
				labelTitle.text = seloInfo.labelTitle;

			labelIcon.sprite = seloInfo.labelIcon;
			labelDescription.text = seloInfo.labelDescription;
		}
		else
		{
			labelTitleUso.text = seloInfo.labelTitle;
			labelIconUso.sprite = seloInfo.labelIcon;
			labelDescriptionUso.text = seloInfo.labelDescription;
		}

		if(selosMaiores != null)
		{
			for(int i = 0; i < selosMaiores.Length; i++)
			{
				selosMaiores[i].SetActive(false);
			}
		}

		NewUIManager.Instance.EnablePanel(panelName);
	}

	public override void Show ()
	{
		panelGO.SetActive(true);

		if(seloInfo.category != LABEL_CATEGORY.USO_PRODUTOS)
		{
			backButton.EnableButton();
			backButton.GetAsButton().onClick.RemoveAllListeners();
			backButton.GetAsButton().onClick.AddListener(OnClickBackButton);
		}
		else
		{
			backButtonUso.EnableButton();
			backButtonUso.GetAsButton().onClick.RemoveAllListeners();
			backButtonUso.GetAsButton().onClick.AddListener(OnClickBackButton);
		}
		
		panelImage.enabled = true;
		
		if(tweens != null && tweens.Length > 0)
		{
			int index = 0;

			if(seloInfo.category == LABEL_CATEGORY.USO_PRODUTOS)	//Tela diferente no caso de ser dessa catergoria....
				index = 1;

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
			if(seloInfo.category == LABEL_CATEGORY.USO_PRODUTOS)	//Tela diferente no caso de ser dessa catergoria....
				index = 1;
			
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
