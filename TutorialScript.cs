using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialScript : MonoBehaviour {

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
	GameObject panelRight;
	GameObject panelLast;
	PlayerController playerController;
	float timer;
	bool isTimer;
	public bool isTutorial=true;
	bool isFirst;
	float distance1=21.55f;
	float distance2=21.55f;
	float smallTimer1;

	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("isTutorialDone", 1);
		Time.timeScale = 0;
		isTimer = false;
		player = GameObject.Find ("Player");
		panelLeft = GameObject.Find ("panelLeft");
		panelRight = GameObject.Find ("panelRight");
		panelLast = GameObject.Find ("LastPanel");
		playerController = player.GetComponent<PlayerController> ();
		panelRight.SetActive(false);
		panelLeft.SetActive(true);
		panelLast.SetActive(false);
		playerController.isRedButton = true;
		playerController.isGreenButton = false;
		isFirst = true;
		for (int i = 0; i < 10; i++) {
			Instantiate (enemies [0], this.transform.position + new Vector3 (-4.0f*i, distance1, 0), this.transform.rotation);
			Instantiate (enemies [0], this.transform.position - new Vector3 (4.0f*i, distance2, 0), this.transform.rotation);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		if (isTimer == true) {
			timer += Time.deltaTime;
			smallTimer1 += Time.deltaTime;
			if (smallTimer1 > 0.6f) {
				//土台コース
				for (int i = 0; i < 7; i++) {
					Instantiate (enemies [0], this.transform.position + new Vector3 (0, 4.0f * i + distance1, 0), this.transform.rotation);
					Instantiate (enemies [0], this.transform.position - new Vector3 (0, 4.0f * i + distance2, 0), this.transform.rotation);
				}
				smallTimer1 = 0;
			}
		}

		if ((Input.GetKeyDown ("space") == true || isMousePositionRightDown () == true)&& isFirst==true) {
			if (playerController.isRedButton == true) {
				isTimer = true;
				panelLeft.SetActive (false);
				if (timer > 3 && timer < 5.5f) {
					TutorialIndication.text = serifu [0];
				}
				if (timer > 5.5f) {
					Time.timeScale = 0.05f;
					TutorialIndication.text = serifu [1];
					panelRight.SetActive (true);
					playerController.isRedButton = false;
					playerController.isGreenButton = true;

				} else {
					Time.timeScale = 2;
				}
			}
		}

		if (Input.GetKeyDown ("z") == true || isMousePositionLeftDown () == true) {
			if (playerController.isGreenButton == true) {
//				Time.timeScale = 2;
				panelRight.SetActive (false);
				TutorialIndication.text = serifu [2];
				playerController.isRedButton = true;
				isFirst = false;


//				if (timer > 8) {
//					Time.timeScale = 2;
//					TutorialIndication.text = serifu [3];
//					Time.timeScale = 0.3f;
//					panelRight.SetActive (false);
//					panelLeft.SetActive (false);
//				} 
			}
		}

		if ((Input.GetKeyDown ("space") == true || isMousePositionRightDown () == true)&&isFirst==false) {
			if (playerController.isRedButton == true) {
				Time.timeScale = 2;
			}
		}

		if (timer > 11) {
			Time.timeScale = 0;
			TutorialIndication.text = serifu [0];
			panelLast.SetActive(true);

		}
//		if (timer > 12) {
//			TutorialIndication.text = serifu [0];
//
//		}
//		if (timer > 13) {
//			Time.timeScale = 2;
//			playerController.isRedButton = true;
//			playerController.isGreenButton = true;
//		}

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
		SceneManager.LoadScene ("Tutorial");
	}

	public void StartButton(){
		SceneManager.LoadScene ("Tutorial 1");
	}
}
