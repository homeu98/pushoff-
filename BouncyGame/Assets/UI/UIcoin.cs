using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIcoin : MonoBehaviour {

	Text text;
	int coinNumber;
	GameManager gm;

	// Use this for initialization
	void Start () {

		text = GetComponent<Text> ();
		gm = GameObject.FindWithTag ("GM").GetComponent<GameManager> ();

	}
	
	// Update is called once per frame
	void Update () {
	
		text.text = gm.coin.ToString (); 

	}




}
