using UnityEngine;
using System.Collections;

public class deathScript : MonoBehaviour {

	/*Animator anim;
	GameObject Anim;*/

	public bool bear, bigfoot, bird, boar, bunny, cowboy, cazyChicken, fireFox, grassHopper, porcupine, skunk;
	GameManager gm;


	void Start(){

		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();


	}

	public void dead(){

		print ("killedThisMOtehrlawj;efkla");

		if (bear) {

			gm.SendMessage ("nBear", -1, SendMessageOptions.DontRequireReceiver);
			Destroy (this.gameObject);

		}

		if (bigfoot) {

			gm.SendMessage ("nBigFoot", -1, SendMessageOptions.DontRequireReceiver);
			Destroy (this.gameObject);

		}

		if (bird) {
			gm.SendMessage ("nBird", -1, SendMessageOptions.DontRequireReceiver);

			Destroy (this.gameObject);
		}

		if (boar) {
			gm.SendMessage ("nBoar", -1, SendMessageOptions.DontRequireReceiver);

			Destroy (this.gameObject);

		}

		if (bunny) {
			gm.SendMessage ("nBunny", -1, SendMessageOptions.DontRequireReceiver);

			Destroy (this.gameObject);
		}

		if (cowboy) {
			gm.SendMessage ("nCowBoy", -1, SendMessageOptions.DontRequireReceiver);

			Destroy (this.gameObject);
		}

		if (cazyChicken) {
			gm.SendMessage ("nCrazyChicken", -1, SendMessageOptions.DontRequireReceiver);

			Destroy (this.gameObject);
		}

		if (fireFox) {
			gm.SendMessage ("nFireFox", -1, SendMessageOptions.DontRequireReceiver);

			Destroy (this.gameObject);
		}

		if (grassHopper) {
			gm.SendMessage ("nGrassHopper", -1, SendMessageOptions.DontRequireReceiver);

			Destroy (this.gameObject);
		}

		if (porcupine) {
			gm.SendMessage ("nPorcupine", -1, SendMessageOptions.DontRequireReceiver);

			Destroy (this.gameObject);
		}

		if (skunk) {
			gm.SendMessage ("nSkunk", -1, SendMessageOptions.DontRequireReceiver);

			Destroy (this.gameObject);
		}

	}


	void OnCollisionEnter(Collider other){

		if (other.tag == "looper") {

			print ("hit");
			if (bear) {

				gm.SendMessage ("nBear", -1, SendMessageOptions.DontRequireReceiver);
				Destroy (this.gameObject);

			}

			if (bigfoot) {

				gm.SendMessage ("nBigFoot", -1, SendMessageOptions.DontRequireReceiver);
				Destroy (this.gameObject);

			}

			if (bird) {
				gm.SendMessage ("nBird", -1, SendMessageOptions.DontRequireReceiver);

				Destroy (this.gameObject);
			}

			if (boar) {
				gm.SendMessage ("nBoar", -1, SendMessageOptions.DontRequireReceiver);

				Destroy (this.gameObject);

			}

			if (bunny) {
				gm.SendMessage ("nBunny", -1, SendMessageOptions.DontRequireReceiver);

				Destroy (this.gameObject);
			}

			if (cowboy) {
				gm.SendMessage ("nCowBoy", -1, SendMessageOptions.DontRequireReceiver);

				Destroy (this.gameObject);
			}

			if (cazyChicken) {
				gm.SendMessage ("nCrazyChicken", -1, SendMessageOptions.DontRequireReceiver);

				Destroy (this.gameObject);
			}

			if (fireFox) {
				gm.SendMessage ("nFireFox", -1, SendMessageOptions.DontRequireReceiver);

				Destroy (this.gameObject);
			}

			if (grassHopper) {
				gm.SendMessage ("nGrassHopper", -1, SendMessageOptions.DontRequireReceiver);

				Destroy (this.gameObject);
			}

			if (porcupine) {
				gm.SendMessage ("nPorcupine", -1, SendMessageOptions.DontRequireReceiver);

				Destroy (this.gameObject);
			}

			if (skunk) {
				gm.SendMessage ("nSkunk", -1, SendMessageOptions.DontRequireReceiver);

				Destroy (this.gameObject);
			}

		}
	}

}
