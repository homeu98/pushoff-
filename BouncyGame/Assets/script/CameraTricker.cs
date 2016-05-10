using UnityEngine;
using System.Collections;

public class CameraTricker : MonoBehaviour {

	public Transform player;
	Vector3 offset;
	// Use this for initialization
	void Start () {
		offset =  transform.position - player.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		pos.z = player.position.z + offset.z;
		transform.position = pos;



	}
}
