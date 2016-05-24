using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playOrPurcahseScript : MonoBehaviour {


	characterSelectScript control;
	int currentNumber;
	int currentChoosenCharacter;
	Button btt;

	// Use this for initialization
	void Start () {
	
		control = GameObject.FindWithTag ("controlScript").GetComponent<characterSelectScript> (); 
		btt = GetComponent<Button> ();

	}
	
	// Update is called once per frame
	void Update () {

		currentNumber = control.minButtonNum;


	}

	void characterSelecting(int whichCharacter){

		//inside, will be using playerprefs to save down what character the player have choosen

		switch (whichCharacter) 
		{

		case 1:
			
			break;

		case 2:

			break;

		case 3:

			break;

		case 4:

			break;

		case 5:

			break;


		default:
		
			break;




		}


	}

	public void pressed(){

		characterSelecting (currentNumber);

	}

}
