using UnityEngine;
using System.Collections;

public class smallRocks : MonoBehaviour {

	GameObject player;
	Rigidbody rigi;
	public float force;
	int valueX,valueZ;
	public float speed;

	// Use this for initialization
	void Start () {

		player = GameObject.FindWithTag ("Player");
		rigi = transform.GetComponent<Rigidbody> ();


		valueX = Random.Range (-2, 2);
		valueZ = Random.Range (-2, 6);

		print (valueX + "" + valueZ);
		rigi.AddForce (Vector3.up * force);

	}
	
	// Update is called once per frame
	void Update () {

		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, new Vector3(valueX, 0f, valueZ) , step) ;

	
	}

	void OnCollisionEnter(Collision other){


		other.gameObject.SendMessage ("die", null, SendMessageOptions.DontRequireReceiver);

		//Destroy (this.gameObject);

	}

}
