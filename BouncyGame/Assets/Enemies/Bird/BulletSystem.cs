using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletSystem : MonoBehaviour {
	public int x=3;
	public int y=3;
	public LayerMask AttackMask;
	public float speed=3f;
	public GameObject bullet;
	public float period=3f;

	float NextAttackTime; 
	GameObject temporaryBullet;
	GameObject[,] bulletArray;
	List<GameObject> bulletList;

	// Use this for initialization
	void Awake(){
		//bulletDirection = new GameObject[2*x, 2*y];
		bulletList = new List<GameObject>();
	}

	void Start () {
		NextAttackTime = Time.time + period;


		}
	
	// Update is called once per frame
	void Update () {
			
			if(Time.time > NextAttackTime){
			bulletList.Clear ();
				for(int i = -x; i < x; i++){
					for(int j = -y; j < y; j++){
						temporaryBullet=(GameObject)Instantiate(bullet);
						Quaternion rotation = Quaternion.LookRotation (new Vector3 (i,  0f, j) - temporaryBullet.transform.position);

						temporaryBullet.transform.rotation = Quaternion.Slerp (temporaryBullet.transform.rotation, rotation, 5f);
						temporaryBullet.transform.position = transform.position;
					temporaryBullet.transform.parent = transform.transform;
						//bulletDirection[i,j] = temporaryBullet;
						bulletList.Add(temporaryBullet);
					}
				}
				NextAttackTime += period;
			}

			foreach(GameObject n in bulletList){
			if(n != null)
				n.transform.Translate (Vector3.forward * Time.deltaTime * speed);
			
			}
				//temporaryBullet.transform.position = Vector3.MoveTowards (temporaryBullet.transform.position, new Vector3 (temporaryBullet.transform.position.x + i, temporaryBullet.transform.position.y, temporaryBullet.transform.position.z + j) * 50f, Time.deltaTime*5f);


	}




}
