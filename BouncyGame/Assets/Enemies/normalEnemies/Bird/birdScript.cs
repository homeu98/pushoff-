using UnityEngine;
using System.Collections;

public class birdScript : MonoBehaviour {

	public float flyingSpeed, whenToShit;

	GameManager gm;

	float timer = 5f;

	public GameObject birdShitBullet;
	// Use this for initialization
	void Start () {

		StartCoroutine ("birdShit");
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();

	}
	
	// Update is called once per frame
	void Update () {
	
		transform.Translate (Vector3.forward * flyingSpeed * Time.deltaTime);

		timer -= Time.deltaTime;

		if (timer <= 0) {


			Destroy (this.gameObject);


		}

	}

	IEnumerator birdShit(){

		yield return new WaitForSeconds (whenToShit);

		Instantiate (birdShitBullet, transform.position, transform.rotation);

		StartCoroutine ("birdShit");

	}






}
