using UnityEngine;
using System.Collections;

public class JumpEffect : MonoBehaviour {
	public GameObject JumpParticle;


	void JumpEvent(){
		Instantiate (JumpParticle, transform.position, Quaternion.identity);
	}
}
