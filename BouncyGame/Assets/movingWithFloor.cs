using UnityEngine;
using System.Collections;

public class movingWithFloor : MonoBehaviour {


	public Rigidbody rb;


	void Start() {
		rb = GetComponent<Rigidbody>();
	}


	void FixedUpdate() {


	}


	void OnCollisionStay(Collision other){

		print ("ON");
		transform.parent = other.transform;

	}


}
