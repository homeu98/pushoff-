using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StandalonePlayer : MonoBehaviour {
	public float pressure=10f;
	//public float MinPressure=3f;
//	public float thrustForce = 3f;
	public static bool IsKilled = false;

	//public float RotateSensitivity=90f;
	public static Vector3 direction;

	float Rot_z;

	public static Quaternion rot;


	Rigidbody rb;


	public  bool onGround=true;

	public  static bool crouch=false;

	SphereCollider WeaponCollider;

	Quaternion targetRotation;
	Vector3 rotation;

	public  float temporaryHorizontalInput;

	public static	StandalonePlayer instance;

	GameManager gm;



	void Start () {
		rb = GetComponent<Rigidbody> ();
		WeaponCollider = GetComponent<SphereCollider> ();
		IsKilled = false;
		instance = this;
		gm = GameObject.FindWithTag ("GM").GetComponent<GameManager> ();

	}
	

	void Update () {
		

		if (onGround ) {			

			if (crouch) {
				//pressure += MinPressure;
			//	thrustForce += MinThrustForce;

				rb.velocity = new Vector3 (0f , pressure, 0f );
				WeaponCollider.enabled = true;
						onGround  = false;
					}
			}



	}







	void OnTriggerEnter(Collider other){
		if (other.transform.CompareTag ("grid")) {
			crouch = false;
			onGround = true;
			WeaponCollider.enabled = false;
		}
			
		other.gameObject.SendMessage ("tookDamage", null, SendMessageOptions.DontRequireReceiver);

		if (other.tag == "miniBoss") {
			gm.gameObject.SendMessage ("nOfKill", 2, SendMessageOptions.DontRequireReceiver);
		} else if(other.tag == "enemy") {

			gm.gameObject.SendMessage ("nOfKill", 1, SendMessageOptions.DontRequireReceiver);

		}

			//if(other.collider.CompareTag("enemy")){
		//	other.gameObject.SendMessage ("tookDamage", null, SendMessageOptions.DontRequireReceiver);
		//}
		//if(other.collider.CompareTag("GrassHopper") && GrassHopper.onGround){

		//}
	}



	/*public void Crouch(bool IsCrouch){
		crouch = IsCrouch;
	}*/


public void StartMoving(float thrustForce){
	//	rb.MovePosition (rb.position + transform.forward * thrustForce);
		if (onGround) {
			rb.AddForce (transform.forward * thrustForce);
		}
	}

	public void StartRotation(float HorizontalInput){

		//targetRotation=transform.localRotation;
		//targetRotation.eulerAngles  = Vector3.up * rotateAngle;
		//Rot_z = HorizontalInput;
		if (Shunk.IsFaint) {
			if (Time.time < Shunk.TimeUpToDisappear) {
				transform.localEulerAngles -= Vector3.up * HorizontalInput;
			} else {
				Shunk.IsFaint = false;
			}
		} else {

			transform.localEulerAngles += Vector3.up * HorizontalInput;
		}

	}


	//This is the method to send when enemies hits the player, this is also the method to player player's death animation.

	void die(){
		IsKilled = true;
		print ("deadalready");
		Destroy (this.gameObject);

	}

	public void Crouch(bool IsCrouch){
		crouch = IsCrouch;
	}

}
