using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{

	public float speed = 0;
	public float jumpPower = 5;
	public bool isPlaying;
	public Text countText;
	public Text RedMiniCountText;
	public Text YellowMiniCountText;
	public AudioClip jumpSound;
	public AudioClip pointSound;
	public GameObject jumpEffect;
	public GameObject pausedPanel;
	public GameObject greenLamp;
	public GameObject redLamp;
	public GameObject muteEffect;
	public Sprite[] playerSprite;
	bool isPause;
	bool isMute;

    public int count;
	int redMiniCount;
	int yellowMiniCount;
	int bonusRedCount;
	int bonusGreenCount;
	float timer;
	public bool isGreenButton;
	public bool isRedButton;
	GameObject CourseSpawner;
	CourseSpawnerScript courseSpawnerScript;




	AudioSource audioSource;
	SpriteRenderer playerRenderer;

	// Use this for initialization
	void Start ()
	{
//		PlayerPrefs.DeleteAll();
		pausedPanel.SetActive(false);

		isPlaying = true;
		playerRenderer = this.gameObject.GetComponent<SpriteRenderer> ();
		audioSource = this.gameObject.GetComponent<AudioSource> ();
		if (SceneManager.GetActiveScene ().name == "Main") {
			isGreenButton = true;
			isRedButton = true;
		}
		CourseSpawner = GameObject.Find ("CourseSpawner");
		courseSpawnerScript = CourseSpawner.GetComponent<CourseSpawnerScript> ();

	}
	
	// Update is called once per frame
	void Update ()
	{
//		timer += Time.deltaTime;
//		count = Mathf.FloorToInt (timer);
//		countText.text = count.ToString();
//
//		if (Input.GetKeyDown ("m") == true) {
//			this.gameObject.GetComponent<Rigidbody > ().velocity = new Vector3 (0, jumpPower, 0);
//			playerRenderer.sprite = playerSprite [1];
//			audioSource.clip = jumpSound;
//			audioSource.Play ();
//		}
//		if (Input.GetKeyDown ("n") == true) {
//			this.gameObject.GetComponent<Rigidbody > ().velocity = new Vector3 (0, jumpPower, 0);
//			playerRenderer.sprite = playerSprite [0];
//			audioSource.clip = jumpSound;
//			audioSource.Play ();
//		}
//		if (Input.GetKeyDown ("m") == true || Input.GetKeyDown ("n") == true || isMousePositionRightDown () == true) {
//			
//			GameObject jumpping = Instantiate (jumpEffect, this.transform.position + new Vector3 (1.74f, 5.21f, 0), this.transform.rotation) as GameObject;
//			Destroy (jumpping, 0.2f);
//
//		}


		//////////////////////////////////////////





		if (Input.GetKeyDown ("space") == true || isTouchPositionRightDown () == true) {
			this.gameObject.GetComponent<Rigidbody > ().velocity = new Vector3 (0, jumpPower, 0);
			audioSource.clip = jumpSound;
			audioSource.Play ();
			GameObject jumpping = Instantiate (jumpEffect, this.transform.position + new Vector3 (1.74f, 5.21f, 0), this.transform.rotation) as GameObject;
			Destroy (jumpping, 0.2f);
		}
		if (Input.GetKeyDown ("z") == true ||  isTouchPositionLeftDown () == true) {
			if (playerRenderer.sprite == playerSprite [0]) {
				playerRenderer.sprite = playerSprite [1];
			} else {
				playerRenderer.sprite = playerSprite [0];
			}
		}
			

//		if (Input.GetKeyDown ("space") == true) {
//
//			GameObject jumpping = Instantiate (jumpEffect, this.transform.position + new Vector3 (1.74f, 5.21f, 0), this.transform.rotation) as GameObject;
//			Destroy (jumpping, 0.2f);
//
//		}

		///////////////////////////////////////////////////

		if (bonusGreenCount == 4) {
			greenLamp.SetActive(true);
		} else {
			greenLamp.SetActive(false);
		}

		if (bonusRedCount == 4) {
			redLamp.SetActive(true);
		} else {
			redLamp.SetActive(false);
		}




		if (bonusGreenCount == 5) {
			
			courseSpawnerScript.feverGreen ();
			count += courseSpawnerScript.greenBonus;
			countText.text = count.ToString ();
			bonusGreenCount = 0;
			YellowMiniCountText.text = bonusGreenCount.ToString ();
		}
		if (bonusRedCount == 5) {
			
			courseSpawnerScript.feverRed ();
			count += courseSpawnerScript.redBonus;
			countText.text = count.ToString ();
			bonusRedCount = 0;
			RedMiniCountText.text = bonusRedCount.ToString ();
		}
	}


	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Enemy") {
			Debug.Log ("GAME OVER");
			speed = 0;
			jumpPower = 0;
			isPlaying = false;
		}
		if (playerRenderer.sprite == playerSprite [1]) {
			if (col.gameObject.tag == "EnemyRed") {

//				audioSource.clip = pointSound;
//				audioSource.Play ();
				Destroy (col.gameObject);
				count++;
				countText.text = count.ToString ();
				Debug.Log (count);
//				Instantiate (redEffect, col.gameObject.transform.position, this.transform.rotation);

			} else if (col.gameObject.tag == "EnemyRedmini") {

//				audioSource.clip = pointSound;
//				audioSource.Play ();
				Destroy (col.gameObject);
				redMiniCount++;
				bonusRedCount++;
				RedMiniCountText.text = bonusRedCount.ToString ();

			} else {
				Debug.Log ("GAME OVER");
				speed = 0;
				jumpPower = 0;
				isPlaying = false;
			}
		} 
		if (playerRenderer.sprite == playerSprite [0]) {
			if (col.gameObject.tag == "EnemyYellow") {

//				audioSource.clip = pointSound;
//				audioSource.Play ();
				Destroy (col.gameObject);
				count++;
				countText.text = count.ToString ();
				Debug.Log (count);
//				Instantiate (yellowEffect, col.gameObject.transform.position, this.transform.rotation);
			} else if (col.gameObject.tag == "EnemyYellowmini") {
//
//				audioSource.clip = pointSound;
//				audioSource.Play ();
				Destroy (col.gameObject);
				bonusGreenCount++;
				yellowMiniCount++;
				YellowMiniCountText.text = bonusGreenCount.ToString ();
			} else {
				Debug.Log ("GAME OVER");
				speed = 0;
				jumpPower = 0;
				isPlaying = false;
			}
		}

		if (isPlaying == false) {
			PlayerPrefs.SetInt ("score0", count);
			PlayerPrefs.SetInt ("score1", redMiniCount);
			PlayerPrefs.SetInt ("score2", yellowMiniCount);
			SceneManager.LoadScene ("End");
		}
	}

//	bool isMousePositionLeftDown ()
//	{
//		
//		if (Input.GetMouseButtonDown (0)) {
//			if (Input.mousePosition.x < Screen.width / 2 &&Input.mousePosition.y < Screen.height*13/14 && isGreenButton == true) {
//				return true;
//			} 
//		}
//		return false;
//	}
//
//	bool isMousePositionRightDown ()
//	{
//		
//		if (Input.GetMouseButtonDown (0)) {
//			if (Input.mousePosition.x > Screen.width / 2 &&Input.mousePosition.y < Screen.height*13/14 && isRedButton == true) {
//				return true;
//			} 
//		}
//		return false;
//	}

	// // // // // // // // // // // //
	bool isTouchPositionLeftDown ()
	{
		if (Input.touchCount > 0) {
			for (var i = 0; i < Input.touchCount; ++i) {
				Touch touch = Input.GetTouch (i);
				if (touch.phase == TouchPhase.Began) {
					if (touch.position.x < (Screen.width / 2) && touch.position.y < Screen.height * 13 / 14 && isGreenButton == true) {
						return true;
					}
				}
			}
		}
			return false;
	}
	

	bool isTouchPositionRightDown ()
	{
		if (Input.touchCount > 0) {
			for (var i = 0; i < Input.touchCount; ++i) {
				Touch touch = Input.GetTouch (i);
				if (touch.phase == TouchPhase.Began) {
					if (touch.position.x > (Screen.width / 2) && touch.position.y < Screen.height * 13 / 14 && isRedButton == true) {
						return true;
					}
				}
			}
		}
		return false;
	}

	// // // // // 

	public void PauseButton ()
	{
		if (isPause) {
			isPause = false;
			Time.timeScale = 2;
			pausedPanel.SetActive (false);
			isGreenButton = true;
			isRedButton = true;
		} else {
			Time.timeScale = 0;
			pausedPanel.SetActive (true);
			isPause = true;
			isGreenButton = false;
			isRedButton = false;
		}
	}
	public void MuteButton ()
	{
		if (isMute) {
			isMute = false;
			AudioListener.volume = 1;
			muteEffect.SetActive(true);
		} else {
			isMute = true;
			muteEffect.SetActive(false);
			AudioListener.volume = 0;
		}
	}

	public void ResumeButton ()
	{
			isPause = false;
			Time.timeScale = 2;
			pausedPanel.SetActive (false);
			isGreenButton = true;
			isRedButton = true;
	
		
	}
}







