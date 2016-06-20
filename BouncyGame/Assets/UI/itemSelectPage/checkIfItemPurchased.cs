using UnityEngine;
using System.Collections;

public class checkIfItemPurchased : MonoBehaviour  {


	public bool checkIfItemPured(string name){

		bool whichItem  = PlayerPrefsX.GetBool (name);

		if (whichItem) {

			return true;


		} else {


			return false;

		}


	}


}
