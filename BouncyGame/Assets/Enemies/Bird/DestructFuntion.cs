using UnityEngine;
using System.Collections;

public class DestructFuntion : MonoBehaviour {
	public float Timer = 3f;
	public float speed= 2f;

	// Use this for initialization
	void Start () {
		
		Destroy (gameObject, Timer);
	}
	
	void Update(){

		transform.Translate (transform.forward * Time.deltaTime * speed);


	}

	void OnCollisionEnter(Collision other){
		if(other.collider.CompareTag("Player")){
			other.collider.SendMessage ("die", null, SendMessageOptions.DontRequireReceiver);
		}
	}
}
