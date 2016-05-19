using UnityEngine;
using System.Collections;


public class GameManager : MonoBehaviour {

	//public int buffalo, bear, bigFoot, bird, boar, bunny, cowBoy, crazyChicken, fireFox, grassHopper, porcupine, skunk;
	int totalNumber;
	GameObject mainCamera;
	GameManager gm;
	progressBar pb;

	public int numbersOfKill, coin, numberOfEnemiesSpawned;

	void Start(){

		pb = GameObject.FindWithTag ("progressBar").GetComponent<progressBar> ();
		gm = GameObject.FindWithTag ("GM").GetComponent<GameManager> ();

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



		if (tag == "enemy") {

			numberOfEnemiesSpawned += 1;

			pb.SendMessage ("add", null, SendMessageOptions.DontRequireReceiver);

		}


	}

	void deadEnemies(string tag){

		if (tag == "enemy") {

			numbersOfKill += 1;

		}

		if (tag == "boss") {

			numberOfEnemiesSpawned = 0;

		}

	}


	void addCoin(){

		coin += 1;

	}
		

	void jumped(){

		GameObject graveYard = GameObject.FindWithTag ("graveYard");

		if (graveYard != null) {
			graveYard.SendMessage ("addUp", null, SendMessageOptions.DontRequireReceiver);
		}
	}
}
