using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IDragHandler , IPointerUpHandler, IPointerDownHandler {

	Image controlArea;
	Vector3 inputVector;

	Vector2 pos;
	Vector3 initialPoint;


	 Vector3 direction;

	public Transform player;


	  Quaternion targetRotation;

	void Start(){
		controlArea = GetComponent<Image> ();
	}

	public virtual void OnDrag(PointerEventData ped){
		
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle (controlArea.rectTransform, ped.position, ped.pressEventCamera, out pos)) {
			pos.x = (pos.x / controlArea.rectTransform.sizeDelta.x );
			pos.y = (pos.y / controlArea.rectTransform.sizeDelta.y );

			inputVector = new Vector3 (pos.x*2 +1, 0, pos.y *2 - 1);
			inputVector = (inputVector.magnitude > 1f) ? inputVector.normalized : inputVector;
			print (inputVector);
		//	Jump.rot.eulerAngles = inputVector;

			direction=inputVector;

		}
		targetRotation = Quaternion.LookRotation (direction);
		player.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle (player.eulerAngles.y, targetRotation.eulerAngles.y, 300 * Time.deltaTime);

	}

	public virtual void OnPointerDown(PointerEventData ped){
		OnDrag (ped);
		initialPoint =inputVector;
		print (initialPoint);

		targetRotation = Quaternion.LookRotation (direction);
		player.eulerAngles = targetRotation.eulerAngles;

	}

	public virtual void OnPointerUp(PointerEventData ped){
		direction = Vector3.zero;
		inputVector = Vector3.zero;
	}




}
