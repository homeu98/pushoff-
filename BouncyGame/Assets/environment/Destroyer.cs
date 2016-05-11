using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour 
{
	//public GameObject target;

	void OnTriggerEnter(Collider col)
	{

		print ("hitting");

		col.SendMessage ("create", null, SendMessageOptions.DontRequireReceiver);
	
		col.SendMessage ("tookDamage", null, SendMessageOptions.DontRequireReceiver);

		col.SendMessage ("die", null, SendMessageOptions.DontRequireReceiver);

	}
		

}
