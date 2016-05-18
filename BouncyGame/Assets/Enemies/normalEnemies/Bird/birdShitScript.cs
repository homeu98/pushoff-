using UnityEngine;
using System.Collections;

public class birdShitScript : MonoBehaviour {

	SphereCollider col;

	// Use this for initialization
	void Start () {

		col = GetComponent<SphereCollider> ();
		col.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator birdShit(){

		yield return new WaitForSeconds (2);
		col.enabled = true;

		yield return new WaitForSeconds (0.5f);

		Destroy (this.gameObject);
	}

	void OnCollisionEnter(Collision other){

		other.gameObject.SendMessage ("die", null, SendMessageOptions.DontRequireReceiver);

		StartCoroutine ("birdShit");
		//In here, we can add explosion to the bullet when it hits the player.

	}


	void OnTriggerEnter(Collider col){

		if (col.tag == "Player") {

			col.gameObject.SendMessage ("die", null, SendMessageOptions.DontRequireReceiver);

		}

	}
}
