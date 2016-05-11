using UnityEngine;
using System.Collections;

public class CamReference : MonoBehaviour 
{
	public GameObject player;
	public float camX;
	public float camZ;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.gameObject.transform.position = new Vector3 (player.transform.position.x + camX, 1, player.transform.position.z - camZ);	
	}
}
