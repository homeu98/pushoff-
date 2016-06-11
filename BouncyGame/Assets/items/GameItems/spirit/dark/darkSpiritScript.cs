using UnityEngine;
using System.Collections;

public class darkSpiritScript : MonoBehaviour {

	public GameObject darkObj;
	public float pauseTimer;
	bool controling;

	// Use this for initialization
	void Start () {
		
		StartCoroutine ("darkAttack");
	
	}
	
	// Update is called once per frame
	void Update () {

		if (controling)
			controlAnim ();
	
	}



	IEnumerator darkAttack(){

		yield return new WaitForSeconds (pauseTimer);


		Vector3 randomPosition = Random.insideUnitSphere * 5;

		randomPosition.y = 0.7f;

		if (randomPosition.x < 1) {

			randomPosition.x = 1.5f;

		}

		if (randomPosition.z < 1) {

			randomPosition.z = 1.5f;

		}



		Instantiate (darkObj, randomPosition, this.transform.rotation);

		//StartCoroutine ("earthAttack");

	}

	void controlAnim(){

		//playanimtion

	}



}
