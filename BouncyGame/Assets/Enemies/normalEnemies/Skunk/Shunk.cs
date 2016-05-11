using UnityEngine;
using System.Collections;



public class Shunk : MonoBehaviour {
	bool IsDanger = false;
	public float chargeTime = 1.5f;
	float NextEjectTime;
	public float StinkDuration = 3f;
	public static float TimeUpToDisappear;
	public static bool IsFaint;
	GameManager gm;


	// Use this for initialization
	void Start () {
		NextEjectTime = Time.time + chargeTime;

		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();

		gm.SendMessage ("nSkunk", 1, SendMessageOptions.DontRequireReceiver);

	}
	
	// Update is called once per frame
	void Update () {

	
		if(IsDanger){
			if (Time.time > NextEjectTime) {
				
				IsFaint = true;
				TimeUpToDisappear = Time.time + StinkDuration;

					NextEjectTime += chargeTime;

			}

		}
	}

	void OnTriggerStay(Collider other){
		if(other.CompareTag("Player")){

			IsDanger = true;
		}
	}

	void OnTriggerExit(Collider other){
		if(other.CompareTag("Player")){
			
			IsDanger = false;

		}
	}


		
		

}
