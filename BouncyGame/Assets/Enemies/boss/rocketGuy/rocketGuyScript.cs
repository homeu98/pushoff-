using UnityEngine;
using System.Collections;

public class rocketGuyScript : MonoBehaviour {

	private rocketGuy eType = rocketGuy.Idle;

	public float restTimer, movePauseTimer, step, homingMissleFlyingTime, pausePeroidOfAirStikeBullet;
	GameObject player;

	public GameObject airStrikeBullet;

	Vector3 playerPosition;

	Rigidbody rigi;

	Vector3 playerAirPosition, playerGroundPosition;

	public GameObject homingRocket;

	bool onGround = false;

	bool onSky = false;


	// Use this for initialization
	void Start () {
		
		player = GameObject.FindWithTag ("Player");

		rigi = GetComponent<Rigidbody> ();

		StartCoroutine ("movePause");
	}
	
	// Update is called once per frame
	void Update () {
		
		playerGroundPosition = new Vector3 (transform.position.x, 0f, transform.position.z);

		playerAirPosition = new Vector3 (transform.position.x, 3.0f, transform.position.z);

		if (eType == rocketGuy.resting) {

			if (onGround) {



			} else {

				transform.position = Vector3.MoveTowards (transform.position, playerGroundPosition, step); 
			}
		}

		if (eType == rocketGuy.rampageAttack) {

			print ("isright");
			rampageAttack ();

		}


		while (eType == rocketGuy.returningToAir) {

			onGround = false;
			transform.position = Vector3.MoveTowards (transform.position, playerAirPosition, step);

		}


		print (eType);

	
	}


	public enum rocketGuy{

		Idle,
		rampageAttack,
		airStrikeAttack,
		homingMissle,
		returningToAir,
		resting,

	}



	void chooseType(rocketGuy what){
		playerPosition = player.transform.position;

		switch (eType) {

		case rocketGuy.Idle:
			StartCoroutine ("rest");
			break;

		case rocketGuy.rampageAttack:

			break;

		case rocketGuy.airStrikeAttack:
			print ("i'm airStirking");
			StartCoroutine ("airStrike");
			break;

		case rocketGuy.homingMissle:
			StartCoroutine ("homingMissle");
			break;

		case rocketGuy.returningToAir:
			onGround = false;
			break;
		

		case rocketGuy.resting:
			StartCoroutine ("rest");

			break;

		}



	}


	IEnumerator rest(){

		//eType = rocketGuy.resting;

		yield return new WaitForSeconds (restTimer);

		eType = rocketGuy.returningToAir;

		chooseType (eType);

		//StartCoroutine ("movePause");

	}


	IEnumerator movePause(){


		eType = rocketGuy.Idle;

		yield return new WaitForSeconds (movePauseTimer);

		var rocketGuyAttack = (rocketGuy)Random.Range (1, 4);

		eType = rocketGuyAttack;

		chooseType (eType);

	}

	void rampageAttack(){


		print ("ramping");
		//playerPosition.y = 0.0f;
		transform.position = Vector3.MoveTowards (transform.position, playerPosition, step);

		if (Vector3.Distance (transform.position, playerPosition) <= 0.5) {

			print ("arrived");

			eType = rocketGuy.resting;

			chooseType (eType);

		}


	}

	IEnumerator homingMissle(){


		Instantiate (homingRocket, transform.position, transform.rotation);

		yield return new WaitForSeconds (homingMissleFlyingTime);
		 
		eType = rocketGuy.resting;

		chooseType (eType);

	}



	IEnumerator airStrike(){

		print ("airstirking");
		for (int i = 0; i <= 3; i++) {

			Vector3 spawnPosition = new Vector3(playerPosition.x, playerPosition.y + 3f, playerPosition.z + i);

			Instantiate (airStrikeBullet, spawnPosition, transform.rotation);

			yield return new WaitForSeconds (pausePeroidOfAirStikeBullet);


		}

		yield return new WaitForSeconds (2f);


		eType = rocketGuy.resting;

		chooseType (eType);


	}


	void OnCollisionEnter(Collision other){


		if (other.gameObject.tag == "grid") {

			onGround = true;
		}


	}



}
