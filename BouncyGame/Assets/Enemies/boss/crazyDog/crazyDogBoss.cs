using UnityEngine;
using System.Collections;

public class crazyDogBoss : MonoBehaviour {

	public float pauseAttackTimer, shootingTimer, restTimer;

	GameObject player;

	public GameObject barkingBullet;

	public int forceToBite; 

	int currentShootingCounter;

	public float movePausingTimer;

	Vector3 startingPosition, playerPosition;

	public GameObject chain1, chain2, chain3;

	bool bool1, bool2, bool3;

	bool getBack = false;

	int chainCounter = 3;
	GameObject gm;		

	private crazyDogType eType = crazyDogType.Idle;



	public enum crazyDogType{

		Idle,
		swipeAttack,
		barkingAttack,
		straightBiteAttack,
		resting,
		returningToPosition

	}




	// Use this for initialization
	void Start () {

		//StartCoroutine ("movePause");
	//	rigi = GetComponent<Rigidbody>();
		player = GameObject.FindWithTag ("Player");

		startingPosition = this.transform.position;
		chooseType (eType);


		gm = GameObject.FindWithTag ("GM");

		gm.SendMessage ("bossHealth", chainCounter, SendMessageOptions.DontRequireReceiver);
	
	}




	// Update is called once per frame
	void Update () {


		if (player.gameObject != null) {

			if (eType == crazyDogType.straightBiteAttack && eType != crazyDogType.returningToPosition) {

				straightBiteAttack (playerPosition);

			}

			if (eType == crazyDogType.returningToPosition) {

				returningToPosition ();
			}

			if (eType == crazyDogType.resting) {

				if (chain1 != null) {
					chain1.SendMessage ("canDie", true, SendMessageOptions.DontRequireReceiver);
				}

				if (chain2 != null) {
					chain2.SendMessage ("canDie", true, SendMessageOptions.DontRequireReceiver);
				}	

				if(chain3 != null){
				chain3.SendMessage ("canDie", true, SendMessageOptions.DontRequireReceiver);


				}
				print ("killthosechainNOw");

			

			}

		}

	
		//yield return new WaitForSeconds (pauseAttackTimer);

	}




	void chooseType(crazyDogType what){


		switch (eType) {

		case crazyDogType.Idle:
			Ideling ();
			break;

		case crazyDogType.swipeAttack:
			swipeAttack ();
			break;

		case crazyDogType.barkingAttack:
			barkAttack (0);
			currentShootingCounter = 0;
			break;

		case crazyDogType.straightBiteAttack:
			playerPosition = player.transform.position;
			//straightBiteAttack ();
			break;

		case crazyDogType.resting:
			
			break;

		case crazyDogType.returningToPosition:
			//returningToPosition ();
			break;

		}



	}

	void Ideling(){

		//playAnimationIdeling

		StartCoroutine ("movePause");



	}

	IEnumerator rest(){

		eType = crazyDogType.resting;

		yield return new WaitForSeconds (restTimer);
		


		StartCoroutine ("movePause");

	}

	IEnumerator movePause(){

		yield return new WaitForSeconds (movePausingTimer);

		var crazyAttack = (crazyDogType)Random.Range (1, 4);

		if (chain1 != null) {
			chain1.SendMessage ("canDie", false, SendMessageOptions.DontRequireReceiver);
		}

		if (chain2 != null) {
			chain2.SendMessage ("canDie", false, SendMessageOptions.DontRequireReceiver);
		}	

		if(chain3 != null){
			chain3.SendMessage ("canDie", false, SendMessageOptions.DontRequireReceiver);


		}
		eType =  crazyAttack;

		chooseType (eType);
	}



	void returningToPosition(){

		print ("returning");

		if (transform.position == startingPosition) {

			eType = crazyDogType.resting;

			StartCoroutine ("rest");



		} else {

			transform.position =  Vector3.MoveTowards (transform.position, startingPosition, forceToBite * Time.deltaTime);

		}

	}





	IEnumerator pauseShooting(){

		yield return new WaitForSeconds (shootingTimer);

		Instantiate (barkingBullet, transform.position, barkingBullet.transform.rotation);

		currentShootingCounter += 1;

		barkAttack (currentShootingCounter);

	}



	void barkAttack(int currentShot){

		//print (currentShootingCounter);

		//print ("shoot");

		if (currentShootingCounter >= 3) {

			//currentShootingCounter = 1;

			eType = crazyDogType.resting;

			StartCoroutine ("rest");

		} else {

			StartCoroutine ("pauseShooting");

		
		}





	}



	void swipeAttack(){

		print ("swipeAttack");

		StartCoroutine ("rest");


	}

	IEnumerator straightAttackBack(){

		yield return new WaitForSeconds (2);

		getBack = true;

	}




	void straightBiteAttack(Vector3 position){

		print (position);

		//Vector3 playerPosition = player.transform.position;



		if (transform.position.x <= startingPosition.x - 1.5f || transform.position.x >= startingPosition.x + 4.5 || transform.position.z >= startingPosition.z + 2.5 || transform.position.z <= startingPosition.z - 2.5f ) {

			eType = crazyDogType.returningToPosition;

			StartCoroutine ("straightAttackBack");
			//getBack = false;

		} else {

			//transform.LookAt (player);
			transform.position =  Vector3.MoveTowards (transform.position, playerPosition, forceToBite * Time.deltaTime);

		}

	}

	void OnColliderEnter(Collider other){


		other.SendMessage ("die", null, SendMessageOptions.DontRequireReceiver);


	}

	void chainDie(bool hit){

		chainCounter--;

		if (chainCounter <= 0) {

			Destroy (this.gameObject);

		}

		StartCoroutine ("movePause");



		//

	}


}
