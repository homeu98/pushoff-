using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class progressBar : MonoBehaviour {

	Slider slider;
	GameManager gm;

	// Use this for initialization
	void Start () {

		slider = GetComponent<Slider> ();
	
	}
	
	// Update is called once per frame
	void Update () {


	
	}

	void add(int number){

		slider.value += number;

	}

}
