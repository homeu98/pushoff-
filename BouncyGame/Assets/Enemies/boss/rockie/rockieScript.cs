using UnityEngine;
using System.Collections;

public class rockieScript : MonoBehaviour {

	private rockie eType = rockie.Idle;

	public GameObject bigRock, smallRocks, underGroundRocks;

	public int numberOfSmallRocks, numberOfUnderGroundRocks;

	GameObject player;

	public float speedOfUnderGroundRocks;

	// Use this for initialization
	void Start () {

		player = GameObject.FindWithTag ("Player");

		StartCoroutine ("movePause");
	
	}
	
	// Update is called once per frame
	void Update () {


		//OnDrawGizmosSelected ();

		print (eType);


		Vector3 relativePos = new Vector3(player.transform.position.x , this.transform.position.y , player.transform.position.z) ;

		transform.LookAt (relativePos);


	
	}


	public enum rockie{

		Idle,
		throwBigRocks,
		shakeOffRocks,
		underGroundRocks,
		resting

	}



	void chooseType(rockie what){

		switch (eType) {

		case rockie.Idle:
			//StartCoroutine ("rest");
			break;

		case rockie.throwBigRocks:
			StartCoroutine ("throwingBigRocks");
			break;

		case rockie.shakeOffRocks:
			StartCoroutine ("shakingOffRocks");
			break;

		case rockie.underGroundRocks:
			StartCoroutine ("underGroundRocksPunch");
			break;

		case rockie.resting:
			StartCoroutine ("rest");
			break;

		}



	}


	IEnumerator movePause(){

		eType = rockie.Idle;

		yield return new WaitForSeconds (3);

		var rockieAttack = (rockie)Random.Range (1, 4);

		eType = rockieAttack;

		chooseType (eType);

	}


	IEnumerator throwingBigRocks(){

		yield return new WaitForSeconds (1);

		Vector3 spawnPosition = new Vector3 (transform.position.x, transform.position.y + 0.5f, transform.position.z - 1f);

		Instantiate (bigRock, spawnPosition, transform.rotation);

		StartCoroutine ("movePause");

	}


	IEnumerator shakingOffRocks(){

		yield return new WaitForSeconds (1);

		for (int i = 0; i <= numberOfSmallRocks; i++) {


			Vector3 spawnPosition = new Vector3 (transform.position.x, transform.position.y + 0.5f, transform.position.z);
		
			Instantiate (smallRocks, spawnPosition, transform.rotation);


		}

		StartCoroutine ("movePause");
	}


	IEnumerator underGroundRocksPunch(){

		yield return new WaitForSeconds (1);

		//float distanceBetween = Vector3.Distance (transform.position, player.transform.position);

		Vector3 midPoint = (transform.position + player.transform.position) * 0.5f;
		midPoint.y = 0f;

		Vector3 firstPoint = Vector3.Lerp (transform.position, player.transform.position , 0.25f);
		firstPoint.y = 0f;

		Vector3 secondPoint = Vector3.Lerp (transform.position, player.transform.position , 0.75f);
		secondPoint.y = 0f;

		Vector3 playerPosition = player.transform.position;
		playerPosition.y = 0f;
		//print (midPoint);

		for (int i = 0; i <= 4; i++) {

			if (i == 1) {
				
				Instantiate (underGroundRocks, firstPoint, transform.rotation);


			} else if (i == 2) {


				Instantiate (underGroundRocks, midPoint, transform.rotation);


			} else if (i == 3) {


				Instantiate (underGroundRocks, secondPoint, transform.rotation);


			} else if (i == 4) {

				Instantiate (underGroundRocks, playerPosition, transform.rotation);


			}


			yield return new WaitForSeconds (speedOfUnderGroundRocks);

	
		}

		StartCoroutine ("movePause");
	}

	void die(bool hit){



	}




}
