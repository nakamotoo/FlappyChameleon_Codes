using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {


	public float speed = 5;
	public float startPosition;
	public float endPosition;
	// Use this for initialization


	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		//毎フレームxポジションを少しづつ移動
		transform.Translate(-1*speed*Time.deltaTime, 0, 0 );

		//スクロールが目標ポイントまで到達したかチェック
		if (transform.position.x <= endPosition)ScrollEnd();

	}

	void ScrollEnd()
	{
		//スクロールする分を戻す
		transform.Translate(-1*(endPosition-startPosition),0,0);
	}
}
