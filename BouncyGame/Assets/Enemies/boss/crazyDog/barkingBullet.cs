using UnityEngine;
using System.Collections;

public class barkingBullet : MonoBehaviour {

	public float movingSpeed;

	GameObject player;

	Vector3 playerPosition;

	void Start(){

		player = GameObject.FindWithTag ("Player");


		playerPosition = player.transform.position;
		transform.LookAt (playerPosition);

	}

	// Update is called once per frame
	void Update () {

		transform.Translate (Vector3.forward * movingSpeed * Time.deltaTime);

	}


	void OnCollisionEnter(Collision other){

		//no mater what the fireball hits, it will just explode.

		//the bullet hits the player, it dies.
		if(other.collider.CompareTag("Player")){
			other.gameObject.SendMessage ("die", null, SendMessageOptions.DontRequireReceiver);
		}
		//In here, we can add explosion to the bullet when it hits the player.

		Destroy (this.gameObject);
	}

}
