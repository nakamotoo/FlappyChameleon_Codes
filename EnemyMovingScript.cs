using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovingScript : MonoBehaviour {

	public float speed = 5;
	GameObject player;
	bool playing;
	PlayerController playerController;


	// Use this for initialization
	void Start () {

		player = GameObject.Find ("Player");
		playerController = player.GetComponent<PlayerController> ();
		Destroy (this.gameObject, 10.0f);
	}
	
//	 Update is called once per frames
	void Update () {
		
//		if (this.transform.position.y >= 26) {
//			this.transform.position += new Vector3 (-speed * Time.deltaTime, -speed * Time.deltaTime, 0);
//		} else if (this.transform.position.y <= -8) {
//			this.transform.position += new Vector3 (-speed * Time.deltaTime, speed * Time.deltaTime, 0);
//		} else {
//			this.transform.position += new Vector3 (-speed * Time.deltaTime, speed * Time.deltaTime, 0);
//		}


		if (playerController.isPlaying == false) {
			speed = 0;
		} 



	}
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "EnemyRed" || col.gameObject.tag == "EnemyYellow") {
			Destroy (this.gameObject);
		}
	}
}
