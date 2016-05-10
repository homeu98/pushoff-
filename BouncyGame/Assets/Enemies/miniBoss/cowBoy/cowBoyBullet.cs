using UnityEngine;
using System.Collections;

public class cowBoyBullet : MonoBehaviour {

	public float bulletSpeed;
	float timer = 4f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		this.transform.Translate (Vector3.forward * bulletSpeed * Time.deltaTime);
	
		timer -= Time.deltaTime;

		if (timer <= 0) {

			Destroy (this.gameObject);
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
