using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NavigationButton : MonoBehaviour 
{
	public Button button;

	public NewBasePanel disablePanel;
	public string openPanel;

	public void Awake()
	{
		button = GetComponent<Button>();
		button.onClick.AddListener(OnClickButton);
	}

	public void OnClickButton()
	{
		NewUIManager.Instance.DisablePanel(disablePanel.panelName);
		NewUIManager.Instance.EnablePanel(openPanel);
	}
}
