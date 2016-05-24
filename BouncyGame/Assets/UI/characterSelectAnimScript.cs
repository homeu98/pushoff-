using UnityEngine;
using System.Collections;

public class characterSelectAnimScript : MonoBehaviour {

	Animator anim;
	characterSelectScript control;
	int currentNumber;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
		control = GameObject.FindWithTag ("controlScript").GetComponent<characterSelectScript> (); 


	}
	
	// Update is called once per frame
	void Update () {
		
		if (currentNumber == control.minButtonNum) {

			anim.SetBool ("scaleUpAndSpin", true);

			//anim
		} else if(currentNumber != control.minButtonNum){

			anim.SetBool ("scaleUpAndSpin", false);
		}
	}

	void characterNumber(int number){

		currentNumber = number;


	}
}
