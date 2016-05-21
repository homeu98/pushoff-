using UnityEngine;
using System.Collections;

public class CameraForcePlayer : MonoBehaviour {
	public float speed = 3f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (-transform.forward * Time.deltaTime * speed);
	}

	void miniBoss(bool boss){

		if(boss)
		speed = 0f;

		if (!boss)
			speed = 0.4f;
	}
}
