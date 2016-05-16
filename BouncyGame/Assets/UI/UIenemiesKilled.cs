using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIenemiesKilled : MonoBehaviour {


	Text uiCoin;
	GameManager gm;


	// Use this for initialization
	void Start () {

		uiCoin = GetComponent<Text> ();
		gm = GameObject.FindWithTag ("GM").GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {

		//print (gm.numbersOfKill);
		uiCoin.text = gm.numbersOfKill.ToString ();
	
	}

}
