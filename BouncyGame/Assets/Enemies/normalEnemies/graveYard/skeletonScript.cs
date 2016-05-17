using UnityEngine;
using System.Collections;

public class skeletonScript : MonoBehaviour {

	GameObject player;
	public float moveSpeed, lastTimer;

	// Use this for initialization
	void Start () {

		player = GameObject.FindWithTag ("Player");

		StartCoroutine ("dying");
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.LookAt (player.transform);

		transform.Translate (Vector3.forward * Time.deltaTime * moveSpeed);

	
	}

	void OnCollisionEnter(Collision other){

		if(other.collider.CompareTag("Player")){
			print ("OK");
			other.collider.SendMessage ("die", null, SendMessageOptions.DontRequireReceiver);
		}

		if (other.collider.CompareTag ("grid")) {

		} else {

			Destroy (this.gameObject);
		}

	
	}


	IEnumerator dying(){

		yield return new WaitForSeconds (lastTimer);

		Destroy (this.gameObject);


	}


}
