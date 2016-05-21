using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StandalonePlayer : MonoBehaviour {

	Rigidbody rb;

	bool holding, moveLeft, moveRight, onGround;

	Vector3 rotation;

	GameManager gm;

	public float jumpDistance, force, thrustForce;

	float currentLerpTime, perc;
	Vector3 startPos;
	Vector3 endPos;
	public float turnForce;

	private Vector3 currentAngle;




	void Start () {
		rb = GetComponent<Rigidbody> ();
		gm = GameObject.FindWithTag ("GM").GetComponent<GameManager> ();
		currentAngle = transform.localEulerAngles;
	}
	

	void Update () {



	}





	void OnCollisionEnter(Collision c){

		print ("pushing");


		if (c.transform.tag != "grid") {

			Vector3 dir = c.contacts [0].point - transform.position;

			dir = dir.normalized;

			c.rigidbody.AddForce (dir * force);
		}
	}
		

	void StartMoving(int direction){

		startPos = gameObject.transform.position;

		if (direction == 1) {
			//endPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z + jumpDistance);

			transform.position = Vector3.Lerp (transform.position, transform.forward * 2, Time.deltaTime );

		}

		if (direction == 2) {

			//endPos = new Vector3 (transform.position.x , transform.position.y, transform.position.z + jumpDistance);
			transform.position = Vector3.Lerp (transform.position, transform.forward * 2, Time.deltaTime );

		}
		currentLerpTime += Time.deltaTime * 5.5f;
		perc = currentLerpTime / 1f;

		//gameObject.transform.position = Vector3.Lerp (startPos, endPos, perc);

		transform.FindChild("playerModel").SendMessage("moved", null, SendMessageOptions.DontRequireReceiver);
		gm.SendMessage ("jumped", null, SendMessageOptions.DontRequireReceiver);
	}
		

	//This is the method to send when enemies hits the player, this is also the method to player player's death animation.

	void die(){
		
		print ("deadalready");
		Destroy (this.gameObject);

	}


	void holdingButton(){

		//playAnimation ready to jump

	}



	void movingLeft(float rotationToLeft){


		transform.FindChild("playerModel").SendMessage("moved", null, SendMessageOptions.DontRequireReceiver);
		gm.SendMessage ("jumped", null, SendMessageOptions.DontRequireReceiver);

			currentAngle = new Vector3 (
				Mathf.LerpAngle (currentAngle.x, currentAngle.x, Time.deltaTime),
			Mathf.LerpAngle (currentAngle.y, currentAngle.y - turnForce, Time.deltaTime * 10 ),
				Mathf.LerpAngle (currentAngle.z, currentAngle.z, Time.deltaTime));
				
			transform.eulerAngles = currentAngle;
		if (onGround) {
			rb.AddForce (transform.forward * thrustForce);
			onGround = false;

		}


	}

	void movingRight(float rotationToRight){

		transform.FindChild("playerModel").SendMessage("moved", null, SendMessageOptions.DontRequireReceiver);
		gm.SendMessage ("jumped", null, SendMessageOptions.DontRequireReceiver);

		currentAngle = new Vector3 (
			Mathf.LerpAngle (currentAngle.x, currentAngle.x, Time.deltaTime),
			Mathf.LerpAngle (currentAngle.y, currentAngle.y + turnForce, Time.deltaTime * 10 ),
			Mathf.LerpAngle (currentAngle.z, currentAngle.z, Time.deltaTime));
		transform.eulerAngles = currentAngle;

		if (onGround) {
			rb.AddForce (transform.forward * thrustForce);
			onGround = false;

		}
	}

	void onGroundNow(){
		print ("onGround");
		onGround = true;

	}

}
