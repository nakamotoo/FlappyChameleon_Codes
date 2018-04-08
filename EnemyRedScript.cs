using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRedScript : MonoBehaviour {

	public float speed = 5;
	GameObject player;
	GameObject enemySpawner;
	bool playing;
	PlayerController playerController;
	float timer;
	EnemySpawnerScript enemyController;


	// Use this for initialization
	void Start () {

		player = GameObject.Find ("Player");
		enemySpawner = GameObject.Find ("EnemySpawner");
		playerController = player.GetComponent<PlayerController> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		
		this.transform.position -= new Vector3 (speed * Time.deltaTime, 0, 0);
		if(playerController.isPlaying == false) {

			speed = 0;
		}

//		if(playerController.isPlaying == true && timer>10) {
//			Destroy (this.gameObject);
//			timer = 0;
//		}

	}
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "EnemyYellowmini") {
			Destroy (this.gameObject);
		}
		if (col.gameObject.tag == "EnemyRedmini") {
			Destroy (this.gameObject);
		}
		if (col.gameObject.tag == "Wall") {
			Destroy(this.gameObject);
		}
	}
}
