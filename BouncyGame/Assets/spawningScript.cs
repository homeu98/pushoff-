using UnityEngine;
using System.Collections;

public class spawningScript : MonoBehaviour {

	public int numberOfChickenSpawn;
	public GameObject[] SpawningPosition, spawningPositionSide, spawningPositionPair;


	public GameObject[] chickenList, bear, bigFoot, boar,bunny, cowBoy, fireFox, grassHopper, porcupine, bird;


	int enemiesNumber= 10;
	int enemiesType;


	int spawningNumber;

	GameManager gm;



	// Use this for initialization
	void Start () {

		randomlizeNumber ();
		InvokeRepeating ("whatToSpawn", 1f, 3f);

		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();


	}
	
	// Update is called once per frame
	void Update () {

	
	
	}
		

	void randomlizeNumber(){

		enemiesType = Random.Range (1, enemiesNumber);

		spawningNumber = Random.Range (0, SpawningPosition.Length - 1);


	}

	void doNotSpawnTheSameThing(){

		// here to set the limit of each enemies spawning number

		if (gm.crazyChicken >= 5) {

			if (enemiesType == 1) 
					enemiesType += 1;
		}


		if (gm.bear >= 2) {

			if (enemiesType == 2) 
				enemiesType += 1;

		}

		if (gm.bigFoot >= 2) {

			if (enemiesType == 3) 
				enemiesType += 1;
		}

		if (gm.boar >= 5) {

			if (enemiesType == 4) 
				enemiesType += 1;
			
		}

		if (gm.bird >= 1) {

			if (enemiesType == 5)
				enemiesType += 1;

		}

		if (gm.bunny >= 2) {

			if (enemiesType == 6) 
				enemiesType += 1;

		}

		if (gm.cowBoy >= 2) {

			if (enemiesType == 7)
				enemiesType += 1;

		}

		if(gm.fireFox >= 2){

			if (enemiesType == 8) 
				enemiesType += 1;

		}

		if(gm.grassHopper>= 1){

			if (enemiesType == 9) 
				enemiesType += 1;

		}

		if(gm.porcupine >= 2){

			if(enemiesType ==10)
				enemiesType = 1;

		}
	}


	void whatToSpawn(){

		randomlizeNumber ();

		doNotSpawnTheSameThing ();

		switch (enemiesType) {

		case 1:


			int teamNumberChicken = Random.Range (0, chickenList.Length);


			//print ("spawnChicken");
			spawningChicken (teamNumberChicken);
			break;

		case 2:

			int teamNumberBear = Random.Range (0, bear.Length);


			//print ("spawningBear");
			spawningBear (teamNumberBear);
			break;
		
		case 3:

			int teamNumberBigFoot = Random.Range (0, bigFoot.Length);

			//print ("spawningBigFoot");
			spawningBigFoot (teamNumberBigFoot);
			break;

		case 4:

			int teamNumberBoar = Random.Range (0, boar.Length);

			//print ("spawningBoar");
			spawningBoar (teamNumberBoar);
			break;
		
		case 5:

			int teamNumberBird = Random.Range (0, bird.Length);


			//print ("spawningBird");
			spawningBird (teamNumberBird);
			break;

		case 6:

			int teamNumberBunny = Random.Range (0, bunny.Length);


			//print ("spawningBunny");
			spawningBunny (teamNumberBunny);
			break;

		case 7:

			int teamNumberCowBoy = Random.Range (0, cowBoy.Length);


			//print ("spawningCowBoy");
			spawningCowBoy (teamNumberCowBoy);
			break;

		case 8:
			int teamFireFox = Random.Range (0, fireFox.Length);


			//print ("spawningFireFox");
			spawningfireFox (teamFireFox);
			break;
		
		case 9:

			int teamGrassHopper = Random.Range (0, grassHopper.Length);

			//print ("spawningGrassHopper");
			spawninGrassHopper (teamGrassHopper);
			break;

		case 10:
			
			int teamPorcupine = Random.Range (0, porcupine.Length);

			//print ("porcupine");
			spawningPorcupine (teamPorcupine);
			break;

	

		default:

			print ("nomral");
			break;



		}


	}


	void spawningChicken(int teamNumberChicken){


		Instantiate (chickenList [teamNumberChicken], SpawningPosition[spawningNumber].transform.position, chickenList [teamNumberChicken].transform.rotation);


	}

	void spawningBear(int teamNumberBear){



		Instantiate (bear [teamNumberBear], SpawningPosition[spawningNumber].transform.position , bear [teamNumberBear].transform.rotation);


	}

	void spawningBigFoot(int teamNumberBigFoot){


		Instantiate (bigFoot [teamNumberBigFoot], SpawningPosition[spawningNumber].transform.position, bigFoot [teamNumberBigFoot].transform.rotation);

	}

	void spawningBoar(int teamNumberBoar){




		Instantiate (boar [teamNumberBoar], SpawningPosition[spawningNumber].transform.position, boar [teamNumberBoar].transform.rotation);


	}

	void spawningBird(int teamNumberBird){



		Instantiate (bird [teamNumberBird], SpawningPosition[spawningNumber].transform.position, bird [teamNumberBird].transform.rotation);


	}

	void spawningBunny(int teamNumberBunny){


		Instantiate (bunny [teamNumberBunny], SpawningPosition[spawningNumber].transform.position, bunny [teamNumberBunny].transform.rotation);


	}

	void spawningCowBoy(int teamNumberCowBoy){


		Instantiate (cowBoy [teamNumberCowBoy], SpawningPosition[spawningNumber].transform.position, cowBoy [teamNumberCowBoy].transform.rotation);


	}


	void spawningfireFox(int teamFireFox){



		Instantiate (fireFox [teamFireFox], SpawningPosition[spawningNumber].transform.position, fireFox [teamFireFox].transform.rotation);


	}

	void spawningPorcupine(int teamPorcupine){


		Instantiate (porcupine [teamPorcupine], SpawningPosition[spawningNumber].transform.position, porcupine [teamPorcupine].transform.rotation);


	}

	void spawninGrassHopper(int teamGrassHopper){



		Instantiate (grassHopper [teamGrassHopper], SpawningPosition[spawningNumber].transform.position, grassHopper [teamGrassHopper].transform.rotation);


	}




}
