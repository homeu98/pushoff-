using UnityEngine;
using System.Collections;

public class spawningScript : MonoBehaviour {


	public GameObject[] chickenList, bear, bigFoot, boar;
	public int numberOfChickenSpawn;

	int enemiesNumber= 5;
	int enemiesType;


	// Use this for initialization
	void Start () {

		randomlizeNumber ();
		InvokeRepeating ("whatToSpawn", 1f, 3f);

	}
	
	// Update is called once per frame
	void Update () {


	
	}
		

	void randomlizeNumber(){

		enemiesType = Random.Range (1, enemiesNumber);
		print (enemiesNumber);

	}


	void whatToSpawn(){

		randomlizeNumber ();

		switch (enemiesType) {

		case 1:

			print ("spawnChicken");
			spawningChicken ();
			break;

		case 2:

			print ("spawningBear");
			spawningBear ();
			break;
		
		case 3:

			print ("spawningBigFoot");
			spawningBigFoot ();
			break;

		case 4:

			print ("spawningBoar");
			spawningBoar ();
			break;

		default:

			print ("nomral");
			break;



		}


	}


	void spawningChicken(){

		int teamNumberChicken = Random.Range (0, chickenList.Length + 1);




		Instantiate (chickenList [1], this.transform.position, chickenList [1].transform.rotation);




	}

	void spawningBear(){

		Instantiate (bear [0], this.transform.position, bear [0].transform.rotation);


	}

	void spawningBigFoot(){

		Instantiate (bigFoot [0], this.transform.position, bigFoot [0].transform.rotation);

	}

	void spawningBoar(){

		Instantiate (boar [0], this.transform.position, boar [0].transform.rotation);


	}



}
