using UnityEngine;
using System.Collections;

public class GrassHopper : MonoBehaviour {
	public float JumpForce = 2f;
	public float period = 2.5f;
	public float CircleRadius= 3f;
	float NextJumpTime;
	public static bool onGround = false;
	Rigidbody rb;
	GameManager gm;
	GameObject player;
	Vector3 playerPosition;
	bool jump;
	public float step;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		NextJumpTime = Time.time + period;

		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();

		gm.SendMessage ("nGrassHopper", 1, SendMessageOptions.DontRequireReceiver);

		player = GameObject.FindWithTag ("Player");

		StartCoroutine ("jumpingPause");
	}


	
	// Update is called once per frame
	void Update () {
		/*if(onGround){
			if(Time.time > NextJumpTime){
				Vector2 JumpDirection = Random.insideUnitCircle * CircleRadius - (Vector2)transform.position;
				rb.velocity = new Vector3 (JumpDirection.x , JumpForce, JumpDirection.y );
				onGround = false;
				NextJumpTime += period;
			}
		}*/

		if (jump && onGround == true) {

			jumping ();
		}

		print (jump);

	}

	void OnCollisionEnter(Collision other){
		if (other.transform.CompareTag ("grid")) {
			
			onGround = true;
		}
		if(other.collider.CompareTag("Player") && transform.position.y >= 0.8f ){
			other.collider.SendMessage ("die", null,SendMessageOptions.DontRequireReceiver);
		}

		if (jump) {
			other.collider.SendMessage ("die", null,SendMessageOptions.DontRequireReceiver);

		}

	}


	IEnumerator jumpingPause(){

		yield return new WaitForSeconds (1);

		playerPosition = player.transform.position;

		rb.AddForce (Vector3.up * JumpForce);

		jump = true;

		yield return new WaitForSeconds (1f);

		jump = false;

		StartCoroutine ("jumpingPause");


	}


	void jumping(){


		transform.position = Vector3.MoveTowards (transform.position, playerPosition, step);


	}

}
