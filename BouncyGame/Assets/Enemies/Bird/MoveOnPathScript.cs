using UnityEngine;
using System.Collections;

public class MoveOnPathScript : MonoBehaviour {

	 EditorPathSCript PathToFollow;

	public int CurrentWayPointID = 0;
	public float speed=2f;
	public float rotationSpeed = 5f;
	public string pathName;

	float reachDistance = 1f;
	//Vector3 last_pos;
	Vector3 current_pos;
	// Use this for initialization


	void Start () {
		PathToFollow = GameObject.Find (pathName).GetComponent<EditorPathSCript> ();

		//last_pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance (PathToFollow.path_objs [CurrentWayPointID].position, transform.position);
		transform.position = Vector3.MoveTowards (transform.position, PathToFollow.path_objs [CurrentWayPointID].position, Time.deltaTime * speed);

		Quaternion rotation = Quaternion.LookRotation (PathToFollow.path_objs [CurrentWayPointID].position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * rotationSpeed);

		if(distance <= reachDistance){
			CurrentWayPointID++;
		}
		if(CurrentWayPointID >= PathToFollow.path_objs.Count){
			CurrentWayPointID= PathToFollow.path_objs.Count-1;
		}
	}


}
