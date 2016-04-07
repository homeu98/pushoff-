using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Jump : MonoBehaviour {
	public float pressure=0f;
	public float minPressure = 2f;
	public float maxPressure = 10f;



	public static Quaternion rot;

	public float thrustForce = 3f;
	public float minThrustForce=3f;
	public float MaxTrustForce=10f;

	Rigidbody rb;
	Animator anim;
	public bool onGround=true;

	bool crouch=false;

	public  float explosionForce;
	public float upwardsModifer = 0f;
	public ForceMode forcemode;
	// Use this for initialization

	public LayerMask emeryMask;

	float distance;


	Ray ray;
	Collider recipient;



	void Start () {
		rb = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();

	
	}
	
	// Update is called once per frame
	void Update () {
	//	print (velocityX);

		RaycastHit hit;
		ray = new Ray (new Vector3 (transform.position.x, transform.position.y, transform.position.z+0.5f), transform.forward);
		if (Physics.Raycast (ray, out hit, 50f, emeryMask)) {
			//ray = new Ray (transform.position, hit.point);
			recipient = hit.collider;
			//	if(recipient.transform.childCount!=0){
			if (recipient.CompareTag ("front"))
				explosionForce =3f;
			if (recipient.CompareTag ("back"))
				explosionForce = 8f;
			if (recipient.CompareTag ("left") || recipient.CompareTag ("right"))
				explosionForce = 5f;
	
	//		print (hit.point);
		} 
			
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
				/*Vector3 pos=		transform.position;
				pos.y = -0.25f;
				transform.position = pos;*/
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


	void FixedUpdate(){
		if(!onGround)
			rb.AddForce (transform.forward * thrustForce);
	
	}

	void OnCollisionEnter(Collision other){
			thrustForce = 0f;
		if(other.transform.CompareTag("ground")){
			onGround = true;
		
			anim.SetBool ("onGround", onGround);
		}

		if (other.gameObject.CompareTag ("Player") && !onGround) {
			print ("sucess");
			recipient.GetComponentInParent<Rigidbody> ().AddExplosionForce (explosionForce , transform.position/*recipient.GetComponentInParent<Transform>().position*/,  0.5f/*recipient.transform.GetComponentInParent<Transform> ().localScale.x*/ ,upwardsModifer ,forcemode);
		} 
	}

	public void Crouch(bool IsCrouch){
		 crouch = IsCrouch;

	}
		

	void OnDrawGizmos(){
		Gizmos.color = Color.red;
		Gizmos.DrawRay (transform.position, transform.forward *50f);
	}

}
