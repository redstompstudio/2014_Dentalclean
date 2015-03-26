using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewBaseButton : MonoBehaviour 
{
	public string buttonName = "";
	private Button button;
	private Text buttonText;

	public bool disableGOWhenButtonIsInactive = false;
	private Color originalNormalColor;
	
	protected virtual void Awake()
	{
		NewUIManager.Instance.AddButton(this);
		
		button = GetComponent<Button>();
		buttonText = GetComponentInChildren<Text>();

		originalNormalColor = GetAsButton().colors.normalColor;
	}
	
	public void EnableButton()
	{
		if(button == null)
			button = GetComponent<Button>();

		button.interactable = true;

		if(disableGOWhenButtonIsInactive)
			gameObject.SetActive(true);
	}
	
	public void DisableButton()
	{
		if(button == null)
			button = GetComponent<Button>();

		button.interactable = false;

		if(disableGOWhenButtonIsInactive)
			gameObject.SetActive(false);
	}

	public void AddOnClickListener(UnityEngine.Events.UnityAction pAction)
	{
		if(button == null)
			button = GetComponent<Button>();

		button.onClick.AddListener(pAction);
	}
	
	public void SetButtonText(string pText)
	{
		buttonText.text = pText;
	}
	
	public Button GetAsButton()
	{
		if(button == null)
			button = GetComponent<Button>();

		return button;
	}

	public void ChangeButtonColor(Color pColor)
	{
		ColorBlock colors = GetAsButton().colors;
		colors.normalColor = pColor;
		GetAsButton().colors = colors;
	}

	public void ChangeToOriginalColor()
	{
		ColorBlock colors = GetAsButton().colors;
		colors.normalColor = originalNormalColor;
		GetAsButton().colors = colors;
	}
}
