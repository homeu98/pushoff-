using UnityEngine;
using System.Collections;


public class GameManager : MonoBehaviour {

	public int buffalo, bear, bigFoot, bird, boar, bunny, cowBoy, crazyChicken, fireFox, grassHopper, porcupine, skunk;
	int totalNumber;
	GameObject mainCamera;

	public int numbersOfKill, coin;

	void Start(){



	}

	void Update(){

		mainCamera = GameObject.FindWithTag ("MainCamera");
		currentNumbersOfEnemies ();

		if (GameObject.FindWithTag ("miniBoss")) {

			mainCamera.SendMessage ("miniBoss", true, SendMessageOptions.DontRequireReceiver);

		} else {

			mainCamera.SendMessage ("miniBoss", false, SendMessageOptions.DontRequireReceiver);


		}
	}

	public void currentNumbersOfEnemies(){

		totalNumber = bear + bigFoot + bird + boar + bunny + cowBoy + crazyChicken + fireFox + grassHopper + porcupine + skunk;
		//print (totalNumber);

	}

	void nOfKill(int killAdd){

		numbersOfKill += killAdd;

	}

	void nBear(int add){

		bear += add;


	}

	void nBigFoot(int add){

		bigFoot += add;


	}

	void nBird(int add){

		bird += add;


	}

	void nBoar(int add){

		boar += add;

	


	}

	void nBunny(int add){

		bunny += add;




	}

	void nCowBoy(int add){

		cowBoy += add;



	}


	void ncrazyChicken(int add){

		crazyChicken += add;





	}

	void nFireFox(int add){
		
		fireFox += add;




	}


	void nGrassHopper(int add){

		grassHopper += add;


	}


	void nPorcupine(int add){

		porcupine += add;



	}

	void nSkunk(int add){

		skunk += add;



	}

	void nBuffalo(int add){

		buffalo += add;

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
