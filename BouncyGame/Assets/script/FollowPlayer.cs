using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	public GameObject playerRef;
	Vector3 shouldPos;

	void Start () 
	{

	}


	void Update () 
	{
		shouldPos = Vector3.Lerp (gameObject.transform.position, playerRef.transform.position, Time.deltaTime);
		gameObject.transform.position = new Vector3 (shouldPos.x , 8, shouldPos.z); 
	}
}
