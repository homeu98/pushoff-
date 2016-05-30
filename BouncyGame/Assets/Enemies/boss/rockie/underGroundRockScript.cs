using UnityEngine;
using System.Collections;

public class underGroundRockScript : MonoBehaviour {

	public float timer;
	bool hit;

	Animator anim;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {

		timer -= Time.deltaTime;

		if (timer <= 0) {

			Destroy (this.gameObject);

		}
	
	}

	void OnCollisionEnter(Collision other){


		if (!other.transform.CompareTag("grid") && anim.GetCurrentAnimatorStateInfo (0).IsName ("underGroundRockAnimation")) {

			Vector3 dir = other.contacts [0].point - transform.position;

			dir = dir.normalized;

			other.rigidbody.AddForce (Vector3.up * 1000);
			//other.gameObject.SendMessage ("dead", true, SendMessageOptions.DontRequireReceiver);

		}

	}



}
