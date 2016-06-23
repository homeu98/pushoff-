using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class progressBar : MonoBehaviour {

	Slider slider;
	GameManager gm;
	spawningScript spawn;
	int number;

	// Use this for initialization
	void Start () {

		slider = GetComponent<Slider> ();
		spawn = GameObject.FindWithTag ("spawn").GetComponent<spawningScript> ();

	}
	
	// Update is called once per frame
	void Update () {


	}



	void switchToHealthBar(){

		//in here, we set the progres bar to the current boss health, 
		// switching its apperance, and the value.

	}

	void add(int currentProgressBar){

		slider.value = currentProgressBar;

	}

	void bossHealth(int health){

		slider.value = health;

	}


}
