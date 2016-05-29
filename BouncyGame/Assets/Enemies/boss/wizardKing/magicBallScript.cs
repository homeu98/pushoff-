using UnityEngine;
using System.Collections;

public class magicBallScript : MonoBehaviour {

	GameObject player;
	public float speed;
	public float timer;

	// Use this for initialization
	void Start () {

		player = GameObject.FindWithTag ("Player");
		transform.LookAt (player.transform);

	
	}
	
	// Update is called once per frame
	void Update () {

		//transform.LookAt (player.transform);

		transform.Translate (Vector3.forward * speed * Time.deltaTime);
		timer -= Time.deltaTime;

		if (timer <= 0) {

			Destroy (this.gameObject);

		}
	
	}

	void OnCollisionEnter(Collision other){

		if (other.collider.tag == "Player") {

			other.gameObject.SendMessage ("die", null, SendMessageOptions.DontRequireReceiver);

		}
		

	}
}
