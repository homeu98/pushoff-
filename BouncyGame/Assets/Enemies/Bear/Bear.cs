using UnityEngine;
using System.Collections;

public class Bear : MonoBehaviour {
	public float ViewRadius = 3f;
	public LayerMask playerMask;
	public float ChaseTime = 4f;
	public float rotationSpeed = 3f;
	public float Speed =2f;
	public  float runAwayTime;
	GameObject player;
	// Use this for initialization
	void Start () {
		runAwayTime = Time.time + ChaseTime;
		 player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {


		if(Physics.CheckSphere(transform.position, ViewRadius, playerMask)){
			if (Time.time > runAwayTime)
				return;

			Quaternion rotation = Quaternion.LookRotation (player.transform.position - transform.position);

			Vector3 zEulerAngles = rotation.eulerAngles;
			zEulerAngles = new Vector3 (0f, rotation.eulerAngles.y, 0f);
			rotation.eulerAngles = zEulerAngles;
		
			transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * rotationSpeed);

			transform.Translate (Vector3.forward * Time.deltaTime* Speed);
		}

	

	}

	void OnCollisionEnter(Collision other){
		if(other.collider.CompareTag("Player")){
			other.collider.SendMessage ("die", null, SendMessageOptions.DontRequireReceiver);
		}
	}
}
