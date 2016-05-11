using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour 
{
	public GameObject target;

	void OnTriggerEnter(Collider col)
	{
		col = target;
		Destroy (target);
	}
}
