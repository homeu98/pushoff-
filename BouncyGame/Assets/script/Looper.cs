using UnityEngine;
using System.Collections;

public class Looper : MonoBehaviour {
	 int numberOfObject;
	float HeightOfGrid;

	// Use this for initialization
	void Start () {
		numberOfObject = 5;
		HeightOfGrid = 4f;
	}

	// Update is called once per frame

	void OnTriggerEnter(Collider other){
		if(other.CompareTag("grid")){
			Vector3 gridPos = other.transform.position;
			gridPos.z += numberOfObject * HeightOfGrid/*other.GetComponent<BoxCollider> ().size.z*/;
			other.transform.position = gridPos;
			other.gameObject.SendMessage ("ChangeTree", null, SendMessageOptions.DontRequireReceiver);
		}
	
	}
}
