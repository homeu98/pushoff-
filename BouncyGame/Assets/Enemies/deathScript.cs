using UnityEngine;
using System.Collections;

public  static class deathScript {

	/*Animator anim;
	GameObject Anim;*/


	public static void tookDamage(Collider deadEnemy){


   	//After they took damage, they should die, in here it include animation and destorying its gameobject

		GameObject.Destroy(deadEnemy.gameObject);
		//print ("dead");


	}


}
