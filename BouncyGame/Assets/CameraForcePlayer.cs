using UnityEngine;
using System.Collections;

public class CameraForcePlayer : MonoBehaviour {
	public float speed = 3f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!StandalonePlayer.IsKilled)
		transform.Translate (-transform.forward * Time.deltaTime * speed);
	}
}
