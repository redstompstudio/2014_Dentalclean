using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NewLockScreenPanel : NewBasePanel
{
	public Scrollbar lockScreenScrollbar;

	public override void Show ()
	{
		base.Show ();
	}

	public override void Hide ()
	{
		base.Hide ();

		panelGO.SetActive(false);
	}

	public void OnValueChanged(float pValue)
	{
		if(pValue <= 0.05f)
		{
			NewUIManager.Instance.EnablePanel("Panel_MainMenu");
			Hide();
		}
	}
}