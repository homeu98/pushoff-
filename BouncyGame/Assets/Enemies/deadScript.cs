﻿using UnityEngine;
using System.Collections;

public class deadScript : MonoBehaviour {


	GameManager gm;

	bool beingPushed;
	public GameObject coin;

	// Use this for initialization
	void Start () {

		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();

		gm.SendMessage ("newEnemies", this.gameObject.tag, SendMessageOptions.DontRequireReceiver);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void dead(bool beingPush){

		if (beingPush) {

			beingPushed = true;

		}

		gm.SendMessage ("deadEnemies", this.gameObject.tag, SendMessageOptions.DontRequireReceiver);
		//Destroy (this.gameObject);


	}

	void OnCollisionEnter(Collision c){

		if (beingPushed && c.gameObject.tag != "Player" && c.gameObject.tag != "grid") {

			int randomCoinNumber = Random.Range (0, 3);
			//c.gameObject.SendMessage ("dead", true, SendMessageOptions.DontRequireReceiver);
			Instantiate(coin, transform.position, coin.transform.rotation);
			Destroy (this.gameObject);

		}


	}
}
