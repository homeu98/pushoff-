using UnityEngine;
using System.Collections;


public class Grid : MonoBehaviour {
	public GameObject plane;
	public int width = 10;
	public int Height = 10;

	GameObject[,] grid;

	GameObject gridPlane;

	public static Grid instance;

	void Awake(){
		instance = this;
		grid = new GameObject[width, Height];
	}
	 
	// Use this for initialization
	void Start () {
		for (int x = 0; x < width; x++){
			for(int z = 0; z < Height ; z++){
				 gridPlane = (GameObject)Instantiate (plane);
				gridPlane.transform.position = new Vector3 (gridPlane.transform.position.x + x , gridPlane.transform.position.y, gridPlane.transform.position.z + z);
				grid [x, z] = gridPlane;
			}
		}
	}

	void Update(){
		for (int x = 0; x < width; x++) {
			for (int z = 0; z < Height; z++) {
				grid [x, z].transform.Translate (transform.forward * 2 * Time.deltaTime);
			}
		}
	}

}
