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

	private const string mainMenuPanelName = "Panel_MainMenu";

	public static NewUIManager Instance
	{
		get{
			if(instance == null)
				instance = FindObjectOfType(typeof(NewUIManager)) as NewUIManager;

			return instance;
		}
	}

#if DEBUG_OPENPANELS
	public bool hasOpenPanel;
	public int openedPanelsCount;
#endif
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
			ExecuteOnBackButton();

#if DEBUG_OPENPANELS
		hasOpenPanel = false;
		openedPanelsCount = 0;

		foreach(string key in panelsDictionary.Keys)
		{
			if(panelsDictionary[key].isVisible)
			{
				hasOpenPanel = true;
				Debug.Log(panelsDictionary[key].panelName);
				openedPanelsCount++;
			}
		}

		Debug.Log("###################");
#endif
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
#if UNITY_EDITOR
		if(panelsDictionary[pPanelName].isVisible)
			Debug.Log(pPanelName + " is activated!");
#endif
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

	public bool IsPanelEnabled(string pPanelName)
	{
		return panelsDictionary[pPanelName].isVisible;
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

//		onBackButtonCallback = null;
	}
}
