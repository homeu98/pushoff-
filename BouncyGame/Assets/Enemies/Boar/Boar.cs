using UnityEngine;
using System.Collections;

public class Boar : MonoBehaviour {
	Rigidbody rb;
	public float MoveSpeed=3f;
	public float SinkSpeed=0.5f;
	bool IsDead=false;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();

	}

	void Update(){
		if(IsDead){
			transform.Translate (-Vector3.up * Time.deltaTime * SinkSpeed);
			if (transform.position.y <= -0.6f)
				destroySelf ();
			
		}else if(!IsDead && transform.position.z < -3f){
			destroySelf ();
		}

	}
	// Update is called once per frame
	void FixedUpdate () {
		if (!IsDead) {
			rb.MovePosition (rb.position - Vector3.forward * Time.deltaTime * MoveSpeed);
		}
	}

	void OnCollisionEnter(Collision other){
		
		if(other.collider.CompareTag("obstacle")){
			IsDead = true;
			rb.isKinematic = true;
		}
		if(other.collider.CompareTag("back")){
			print ("OK");
			other.collider.SendMessage ("die", null, SendMessageOptions.DontRequireReceiver);
		}
	}

	void destroySelf(){
		GameObject.Destroy(gameObject,0f);
	}
}
