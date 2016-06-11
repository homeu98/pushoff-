using UnityEngine;
using System.Collections;

public class earthSpiritScript : MonoBehaviour {

	public GameObject earthObj;
	public float pauseTimer;


	// Use this for initialization
	void Start () {
	

		StartCoroutine ("earthAttack");
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	IEnumerator earthAttack(){

		yield return new WaitForSeconds (pauseTimer);

		Instantiate (earthObj, this.transform.position, this.transform.rotation);

		StartCoroutine ("earthAttack");

	}


}
