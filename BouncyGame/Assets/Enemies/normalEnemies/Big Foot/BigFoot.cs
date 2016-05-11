using UnityEngine;
using System.Collections;

public class BigFoot : MonoBehaviour {
	public float period = 4.0f;
	//public LayerMask playerMask;
	float attackTimer = 2.0f;
	bool isAttacking = false;
	public float movingSpeed;

	public SphereCollider attackzone;
	GameManager gm;

	// Use this for initialization
	void Start () {

		//This is a method to loop a method 
		InvokeRepeating ("Attack", 3.0f, period);
		attackzone = gameObject.GetComponent<SphereCollider> ();
		attackzone.enabled = false;

		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();

		gm.SendMessage ("nBigFoot", 1, SendMessageOptions.DontRequireReceiver);



	}

	// Update is called once per frame
	void Update () {

		//This is a timer to make the attackZone enables a bit longer, as big
		//foot will hit the ground multiple times so, the damage will last for
		//2 second in total.
	



		if (isAttacking) {

			attackTimer -= Time.deltaTime;

			if (attackTimer <= 0) {

				attackzone.enabled = false;
				attackTimer = 2.0f;
				isAttacking = false;
				moving (true);
			} 
		} else if (!isAttacking) {

			moving (false);

		}


	
	}

	//This is just to enable the attack zone, and the attack zone is the spherecollider

	void Attack(){
		/*trigger attack anim 
				.....
		*/

		attackzone.enabled = true;
		isAttacking = true;


	}


	//when something enter its attack zone while it is attacking, "player" will die.
	void OnTriggerEnter (Collider col){


			col.SendMessage ("die", null, SendMessageOptions.DontRequireReceiver);

	}

	void moving(bool attacking){

		if (!attacking) {
			movingSpeed = 0.5f;
			transform.Translate (Vector3.forward * movingSpeed * Time.deltaTime);
		}else if(attacking){

			movingSpeed = 0f;

		}
	
	
	}

}
