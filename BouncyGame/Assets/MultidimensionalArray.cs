using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MultidimensionalArray : MonoBehaviour {

	public List<GameObject > Group = new List<GameObject>();
	public List<Transform> EnemySpawnPoint = new List<Transform>();
	// Use this for initialization
	void Start () {
		for (int i = 0 ; i < Group.Count ; i++){
			int SortOfEnemyID = Random.Range (0, Group.Count);
			int SpawnPosID = Random.Range (0, EnemySpawnPoint.Count);
			Instantiate (Group[SortOfEnemyID],  EnemySpawnPoint[SpawnPosID].position, Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
