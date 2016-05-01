using UnityEngine;
using System.Collections;

public class Looper : MonoBehaviour {
	float numberOfObject;

	// Use this for initialization
	void Start () {
		numberOfObject = Grid.instance.Height;
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter( Collider other){
		if(other.CompareTag("grid")){
			Vector3 gridPos = other.transform.position;
			gridPos.z += numberOfObject * other.GetComponent<BoxCollider> ().size.z;
			other.transform.position = gridPos;
		}
	
	}
}
