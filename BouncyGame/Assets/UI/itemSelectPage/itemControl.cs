using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class itemControl : MonoBehaviour {

	public GameObject[] itemList;
	//	GridLayoutGroup grid;
	//	RectTransform rect;
	float eachCharacterPosition;
	public GameObject centerPoint;
	private float[] distance;

	private int bttLenght;
	bool dragging;
	private int minDistance;
	public int minButtonNum;
	private int bttnDistance;
	public RectTransform panel;
	private string nameOfItem;
	public Text nameOfItemText;
	public GameObject watchVidButton;
	public GameObject payButton;

	// Use this for initialization
	void Start () {

		bttLenght = itemList.Length;
		distance = new float[bttLenght];
		bttnDistance = (int)Mathf.Abs (itemList [1].GetComponent<RectTransform> ().anchoredPosition.x - itemList [0].GetComponent<RectTransform> ().anchoredPosition.x);
		for (int i = 0; i < itemList.Length; i++) {

			distance [i] = (int)Mathf.Abs (itemList [i].GetComponent<RectTransform> ().anchoredPosition.x);
			itemList [i].BroadcastMessage ("itemNumber", i, SendMessageOptions.DontRequireReceiver);
		}


	}

	// Update is called once per frame
	void Update () {

		distanceBetweenCenter ();

		nameOfItem = itemList [minButtonNum].gameObject.name;

		nameOfItemText.gameObject.GetComponent<Text> ().text = nameOfItem;

	}


	void createCharacter(){

		for (int i = 0; i < itemList.Length; i++) {
			print ("make");

			Vector3 location = new Vector3 (transform.position.x, transform.position.y, 0f);
			GameObject playerCharacter = Instantiate (itemList [i], location, itemList[i].transform.rotation) as GameObject;
			playerCharacter.transform.SetParent (this.gameObject.transform);
			playerCharacter.gameObject.transform.localScale = new Vector3 (1f, 1f, 1f);
			playerCharacter.GetComponent<RectTransform> ().localPosition= new Vector3 (transform.position.x, transform.position.y, 0f);
			//float currentWidthSize = rect.sizeDelta.x;
			//float widthSize = 150f + currentWidthSize;
			//rect.sizeDelta = new Vector3(widthSize, 200);

		}

	}
	void lerpToButton(int position){

		float newX = Mathf.Lerp (panel.anchoredPosition.x, position, Time.deltaTime * 10f);
		Vector2 newPosition = new Vector2 (newX, panel.anchoredPosition.y);

		panel.anchoredPosition = newPosition;

	}


	void distanceBetweenCenter(){


		for (int i = 0; i < itemList.Length; i++) {

			distance [i] = (int)Mathf.Abs (centerPoint.transform.position.x - itemList [i].transform.position.x);

		}

		int minDistance = (int) Mathf.Min (distance);

		for (int a = 0; a < itemList.Length; a++) {


			if (minDistance == distance [a]) {

				minButtonNum = a;
			}

		}


		if (!dragging) {

			lerpToButton (minButtonNum * -bttnDistance);

		}


	}



	public void drag(bool active){

		dragging = active;

		if (!active) {
			for (int i = 0; i < itemList.Length; i++) {

				itemList [minButtonNum].SendMessage ("choosenOne", true, SendMessageOptions.DontRequireReceiver);

				if (minButtonNum != i) {

					itemList [i].SendMessage ("choosenOne", false, SendMessageOptions.DontRequireReceiver);

				}

			}

		}
	}

	public void goBackButton(){

		SceneManager.LoadScene ("standalone 1");

	}


}


