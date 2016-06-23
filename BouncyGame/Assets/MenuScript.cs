using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

	public GameObject eachButtonPanel;
	public GameObject LosePage;
	public Animator replayPanelParamter;
	public GameObject Player;

	RewardSystem rewardsystem;

	bool Unparent = false;




	void Start () {
		rewardsystem = GameObject.FindGameObjectWithTag ("canvas").GetComponent<RewardSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartGame(){
		eachButtonPanel.SetActive (false);

		Rigidbody rb = Player.GetComponent<Rigidbody> ();
		Player.transform.SetParent (null);
		//Vector3 currentAngle = Player.transform.localEulerAngles;
		/*if(!Player.transform.IsChildOf(Camera.main.transform)){
			Player.transform.localEulerAngles = Vector3.zero;
			Destroy(Player.GetComponent<Animator> ()) ;
			Player.GetComponentInChildren<Animator> ().enabled = true;
		}*/
		rb.useGravity = true;
		rb.AddForce (new Vector3(0f,150f,80f));
	}
	public void viewStandalone(){
		SceneManager.LoadScene ("standalone 1");
	}
	public void viewCharacter(){
		SceneManager.LoadScene ("characterSelectScene");
	}
	public void viewAchievement(){
		SceneManager.LoadScene ("achievementSelectScene");
	}
	public void viewItems(){
		SceneManager.LoadScene ("itemsSelectScene");
	}
	public void viewSetting(){
		SceneManager.LoadScene ("settingSelectScene");
	}
	public void viewLottery(){
		SceneManager.LoadScene ("LotteryScene");
	}


	public void PopInLosePage(){
		LosePage.SetActive (true);
		if(LosePage.activeSelf){
			rewardsystem.PlayTimesReward ();
			rewardsystem.TemporarySkinsOrItemsReward ();
			rewardsystem.AskToLottery ();
			replayPanelParamter.SetTrigger ("GameOver");
		}

	}
}
