using UnityEngine;
using System.Collections;

public class chain : MonoBehaviour {

	BoxCollider col;
	public GameObject dog;
	GameObject player;

	// Use this for initialization
	void Start () {

		col = GetComponent<BoxCollider> ();
		player = GameObject.FindWithTag ("Player");

		col.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void canDie(bool dieBool){

		//print ("killME");
		if (dieBool) {
			col.enabled = true;
		} else {

			col.enabled = false;
		}

	}

	void tookDamage(){

		dog.SendMessage ("chainDie", null, SendMessageOptions.DontRequireReceiver);

		Vector3 dogPosition = new Vector3 (dog.transform.position.x, dog.transform.position.y , dog.transform.position.z - 4.0f);

		player.transform.position = dogPosition;
		Destroy (this.gameObject);

	}

}
