/***********************************************
				EasyTouch Controls
	Copyright © 2014-2015 The Hedgehog Team
  http://www.blitz3dfr.com/teamtalk/index.php
		
	  The.Hedgehog.Team@gmail.com
		
**********************************************/
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;

[System.Serializable]
public class ETCButton : ETCBase, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler { 

	#region Unity Events
	[System.Serializable] public class OnDownHandler : UnityEvent{}
	[System.Serializable] public class OnPressedHandler : UnityEvent{}
	[System.Serializable] public class OnPressedValueandler : UnityEvent<float>{}
	[System.Serializable] public class OnUPHandler : UnityEvent{}

	[SerializeField] public OnDownHandler onDown;
	[SerializeField] public OnPressedHandler onPressed;
	[SerializeField] public OnPressedValueandler onPressedValue;
	[SerializeField] public OnUPHandler onUp;
	#endregion

	#region Members

	#region Public members
	public ETCAxis axis;

	public Sprite normalSprite;
	public Color normalColor;

	public Sprite pressedSprite;
	public Color pressedColor;	
	#endregion

	#region Private members
	private UnityEngine.UI.Image cachedImage; 
	private bool isOnPress;
	private GameObject previousDargObject;
	#endregion

	#endregion

	#region Constructor
	public ETCButton(){

		axis = new ETCAxis( "Button");
		_visible = true;
		_activated = true;

		showPSInspector = true; 
		showSpriteInspector = false;
		showBehaviourInspector = false;
		showEventInspector = false;
	}
	#endregion

	#region Monobehaviour Callback
	protected override void Awake (){
		base.Awake ();
		cachedImage = GetComponent<UnityEngine.UI.Image>();
	}

	void Start(){
		isOnPress = false;
	}

	void Update(){
		if (!useFixedUpdate){
			UpdateButton();
		}
	}

	void FixedUpdate(){
		if (useFixedUpdate){
			UpdateButton();
		}
	}
	#endregion

	#region UI Callback
	public void OnPointerEnter(PointerEventData eventData){
		if (isSwipeIn &&  axis.axisState == ETCAxis.AxisState.None){

			if (eventData.pointerDrag != null){
				if (eventData.pointerDrag.GetComponent<ETCBase>() && eventData.pointerDrag!= gameObject){
					previousDargObject=eventData.pointerDrag;
				}
			}

			eventData.pointerDrag = gameObject;
			eventData.pointerPress = gameObject;
			OnPointerDown( eventData);
		}
	}

	public void OnPointerDown(PointerEventData eventData){

		if (_activated){
			axis.ResetAxis();
			axis.axisState = ETCAxis.AxisState.Down;

			isOnPress = false;

			onDown.Invoke();
			ApllyState();
		}
	}

	public void OnPointerUp(PointerEventData eventData){
	
		isOnPress = false;
		axis.axisState = ETCAxis.AxisState.Up;
		axis.axisValue = 0;
		onUp.Invoke();
		ApllyState();

		if (previousDargObject){
			ExecuteEvents.Execute<IPointerUpHandler> (previousDargObject, eventData, ExecuteEvents.pointerUpHandler);
			previousDargObject = null;
		}
	}

	public void OnPointerExit(PointerEventData eventData){
		if (axis.axisState == ETCAxis.AxisState.Press && !isSwipeOut){
			OnPointerUp(eventData);
		}
	}
	#endregion

	#region Button Update
	private void UpdateButton(){

		if (axis.axisState == ETCAxis.AxisState.Down){
			isOnPress = true;
			StartCoroutine( SwitchToPress() );
		}

		if (isOnPress){
			axis.UpdateButton();
			onPressed.Invoke();
			onPressedValue.Invoke( axis.axisValue);

		}


		if (axis.axisState == ETCAxis.AxisState.Up){
			isOnPress = false;
			StartCoroutine( SwitchToNone() );
		}
	}

	IEnumerator SwitchToPress(){

		yield return new WaitForEndOfFrame();
		axis.axisState = ETCAxis.AxisState.Press;
	}

	IEnumerator SwitchToNone(){
		
		yield return new WaitForEndOfFrame();
		axis.axisState = ETCAxis.AxisState.None;
	}
	#endregion

	#region Private Method
	protected override void SetVisible (){
		GetComponent<UnityEngine.UI.Image>().enabled = _visible;
	}

	private void ApllyState(){

		switch (axis.axisState){
		case ETCAxis.AxisState.Down:
			case ETCAxis.AxisState.Press:
				cachedImage.sprite = pressedSprite;
				cachedImage.color = pressedColor;
				break;
			default:
				cachedImage.sprite = normalSprite;
				cachedImage.color = normalColor;
				break;
		}


	
	}
	#endregion
}
