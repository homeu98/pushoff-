using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CrackRandomBox : MonoBehaviour {
	int touchTimes = 5;
	public int prizeForOneTime = 300;
	bool AlreadyPaid = false;
	public Text totalMoneyText;
	public Text PrizeText;

	public GameObject RandomBox;

	int InititalTotalMoney;


	public int TestingForTotalMoney = 1000;

	void Awake(){
		PlayerPrefs.SetInt ("totalMoney", TestingForTotalMoney);
	}
	// Use this for initialization
	void Start () {
		InititalTotalMoney = PlayerPrefs.GetInt ("totalMoney");
		totalMoneyText.text = "" + InititalTotalMoney;
		PrizeText.text = "" + prizeForOneTime;
	}

	void Update(){
		if (touchTimes <= 0) {
			//	Destroy (RandomBox,.5f);
			transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, Time.deltaTime * 10f);
		}


	}

	void OnMouseDown(){
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		Physics.Raycast (ray, out hit);
		if(hit.collider.gameObject == RandomBox){

			if ( !AlreadyPaid && InititalTotalMoney >= prizeForOneTime) {
				int AfterTotalMoney = InititalTotalMoney - prizeForOneTime;
				PlayerPrefs.SetInt ("totalMoney", AfterTotalMoney);
				print ("OK");
				StartCoroutine ("PaidForLottery");
				AlreadyPaid = true;
				touchTimes--;
			} 

			if(AlreadyPaid){
				touchTimes--;
			}else{
				print ("NotEnoughMoney");
			}

		/*	if (touchTimes <= 0) {
			//	Destroy (RandomBox,.5f);
				transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, Time.deltaTime * 10f);
			}*/

		}
	}

	IEnumerator PaidForLottery(){

		while (PlayerPrefs.GetInt("totalMoney") < InititalTotalMoney){
			yield return new WaitForSeconds (0.02f);
			InititalTotalMoney -= 10;
			totalMoneyText.text = "" + InititalTotalMoney;
		}
		yield return null;
	}

	public void BackToPlaying(){
		SceneManager.LoadScene ("standalone 1");
	}


}
