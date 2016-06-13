using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playOrPurcahseScript : MonoBehaviour {


	characterSelectScript control;
	int currentNumber;
	int currentChoosenCharacter;
	Button btt;
	public Text text;
	string currentSkinName;

	// Use this for initialization
	void Start () {
	
		control = GameObject.FindWithTag ("controlScript").GetComponent<characterSelectScript> (); 
		btt = GetComponent<Button> ();

	}
	
	// Update is called once per frame
	void Update () {



	}


	public void pressed(){

		//if purchase was done, it will set the skin.

		if (true) {

			//purchasing on google play or app store

			//done!

			PlayerPrefs.SetInt ("skinNumber", currentNumber);
			PlayerPrefsX.SetBool (currentSkinName, true);

		} else {


			//either they exit the purchase or did not have enough money or whatever

			//do nothing.

		}



	}

	void check(string name){

		currentSkinName = name;

		text.text = "$0.99";

	}


	void thisSkin(int whichSkinNUmber){

		currentNumber = whichSkinNUmber;

		text.text = "PLAY";

	}

}
