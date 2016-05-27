using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class cameraMovingScript : MonoBehaviour {

	private float speed;

	Slider progressBar;


	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
	
		transform.position += Vector3.forward * speed;


		if (GameObject.FindWithTag ("miniBoss")) {

			speed = 0f;
		} else {

			speed = 0.005f;
		}


	}
		


}
