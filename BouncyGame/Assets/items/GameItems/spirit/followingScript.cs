using UnityEngine;
using System.Collections;

public class followingScript : MonoBehaviour {

	float speed = 1f;
	GameObject player;

	GameObject spiritPos;

	// Use this for initialization
	void Start () {
		
		player = GameObject.FindWithTag ("Player");
		spiritPos = GameObject.FindWithTag ("spiritPos");
	
	}
	
	// Update is called once per frame
	void Update () {

		followScript ();
	
	}


	void followScript(){

		float step = speed * Time.deltaTime;

		if (Vector3.Distance (this.transform.position, spiritPos.transform.position) >= 1.5) {

			speed = 1.5f ;

		} else {

			speed = 0.8f;

		}

		transform.position = Vector3.MoveTowards (this.transform.position, spiritPos.transform.position, step);


	}


}
