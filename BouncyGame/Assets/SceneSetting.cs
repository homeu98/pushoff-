using UnityEngine;
using System.Collections;

public class SceneSetting : MonoBehaviour {
	AudioSource audio;
	// Use this for initialization


	void Start () {
		audio = GetComponent<AudioSource> ();	
		audio.enabled = PlayerPrefsX.GetBool("IsVolume");
	}
	
	// Update is called once per frame
	void Update () {
		//audio.enabled = PlayerPrefsX.GetBool("IsVolume");

	}
}
