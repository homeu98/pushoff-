using UnityEngine;
using System.Collections;


public class GameManager : MonoBehaviour {

	int totalNumber;
	GameObject mainCamera, player;
	GameManager gm;
	playerModelAnimationScript pa;

	progressBar pb;

	public int numbersOfKill, coin, numberOfEnemiesSpawned;

	public int nKills, nDeath, nHopped;

	Mesh curSkin;
	Material currentMaterial;

	void Awake(){

		player = GameObject.FindWithTag ("Player");

		pb = GameObject.FindWithTag ("progressBar").GetComponent<progressBar> ();
		gm = GameObject.FindWithTag ("GM").GetComponent<GameManager> ();

		totalMoney = PlayerPrefs.GetInt ("totalMoney");


	}

	void Update(){

		mainCamera = GameObject.FindWithTag ("MainCamera");
		miniBossIsHere ();
		print ("number of enemies" + numberOfEnemiesSpawned);

	}

	void miniBossIsHere(){

		if (GameObject.FindWithTag ("miniBoss")) {

			mainCamera.SendMessage ("miniBoss", true, SendMessageOptions.DontRequireReceiver);

		} else {

			mainCamera.SendMessage ("miniBoss", false, SendMessageOptions.DontRequireReceiver);


		}
	}


	void newEnemies(string tag){

		if (numberOfEnemiesSpawned == 100) {

			gm.SendMessage ("progressBarCurrent", 3, SendMessageOptions.DontRequireReceiver);


		}else if (numberOfEnemiesSpawned % 10 == 0 && numberOfEnemiesSpawned != 0) {

			gm.SendMessage ("progressBarCurrent", 2, SendMessageOptions.DontRequireReceiver);

		} else {

			gm.SendMessage ("progressBarCurrent", 1, SendMessageOptions.DontRequireReceiver);

		}





	}

	void deadEnemies(string tag){

		if (tag == "enemy") {

			numbersOfKill += 1;

		}

		if (tag == "boss") {

			numberOfEnemiesSpawned = 0;

		}

		nDeath++;
		savingData (2);
	}


	void addCoin(){

		coin ++;

		totalMoney += coin;
		PlayerPrefs.SetInt ("totalMoney", totalMoney);

	}

	public void holdingDown(){

		player.SendMessage ("holdingButton", null, SendMessageOptions.DontRequireReceiver);

	}

	public void jumpLeft(){

		nHopped++;
		savingData (3);

		player.SendMessage ("movingLeft", null, SendMessageOptions.DontRequireReceiver);

		GameObject graveYard = GameObject.FindWithTag ("graveYard");
	
		if (graveYard != null) {
			graveYard.SendMessage ("addUp", null, SendMessageOptions.DontRequireReceiver);
		}
	}

	public void jumpRight(){

		nHopped++;
		savingData (3);
		player.SendMessage ("movingRight", null, SendMessageOptions.DontRequireReceiver);

		GameObject graveYard = GameObject.FindWithTag ("graveYard");

		if (graveYard != null) {
			graveYard.SendMessage ("addUp", null, SendMessageOptions.DontRequireReceiver);
		}

	}
		
		
	public void achievementUnlocking(){

		//Kills
		if (getKills == 500) {

			PlayerPrefsX.SetBool ("LegendaryPusher", true);
			rewardThePlayer (rewardType.characterSkin, 1);

		} else if (getKills == 300) {

			PlayerPrefsX.SetBool ("AmazingPusher", true);
			rewardThePlayer (rewardType.coins, 300);


		} else if (getKills == 200) {


			PlayerPrefsX.SetBool ("GreatPusher", true);
			rewardThePlayer (rewardType.coins, 250);


		} else if (getKills == 100) {

			PlayerPrefsX.SetBool ("GoodPusher", true);
			rewardThePlayer (rewardType.coins, 200);



		} else if (getKills == 10) {

			PlayerPrefsX.SetBool ("AmateurPusher", true);
			rewardThePlayer (rewardType.coins, 100);



		}


		//Death
		if (getDeath == 50) {

			PlayerPrefsX.SetBool ("badPlayer", true);
			rewardThePlayer (rewardType.coins, 300);


		}

		//Hopped
		if (getHopped == 500) {

			PlayerPrefsX.SetBool ("Hopper", true);
			rewardThePlayer (rewardType.coins, 100);

		}


	}


	public enum rewardType{

		coins,
		characterSkin

	}

	private rewardType type = rewardType.coins;

	public void savingData(int dataNumber){

		switch(dataNumber){

		case 1:
			PlayerPrefs.SetInt ("nKills", nKills);

			break;

		case 2:
			PlayerPrefs.SetInt ("nDeath", nDeath);

			break;
		
		case 3:
			PlayerPrefs.SetInt ("nHopped", nHopped);

			break;

		}
			
		loadData ();

	}

	public int getKills, getDeath, getHopped;

	void loadData(){

		getKills = PlayerPrefs.GetInt ("nKills");
		getDeath = PlayerPrefs.GetInt ("nDeath");
		getHopped = PlayerPrefs.GetInt ("nHopped");


		achievementUnlocking ();

	}

	public int totalMoney;

	void rewardThePlayer(rewardType whatType, int amountOfReward){

		if (whatType == rewardType.coins) {

			totalMoney = PlayerPrefs.GetInt ("totalMoney");
			PlayerPrefs.SetInt ("totalMoney", amountOfReward + totalMoney);

		}

		if (whatType == rewardType.characterSkin) {

			//getSkin

		}


	}




}
