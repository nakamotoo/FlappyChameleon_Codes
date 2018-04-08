using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class EndSceneManager : MonoBehaviour {

	public Text lastScore0Text;
	public Text lastScore1Text;
	public Text lastScore2Text;
	public Text highScoreText;
	public Text newHighScoreText;
	int lastScore0;
	int lastScore1;
	int lastScore2;
	int highScore;
	int playedCount;
	UnityAds unityAds;

	// Use this for initialization
	void Start () {
		lastScore0 = PlayerPrefs.GetInt ("score0");
		lastScore0Text.text = lastScore0.ToString();
		lastScore1 = PlayerPrefs.GetInt ("score1");
		lastScore1Text.text = lastScore1.ToString();
		lastScore2 = PlayerPrefs.GetInt ("score2");
		lastScore2Text.text = lastScore2.ToString();



		if (PlayerPrefs.HasKey ("highScore") == true) {
			highScore = PlayerPrefs.GetInt ("highScore");
			if (highScore < lastScore0) {
				highScore = lastScore0;
				Debug.Log ("New High Score!");
				newHighScoreText.text = "New High Score!";
				PlayerPrefs.SetInt ("highScore", highScore);
			}
		} else {
			highScore = lastScore0;
			PlayerPrefs.SetInt ("highScore", highScore);
		}
		highScoreText.text = highScore.ToString ();

		if (PlayerPrefs.HasKey ("playCount") == true) {
			playedCount = PlayerPrefs.GetInt ("playCount")+1 ;
			PlayerPrefs.SetInt ("playCount", playedCount);
			Debug.Log ("hogehoge"+playedCount);
		} else {
			PlayerPrefs.SetInt ("playCount", 1);
			Debug.Log ("hoge"+playedCount);
		}

	}


	
	// Update is called once per frame
	void Update () {

	}

	public void RetryButton(){
		int RandomInt=Random.Range(0,3);

		if (playedCount > 7&&Advertisement.IsReady ()==true) {
			if (RandomInt == 0) {
				GameObject.Find ("UnityAds").GetComponent<UnityAds> ().ShowAd (ChangeScene);
			} else {
				SceneManager.LoadScene ("Main");
			}
		} else {
					SceneManager.LoadScene ("Main");
		}
	}
	void ChangeScene(){
		SceneManager.LoadScene ("Main");
	}
	public void TopButton(){
		SceneManager.LoadScene ("Start");
	}
}
