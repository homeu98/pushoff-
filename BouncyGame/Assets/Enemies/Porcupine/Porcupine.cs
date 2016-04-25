using UnityEngine;
using System.Collections;

public class Porcupine : MonoBehaviour {
	
	Vector2 escapeDirection;
	public float runAwaySpeed=2f;
	// Use this for initialization
	void Start () {
		escapeDirection = Random.insideUnitCircle * 2f - (Vector2)transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (BulletSystem.instance.AttackTimes <= 0) {
			transform.Translate (new Vector3 (escapeDirection.x,0f,escapeDirection.y) * Time.deltaTime * runAwaySpeed);
		} else {
			Vector2 Extent = Random.insideUnitCircle * 2f;
			transform.Translate (new Vector3 (Extent.x, 0f, Extent.y) * Time.deltaTime);
		}
	}


}
