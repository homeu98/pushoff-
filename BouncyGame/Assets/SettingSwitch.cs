using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingSwitch : MonoBehaviour {

	public  Image SoundButton;
	public  Image VibrationButton;
	public	  Image DeveloperButton;



	// Use this for initialization
	void Start () {
		SoundButton.color=PlayerPrefsX.GetColor ("SoundColor");
		VibrationButton.color=PlayerPrefsX.GetColor ("VibrationColor");
		DeveloperButton.color=PlayerPrefsX.GetColor ("DeveloperColor");
	}
	
	// Update is called once per frame
	void Update () {

	}
		


	public void BackToStartGame(){
		
		SceneManager.LoadScene ("Standalone 1");
	}
		

	public void TurnSound(){
		
		if (PlayerPrefsX.GetBool("IsVolume")) {
			print("turnToFalse");
			PlayerPrefsX.SetColor ("SoundColor", Color.red);
			SoundButton.color=PlayerPrefsX.GetColor ("SoundColor");
			PlayerPrefsX.SetBool("IsVolume", false);
			return;
		} 
		if(!PlayerPrefsX.GetBool("IsVolume")) {
			print ("turnToTrue");
			PlayerPrefsX.SetColor ("SoundColor", Color.green);
			SoundButton.color=PlayerPrefsX.GetColor ("SoundColor");
			PlayerPrefsX.SetBool("IsVolume", true);
			return;
		}

	}

	public void TurnVibration(){

		if (PlayerPrefsX.GetBool("IsVibration")) {
			print("turnToFalse");
			PlayerPrefsX.SetColor ("VibrationColor", Color.red);
			VibrationButton.color=PlayerPrefsX.GetColor ("VibrationColor");
			PlayerPrefsX.SetBool("IsVibration", false);
			return;
		} 
		if(!PlayerPrefsX.GetBool("IsVibration")) {
			print ("turnToTrue");
			PlayerPrefsX.SetColor ("VibrationColor", Color.green);
			VibrationButton.color=PlayerPrefsX.GetColor ("VibrationColor");
			PlayerPrefsX.SetBool("IsVibration", true);
			return;
		}

	}

	public void TurnDeveloper(){

		if (PlayerPrefsX.GetBool("IsDeveloper")) {
			print("turnToFalse");
			PlayerPrefsX.SetColor ("DeveloperColor", Color.red);
			DeveloperButton.color=PlayerPrefsX.GetColor ("DeveloperColor");
			PlayerPrefsX.SetBool("IsDeveloper", false);
			return;
		} 
		if(!PlayerPrefsX.GetBool("IsDeveloper")) {
			print ("turnToTrue");
			PlayerPrefsX.SetColor ("DeveloperColor", Color.green);
			DeveloperButton.color=PlayerPrefsX.GetColor ("DeveloperColor");
			PlayerPrefsX.SetBool("IsDeveloper", true);
			return;
		}

	}


}
