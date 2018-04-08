using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
//		if (Input.GetKeyDown ("a")) {
//
//			GameObject.Find ("UnityAds").GetComponent<UnityAds> ().ShowAd ();
//		}
		
	}

	public void StartButton ()
	{
//		GameObject.Find ("UnityAds").GetComponent<UnityAds> ().ShowRewardedVideo (ChangeScene, skip, fail);
		ChangeScene ();
	}

	void ChangeScene ()
	{
		if (PlayerPrefs.HasKey ("isTutorialDone") == false) {
			SceneManager.LoadScene ("Tutorial");
		} else {
			SceneManager.LoadScene ("Main");
		}
	}

	void fail ()
	{
		Debug.Log ("fail");
	}

	void skip ()
	{
		Debug.Log ("skip");
	}

	public void Tutorial ()
	{
		SceneManager.LoadScene ("Tutorial");
	}
}
