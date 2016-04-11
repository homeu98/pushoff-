using UnityEngine;
using System.Collections;

public class FrontgettingHit : MonoBehaviour {
	Rigidbody rb;


	// Use this for initialization
	void Start () {
		rb = GetComponentInParent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FrontGetHurt(float damage){
		//rb.AddExplosionForce (damage, transform.position, 0.1f,0f, ForceMode.Impulse);
		rb.AddForce (-transform.forward * damage );
	}


}
