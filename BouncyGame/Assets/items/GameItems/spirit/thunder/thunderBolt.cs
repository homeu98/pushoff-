using UnityEngine;
using System.Collections;

public class thunderBolt : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.position += Vector3.down * Time.deltaTime * speed;
	
	}


	void OnCollisionEnter(Collision other){

		other.gameObject.SendMessage ("dead", null, SendMessageOptions.DontRequireReceiver);

		Destroy (this.gameObject);
	}


}
