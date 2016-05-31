using UnityEngine;
using System.Collections;

public class bombScript: MonoBehaviour {

	GameObject player;
	Rigidbody rigi;
	public float force;
	int valueX,valueZ;
	public float speed;
	public SphereCollider explosiveRadius;

	// Use this for initialization
	void Start () {
		
		explosiveRadius.enabled = false;
		player = GameObject.FindWithTag ("Player");
		rigi = transform.GetComponent<Rigidbody> ();


		valueX = Random.Range (-2, 2);
		valueZ = Random.Range (-2, 6);

		rigi.AddForce (Vector3.up * force);

		StartCoroutine ("exploding");

	}
	
	// Update is called once per frame
	void Update () {

		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, new Vector3(valueX, 0.5f, valueZ) , step) ;

	}


	IEnumerator exploding(){

		yield return new WaitForSeconds (3);

		explosiveRadius.enabled = true;

		yield return new WaitForSeconds (1);

		Destroy (this.gameObject);

	}

}
