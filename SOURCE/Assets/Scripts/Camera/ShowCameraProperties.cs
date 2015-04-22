using UnityEngine;
using System.Collections;

public class ShowCameraProperties : MonoBehaviour 
{
	public static ShowCameraProperties instance;

	public Camera cam;

	void Awake()
	{
		instance = this;
	}

	void OnGUI()
	{
		if(GUILayout.Button(" CAMERA SETTINGS \n"))
		{
			if(cam == null)
				cam = (FindObjectOfType(typeof(SetBGCameraLayerBehaviour)) as SetBGCameraLayerBehaviour).GetComponent<Camera>();
		}

		if(cam != null)
		{
			GUILayout.Label(" SIZE: " + cam.orthographicSize);
			cam.orthographicSize = GUILayout.HorizontalSlider(cam.orthographicSize, 0, 10);
			
			GUILayout.Space(30);
			
			GUILayout.Label(" RECT: " + cam.rect);
			Rect camRect = cam.rect;
			
			GUILayout.Space(15);
			camRect.x = GUILayout.HorizontalSlider(camRect.x, -1, 1);
			GUILayout.Space(15);
			camRect.y = GUILayout.HorizontalSlider(camRect.y, -1, 1);
			GUILayout.Space(15);
			camRect.width = GUILayout.HorizontalSlider(camRect.width, -1, 1);
			GUILayout.Space(15);
			camRect.height = GUILayout.HorizontalSlider(camRect.height, -1, 1);
			
			cam.rect = camRect;
		}
	}
}
