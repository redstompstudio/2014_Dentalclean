using UnityEngine;
using System.Collections;
using Vuforia;

public class DCTrackableProduct : MonoBehaviour, ITrackableEventHandler
{
	private TrackableBehaviour mTrackableBehaviour;

	public string productID;
	private bool isTracking;

	void Start()
	{
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
	}
	
	/// <summary>
	/// Implementation of the ITrackableEventHandler function called when the
	/// tracking state changes.
	/// </summary>
	public void OnTrackableStateChanged(
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
		    newStatus == TrackableBehaviour.Status.TRACKED ||
		    newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			OnTrackingFound();
		}
		else
		{
			OnTrackingLost();
		}
	}
	
	private void OnTrackingFound()
	{
#if UNITY_EDITOR
		Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
#endif
		isTracking = true;
		ProductsManager.Instance.GetProduct(productID).OnClickButton();
	}

	private void OnTrackingLost()
	{
#if UNITY_EDITOR
		Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
#endif
		isTracking = false;
	}
}
