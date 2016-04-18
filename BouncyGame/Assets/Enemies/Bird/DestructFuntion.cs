using UnityEngine;
using System.Collections;

public class DestructFuntion : MonoBehaviour {
	public GameObject birdParent;
	// Use this for initialization
	void Start () {
		
		Destroy (gameObject, 3f);
	}
	

}
