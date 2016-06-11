using UnityEngine;
using System.Collections;

public class waterBubbleScript : MonoBehaviour {


	GameObject player;
	Rigidbody rigi;
	public float force;
	Vector3 randomPosition ;
	// Use this for initialization
	void Start () {

		player = GameObject.FindWithTag ("Player");
		rigi = transform.GetComponent<Rigidbody> ();

		randomLocation ();


	
	}
	
	// Update is called once per frame
	void Update () {

		//randomLocation ();
	
	}

	void randomLocation(){

		randomPosition = Random.insideUnitSphere * 4;
		//ArandomPosition.y = 2f;
		rigi.AddForce(randomPosition * force);
		//rigi.velocity = randomPosition;

	}


	void OnCollisionEnter(Collision other){

		if (other.gameObject.tag == "grid") {

			//pop animation

			Destroy (this.gameObject);

		} else if(other.gameObject.tag == "enemy"){

			other.gameObject.SendMessage ("bubbled", null, SendMessageOptions.DontRequireReceiver);

			Destroy (this.gameObject);
			
		}


	}



}
