using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {
	public float speed = 3f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * Time.deltaTime * speed);
	}

	/*void OnCollisionEnter(Collision other){

		if(other.collider.CompareTag("Player")){
			print ("OK");
			other.collider.SendMessage ("die", null, SendMessageOptions.DontRequireReceiver);
		}
	}*/


}
