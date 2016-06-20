using UnityEngine;
using System.Collections;

public class itemAnimScript : MonoBehaviour {

	Animator anim;
	itemControl control;
	int currentNumber;
	checkIfItemPurchased itemPur;



	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
		control = GameObject.FindWithTag ("controlScript").GetComponent<itemControl> (); 
		itemPur = GameObject.FindWithTag ("controlScript").GetComponent<checkIfItemPurchased> (); 
		//characterUnl = GameObject.FindWithTag ("controlScript").GetComponent<characterUnlockingScript> (); 

	}

	// Update is called once per frame
	void Update () {


		if (currentNumber == control.minButtonNum) {

			anim.SetBool ("scaleUpAndSpin", true);
			sendItems ();
			//anim
		} else if(currentNumber != control.minButtonNum){

			anim.SetBool ("scaleUpAndSpin", false);
		}
	}

	void itemNumber(int number){

		currentNumber = number;


	}

	void sendItems(){

		if (!itemPur.checkIfItemPured (this.transform.name)) {

			control.SendMessage ("check", this.transform.name, SendMessageOptions.DontRequireReceiver);


		} else {

			control.SendMessage ("thisItem", currentNumber, SendMessageOptions.DontRequireReceiver);


		}

	}



}
