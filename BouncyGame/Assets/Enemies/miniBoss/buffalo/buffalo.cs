using UnityEngine;
using System.Collections;

public class buffalo : MonoBehaviour {


	public float rampageSpeed;
	GameObject player;
	public float restTimer;
	bool ramping = false;
	int numberOfRampePage = 0;

	float timer = 2f;


	// Use this for initialization
	void Start () {

		player = GameObject.FindWithTag ("Player");
		StartCoroutine ("chraging");

	
	}
	
	// Update is called once per frame
	void Update () {

		//timer -= Time.deltaTime;


		if (!ramping) {
			transform.LookAt (player.transform);

		
		} else {

			if (numberOfRampePage >= 3) {

				runAway ();
			} else {

				rampage ();
			}
		
		}


	}

	IEnumerator chraging(){

		ramping = false;

		yield return new WaitForSeconds (restTimer);

		ramping = true;

		numberOfRampePage += 1;

		print (numberOfRampePage);

		if (numberOfRampePage < 3) {
			rampage ();

		}




	}


	void rampage (){

		Vector3 playerPosition = player.transform.position;
		float screenWidth = Screen.width;
		float screenHeight = Screen.height;

		Vector3 tmpPos = Camera.main.WorldToScreenPoint (transform.position);

		print ("tmpPos" + tmpPos + "screenWidth " + Screen.width + "screenHeight" + Screen.height);


		if (tmpPos.y >= Screen.height - 50f || tmpPos.x >= screenWidth - 50f || tmpPos.y <= 50f || tmpPos.x <= 50f){


			StartCoroutine ("chraging");

		} else {

			transform.Translate (Vector3.forward * rampageSpeed * Time.deltaTime);


		}





	}

	void runAway(){

		transform.Translate (Vector3.forward * rampageSpeed * Time.deltaTime);

	}


	void OnCollisionEnter(Collision other){


		if (ramping) {


			other.gameObject.SendMessage ("die", null, SendMessageOptions.DontRequireReceiver);


		}
	}



}
