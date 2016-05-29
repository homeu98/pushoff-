using UnityEngine;
using System.Collections;

public class wizardKingScript : MonoBehaviour {

	private attackType eType = attackType.Idle;

	GameObject player;

	public float movePauseTimer, thunderCloudLastTime;

	public int numberOfSkeleton, numberOfMagicBall;

	public GameObject skeleton, thunderCloud, magicBall;

	public int health;

	public float speed;

	public SphereCollider sheild;

	// Use this for initialization
	void Start () {
	
		sheild.enabled = true;

		player = GameObject.FindWithTag ("Player");

		StartCoroutine ("movePause");

	}
	
	// Update is called once per frame
	void Update () {

		if (eType == attackType.thunderCloud) {

			controlingCloud ();

		}

		if (eType == attackType.Idle) {

			sheild.enabled = true;
			moving ();

		} else {

			sheild.enabled = false;

		}


		Vector3 relativePos = new Vector3(player.transform.position.x , this.transform.position.y , player.transform.position.z) ;

		transform.LookAt (relativePos);


		//float rotation = Mathf.Atan2 (relativePos., relativePos.z) * Mathf.Rad2Deg;
		//transform.rotation = Quaternion.Euler (0.0f, rotation, 0.0f);


	}

	void moving(){

		transform.Translate (Vector3.forward * speed * Time.deltaTime);


	}

	public enum attackType {

		Idle,
		thunderCloud,
		magicBall,
		skeleton,
		resting

	}


	IEnumerator movePause(){

		eType = attackType.Idle;

		yield return new WaitForSeconds (movePauseTimer);

		var wizardKingAttack = (attackType)Random.Range (1, 4);

		eType = wizardKingAttack;

		chooseType (eType);

	}




	void chooseType(attackType what){

		switch (eType) {

		case attackType.Idle:
			//StartCoroutine ("rest");
			break;

		case attackType.magicBall:
			StartCoroutine ("summonMagicBall");
			print ("magicBall");
			break;

		case attackType.skeleton:
			StartCoroutine ("summonSkeleton");
			print("skeleton");
			break;

		case attackType.thunderCloud:
			StartCoroutine ("summonThunderCloud");
			print("thunderCloud");
			break;

		case attackType.resting:
			StartCoroutine ("rest");
			break;

		}



	}


	IEnumerator summonSkeleton(){

		//yield return new WaitForSeconds (1);


		for (int i = 0; i <= numberOfSkeleton; i++) {

			Vector3 spawnPosition = new Vector3 (this.transform.position.x, transform.position.y, transform.position.z - 0.5f);

			Instantiate (skeleton, spawnPosition, transform.rotation);

			yield return new WaitForSeconds (2);

		}

		StartCoroutine ("movePause");
		
	}


	IEnumerator summonThunderCloud(){

		Vector3 thunderCloudSpawnPosition = new Vector3 (this.transform.position.x, this.transform.position.y + 1.5f, this.transform.position.z);

		Instantiate (thunderCloud, thunderCloudSpawnPosition, transform.rotation);

		yield return new WaitForSeconds (thunderCloudLastTime);

		StartCoroutine ("movePause");

	}

	void controlingCloud(){

		//playAnimation


	}


	IEnumerator summonMagicBall(){

		for (int i = 0; i <= numberOfMagicBall; i++) {

			Vector3 spawnPosition = new Vector3 (this.transform.position.x, transform.position.y, transform.position.z - 0.5f);

			Instantiate (magicBall, spawnPosition, transform.rotation);

			yield return new WaitForSeconds (2);


		}

		StartCoroutine ("movePause");

		

	}

	void dead(){

		if (eType ==  attackType.Idle) {

			health--;

			var wizardKingAttack = (attackType)Random.Range (1, 4);

			eType = wizardKingAttack;

			chooseType (eType);


		}

		if (health <= 0) {

			//dead 
			Destroy(this.gameObject);

		}



	}

	void OnTriggerEnter(Collider c){

		if (c.tag == "Player") {

			c.SendMessage ("die", null, SendMessageOptions.DontRequireReceiver);

		}

	}



}
