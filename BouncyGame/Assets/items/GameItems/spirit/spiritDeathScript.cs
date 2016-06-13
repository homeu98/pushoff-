using UnityEngine;
using System.Collections;

public class spiritDeathScript : MonoBehaviour {

	float deathTime = 12f;

	// Use this for initialization
	void Start () {

		StartCoroutine ("rest");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator rest(){

		yield return new WaitForSeconds (deathTime);

		Destroy (this.gameObject);

	}



}
