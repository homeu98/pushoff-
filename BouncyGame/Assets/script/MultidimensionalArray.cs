using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MultidimensionalArray : MonoBehaviour {
	public int NumberOfEnemy1 = 5;
	public List<GameObject > Group1 = new List<GameObject>();
	public List<Transform> Group1SpawnPoint = new List<Transform>();

	public int NumberOfEnemy2 = 5;
	public List<GameObject > Group2 = new List<GameObject>();
	public List<Transform> Group2SpawnPoint = new List<Transform>();
	// Use this for initialization
	void Start () {
		for (int i = 0 ; i < NumberOfEnemy1 ; i++){
			int SortOfEnemyID = Random.Range (0, Group1.Count);
			int SpawnPosID = Random.Range (0, Group1SpawnPoint.Count);
			Instantiate (Group1[SortOfEnemyID],  Group1SpawnPoint[SpawnPosID].position, Group1[SortOfEnemyID].transform.rotation);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
