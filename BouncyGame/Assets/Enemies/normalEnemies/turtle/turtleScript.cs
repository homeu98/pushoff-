using UnityEngine;
using System.Collections;

public class turtleScript : MonoBehaviour {



	public float movingSpeed, shootingSpeed;

	int statusOfTurtle = 0;

	bool startRolling = false;

	// Use this for initialization
	void Start () {
	


	}


	
	// Update is called once per frame
	void Update () {

		if (statusOfTurtle == 0) {

			transform.position += Vector3.back * movingSpeed * Time.deltaTime;
			print ("walking");
		}

		if (startRolling) {

			transform.Translate (Vector3.forward * shootingSpeed * Time.deltaTime);

		}
	}


	void OnCollisionEnter(Collision other){

		other.gameObject.SendMessage ("tookDamage", null, SendMessageOptions.DontRequireReceiver);

	}

	void tookDamage(){

		statusOfTurtle += 1;

		if (statusOfTurtle == 2) {

			startRolling = true;
		}

	}


}
