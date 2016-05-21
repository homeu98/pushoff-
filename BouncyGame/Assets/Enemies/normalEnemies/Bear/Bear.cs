using UnityEngine;
using System.Collections;

public class Bear : MonoBehaviour {


	public  float runAwayTime, runAwaySpeed, chasingSpeed;
	GameObject player;
	GameManager gm;
	SphereCollider lookZone;
	bool startChasing = false;


	// Use this for initialization
	void Start () {
		 player = GameObject.FindGameObjectWithTag ("Player");
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
		lookZone = GetComponent<SphereCollider> ();

	}
	
	// Update is called once per frame
	void Update () {

		if (startChasing) {

			//transform.LookAt (player.transform);
			transform.position = Vector3.MoveTowards (transform.position, player.transform.position, chasingSpeed);


		}

		if (!startChasing) {

			Vector3 endPoint = new Vector3 (3f, 1.3f, -4f);
			transform.position = Vector3.MoveTowards (transform.position, endPoint, runAwaySpeed);


		}

	}

	IEnumerator chasing(){

		yield return new WaitForSeconds (runAwayTime);

		startChasing = false;

	}

	void OnCollisionEnter(Collision other){
		if(other.collider.CompareTag("Player")){
			other.collider.SendMessage ("die", null, SendMessageOptions.DontRequireReceiver);
		}
	}

	void OnTriggerEnter(Collider other){

		if (other.tag == "Player") {

			StartCoroutine ("chasing");
			startChasing = true;

		}


	}
}
