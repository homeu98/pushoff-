using UnityEngine;
using System.Collections;

public class fireSpiritScript : MonoBehaviour {


	public GameObject fireObj;
	public float pauseTimer;


	// Use this for initialization
	void Start () {
	



		StartCoroutine ("fireAttack");
	}
	
	// Update is called once per frame
	void Update () {

	}


	IEnumerator fireAttack(){

		yield return new WaitForSeconds (pauseTimer);

		Instantiate (fireObj, this.transform.position, this.transform.rotation);

		StartCoroutine ("fireAttack");

	}

}
