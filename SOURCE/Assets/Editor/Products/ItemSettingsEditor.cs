using System.Collections;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ItemSettings), true), CanEditMultipleObjects]
public class ItemSettingsEditor : Editor 
{
	private ItemSettings myTarget;

	void OnEnable()
	{
		myTarget = target as ItemSettings;
	}
	
	public override void OnInspectorGUI ()
	{
		myTarget.productID = EditorGUILayout.TextField("Product ID: ", myTarget.productID);
		myTarget.itemInformationText = EditorGUILayout.TextField("Product Information: ", myTarget.itemInformationText, GUILayout.MinHeight(150));

		base.OnInspectorGUI();

		EditorUtility.SetDirty(myTarget);
	}
}
