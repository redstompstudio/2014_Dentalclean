using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Vuforia;

public class CameraFocusButton : MonoBehaviour 
{
	public Button focusButton;
	public int focusMode = 0;

	void Awake()
	{
		if(focusButton == null)
			focusButton = GetComponent<Button>();

		focusButton.onClick.RemoveAllListeners();
		focusButton.onClick.AddListener(ChangeFocus);
	}

	public void ChangeFocus()
	{
		focusMode++;
		
		if(focusMode > 4)
			focusMode = 0;

		bool focusModeSet = CameraDevice.Instance.SetFocusMode((CameraDevice.FocusMode)focusMode);

#if UNITY_EDITOR
		Debug.Log("Set to: " + (CameraDevice.FocusMode)focusMode);
		
		if(!focusModeSet)
			Debug.LogError("Failed to set focus Mode: " + (CameraDevice.FocusMode)focusMode);
#endif
	}
}
