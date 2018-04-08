using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class memo : MonoBehaviour {
//
//	// Use this for initialization
//	void Start () {
//		
//	}
//	
//	// Update is called once per frame
//
//	void Update ()
//	{
//
//
//		if (playerController.isPlaying == true) {
//
//			timer += Time.deltaTime;
//		
//			smallTimer += Time.deltaTime;
//
//			if (smallTimer > 3) {
//				float randomFloat1 = Random.Range (-15.0f, 26.0f);
//				Instantiate (enemy[0], this.transform.position + new Vector3 (0, randomFloat1, 0), this.transform.rotation);
//				if (isEnemyInstansiate == true) {
//						
//
//					float randomFloat2 = Random.Range (-15.0f, 26.0f);
//					float difCapacity = 7.0f;
//
//					//絶対値
//					if (Mathf.Abs (randomFloat2 - randomFloat1) < 7) {
//						if (randomFloat2 > randomFloat1) {
//							randomFloat2 += difCapacity;
//						} else {
//							randomFloat2 -= difCapacity;
//						}
//					}
//					Instantiate (enemy[1], this.transform.position + new Vector3 (0, randomFloat2, 0), this.transform.rotation);
//				}
//			
//				timer = 0;
//			
//			}
//
//			if (isEnemyFallInstantiate == true) {
//				timerFall += Time.deltaTime;
//				if (timerFall > 9) {
//					Instantiate (enemy[4], this.transform.position + new Vector3 (-20, 20, 0), this.transform.rotation);
//					timerFall = 0;
//				}
//			}
//			if (isEnemyRedInstansiate == true) {
//				timerRed += Time.deltaTime;
//				if (timerRed > 4) {
//					Instantiate (enemy[2], this.transform.position + new Vector3 (0, Random.Range (-20.0f, 30.0f), 0), this.transform.rotation);
//					timerRed = 0;
//				}
//			}
//			if (isEnemyYellowInstantiate == true) {
//				timerYellow += Time.deltaTime;
//				if (timerYellow > 4) {
//					Instantiate (enemy[3], this.transform.position + new Vector3 (0, Random.Range (-20.0f, 30.0f), 0), this.transform.rotation);
//					timerYellow = 0;
//				}
//			}
//		}
//
//			
//	}
//
//	void StartEnemy ()
//	{
//		isEnemyInstansiate = true;
//	}
//	void StartEnemyFall ()
//	{
//		isEnemyFallInstantiate = true;
//	}
//	void StartEnemyRed()
//	{
//		isEnemyRedInstansiate = true;
//	}
//	void StartEnemyYellow()
//	{
//		isEnemyYellowInstantiate = true;}
//}