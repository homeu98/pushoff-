using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RewardSystem : MonoBehaviour {
	int playTimes = 0;

	public float PlayTimesRewardPercentage = 30f;
	public float TemporaryRewardPercentage = 10f;
	//[Range(50,500)]public int RewardCoins;
	public int MinRewardCoins=50;
	public int MaxRewardCoins=500;
	GameManager gm;

	bool AlreadyRewardPlayTimes = false; 
	bool PlayTimesRewarding = false;

	public Text CoinsRewardText;
	public Text TemporaryRewardText;
	public Text SkinsRewardText;

	//Animator Paramter
	public Animator CoinsReward;
	public  Animator TemporaryReward;
	public Animator SkinsReward;
	public Animator WatchAdsReward;
	// Use this for initialization

	void Start () {

		playTimes = PlayerPrefs.GetInt ("playTimes");
		AlreadyRewardPlayTimes = PlayerPrefsX.GetBool ("AlreadyRewardPlayTimes");

		gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
		print (playTimes);
	}


	public void AddPlayTimes(){
		if(!AlreadyRewardPlayTimes){
			playTimes++;
			PlayerPrefs.SetInt ("playTimes", playTimes);
		}
	}

	public void PlayTimesReward(){
		if (playTimes >= 3 && !AlreadyRewardPlayTimes && !PlayTimesRewarding) {
			float compareNumber = Random.Range (1f, 100f);
			if (PlayTimesRewardPercentage >= compareNumber) {
				//CoinsRewardText.text = "Brave Player!" + playTimes + "Times !";
			
				//StartCoroutine ("calculateRewardCoins");
				PlayTimesRewarding = true;
				AlreadyRewardPlayTimes = true;
				PlayerPrefsX.SetBool ("AlreadyRewardPlayTimes", AlreadyRewardPlayTimes);
				CoinsReward.SetTrigger ("IsCoinsReward");
			}
		}
		if(!PlayTimesRewarding){
			WatchAdsReward.SetTrigger ("IsWatchAds");
		}
	}

	public void AskToLottery(){
		if (PlayerPrefs.GetInt ("totalMoney") >= 300) {
			SkinsReward.SetTrigger ("IsSkinsReward");
		}
	}

	public void TemporarySkinsOrItemsReward(){
		float compareNumber = Random.Range (1f, 100f);
		if(PlayerPrefs.GetInt ("totalMoney") >= 300 && TemporaryRewardPercentage >=compareNumber){
			TemporaryReward.SetTrigger("IsTemporaryReward");
		}else if(PlayerPrefs.GetInt ("totalMoney") < 300 && TemporaryRewardPercentage >=compareNumber){
			TemporaryRewardText.rectTransform.parent.localPosition = SkinsRewardText.rectTransform.parent.localPosition;
			TemporaryReward.SetTrigger("IsTemporaryReward");
		}

	}

	IEnumerator calculateRewardCoins(){
		int CoinsAfterReward;
		CoinsAfterReward = gm.totalMoney + Random.Range(MinRewardCoins, MaxRewardCoins);
		PlayerPrefs.SetInt ("totalMoney",CoinsAfterReward);
		while(gm.totalMoney < CoinsAfterReward){
			yield return new WaitForSeconds (0.1f);
			gm.totalMoney++;
		}
		//PlayerPrefs.SetInt ("totalMoney",CoinsAfterReward);
	}

	public void GetCoins(){
		StartCoroutine ("calculateRewardCoins");
	}

	void OnApplicationQuit(){
		PlayerPrefs.SetInt ("playTimes",0);
		PlayerPrefsX.SetBool ("AlreadyRewardPlayTimes",false);
	}

}
