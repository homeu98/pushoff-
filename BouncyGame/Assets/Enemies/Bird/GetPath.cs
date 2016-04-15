using UnityEngine;
using System.Collections;

public class GetPath : MonoBehaviour {

	public GameObject[] allPaths;
	// Use this for initialization
	void Awake () {
		int number = Random.Range (0, allPaths.Length);
		allPaths [number].SetActive (true);
		transform.position = allPaths [number].transform.position;
		MoveOnPathScript yourPath = GetComponent<MoveOnPathScript> ();
		yourPath.pathName = allPaths [number].name;
	}
	

}
