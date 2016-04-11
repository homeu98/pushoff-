using UnityEngine;
using System.Collections;

public class EmeryManager : MonoBehaviour {
	public Transform emery1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		emery1.position += emery1.transform.forward * Time.deltaTime * 2f;
	}
}
