using UnityEngine;
using System.Collections;

public class waterSpiritScript : MonoBehaviour {


	public GameObject waterObj;
	public float pauseTimer;


	// Use this for initialization
	void Start () {
	
		StartCoroutine ("waterAttack");
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	IEnumerator waterAttack(){

		yield return new WaitForSeconds (pauseTimer);

		Instantiate (waterObj, this.transform.position, this.transform.rotation);

		StartCoroutine ("waterAttack");

	}


}
