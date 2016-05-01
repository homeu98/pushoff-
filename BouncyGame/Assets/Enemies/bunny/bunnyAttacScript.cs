using UnityEngine;
using System.Collections;

public class bunnyAttacScript : MonoBehaviour {

	public GameObject homingCarrot;
	float playerLocation;
	public float shootPeroid = 3.0f;
	GameObject player;
	GameManager gm;

	// Use this for initialization
	void Start () {

		player = GameObject.FindWithTag ("Player");
		InvokeRepeating ("attack", 2.0f, shootPeroid);

		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();

		gm.SendMessage ("nBunny", 1, SendMessageOptions.DontRequireReceiver);


	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void attack(){

		/*
		 * 
		 * simple attack, here can add attack animation 

		*/

		Vector3 playerPosition = player.transform.position;

		Vector3 currentLocation = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z - 1.0f);

		Instantiate (homingCarrot, currentLocation, this.transform.localRotation);


	}
}
