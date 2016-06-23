using UnityEngine;
using System.Collections;

public class HeavyHSscript : MonoBehaviour {

	public float movePauseTimer;
	private heavy eType = heavy.Idle;
	public float rotationSpeed;
	public float rotationRight = 90;
	public float rotated, throwingBombTime;
	public int numberOfBomb;
	public BoxCollider circleAttackZone;
	public GameObject bomb;
	public float runSpeed;
	bool hitWall;
	Vector3 startingPosition;
	public float goBackSpeed;

	GameObject gm;		
	public int health = 4;

	// Use this for initialization
	void Start () {
	
		startingPosition = transform.position;
		circleAttackZone.enabled = false;
		StartCoroutine ("movePause");

	}
	
	// Update is called once per frame
	void FixedUpdate () {


		if (eType == heavy.circleShoot) {

			circleShooting ();

		}

		if (eType == heavy.eatingSandwich) {

			eatingSandWich ();

		}
	
		print (eType);



		gm = GameObject.FindWithTag ("GM");

		gm.SendMessage ("bossHealth", health, SendMessageOptions.DontRequireReceiver);

	}


	public enum heavy{

		Idle,
		circleShoot,
		throwingBomb,
		eatingSandwich,
		resting

	}


	void chooseType(heavy what){

		switch (eType) {

		case heavy.Idle:
			//StartCoroutine ("rest");
			break;

		case heavy.circleShoot:
			rotated = 0f;
			rotationRight = 90f;
			break;

		case heavy.throwingBomb:
			StartCoroutine ("throwingBomb");
			break;

		case heavy.eatingSandwich:
			
			break;

		case heavy.resting:
			StartCoroutine ("rest");
			break;

		}



	}

	IEnumerator movePause(){

		eType = heavy.Idle;

		hitWall = false;

		yield return new WaitForSeconds (movePauseTimer);

		var heavyAttack = (heavy)Random.Range (1, 4);

		eType = heavyAttack;

		chooseType (eType);

	}

	IEnumerator throwingBomb(){

		yield return new WaitForSeconds (1);

		for (int i = 0; i <= numberOfBomb; i++) {

			Vector3 spawnPosition = new Vector3 (transform.position.x, transform.position.y + 0.5f, transform.position.z);

			Instantiate (bomb, spawnPosition, transform.rotation);

			yield return new WaitForSeconds (2);


		}

		StartCoroutine ("movePause");


	}




	void circleShooting(){


		rotationRight += Time.deltaTime * rotationSpeed;
		rotated += Time.deltaTime * rotationSpeed;


		if (rotated >= 360) {
			circleAttackZone.enabled = false;


			StartCoroutine ("movePause");
		} else {

			transform.rotation = Quaternion.Euler(0,rotationRight,0);
			circleAttackZone.enabled = true;
		}
			

	}

	void eatingSandWich(){

		float direction = Random.Range (0, 360);

		Quaternion rotation = Quaternion.Euler (0f, direction, 0f);


		transform.rotation = Quaternion.Lerp (transform.rotation, rotation, Time.deltaTime);


		transform.position += Vector3.forward * runSpeed * Time.deltaTime;

	

	}

	void moveBackToCenter(){

		float speed = Time.deltaTime * goBackSpeed;

		transform.position = Vector3.MoveTowards (transform.position, startingPosition, speed);

		//StartCoroutine ("movePause");

	}

	void OnCollisionEnter(Collision other){

		if (eType == heavy.eatingSandwich && other.gameObject.tag != "grid") {

			hitWall = true;

		}

		other.gameObject.SendMessage ("die", null, SendMessageOptions.DontRequireReceiver);

	}

	void OnTriggerEnter(Collider other){


		other.gameObject.SendMessage ("die", null, SendMessageOptions.DontRequireReceiver);

	}


	void dead(bool hit){


		health--;

		if (health <= 0) {

			Destroy (this.gameObject);

		}

		StartCoroutine ("movePause");

	}
}
