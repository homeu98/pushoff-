using UnityEngine;
using System.Collections;

public class droppingRock : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnCollisionEnter(Collision other){

		print ("uh");

		other.gameObject.SendMessage ("die", null, SendMessageOptions.DontRequireReceiver);

		Destroy (this.gameObject);

	}

}
