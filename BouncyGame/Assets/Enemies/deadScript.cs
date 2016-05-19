using UnityEngine;
using System.Collections;

public class deadScript : MonoBehaviour {


	GameManager gm;

	// Use this for initialization
	void Start () {

		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();

		gm.SendMessage ("newEnemies", this.gameObject.tag, SendMessageOptions.DontRequireReceiver);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void dead(){

		gm.SendMessage ("deadEnemies", this.gameObject.tag, SendMessageOptions.DontRequireReceiver);
		Destroy (this.gameObject);


	}
}
