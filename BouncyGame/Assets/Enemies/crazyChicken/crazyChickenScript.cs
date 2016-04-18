using UnityEngine;
using System.Collections;

public class crazyChickenScript : MonoBehaviour {

	public float speed;
	Vector3 rotateDegree;
	float activetimer = 3f;
	float randomValue;
	public float turningPeroid;
	float randomDegree;
	bool pause;
	public float restTimer;

	// Use this for initialization
	void Start () {

		transform.Rotate (new Vector3 (0f, 180f, 0f));
		InvokeRepeating ("turn", 1f, turningPeroid);

	}
	
	// Update is called once per frame


	void Update(){

		pausingTimer ();

		if (pause) {

			StartCoroutine ("restartPausing");


		} else {

			move ();

		}

	}

	IEnumerator restartPausing(){

		yield return new WaitForSeconds (restTimer);

		pause = false;
		activetimer = 3f;

		print (pause);

	}


	void move(){

		transform.Translate (Vector3.forward * speed * Time.deltaTime);

	}
						
    void turn(){


		randomingTiming ();
	
		transform.Rotate (rotateDegree);

	
	}

	void randomingTiming(){

		randomValue = Random.value;
		randomDegree = Random.Range (-45f, 45f);
		rotateDegree = new Vector3 (0f, randomDegree, 0f);
	}

	void pausingTimer(){

		activetimer -= Time.deltaTime;

		if (activetimer <= 0) {

			StartCoroutine ("restartPausing");
			print ("waiting");
			pause = true;
		} else {

			pause = false;
	
		}
	}
}
