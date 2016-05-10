using UnityEngine;
using System.Collections;

public class droppingCoin : MonoBehaviour {

	public GameObject coin;
	int numberOfCoinDrop;

	// Use this for initialization
	void Start () {

		if (gameObject.tag == "miniBoss") {


			numberOfCoinDrop = 5;
		} else {

			numberOfCoinDrop = 1;
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void drop(){

		for (int i = 0; i >= numberOfCoinDrop; i++) {
			Instantiate (coin, this.transform.position, this.transform.localRotation);
		}
	}


}
