using UnityEngine;
using System.Collections;

public class TestManager : MonoBehaviour {
	public GameObject shitBoomer;
	public PoolManager instance;
	public float period = 3f;
	public int MaxNumberOf = 1;
	float NextAttackTime;

	// Use this for initialization
	void Start () {
		NextAttackTime = Time.time + period;

		instance.CreatePool (shitBoomer, MaxNumberOf);

	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > NextAttackTime){
			instance.ReuseObject (shitBoomer, transform.position , Quaternion.identity);
			NextAttackTime += period;
		}
	}
}
