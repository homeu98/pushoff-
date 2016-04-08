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

	void GetHurt(float damage){
		rb.AddExplosionForce (damage, transform.position, 0.3f,.8f, ForceMode.Impulse);
		rb.AddForce (transform.forward * damage *10f);
	}
}
