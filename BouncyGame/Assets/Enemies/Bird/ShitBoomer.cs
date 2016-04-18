using UnityEngine;
using System.Collections;

public class ShitBoomer : MonoBehaviour {
	public float period = 3f;
	public GameObject shitBoomer;
	float NextAttackTime;
	// Use this for initialization
	void Start () {
		NextAttackTime = Time.time + period;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > NextAttackTime){
			GameObject temporaryShitBoomer = Instantiate (shitBoomer,transform.position, Quaternion.identity) as GameObject;
			NextAttackTime += period;

		}
	}
}
