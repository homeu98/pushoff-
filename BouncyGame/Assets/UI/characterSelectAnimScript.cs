using UnityEngine;
using System.Collections;

public class characterSelectAnimScript : MonoBehaviour {

	Animator anim;
	characterSelectScript control;
	int currentNumber;
	characterUnlockingScript characterUnl;
	GameObject playOrPur;


	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
		control = GameObject.FindWithTag ("controlScript").GetComponent<characterSelectScript> (); 

		characterUnl = GameObject.FindWithTag ("controlScript").GetComponent<characterUnlockingScript> (); 
		playOrPur = GameObject.FindWithTag ("playOrPur");
	}
	
	// Update is called once per frame
	void Update () {
		
		if (currentNumber == control.minButtonNum) {

			anim.SetBool ("scaleUpAndSpin", true);
			sendSkin ();
			//anim
		} else if(currentNumber != control.minButtonNum){

			anim.SetBool ("scaleUpAndSpin", false);
		}
	}

	void characterNumber(int number){

		currentNumber = number;


	}

	void sendSkin(){

		if (!characterUnl.checkIfSkinUnlocked (this.transform.name)) {

			playOrPur.SendMessage ("check", this.transform.name, SendMessageOptions.DontRequireReceiver);

		} else {

			playOrPur.SendMessage ("thisSkin", currentNumber, SendMessageOptions.DontRequireReceiver);


		}
			
	}




}
