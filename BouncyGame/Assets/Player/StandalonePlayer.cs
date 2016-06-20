using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StandalonePlayer : MonoBehaviour {

	Rigidbody rb;

	bool holding, moveLeft, moveRight, onGround;

	Vector3 rotation;

	GameManager gm;

	public float jumpDistance, force, thrustForce;

	public int currentSpirit;

	float currentLerpTime, perc;
	Vector3 startPos;
	Vector3 endPos;
	public float turnForce;

	private Vector3 currentAngle;

	public GameObject[] spiritObj;
	public GameObject spiritSpawnPosition;

	//cant jump when in air
	bool OnSky=true;

	void FixedUpdate () {
		rb = GetComponent<Rigidbody> ();
		gm = GameObject.FindWithTag ("GM").GetComponent<GameManager> ();
		//currentAngle = transform.localEulerAngles;
	}
	

	void Update () {
		onGroundNow ();
		print (onGround);
	}
		


	void OnCollisionEnter(Collision c){

		//----
		if(OnSky){
			if(c.gameObject.layer==12){
				OnSky = false;
				Destroy(GetComponent<Animator> ()) ;
				currentAngle = transform.localEulerAngles;
			}
		}
		//----


		if (!c.transform.CompareTag("grid")) {

			print ("pushing");

			Vector3 dir = c.contacts [0].point - transform.position;

			dir = dir.normalized;

			c.gameObject.GetComponent<Rigidbody> ().AddForce (dir * force); 
			c.gameObject.SendMessage ("dead", true, SendMessageOptions.DontRequireReceiver);

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

		//-----
		gm.gameObject.SendMessage("PopInLosePage",null,SendMessageOptions.DontRequireReceiver);
		//-----

		print ("deadalready");
		Destroy (this.gameObject);

	}


	void holdingButton(){

		//playAnimation ready to jump

	}



	void movingLeft(){


		transform.FindChild("playerModel").SendMessage("moved", null, SendMessageOptions.DontRequireReceiver);

			currentAngle = new Vector3 (
				Mathf.LerpAngle (currentAngle.x, currentAngle.x, Time.deltaTime),
				Mathf.LerpAngle (currentAngle.y, currentAngle.y - turnForce, Time.deltaTime * 10 ),
				Mathf.LerpAngle (currentAngle.z, currentAngle.z, Time.deltaTime));
		transform.localEulerAngles = currentAngle;

		if (onGround) {
			rb.AddForce (transform.forward * thrustForce);
			onGround = false;

		}


	}

	void movingRight(){

		transform.FindChild("playerModel").SendMessage("moved", null, SendMessageOptions.DontRequireReceiver);

		currentAngle = new Vector3 (
			Mathf.LerpAngle (currentAngle.x, currentAngle.x, Time.deltaTime),
			Mathf.LerpAngle (currentAngle.y, currentAngle.y + turnForce, Time.deltaTime * 10 ),
			Mathf.LerpAngle (currentAngle.z, currentAngle.z, Time.deltaTime));
		transform.localEulerAngles = currentAngle;

		if (onGround) {
			rb.AddForce (transform.forward * thrustForce);
			onGround = false;

		}
	}

	void onGroundNow(){
		
		if(transform.GetChild(0).transform.localPosition == Vector3.zero && OnSky==false){
			onGround = true;
		}

		/*print ("onGround");
		onGround = true;*/

	}

	void spirit(int whichSpirit){

		switch(whichSpirit){

		case 0:

			//fire				
			Instantiate(spiritObj[0], spiritSpawnPosition.transform.position, transform.rotation);

			break;

		case 1:

			//water
			Instantiate(spiritObj[1], spiritSpawnPosition.transform.position, transform.rotation);


			break;

		case 2:

			//thunder
			Instantiate(spiritObj[2], spiritSpawnPosition.transform.position, transform.rotation);


			break;

		case 3:

			//earth
			Instantiate(spiritObj[3], spiritSpawnPosition.transform.position, transform.rotation);


			break;

		case 4:

			//dark
			Instantiate(spiritObj[4], spiritSpawnPosition.transform.position, transform.rotation);


			break;

		case 5:

			//light
			Instantiate(spiritObj[5], spiritSpawnPosition.transform.position, transform.rotation);


			break;


		default:

			break;




		}


	}

}
