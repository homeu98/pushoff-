using UnityEngine;
using System.Collections;

public class coin : MonoBehaviour {

	GameManager gm;

	// Use this for initialization
	void Start () {

		gm = GameObject.FindWithTag ("GM").GetComponent<GameManager> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision other){

		if (other.gameObject.CompareTag("Player")) {

			gm.SendMessage ("addCoin", null, SendMessageOptions.DontRequireReceiver);

			Destroy (this.gameObject);

			print ("picked");
		}

	}

}
