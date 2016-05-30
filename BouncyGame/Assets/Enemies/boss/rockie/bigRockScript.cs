using UnityEngine;
using System.Collections;

public class bigRockScript : MonoBehaviour {

	GameObject player;
	Rigidbody rigi;
	public float force;

	// Use this for initialization
	void Start () {

		player = GameObject.FindWithTag ("Player");
		rigi = transform.GetComponent<Rigidbody> ();
	
		Vector3 dir =   player.transform.position - transform.position; 

		rigi.AddForce(dir * force);


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision other){


		other.gameObject.SendMessage ("die", null, SendMessageOptions.DontRequireReceiver);

		//Destroy (this.gameObject);
	}



}
