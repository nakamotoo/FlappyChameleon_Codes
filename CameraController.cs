using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public float speed = 0;
	public GameObject player;
	bool playing;
	PlayerController playerController;

	void Start () {
		Time.timeScale = 2;
		playerController = player.GetComponent<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
   		if(playerController.isPlaying == false) {
			speed = 0;
		}
	}
}

