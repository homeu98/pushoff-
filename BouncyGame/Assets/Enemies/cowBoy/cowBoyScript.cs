﻿using UnityEngine;
using System.Collections;

public class cowBoyScript : MonoBehaviour {

	public GameObject bullet;
	float orginalDegree;
	Vector3 bulletPosition, leftBulletPosition, rightBulletPosition;
	float bulletPlusPosition;
	public float restTimer;

	Quaternion bulletLeftRotation, bulletRightRotation;

	bool pause;

	int reloadingCounter = 3;
	float timer = 2.0f;

	GameObject player;

	// Use this for initialization
	void Start () {

		player = GameObject.FindWithTag ("Player");
	
	
	}

	IEnumerator restartPausing(){

		yield return new WaitForSeconds (restTimer);

		pause = false;
		timer = 2.0f;
		reloadingCounter = 3;


	}

	// Update is called once per frame
	void Update () {

		bulletPlusPosition = this.transform.position.y - 1.0f;
		bulletPosition = new Vector3(this.transform.position.x,this.transform.position.y, this.transform.position.z - 1.0f);
		bulletLeftRotation = Quaternion.Euler (0f, 145f, 0f);
		bulletRightRotation = Quaternion.Euler (0f, 215f, 0f);
		leftBulletPosition = new Vector3 (this.transform.position.x + 0.5f, this.transform.position.y, this.transform.position.z - 1.0f);
		rightBulletPosition = new Vector3 (this.transform.position.x - 0.5f, this.transform.position.y, this.transform.position.z - 1.0f);


		if(!pause)
		timer -= Time.deltaTime;

		if (timer <= 0) {

			shoot ();
			reloadingCounter--;
			timer = 2.0f;


		}

		if (reloadingCounter <= 0) {

			pause = true;
			StartCoroutine ("restartPausing");

		}

		transform.LookAt (player.transform);
	

	}



	void shoot(){	

		Instantiate (bullet, bulletPosition, this.transform.localRotation);
		Instantiate (bullet, leftBulletPosition, bulletLeftRotation);
		Instantiate (bullet, rightBulletPosition, bulletRightRotation);


	}





}