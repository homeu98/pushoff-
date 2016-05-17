using UnityEngine;
using System.Collections;

public class airStrikeBullet : MonoBehaviour {

	public float explodeTImer, stayTimer;

	public SphereCollider radius;

	// Use this for initialization
	void Start () {

		radius = GetComponent<SphereCollider> ();

		radius.enabled = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnCollisionEnter(Collision other){
		
		StartCoroutine ("countDownExplsion");



	}

	void OnTriggerEnter(Collider other){


		other.SendMessage ("die", null, SendMessageOptions.DontRequireReceiver);

	}



	IEnumerator countDownExplsion(){

		yield return new WaitForSeconds (explodeTImer);

		radius.enabled = true;

		yield return new WaitForSeconds (stayTimer);

		Destroy (this.gameObject);


	}
		

}

