using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TweenImageAlpha))]
public class TweenImageAlphaEditor : UITweenerEditor
{
	public override void OnInspectorGUI ()
	{
		GUILayout.Space(6f);
		NGUIEditorTools.SetLabelWidth(120f);
		
		TweenImageAlpha tw = target as TweenImageAlpha;
		GUI.changed = false;
		
		float from = EditorGUILayout.Slider("From", tw.from, 0f, 1f);
		float to = EditorGUILayout.Slider("To", tw.to, 0f, 1f);
		
		if (GUI.changed)
		{
			NGUIEditorTools.RegisterUndo("Tween Change", tw);
			tw.from = from;
			tw.to = to;
			NGUITools.SetDirty(tw);
		}
		
		DrawCommonProperties();
	}
}
