using UnityEngine;
using System.Collections;

public class destructBoomer : MonoBehaviour {
	public float Timer = 3f;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, Timer);
	}
	

}
