using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingSwitch : MonoBehaviour {

	public  Image SoundButton;
	public  Image VibrationButton;
	public	  Image DeveloperButton;


	public static bool IsVolume = true;
	public static bool IsVibration =true;

	int s = 1;
	int v = 1;
	int d = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void BackToStartGame(){
		
		SceneManager.LoadScene ("Standalone 1");
	}
		

	public void TurnSound(){
		
		if (s == 1 ) {
			print("OK");
			SoundButton.color = Color.red;
			IsVolume = false;
			s = -1;
			return;
		} 
		if(s==-1) {
			print ("NO");
			SoundButton.color = Color.green;
			s =  1;
			return;
		}

	}

	public void TurnVibration(){
		if (v== 1) {
			VibrationButton.color = Color.red;
			IsVibration = false;
			v = -1;
			return;
		} 
		if(v==-1) {
			VibrationButton.color = Color.green;
			IsVibration = true;
			v = 1;
			return;
		}

	}

	public void TurnDeveloper(){
		if (d== 1) {
			DeveloperButton.color = Color.red;
			IsVibration = false;
			d = -1;
			return;
		} 
		if(d==-1) {
			DeveloperButton.color = Color.green;
			IsVibration = true;
			d = 1;
			return;
		}

	}


}
