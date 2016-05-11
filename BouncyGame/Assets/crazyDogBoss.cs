using UnityEngine;
using System.Collections;

public class crazyDogBoss : MonoBehaviour {

	public float pauseAttackTimer, shootingTimer, restTimer;

	GameObject player;

	Rigidbody rigi;

	public GameObject barkingBullet;

	public int forceToBite; 

	int currentAttackMove;

	public bool attacking;

	int currentShootingCounter;

	Vector3 startingPosition;






	// Use this for initialization
	void Start () {

		//StartCoroutine ("movePause");
		rigi = GetComponent<Rigidbody>();
		player = GameObject.FindWithTag ("Player");


		startingPosition = this.transform.position;
		StartCoroutine ("startKilling");

	
	}


	IEnumerator startKilling(){

		yield return new WaitForSeconds (pauseAttackTimer);

		currentAttackMove = Random.Range(1,4);

		print (currentAttackMove);

		switch (currentAttackMove) {

		case 1:

			barkAttack (currentShootingCounter);
			break;

		case 2:

			swipeAttack ();
			break;

		case 3:

			straightBiteAttack ();
			break;

		default:
			
			break;

		}

	}


	// Update is called once per frame
	void Update () {

		if (attacking) {

			straightBiteAttack ();
		}

		if (this.transform.position == player.transform.position) {

			transform.position =  Vector3.MoveTowards (transform.position, startingPosition, forceToBite * Time.deltaTime);


		}

	
	}



	IEnumerator movePause(){

		yield return new WaitForSeconds (restTimer);

		startKilling ();

	}

	IEnumerator pauseShooting(){

		yield return new WaitForSeconds (shootingTimer);

		currentAttackMove += 1;

		barkAttack (currentShootingCounter);


	}



	void barkAttack(int currentShot){

		print ("shoot");

		if (currentShootingCounter >= 3) {

			StartCoroutine ("movePause");
		}

		Instantiate (barkingBullet, transform.position, barkingBullet.transform.rotation);

		StartCoroutine ("pauseShooting");



	}



	void swipeAttack(){

		print ("swipeAttack");



	}

	void straightBiteAttack(){

		print ("straightBiteAttack");

		Vector3 playerPosition = player.transform.position;

		print (playerPosition);

		transform.position =  Vector3.MoveTowards (transform.position, playerPosition, forceToBite * Time.deltaTime);

		attacking = true;
		//StartCoroutine ("movePause");
		
	}

	void OnColliderEnter(Collider other){


		other.SendMessage ("die", null, SendMessageOptions.DontRequireReceiver);


	}

}
