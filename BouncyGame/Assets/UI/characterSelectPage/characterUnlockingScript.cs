using UnityEngine;
using System.Collections;

public class characterUnlockingScript : MonoBehaviour {


	public bool checkIfSkinUnlocked(string name){
		
		bool whichSkin = PlayerPrefsX.GetBool (name);

		if (whichSkin) {

			return true;


		} else {


			return false;

		}
			

	}



}
