using UnityEngine;
using System.Collections;

public class thunderSpiritScript : MonoBehaviour {

	public GameObject thunderBolt;
	public float pauseTimer;

	// Use this for initialization
	void Start () {

		StartCoroutine ("thunderAttack");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator thunderAttack(){

		yield return new WaitForSeconds (pauseTimer);

		Vector3 randomPosition = Random.insideUnitSphere * 2 + this.transform.position ;

		randomPosition.y = 4f;

		Instantiate (thunderBolt, randomPosition, this.transform.rotation);

		StartCoroutine ("thunderAttack");

	}
}
