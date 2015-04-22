using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraToTexture : MonoBehaviour 
{
	WebCamDevice[] devices;
	UnityEngine.UI.RawImage image;
	WebCamTexture texture;
	Material myMaterial;

	// Use this for initialization
	void Start () 
	{
		image = GetComponent<UnityEngine.UI.RawImage>();
		devices = WebCamTexture.devices;
		myMaterial = renderer.material;

		if(devices != null && devices.Length > 0)
		{
			texture = new WebCamTexture(devices[0].name, 900, 1600, 30);

			if(texture != null)
				texture.Play();

			myMaterial.mainTexture = texture;
			/*
			image.texture = texture;
			image.material.mainTexture = texture;
			*/
		}
	}

	void Update()
	{
		if(texture == null)
		{
			texture = new WebCamTexture(devices[0].name, 900, 1600, 30);

			if(texture != null)
				texture.Play();

			if(myMaterial)
				myMaterial.mainTexture = texture;
		}
		else
		{
			texture.Play();

			if(myMaterial)
				myMaterial.mainTexture = texture;
		}
	}
}
