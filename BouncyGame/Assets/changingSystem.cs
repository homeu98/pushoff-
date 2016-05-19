using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class changingSystem : MonoBehaviour {
	public GameObject[] NumberOfTree;
	public List<Mesh> TypeOfTree = new List<Mesh>();

	List<int> NoOfAlreadyChange = new List<int>();

	int NumberOfChange;
	int NoOfChange;
	int NoOfType;

	void Awake(){
		NumberOfChange = Random.Range (5, NumberOfTree.Length);
	}

	void Start(){
		NoOfAlreadyChange.Clear ();

		for (int i = 0; i < NumberOfChange; i++) {

			NoOfChange = Random.Range (0, NumberOfTree.Length);
			if (!NoOfAlreadyChange.Contains (NoOfChange)) {
				NoOfAlreadyChange.Add (NoOfChange);
			} else {
				while(NoOfAlreadyChange.Contains(NoOfChange)){
					NoOfChange = Random.Range (0, NumberOfTree.Length);
				}
				NoOfAlreadyChange.Add (NumberOfChange);
			}

			NoOfType = Random.Range (0, TypeOfTree.Count);

			NumberOfTree [NoOfChange].GetComponentInChildren<MeshFilter> ().mesh = TypeOfTree [NoOfType];
		}
	}

	void ChangeTree(){
		 NumberOfChange = Random.Range (5, NumberOfTree.Length);
		NoOfAlreadyChange.Clear ();

		for (int i = 0 ; i < NumberOfChange ; i++){
			
			 NoOfChange = Random.Range (0, NumberOfTree.Length);
			if (!NoOfAlreadyChange.Contains (NoOfChange)) {
				NoOfAlreadyChange.Add (NoOfChange);
			} else {
				while(NoOfAlreadyChange.Contains(NoOfChange)){
					NoOfChange = Random.Range (0, NumberOfTree.Length);
				}
				NoOfAlreadyChange.Add (NumberOfChange);
			}

			 NoOfType = Random.Range (0, TypeOfTree.Count);

			NumberOfTree [NoOfChange].GetComponentInChildren<MeshFilter> ().mesh = TypeOfTree [NoOfType];

		}
	}
}
