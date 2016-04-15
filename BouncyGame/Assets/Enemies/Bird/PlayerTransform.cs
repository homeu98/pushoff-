using UnityEngine;
using System.Collections;

public class PlayerTransform : MonoBehaviour {
	public Transform player;
	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
		if(player != null)
			
			transform.position = player.position;
		
	}
}
