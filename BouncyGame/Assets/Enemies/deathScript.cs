using UnityEngine;
using System.Collections;

public  class deathScript : MonoBehaviour {

	Animator anim;
	GameObject Anim;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void tookDamage(){


   	//After they took damage, they should die, in here it include animation and destorying its gameobject

		Destroy (this.gameObject);
		print ("dead");


	}


}
