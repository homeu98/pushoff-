using UnityEngine;
using System.Collections;

public class controlScript : MonoBehaviour {

	GameObject player;
	public float rotationLeft, rotationRight;

	// Use this for initialization
	void Start () {
	
		player = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void holding(){
		player.SendMessage ("holdingButton", null, SendMessageOptions.DontRequireReceiver);

	}

	public void moveLeft(float rotationLeft){

		player.SendMessage ("movingLeft", rotationLeft, SendMessageOptions.DontRequireReceiver);
	}
		
	public void moveRight(float rotationRight){
		print ("holding");

		player.SendMessage ("movingRight", rotationRight, SendMessageOptions.DontRequireReceiver);

	}
}
