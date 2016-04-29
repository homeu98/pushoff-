using UnityEngine;
using System.Collections;

public class aiJumpingScript : MonoBehaviour {

	Rigidbody rigi;
	public float jumpForce;
	public float jumpPeroid;

	// Use this for initialization
	void Start () {
	
		rigi = transform.GetComponent<Rigidbody> ();
		InvokeRepeating ("jumping", 0, jumpPeroid);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void jumping(){

		rigi.AddForce (Vector3.up * jumpForce);
		print ("jumping");

	}


}
