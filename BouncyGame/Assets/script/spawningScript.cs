using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class spawningScript : MonoBehaviour {

	public GameObject[] SpawningPosition, spawningPositionSide, spawningPositionPair;

	public GameObject miniBossSpawnPoint, birdSpawnPoint;

	private spawningStatus eType = spawningStatus.normalEnemies;


	public GameObject[] chickenList, bear, bigFoot, boar, fireFox, grassHopper, porcupine, bird, graveYard, turtleList;

	public GameObject[] miniBossList;

	public GameObject[] bossList;

	GameObject mainCamera;

	int enemiesNumber= 10;
	int enemiesType;

	public int currentCounter = 0;

	int spawningNumber;

	public float pauseSpawningTime ;

	GameManager gm;

	bool miniBossHere;

	bool spawn;


	public enum spawningStatus{

		normalEnemies,
		boss,
		notSpawning

	}


	// Use this for initialization
	void Start () {
		//InvokeRepeating ("whatToSpawn", 1f, 3f);
		mainCamera = GameObject.FindWithTag ("MainCamera");
		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();

		chooseType (currentCounter);

	}


	IEnumerator pauseSpawning(){

		yield return new WaitForSeconds (pauseSpawningTime);

	}

	
	// Update is called once per frame
	void Update () {


		if (eType == spawningStatus.notSpawning) {


		}
	
	}


	void chooseType(int currentCounter){

		if (currentCounter >= 100) {

			eType = spawningStatus.boss;
			spawn = false;

			//here, we send message to the camera to pause it at the arena
			//as well as stopping the spawning

		} else if (currentCounter < 100) {

			eType = spawningStatus.normalEnemies;

			spawn = true;
		}
			

		StartCoroutine ("whatToSpawn", spawn);


	}



	IEnumerator whatToSpawn(bool spawn){



		switch (eType) {

		case spawningStatus.normalEnemies:

			enemiesType = Random.Range (0, 11);
			spawningNumber = Random.Range (0, SpawningPosition.Length - 1);

			break;

		case spawningStatus.boss:

			enemiesType = 12;


			break;

		}
			
		if (spawn) {
			yield return new WaitForSeconds (pauseSpawningTime);


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
				int teamFireFox = Random.Range (0, fireFox.Length);

			//print ("spawningFireFox");
				spawningfireFox (teamFireFox);
				break;
		
			case 7:

				int teamGrassHopper = Random.Range (0, grassHopper.Length);

			//print ("spawningGrassHopper");
				spawninGrassHopper (teamGrassHopper);
				break;

			case 8:
			
				int teamPorcupine = Random.Range (0, porcupine.Length);

			//print ("porcupine");
				spawningPorcupine (teamPorcupine);
				break;

	
			case 9:

				int graveYardList = Random.Range (0, graveYard.Length);
				spawningGraveYard (graveYardList);
				break;
		
			case 10:

				int turtle = Random.Range (0, turtleList.Length);
				spawningTutrle (turtle);
				break;
	
			case 11:

				int miniBoss = Random.Range (0, miniBossList.Length);
				spawningMiniBosses (miniBoss);

				break;

			case 12:

				int boss = Random.Range (0, bossList.Length);
				spawningMiniBosses (boss);



				break;

		
			default:

				break;

			}

			currentCounter = currentCounter + 2;

			chooseType (currentCounter);

		} 
	}

	void spawningMiniBosses(int whichBoss ){

		Instantiate (miniBossList[whichBoss] ,miniBossSpawnPoint.transform.position, miniBossList[whichBoss].transform.rotation);


	}

	void spawningTutrle(int teamTurtle ){

		Instantiate (turtleList[teamTurtle] ,SpawningPosition[spawningNumber].transform.position, turtleList[teamTurtle].transform.rotation);


	}


	void spawningChicken(int teamNumberChicken){


		Instantiate (chickenList [teamNumberChicken], SpawningPosition[spawningNumber].transform.position, chickenList [teamNumberChicken].transform.rotation);


	}

	void spawningGraveYard (int teamNumberGraveYard){

		Instantiate (graveYard [teamNumberGraveYard], SpawningPosition[spawningNumber].transform.position, graveYard [teamNumberGraveYard].transform.rotation);

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

		Instantiate (bird [teamNumberBird], birdSpawnPoint.transform.position, bird [teamNumberBird].transform.rotation);
	

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

	void spawningBoss(int whichBossNumber){


		Instantiate (bossList [whichBossNumber], miniBossSpawnPoint.transform.position, bossList [whichBossNumber].transform.rotation);


	}




}
