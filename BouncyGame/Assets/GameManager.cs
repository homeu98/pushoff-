using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int bear, bigFoot, bird, boar, bunny, cowBoy, crazyChicken, fireFox, grassHopper, porcupine, skunk;
	int totalNumber;

	void Start(){


	}

	void Update(){

		currentNumbersOfEnemies ();
	}

	public void Restart(){
		Application.LoadLevel (Application.loadedLevel);
	}

	public void currentNumbersOfEnemies(){

		totalNumber = bear + bigFoot + bird + boar + bunny + cowBoy + crazyChicken + fireFox + grassHopper + porcupine + skunk;
		print (totalNumber);
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
		
}
