﻿using UnityEngine;
using System.Collections;

public class homingMissleScript : MonoBehaviour {


	GameObject player;

	public float speed;

	// Use this for initialization
	void Start () {

		player = GameObject.FindWithTag ("Player");
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.LookAt (player.transform);

		transform.Translate (Vector3.forward * speed * Time.deltaTime );

	}


	void OnCollisionEnter(Collision other){

		Destroy (this.gameObject);
	}


}
