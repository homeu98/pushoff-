using UnityEngine;
using System.Collections;

public class GrassHopper : MonoBehaviour {


	Rigidbody rb;
	GameManager gm;
	GameObject player;
	public float runAwayTime, jumpingSpeed, force;
	bool jumping = false;



	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();

		player = GameObject.FindWithTag ("Player");
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
		StartCoroutine ("chasing");
	}
	
	// Update is called once per frame
	void Update () {

		if (jumping) {

			chase ();

		}

	}


	IEnumerator chasing(){
		
		rb.AddForce (Vector3.up * force);
		jumping = true;
		yield return new WaitForSeconds (runAwayTime);

		jumping = false;
		yield return new WaitForSeconds (2);
		StartCoroutine ("chasing");


	}


	void chase(){

		transform.position = Vector3.MoveTowards (transform.position, player.transform.position, jumpingSpeed);
	}


	void OnCollisionEnter(Collision other){

		if(other.collider.CompareTag("Player") && transform.position.y >= 0.8f){
			other.collider.SendMessage ("die", null,SendMessageOptions.DontRequireReceiver);
		}
	}


}
