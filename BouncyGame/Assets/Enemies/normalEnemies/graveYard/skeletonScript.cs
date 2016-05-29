using UnityEngine;
using System.Collections;

public class skeletonScript : MonoBehaviour {

	GameObject player;
	public float moveSpeed, lastTimer;

	// Use this for initialization
	void Start () {

		player = GameObject.FindWithTag ("Player");

		StartCoroutine ("dying");
	
	}
	
	// Update is called once per frame
	void Update () {


		Vector3 relativePos = new Vector3(player.transform.position.x , this.transform.position.y , player.transform.position.z) ;

		transform.LookAt (relativePos);

		transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);


	
	}

	void OnCollisionEnter(Collision other){

		if(other.collider.CompareTag("Player")){
			print ("OK");
			other.collider.SendMessage ("die", null, SendMessageOptions.DontRequireReceiver);
		}

	
	}


	IEnumerator dying(){

		yield return new WaitForSeconds (lastTimer);

		Destroy (this.gameObject);


	}


}
