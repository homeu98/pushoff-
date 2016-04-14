using UnityEngine;
using System.Collections;

public class BigFoot : MonoBehaviour {
	public float period = 3f;
	public LayerMask playerMask;
	float nextAttackTime;
	float attackRadius=1f;
	// Use this for initialization
	void Start () {
		nextAttackTime = Time.time + period;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextAttackTime) {
			Attack ();
		}
	}

	void Attack(){
		/*trigger attack anim 
				.....
			
		*/

		if(Physics2D.OverlapCircle (new Vector2(transform.position.x, transform.position.z), attackRadius, playerMask)){
			StandalonePlayer.IsKilled = true;
		}
	}
}
