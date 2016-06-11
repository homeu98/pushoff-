using UnityEngine;
using System.Collections;

public class fireBall : MonoBehaviour {


	GameObject player;
	Rigidbody rigi;
	public float force;

	// Use this for initialization
	void Start () {


		player = GameObject.FindWithTag ("Player");
		rigi = transform.GetComponent<Rigidbody> ();
		randomLocation ();

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void randomLocation(){

		Vector3 randomPosition = Random.insideUnitSphere * 5;

		rigi.AddForce(randomPosition * force);


	}

	void OnCollisionEnter(Collision other){


		other.gameObject.SendMessage ("dead", null, SendMessageOptions.DontRequireReceiver);

		StartCoroutine ("keepOnBurning");


	}

	IEnumerator keepOnBurning(){

		yield return new WaitForSeconds (2);

		Destroy (this.gameObject);
	}

}
