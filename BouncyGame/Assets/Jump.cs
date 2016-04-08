using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Jump : MonoBehaviour {
	public float pressure=0f;
	public float minPressure = 2f;
	public float maxPressure = 10f;

	public float RotateSensitivity=90f;
	float Rot_z;

	public static Quaternion rot;

	public float thrustForce = 3f;
	public float minThrustForce=3f;
	public float MaxTrustForce=10f;

	Rigidbody rb;
	Animator anim;
	public  bool onGround=true;

	bool crouch=false;


	Collider recipient;

	public float damage = 5f;


	Quaternion targetRotation;
	void Start () {
		rb = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();

	
	}
	
	// Update is called once per frame
	void Update () {	



		if (onGround ) {			

			if (/*Input.GetMouseButton (0) ||*/ crouch) {

					if (pressure < maxPressure) {
						pressure += Time.deltaTime * 10f;
						thrustForce += Time.deltaTime * 10f;
					} else {
						pressure = maxPressure;
						thrustForce = MaxTrustForce;
					}
				anim.SetFloat ("pressure", pressure+minPressure);

				} else {
					if (pressure > 0f) {
						pressure  += minPressure;
					thrustForce += minThrustForce;
					rb.velocity = new Vector3 (0f , pressure, 0f );

							pressure = 0f;
							
							onGround  = false;
							anim.SetFloat ("pressure",0f);
							anim.SetBool ("onGround", onGround);
					}
			}
		}

	}


	public  void FixedUpdate( ){
		if(!onGround)
			rb.AddForce (transform.forward * thrustForce);
		MoveRotation (Rot_z);
	}



	void OnCollisionEnter(Collision other){
			thrustForce = 0f;
		if (other.transform.CompareTag ("ground")) {
			onGround = true;
			anim.SetBool ("onGround", onGround);
		}

		//  Only the tag of the collider is "back"  and  it's bool "onGound" is true, it will getHurt. Means one guy cannot attack the other when  the other flow in air.
		if (other.collider.CompareTag ("back")  &&  other.collider.GetComponentInParent<Jump>().onGround == true ) {
				print ("sucessBack");
				other.collider.GetComponentInParent<Jump> ().onGround = false;
				other.collider.SendMessage ("GetHurt", damage, SendMessageOptions.DontRequireReceiver);
			} 

	}

	public void Crouch(bool IsCrouch){
		 crouch = IsCrouch;

	}		
		
	void MoveRotation(float HorizontalInput){
		Quaternion rot = transform.rotation;
		Vector3  eulerAngles;
		eulerAngles = rot.eulerAngles;
		eulerAngles.y += HorizontalInput * RotateSensitivity * Time.deltaTime;


		transform.eulerAngles = eulerAngles;
	}

	public void StartRotation(float HorizontalInput){
		//targetRotation=transform.localRotation;
		//targetRotation.eulerAngles  = Vector3.up * rotateAngle;
		Rot_z = HorizontalInput;
		//transform.localEulerAngles += Vector3.up * rotateAngle;
	}
}
