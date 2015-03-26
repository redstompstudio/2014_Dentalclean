using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LockScreenScript : MonoBehaviour 
{
	public Scrollbar lockScreenScrollbar;

	void Awake()
	{
	}

	public void OnValueChanged(float pValue)
	{
		Debug.Log(pValue);

		if(pValue <= 0.0f)
		{
			gameObject.SetActive(false);
		}
	}
}
	