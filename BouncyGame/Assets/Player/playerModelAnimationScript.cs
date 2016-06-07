using UnityEngine;
using System.Collections;

public class playerModelAnimationScript : MonoBehaviour {

	Animator anim;
	GameObject player;
	//Mesh mesh;
	//Material rend;
	int characterSkinNumber = 1;
	public Mesh[] characterSkin;
	public Material[] characterSkinTexture;


	// Use this for initialization
	void Start () {

		//mesh = GetComponent<MeshFilter> ().mesh;
		//rend = GetComponent<Renderer> ().material;
		anim = GetComponent<Animator> ();
		player = GameObject.FindWithTag ("Player");

		characterSKinSelected ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void moved(){

		anim.SetTrigger ("Jump");
	}

	void characterSKinSelected(){

		//Here we get the skin number and retrieve it
		characterSkinNumber = PlayerPrefs.GetInt("skinNumber");

		switch (characterSkinNumber) {

		case 1:

			print ("selected");

			//chicken
			gameObject.GetComponent<Renderer> ().material = characterSkinTexture [characterSkinNumber];
			gameObject.GetComponent<MeshFilter> ().mesh = characterSkin [characterSkinNumber];

			break;

		case 2:

			//cat
			gameObject.GetComponent<Renderer> ().material = characterSkinTexture [characterSkinNumber];
			gameObject.GetComponent<MeshFilter> ().mesh = characterSkin [characterSkinNumber];

			break;

		case 3:

			//dog
			gameObject.GetComponent<Renderer> ().material = characterSkinTexture [characterSkinNumber];
			gameObject.GetComponent<MeshFilter> ().mesh = characterSkin [characterSkinNumber];

			break;


		case 4:

			//elephant
			gameObject.GetComponent<Renderer> ().material = characterSkinTexture [characterSkinNumber];
			gameObject.GetComponent<MeshFilter> ().mesh = characterSkin [characterSkinNumber];
			break;


		case 5:

			//frog
			gameObject.GetComponent<Renderer> ().material = characterSkinTexture [characterSkinNumber];
			gameObject.GetComponent<MeshFilter> ().mesh = characterSkin [characterSkinNumber];

			break;


		case 6:

			//kangaroo
			gameObject.GetComponent<Renderer> ().material = characterSkinTexture [characterSkinNumber];
			gameObject.GetComponent<MeshFilter> ().mesh = characterSkin [characterSkinNumber];
			break;


		case 7:

			//knight
			gameObject.GetComponent<Renderer> ().material = characterSkinTexture [characterSkinNumber];
			gameObject.GetComponent<MeshFilter> ().mesh = characterSkin [characterSkinNumber];

			break;


		default:
			 
			gameObject.GetComponent<Renderer> ().material = characterSkinTexture [0];
			gameObject.GetComponent<MeshFilter> ().mesh = characterSkin [0];

			break;

		
		}





	}


}
