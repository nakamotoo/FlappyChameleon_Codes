using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using System;

public class UnityAds : MonoBehaviour
{

	public static UnityAds instance;

	private Action intersticialAdCallback;
	private Action rewardedAdFinishedCallback;
	private Action rewardedAdSkippedCallback;
	private Action rewardedAdFailedCallback;


	void Awake ()
	{
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad (this.gameObject);
		} else {
			Destroy (this.gameObject);
		}
	}


	//全画面広告
	public void ShowAd (Action onComplete = null)
	{
		Debug.Log ("show ad called");
		// 広告再生の準備ができているか確認。
		Debug.Log (Advertisement.IsReady ());
		if (Advertisement.IsReady ()) { 
			// 準備ができていたら、広告再生。
			intersticialAdCallback = onComplete;
			ShowOptions options = new ShowOptions ();
			options.resultCallback = HandleShowResult;
			Advertisement.Show (options);
		}
	}

	//全画面広告のコールバック
	void HandleShowResult (ShowResult result)
	{
		if (intersticialAdCallback != null) {
			intersticialAdCallback ();
		}
	}

	//
	public void ShowRewardedVideo (Action onFinished = null, Action onSkipped = null, Action onFailed = null)
	{
		rewardedAdFinishedCallback = onFinished;
		rewardedAdSkippedCallback = onSkipped;
		rewardedAdFailedCallback = onFailed;

		ShowOptions options = new ShowOptions ();
		options.resultCallback = HandleRewardedVideoResult;

		Advertisement.Show ("rewardedVideo", options);
	}

	//リワード広告のコールバック
	void HandleRewardedVideoResult (ShowResult result)
	{
		if (result == ShowResult.Finished) {
			Debug.Log ("Video completed - Offer a reward to the player");
			// 再開させる
			if (rewardedAdFinishedCallback != null) {
				rewardedAdFinishedCallback ();
			}
		} else if (result == ShowResult.Skipped) {
			Debug.LogWarning ("Video was skipped - Do NOT reward the player");
			//再開させずにゲームオーバー
			if (rewardedAdSkippedCallback != null) {
				rewardedAdSkippedCallback ();
			}
		} else if (result == ShowResult.Failed) {
			Debug.LogError ("Video failed to show");
			if (rewardedAdFailedCallback != null) {
				rewardedAdFailedCallback ();
			}
		}
	}
}
