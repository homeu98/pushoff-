using UnityEngine;
using System.Collections;

public class GrassHopper : MonoBehaviour {
	public float JumpForce = 2f;
	public float period = 2.5f;
	public float CircleRadius= 3f;
	float NextJumpTime;
	public static bool onGround = false;
	Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		NextJumpTime = Time.time + period;
	}
	
	// Update is called once per frame
	void Update () {
		if(onGround){
			if(Time.time > NextJumpTime){
				Vector2 JumpDirection = Random.insideUnitCircle * CircleRadius - (Vector2)transform.position;
				rb.velocity = new Vector3 (JumpDirection.x , JumpForce, JumpDirection.y );
				onGround = false;
				NextJumpTime += period;
			}
		}
	}

	void OnCollisionEnter(Collision other){
		if (other.transform.CompareTag ("grid")) {
			
			onGround = true;
		}
		if(other.collider.CompareTag("Player") && transform.position.y >= 0.8f){
			other.collider.SendMessage ("die", null,SendMessageOptions.DontRequireReceiver);
		}
	}
}
