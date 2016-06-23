using UnityEngine;
using System.Collections;

public class fatGuyScript : MonoBehaviour {

	GameObject player;

	public float restTimer, jumpForce, movePauseTimer, step;

	private fatGuy eType = fatGuy.Idle;

	private Vector3 playerPosition;

	Rigidbody rigi;

	public GameObject bear;

	public SphereCollider spinAttackRange;

	float timer = 0f;

	Camera camera;

	public int health = 4;

	GameObject gm;						

	// Use this for initialization
	void Start () {
	
		player = GameObject.FindWithTag ("Player");

		rigi = transform.GetComponent<Rigidbody> ();

		StartCoroutine ("movePause");

		spinAttackRange.enabled = false;

		gm = GameObject.FindWithTag ("GM");

		gm.SendMessage ("bossHealth", health, SendMessageOptions.DontRequireReceiver);

	}
	
	// Update is called once per frame
	void Update () {

		if (eType == fatGuy.jumpBellyAttack) {

			jumpBellyAttack ();

		} 

		if (eType == fatGuy.spinAttack) {

			spinAttack ();

		}

		print (eType);


		if (health <= 0) {

			Destroy (this.gameObject);

		}

	
	}

	public enum fatGuy{

		Idle,
		jumpBellyAttack,
		summorTheBear,
		spinAttack,
		resting

	}


	void chooseType(fatGuy what){

		switch (eType) {

		case fatGuy.Idle:
			//StartCoroutine ("rest");
			break;

		case fatGuy.jumpBellyAttack:
			rigi.AddForce (Vector3.up * jumpForce);
			playerPosition = player.transform.position;
			break;

		case fatGuy.summorTheBear:
			StartCoroutine ("summonTheBear");
			break;

		case fatGuy.spinAttack:
			//straightBiteAttack ();
			break;

		case fatGuy.resting:
			StartCoroutine ("rest");
			break;

		}



	}




	IEnumerator rest(){

		//eType = fatGuy.resting;

		yield return new WaitForSeconds (restTimer);

		StartCoroutine ("movePause");

	}

	IEnumerator movePause(){

		eType = fatGuy.Idle;

		yield return new WaitForSeconds (movePauseTimer);

		var fatGuyAttack = (fatGuy)Random.Range (1, 4);

		eType = fatGuyAttack;

		chooseType (eType);

	}




	void jumpBellyAttack(){

		//playerPosition = player.transform.position;

		this.transform.position = Vector3.MoveTowards (transform.position, playerPosition, step);

		if (Vector3.Distance (transform.position, playerPosition) <= 0.5) {

			print ("arrived");

			eType = fatGuy.resting;

			chooseType (eType);

		}


	}


	IEnumerator summonTheBear(){

		yield return new WaitForSeconds (0);

		for (int i = 0; i < 3; i++) {
			Vector3 randomPosition = new Vector3 (Random.Range (0f, Screen.width) / 100f, 3f, Random.Range (0f, Screen.height) / 100f);

			Vector3 screenPos = Camera.main.ViewportToWorldPoint (randomPosition);
			
			Instantiate (bear, screenPos, bear.transform.rotation);

		}
		eType = fatGuy.resting;
			
		chooseType (eType);

	}

	void spinAttack(){


		timer += Time.deltaTime;

		if (timer >= 3) {

			spinAttackRange.enabled = false;

			eType = fatGuy.resting;

			chooseType (eType);

			timer = 0f;

		} else {

			spinAttackRange.enabled = true;

			//transform.LookAt (player.transform);
			//transform.position += Vector3.forward * Time.deltaTime;

		

		}
			
	

	}


	void OnCollisionEnter(Collision other){

		if (eType != fatGuy.resting) {
			other.gameObject.SendMessage ("die", null, SendMessageOptions.DontRequireReceiver);
		}

	}

	void tookDamage(){

		if (eType == fatGuy.resting) {

			health -= 1;

			var fatGuyAttack = (fatGuy)Random.Range (1, 4);
			eType = fatGuyAttack;

			chooseType (eType);


		}

		if (health <= 0) {

			//dead
			Destroy (this.gameObject);

		}

	}


}
