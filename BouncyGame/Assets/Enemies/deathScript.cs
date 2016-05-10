using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class deathScript : MonoBehaviour {

	/*Animator anim;
	GameObject Anim;*/

	public bool buffalo, bear, bigfoot, bird, boar, bunny, cowboy, cazyChicken, fireFox, grassHopper, porcupine, skunk;
	GameManager gm;
	public int progress;

	Slider progressBar;


	void Start(){

		gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
		progressBar = GameObject.FindWithTag ("progressBar").GetComponent<Slider> ();

	}

	public void tookDamage(){

		dead ();

	}

	public void dead(){
		
		if (buffalo) {

			gm.SendMessage ("nBuffalo", -1, SendMessageOptions.DontRequireReceiver);
			Destroy (this.gameObject);

		}
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


		progressBar.SendMessage ("add", 5, SendMessageOptions.DontRequireReceiver);


	}


	void OnTriggerEnter(Collider other){

		if (other.tag == "looper") {

			if (buffalo) {

				gm.SendMessage ("nBuffalo", -1, SendMessageOptions.DontRequireReceiver);
				Destroy (this.gameObject);

			}

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

			progressBar.SendMessage ("add", 1, SendMessageOptions.DontRequireReceiver);
	
		}


	
	}

}
