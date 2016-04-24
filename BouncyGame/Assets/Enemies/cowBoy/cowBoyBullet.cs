using UnityEngine;
using System.Collections;

public class cowBoyBullet : MonoBehaviour {

	public float bulletSpeed;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		this.transform.Translate (Vector3.forward * bulletSpeed * Time.deltaTime);
	
	}
}
