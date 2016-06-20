using UnityEngine;
using System.Collections;

public class characterSelectedScript : MonoBehaviour {

	bool Choosen = false;
	RectTransform character;

	// Use this for initialization
	void Start () {

		character = GetComponent<RectTransform> ();
		//lerpToSize (false);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void choosenOne(bool active){

	}


}
