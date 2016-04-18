using UnityEngine;
using System.Collections;

public class homingCarrot : MonoBehaviour {
	
	GameObject thePlayer;
	public float speed = 1.0f;
	public float timer = 5.0f;


	// Use this for initialization
	void Start () {
		
		thePlayer = GameObject.FindWithTag ("Player");
		transform.LookAt (thePlayer.transform);
	

	}
	
	// Update is called once per frame
	void Update () {



		transform.LookAt (thePlayer.transform);
		transform.Translate (Vector3.forward * speed * Time.deltaTime);
	
		timer -= Time.deltaTime;
		if (timer <= 0) {
		
			Destroy (this.gameObject);

			//Player explsion
		}
	}


	void OnCollisionEnter(Collision other){

		//no mater what the fireball hits, it will just explode.

		//the bullet hits the player, it dies.

		other.gameObject.SendMessage ("die", null, SendMessageOptions.DontRequireReceiver);

		//In here, we can add explosion to the bullet when it hits the player.

		Destroy (this.gameObject);
	}

}
