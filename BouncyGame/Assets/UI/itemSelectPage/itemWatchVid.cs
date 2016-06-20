using UnityEngine;
using System.Collections;

using UnityEngine.UI;
public class itemWatchVid : MonoBehaviour {

	itemControl control;
	int currentItem;
	string currentItemName;
	public Text text;
	bool isItPured;
	// Use this for initialization
	void Start () {
	
		control = GameObject.FindWithTag ("controlScript").GetComponent<itemControl> (); 


	}
	
	// Update is called once per frame
	void Update () {

		isItPured = PlayerPrefsX.GetBool (currentItemName);


	}



	public void purchaseItem(){

		//if fucntion needed
		//if enough money, they press the button and it will purchase the items
		//else, the button will just turn black and it can't be press.
		if (isItPured) {

			//playTheGameWiththis
			//and change the button to play button

		} else {
			
			PlayerPrefsX.SetBool (currentItemName, true);


		}


	}


	public void watchVid(){

		if (isItPured) {

			//disable this button.

		} else {

			PlayerPrefsX.SetBool (currentItemName, true);

		}

		//after watched the vid

	}
		

	void check(string name){

		//in here, we need to check if the player has enough money
		//if he has enough money, the button will be normal with the price tag on it
		//and if not, the button will be black and can't be press
		currentItemName = name;

		text.text = "$300";

	}

	void thisItem(int itemNumber){

		//this item is already purhcased, if the player press the play button
		//it will select the item

		//the video button will disapper as well, since this is already purchased.
		//and there will be a timer as well, telling the player they can only
		//use this item within a limited time.

		currentItem = itemNumber;

	}
}
