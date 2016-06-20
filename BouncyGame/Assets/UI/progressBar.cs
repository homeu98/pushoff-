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

		slider.value = spawn.currentCounter;

	}


}
