using UnityEngine;
using System.Collections;

public class graveYardScript : MonoBehaviour {

	int numberOfJump = 0;
	public GameObject skeleton;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		print (numberOfJump);

	
	}


	public void addUp(){

		numberOfJump += 1;

		if (numberOfJump >= 5) {

			Instantiate (skeleton, transform.position, transform.rotation);
			Destroy (this.gameObject);


		}

	}

}
