using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial1Script : MonoBehaviour {

	public Text TutorialIndication;
	public GameObject panel;
	public GameObject[] enemies;
	string[] serifu={
		" ",
		"Tap the left half to change color !",
		"Good ! Then tap the right half to jump !",
		"Great job !!!     " +"Try it yourself !!",
		"Try it yourself !!"
	};

	GameObject player;
	GameObject panelLeft;
	GameObject panelLast;
	PlayerController playerController;
	float timer;
	bool isTimer;
	public bool isTutorial=true;
	bool isFirst;


	// Use this for initialization
	void Start () {
		
		Time.timeScale = 0;
		isTimer = false;
		player = GameObject.Find ("Player");
		panelLeft = GameObject.Find ("panelLeft");
		panelLast = GameObject.Find ("LastPanel");
		playerController = player.GetComponent<PlayerController> ();
		panelLeft.SetActive(true);
		panelLast.SetActive(false);
		playerController.isRedButton = false;
		playerController.isGreenButton = false;
		isFirst = true;
	}

	// Update is called once per frame
	void Update () {
		if (playerController.count == 5) {
			Time.timeScale = 0;
			playerController.isRedButton = false;
			playerController.isGreenButton = false;
			panelLast.SetActive(true);

		}
		if (playerController.isPlaying == false) {
			
			Restart ();
		}
	}


	bool isMousePositionLeftDown(){
		if (Input.GetMouseButtonDown (0)) {
			if (Input.mousePosition.x < Screen.width / 2) {
				return true;
			} 
		}

		return false;
	}

	bool isMousePositionRightDown(){
		if (Input.GetMouseButtonDown (0)) {
			if (Input.mousePosition.x > Screen.width / 2) {
				return true;
			} 
		}
		return false;
	}



	public void Restart(){
		SceneManager.LoadScene ("Tutorial 1");
	}
	public void Top(){
		SceneManager.LoadScene ("Start");
	}

	public void StartButton(){
		SceneManager.LoadScene ("Main");
	}
	public void Try(){
				panelLeft.SetActive(false);
				Time.timeScale=2;
		playerController.isRedButton = true;
		playerController.isGreenButton = true;
			}
}
