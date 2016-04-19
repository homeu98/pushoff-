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

	public float RotateSpeed=0f;
	public  bool onGround=true;

	public  static bool crouch=false;

	Collider recipient;

	Quaternion targetRotation;
	Vector3 rotation;

	void Start () {
		rb = GetComponent<Rigidbody> ();
	
		IsKilled = false;
	
	}
	

	void Update () {
		

		if (onGround ) {			

			if (crouch) {
				//pressure += MinPressure;
			//	thrustForce += MinThrustForce;
				rb.velocity = new Vector3 (0f , pressure, 0f );
									
						onGround  = false;
					}
			}
		}







	void OnCollisionEnter(Collision other){
		if (other.transform.CompareTag ("grid")) {
			crouch = false;
			onGround = true;
		}

		//other.gameObject.SendMessage ("tookDamage", null, SendMessageOptions.DontRequireReceiver);
		if(other.collider.CompareTag("enemy")){
			deathScript.tookDamage(other.collider);
		}
		if(other.collider.CompareTag("GrassHopper") && GrassHopper.onGround){
			deathScript.tookDamage(other.collider);
		}
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
	
	
		 transform.localEulerAngles += Vector3.up * HorizontalInput;

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
