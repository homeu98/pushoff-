using UnityEngine;
using System.Collections;

public class thunderCloud : MonoBehaviour {

	GameObject player;
	public float speed;
	public BoxCollider thunderZone;
	public float timer;

	// Use this for initialization
	void Start () {
	
		player = GameObject.FindWithTag ("Player");
		//thunderZone = this.gameObject.GetComponent<BoxCollider>();
		//thunderZone.enabled = false;

		StartCoroutine("thunderTrigger");
		//InvokeRepeating ("thunderAttack", 1f, 2f);
	}
	
	// Update is called once per frame
	void Update () {

		float step = speed * Time.deltaTime;

		Vector3 playerPosition = new Vector3 (player.transform.position.x, 2.5f, player.transform.position.z);

		transform.position = Vector3.MoveTowards (transform.position, playerPosition, step);

		timer -= Time.deltaTime;

		if (timer <= 0) {

			Destroy (this.gameObject);

		}
	
	}

	IEnumerator thunderTrigger(){

		print ("INside");
		thunderZone.enabled = true;

		yield return new WaitForSeconds (1);

		thunderZone.enabled = false;

		yield return new WaitForSeconds (2);

		StartCoroutine ("thunderTrigger");



	}

	void OnTriggerEnter(Collider other){


		if (other.tag == "Player") {
			print ("attacking");
			other.SendMessage ("die", null, SendMessageOptions.DontRequireReceiver);

		}

	}
		



}
