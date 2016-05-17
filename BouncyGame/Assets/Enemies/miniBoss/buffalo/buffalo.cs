using UnityEngine;
using System.Collections;

public class buffalo : MonoBehaviour {


	public float rampageSpeed, runAwaySpeed;
	GameObject player;
	public float restTimer;
	bool ramping = false;
	int numberOfRampePage = 0;

	Vector3 playerOldPosition;

	private buffaloType eType = buffaloType.notRamping;


	// Use this for initialization
	void Start () {

		player = GameObject.FindWithTag ("Player");
		StartCoroutine ("chraging");

	}

	public enum buffaloType{

		ramping,
		notRamping,
		runningAway

	}



	// Update is called once per frame
	void Update () {

		if (eType == buffaloType.ramping) {

			rampageAttack ();

		}
			
		if (eType == buffaloType.runningAway) {

			runAway ();

		}

		if (numberOfRampePage >= 4) {

			eType = buffaloType.runningAway;
			chooseType (eType);

		}

		print (eType);

	}

	IEnumerator chraging(){
		
		yield return new WaitForSeconds (restTimer);
		numberOfRampePage += 1;
		eType = buffaloType.ramping;
		chooseType (eType);


	}
	void chooseType(buffaloType what){

		switch (eType) {

		case buffaloType.ramping:
			playerOldPosition = player.transform.position;
			//StartCoroutine ("rest");
			break;

		case buffaloType.notRamping:
			StartCoroutine ("chraging");
			break;

		case buffaloType.runningAway:

			break;

		}
	}


	void rampageAttack (){

		transform.position = Vector3.Lerp (transform.position, playerOldPosition, rampageSpeed);

		if (Vector3.Distance (transform.position, playerOldPosition) <= 0.5) {

			eType = buffaloType.notRamping;

			chooseType (eType);
		}
	}



	void runAway(){

		transform.Translate (Vector3.forward * runAwaySpeed * Time.deltaTime);

	}


	void OnCollisionEnter(Collision other){


		if (eType == buffaloType.ramping) {

			other.gameObject.SendMessage ("die", null, SendMessageOptions.DontRequireReceiver);

		}
	}

	void tookDamage(){

		if (eType == buffaloType.notRamping || eType == buffaloType.runningAway) {

			Destroy (this.gameObject);

		}

	}

}
