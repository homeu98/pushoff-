using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Looper : MonoBehaviour {
	 int numberOfObject = 5;
	float HeightOfGrid = 4f;
	float percentageOfPlatform;

	int NoOfPlatform;

	public	GameObject[] TotalPlatform;
	public List<GameObject> TypeOfPlatform = new List<GameObject> ();

	[Range(1f,100f)]public float percentageOfBridge;
	//[Range(1f,100f)]  float percentageOfRoad;

	void Awake(){
		percentageOfPlatform = Random.Range (1f,100f);
		NoOfPlatform = Random.Range (0,5);
	}

	void Start () {
		if(percentageOfPlatform <= percentageOfBridge){
			Vector3 POS = TotalPlatform [NoOfPlatform].transform.position;
			Destroy (TotalPlatform[NoOfPlatform],0f);
			Instantiate (TypeOfPlatform [0], POS, Quaternion.identity);
		}
	}
		

	void OnTriggerEnter(Collider other){
		 percentageOfPlatform = Random.Range (1f,100f);
		if(other.gameObject.layer == 12){
			//print ("OK");
			Vector3 gridPos = other.transform.position;
			gridPos.z += numberOfObject * HeightOfGrid/*other.GetComponent<BoxCollider> ().size.z*/;
			//other.transform.position = gridPos;

			if (other.CompareTag ("grid")) {
				if (percentageOfPlatform <= percentageOfBridge) {
					Destroy (other.gameObject, 0f);
					Instantiate (TypeOfPlatform [0], gridPos, Quaternion.identity);
				} else {
					other.transform.position = gridPos;
					other.gameObject.SendMessage ("ChangeTree", null, SendMessageOptions.DontRequireReceiver);
				}
			}

			if(other.CompareTag("Bridge")){
				if (percentageOfPlatform > percentageOfBridge) {
					Destroy (other.gameObject, 0f);
					Instantiate (TypeOfPlatform [1], gridPos, Quaternion.identity);
					TypeOfPlatform [1].gameObject.SendMessage ("ChangeTree", null, SendMessageOptions.DontRequireReceiver);
				} else {
					other.transform.position = gridPos;
				}
			}
		
			}
	}


}
