using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyFallScript : MonoBehaviour {

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
	
	// Update is called once per frame
	void Update () {

		this.transform.position -= new Vector3 (speed * Time.deltaTime, 0, 0);
		if(playerController.isPlaying == false) {

			speed = 0;
		}
	}
}
