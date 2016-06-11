using UnityEngine;
using System.Collections;

public class earthRockScript : MonoBehaviour {

	GameObject player;
	Rigidbody rigi;
	public float force;
	Animator anim;

	// Use this for initialization
	void Start () {


		player = GameObject.FindWithTag ("Player");
		rigi = transform.GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
		randomLocation ();


	}
	void randomLocation(){

		Vector3 randomPosition = Random.insideUnitSphere * 5;

		randomPosition.y = 2f;

		print (randomPosition);
		rigi.AddForce(randomPosition * force);


	}

	void OnCollisionEnter(Collision other){


		other.gameObject.SendMessage ("dead", null, SendMessageOptions.DontRequireReceiver);

		if (other.gameObject.tag != "Player" && other.gameObject != this.gameObject) {
			rigi.isKinematic = true;

		}
		//this.transform.parent = other.gameObject.transform;

		StartCoroutine ("goinDownAnimation");


	}

	IEnumerator goinDownAnimation(){

		yield return new WaitForSeconds (2);

		Destroy (this.gameObject);
	}

}
