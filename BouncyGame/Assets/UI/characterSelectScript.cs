using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class characterSelectScript : MonoBehaviour {

	public GameObject[] characterList;
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
	private string nameOfCharacter;
	public Text nameOfCharacterObject;

	// Use this for initialization
	void Start () {

		bttLenght = characterList.Length;
		distance = new float[bttLenght];
		bttnDistance = (int)Mathf.Abs (characterList [1].GetComponent<RectTransform> ().anchoredPosition.x - characterList [0].GetComponent<RectTransform> ().anchoredPosition.x);
		for (int i = 0; i < characterList.Length; i++) {
			
			distance [i] = (int)Mathf.Abs (characterList [i].GetComponent<RectTransform> ().anchoredPosition.x);
			characterList [i].BroadcastMessage ("characterNumber", i, SendMessageOptions.DontRequireReceiver);
		}


	}
	
	// Update is called once per frame
	void Update () {
		
		distanceBetweenCenter ();

		nameOfCharacter = characterList [minButtonNum].gameObject.name;

		nameOfCharacterObject.gameObject.GetComponent<Text> ().text = nameOfCharacter;

	}
		

	void createCharacter(){

		for (int i = 0; i < characterList.Length; i++) {
			print ("make");

			Vector3 location = new Vector3 (transform.position.x, transform.position.y, 0f);
			GameObject playerCharacter = Instantiate (characterList [i], location, characterList[i].transform.rotation) as GameObject;
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


		for (int i = 0; i < characterList.Length; i++) {

			distance [i] = (int)Mathf.Abs (centerPoint.transform.position.x - characterList [i].transform.position.x);
		
		}

		int minDistance = (int) Mathf.Min (distance);

		for (int a = 0; a < characterList.Length; a++) {
			

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
			for (int i = 0; i < characterList.Length; i++) {

				characterList [minButtonNum].SendMessage ("choosenOne", true, SendMessageOptions.DontRequireReceiver);

				if (minButtonNum != i) {

					characterList [i].SendMessage ("choosenOne", false, SendMessageOptions.DontRequireReceiver);
				
				}

			}

		}
	}

}
