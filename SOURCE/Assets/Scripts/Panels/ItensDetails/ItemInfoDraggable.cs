using UnityEngine;
using System.Collections;

public class ItemInfoDraggable : MonoBehaviour 
{
	private Transform cachedTransform;

	public Vector3 maxScale = new Vector3(1.4f, 1.4f, 1.4f);
	public Vector3 minScale = Vector3.one;

	public void OnEnable()
	{
		if(cachedTransform == null)
			cachedTransform = GetComponent<Transform>();

		EasyTouch.On_Pinch += OnPinch;
	}

	public void OnDisable()
	{
		EasyTouch.On_Pinch -= OnPinch;
	}

	public void Reset()
	{
		cachedTransform.localScale = Vector3.one;
	}

	void OnPinch(Gesture pGesture)
	{
		cachedTransform.localScale += Vector3.one * pGesture.deltaPinch * Time.deltaTime * Time.deltaTime;

		if(cachedTransform.localScale.x > maxScale.x)
		{
			cachedTransform.localScale = maxScale;
		}
		else if(cachedTransform.localScale.x < minScale.x)
		{
			cachedTransform.localScale = minScale;
		}
	}
}
