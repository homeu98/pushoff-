using UnityEngine;
using System.Collections;

public class cameraMovingScript : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.position += Vector3.forward * speed;

	}



}
