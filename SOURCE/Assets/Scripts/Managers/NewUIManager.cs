using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class NewUIManager : MonoBehaviour 
{
	private static NewUIManager instance;

	public List<NewBasePanel> panels = new List<NewBasePanel>();
	private Dictionary<string, NewBasePanel> panelsDictionary = new Dictionary<string, NewBasePanel>();

	public List<NewBaseButton> buttons = new List<NewBaseButton>();
	private Dictionary<string, NewBaseButton> buttonsDictionary = new Dictionary<string, NewBaseButton>();

	public delegate void OnBackButton();
	public OnBackButton onBackButtonCallback;


	public static NewUIManager Instance
	{
		get{
			if(instance == null)
				instance = FindObjectOfType(typeof(NewUIManager)) as NewUIManager;

			return instance;
		}
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
			ExecuteOnBackButton();
	}

	public void AddPanel(NewBasePanel pPanel)
	{
		if(!panels.Contains(pPanel))
		{
			panels.Add(pPanel);
			panelsDictionary.Add(pPanel.panelName, pPanel);
		}
	}

	public void EnablePanel(string pPanelName)
	{
		if(panelsDictionary.ContainsKey(pPanelName) && !panelsDictionary[pPanelName].isVisible)
		{
			panelsDictionary[pPanelName].Show();
		}
	}

	public void DisablePanel(string pPanelName)
	{
		if(panelsDictionary.ContainsKey(pPanelName))
		{
			panelsDictionary[pPanelName].Hide();
		}
	}

	public void AddButton(NewBaseButton pButton)
	{
		if(!buttons.Contains(pButton))
		{
			buttons.Add(pButton);
			buttonsDictionary.Add(pButton.buttonName, pButton);
		}
	}

	public NewBaseButton GetButton(string pButtonName)
	{
		if(buttonsDictionary.ContainsKey(pButtonName))
			return buttonsDictionary[pButtonName];
			
		return null;
	}

	public void AddBackButtonDelegate(OnBackButton pCallback)
	{
		onBackButtonCallback = pCallback;
	}

	public void ExecuteOnBackButton()
	{
		if(onBackButtonCallback != null)
			onBackButtonCallback();
		else
			Debug.Log("CANNOT EXECUTE!");
		
//		onBackButtonCallback = null;
	}
}
