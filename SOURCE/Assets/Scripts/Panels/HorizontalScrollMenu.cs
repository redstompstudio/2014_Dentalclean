using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HorizontalScrollMenu : MonoBehaviour 
{
	public Scrollbar scrollBar;

	private bool isSwiping;
	public int steps = 4;
	private int currentStep = 0;
	private float offset;

	public float adjustmentSpeed = 2.0f;

	void Awake()
	{
		offset = 1.0f / (steps - 1);
	}

	void OnEnable()
	{
		EasyTouch.On_Swipe += OnSwipe;
		EasyTouch.On_SwipeEnd += OnSwipeEnd;
	}

	void OnDisable()
	{
		EasyTouch.On_Swipe -= OnSwipe;
		EasyTouch.On_SwipeEnd -= OnSwipeEnd;
	}

	void Update()
	{
		if(!isSwiping)
			scrollBar.value = Mathf.MoveTowards(scrollBar.value, currentStep * offset, Time.deltaTime * adjustmentSpeed);
	}

	public void JumpToIndex(int pIndex)
	{
		currentStep = pIndex;
		scrollBar.value = pIndex * offset;
	}

	public void OnSwipe(Gesture pGesture)
	{
		isSwiping = true;
	}

	public void OnSwipeEnd(Gesture pGesture)
	{
		switch(pGesture.swipe)
		{
		case EasyTouch.SwipeDirection.Left:
			currentStep++;

			if(currentStep > steps - 1)
				currentStep = steps - 1;
			break;
			
		case EasyTouch.SwipeDirection.Right:
			currentStep--;

			if(currentStep < 0)
				currentStep = 0;
			break;
		}

		isSwiping = false;
	}
}
