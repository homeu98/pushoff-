using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class AnimationEvent : MonoBehaviour {

	public Text KillValueText;
	public Text CoinValueText;
	public Text ComboValueText;

	int coinsWhenLose = 0;
	int killsWhenLose = 0;
	GameManager gm;


	// Use this for initialization
	void Start () {
		

		gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator DisplayPanelEnd(){
		while(killsWhenLose < gm.numbersOfKill || coinsWhenLose < gm.coin ){
			yield return new WaitForSeconds (0.1f);
			if(killsWhenLose < gm.numbersOfKill){
				killsWhenLose++;
				KillValueText.text = "" + killsWhenLose;
			}
			if(coinsWhenLose < gm.coin){
				coinsWhenLose++;
				CoinValueText.text = ""+coinsWhenLose ;
			}
		}


	}
}
