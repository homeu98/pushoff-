using UnityEngine;
using System.Collections;

public class PatformSpawer : MonoBehaviour 
{
	public GameObject platform;
	public Transform platformSpawnPos;

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player") 
		{
			Instantiate (platform,platformSpawnPos.position , Quaternion.identity);
			Destroy (this.gameObject);
		}
	}
}
