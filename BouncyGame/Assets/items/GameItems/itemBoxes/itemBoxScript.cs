using UnityEngine;
using System.Collections;

public class itemBoxScript : MonoBehaviour {

	int spirit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void randomSpirit(){

		spirit = Random.Range (0, 6);

	}

	void OnTriggerEnter(Collider other){

		if (other.gameObject.tag == "Player") {

			randomSpirit ();

			other.gameObject.SendMessage ("spirit", spirit, SendMessageOptions.DontRequireReceiver);

			print (spirit);

			Destroy (this.gameObject);

		}


	}


}
