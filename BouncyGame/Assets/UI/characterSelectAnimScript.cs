using UnityEngine;
using System.Collections;

public class characterSelectAnimScript : MonoBehaviour {

	Animator anim;
	characterSelectScript control;
	int currentNumber;
	GameManager gm;
	Mesh skin;
	Material skinTexture;

	// Use this for initialization
	void Start () {

		gm = GameObject.FindWithTag ("GM").GetComponent<GameManager> ();
		anim = GetComponent<Animator> ();
		control = GameObject.FindWithTag ("controlScript").GetComponent<characterSelectScript> (); 
		skin = GetComponent<MeshFilter>().sharedMesh;
		skinTexture = GetComponent<Renderer> ().material;
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

		PlayerPrefs.SetInt ("skinNumber", currentNumber);

		print (currentNumber);
		print ("skin");

	}


}
