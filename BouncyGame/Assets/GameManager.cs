using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public void Restart(){
		Application.LoadLevel (Application.loadedLevel);
	}
}
