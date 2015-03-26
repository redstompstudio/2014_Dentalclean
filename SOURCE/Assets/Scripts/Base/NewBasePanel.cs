using UnityEngine;
using System.Collections;

public class NewBasePanel : MonoBehaviour 
{
	public string panelName = "";
	public GameObject panelGO;
	public UnityEngine.UI.Image panelImage;

	public bool enableOnStart = false;
	public bool isVisible;

	protected virtual void Awake()
	{
		NewUIManager.Instance.AddPanel(this);

		if(!enableOnStart)
			panelGO.SetActive(false);
	}

	public virtual void Show()
	{
		isVisible = true;
	}

	public virtual void Hide()
	{
		isVisible = false;
	}
}
