using UnityEngine;
using System.Collections;

public class playerModelAnimationScript : MonoBehaviour {

	Animator anim;
	GameObject player;

	// Use this for initialization
	void Awake () {

		anim = GetComponent<Animator> ();
		player = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void moved(){

		anim.SetTrigger ("Jump");
	}



}
