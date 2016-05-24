using UnityEngine;
using System.Collections;

public class coin : MonoBehaviour {

	GameManager gm;
	Animator anim;

	// Use this for initialization
	void Start () {

		gm = GameObject.FindWithTag ("GM").GetComponent<GameManager> ();
		anim = GetComponent<Animator> ();
		StartCoroutine ("coinJump");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator coinJump(){

		anim.SetTrigger ("jump");
		yield return new WaitForSeconds (2);

		StartCoroutine ("coinJump");


	}

	void OnCollisionEnter(Collision other){

		if (other.gameObject.CompareTag("Player")) {

			gm.SendMessage ("addCoin", null, SendMessageOptions.DontRequireReceiver);

			Destroy (this.gameObject);

			print ("picked");
		}

	}

}
