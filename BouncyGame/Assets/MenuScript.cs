using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void StartGame(){
		GameObject.Find ("Canvas(Menu)").SetActive(false);
	}
	public void viewStandalone(){
		SceneManager.LoadScene ("standalone 1");
	}
	public void viewCharacter(){
		SceneManager.LoadScene ("characterSelectScene");
	}
	public void viewAchievement(){
		SceneManager.LoadScene ("achievementSelectScene");
	}
	public void viewItems(){
		SceneManager.LoadScene ("itemsSelectScene");
	}
	public void viewSetting(){
		SceneManager.LoadScene ("settingSelectScene");
	}
}
