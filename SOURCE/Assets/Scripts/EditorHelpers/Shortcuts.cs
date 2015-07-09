#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Collections;

public class Shortcuts : MonoBehaviour 
{
	[MenuItem("Shortcuts/GO Activate-Deactivate &#g")]
	static void EnableDisableGo()
	{
		if(Selection.gameObjects != null && Selection.gameObjects.Length > 0)
		{
			for(int i = 0; i < Selection.gameObjects.Length; i++)
			{
				Selection.gameObjects[i].SetActive(!Selection.gameObjects[i].activeSelf);
			}
		}
		//Selection.activeGameObject.SetActive(!Selection.activeGameObject.activeSelf);
	}

}
#endif
