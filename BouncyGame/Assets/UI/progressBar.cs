using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class progressBar : MonoBehaviour {

	Slider slider;
	GameManager gm;
	spawningScript spawn;

	// Use this for initialization
	void Start () {

		slider = GetComponent<Slider> ();
		spawn = GameObject.FindWithTag ("spawn").GetComponent<spawningScript> ();

	}
	
	// Update is called once per frame
	void Update () {


	}

	void add(int currentProgress){

		slider.value = currentProgress;

		if (currentProgress >= 100) {

			//spawning Boss



		}


	}

	void switchToHealthBar(){

		//in here, we set the progres bar to the current boss health, 
		// switching its apperance, and the value.

	}




}
