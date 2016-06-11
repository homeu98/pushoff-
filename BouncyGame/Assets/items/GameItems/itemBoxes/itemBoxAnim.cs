using UnityEngine;
using System.Collections;

public class itemBoxAnim : MonoBehaviour {

	Animator anim;
	public float jumpingPause;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
		StartCoroutine ("jumping");

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	IEnumerator jumping(){

		yield return new WaitForSeconds (jumpingPause);

		anim.SetTrigger ("shake");
	
		StartCoroutine ("jumping");
	}

}
