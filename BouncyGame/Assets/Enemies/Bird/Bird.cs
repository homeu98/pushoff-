using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision other){

		if(other.collider.CompareTag("Player")){
			print ("OK");
			other.collider.SendMessage ("die", null, SendMessageOptions.DontRequireReceiver);
		}
	}
}
