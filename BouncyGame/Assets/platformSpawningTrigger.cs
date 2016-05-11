using UnityEngine;
using System.Collections;

public class platformSpawningTrigger : MonoBehaviour {

	public GameObject bigPlatform;
	public GameObject spawningPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void create(){

		print("binsdakljfa;ls");
		Instantiate (bigPlatform, spawningPosition.transform.position, spawningPosition.transform.rotation);

	}


}
