using UnityEngine;
using System.Collections;

public class gettingHit : MonoBehaviour {
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponentInParent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void BackGetHurt(float damage){
		//rb.AddExplosionForce (5f, transform.position, 0.1f, 0.5f, ForceMode.Impulse);
		rb.AddForce (transform.forward * (damage+100f) );
	}
		


}
