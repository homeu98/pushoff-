using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StandalonePlayer : MonoBehaviour {
	//public float pressure=10f;
//	public float thrustForce = 3f;
	public float damage = 5f;
	//public float RotateSensitivity=90f;
	public static Vector3 direction;

	float Rot_z;

	public static Quaternion rot;


	Rigidbody rb;

	public float speed=0f;
	//public  bool onGround=true;

	//bool crouch=false;

	Collider recipient;

	Quaternion targetRotation;

	void Start () {
		rb = GetComponent<Rigidbody> ();
	

	
	}
	

/*	void Update () {

		if (onGround ) {			

			if (crouch) {
			/	pressure += MinPressure;
				thrustForce += MinThrustForce;
				rb.velocity = new Vector3 (0f , pressure, 0f );
									
						onGround  = false;
					}
			}
		}
*/


	void FixedUpdate( ){

			
	}



	void OnCollisionEnter(Collision other){
	//	if (other.transform.CompareTag ("ground")) {
		//	crouch = false;
			//onGround = true;
	//	}

		//  Only the tag of the collider is "back"  and  it's bool "onGound" is true, it will getHurt. Means one guy cannot attack the other when  the other flow in air.
		if (other.collider.CompareTag ("back") /* &&  other.collider.GetComponentInParent<Jump>().onGround == true*/) {
				print ("sucessBack");
			//direction = other.collider.transform.forward;
			//	other.collider.GetComponentInParent<Jump> ().onGround = false;
			other.collider.SendMessage ("BackGetHurt", damage, SendMessageOptions.DontRequireReceiver);
			} 
		if(other.collider.CompareTag ("front")  /*&&  other.collider.GetComponentInParent<Jump>().onGround == true */){
			print ("sucessFront");
			//direction = -other.collider.transform.forward;
			//other.collider.GetComponentInParent<Jump> ().onGround = false;
			other.collider.SendMessage ("FrontGetHurt", damage , SendMessageOptions.DontRequireReceiver);
		}

	}

	/*public void Crouch(bool IsCrouch){
		crouch = IsCrouch;
	}*/


public void StartMoving(float thrustForce){
		rb.MovePosition (rb.position + transform.forward * thrustForce);

	}

	public void StartRotation(float HorizontalInput){

		//targetRotation=transform.localRotation;
		//targetRotation.eulerAngles  = Vector3.up * rotateAngle;
		//Rot_z = HorizontalInput;
		
		transform.localEulerAngles += Vector3.up * HorizontalInput;
	}

 
}
