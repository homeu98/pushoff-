using UnityEngine;
using System.Collections;

public class blackHoleScript : MonoBehaviour {

	SphereCollider blackHoleRadius;
	BoxCollider box;
	public float speed;

	// Use this for initialization
	void Start () {

		StartCoroutine ("deadStar");
	
	}
	
	// Update is called once per frame
	void Update () {


	
	}

	void OnTriggerStay(Collider other){

		print ("enter");
		if (other.tag == "enemy") {

			float step = speed * Time.deltaTime;

			other.transform.position = Vector3.MoveTowards (other.transform.position, this.transform.position, step);

			if (Vector3.Distance (other.transform.position, blackHoleRadius.center) <= 0.2f) {

				other.SendMessage ("dead", null, SendMessageOptions.DontRequireReceiver);
			}

		}
			

	}



	IEnumerator deadStar(){

		yield return new WaitForSeconds (6);

		Destroy (this.gameObject);
	}




}
