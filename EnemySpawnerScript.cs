using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{


	public GameObject[] enemy;
	float timer;
	float smallTimer1;
	float smallTimer2;
	float smallTimer3;
	float timerYellow;
	bool isGenerate;
	public int level=1;
//	bool isEnemyInstansiate = false;
//	bool isEnemyFallInstantiate = false;
//	bool isEnemyRedInstansiate = false;
//	bool isEnemyYellowInstantiate = false;

	GameObject player;
	bool playing;
	PlayerController playerController;
	EnemyScript enemyScript;
	EnemyRedScript enemyRedScript;
	EnemyYellowScript enemyYellowScript;


	int[,] enemyIndex = new int[,]{{4,4,5,5,6,6},{4,5,5,5,5,6},{5,5,5,5,5,5},{5,5,5,5,5,5},{6,5,5,5,5,4},{6,6,5,5,4,4}};


	// Use this for initialization
	void Start ()
	{
		player = GameObject.Find ("Player");
		playerController = player.GetComponent<PlayerController> ();
		isGenerate = true;
//		Invoke ("StartEnemy", 5);
//	    Invoke ("StartEnemyFall", 20);
//		Invoke ("StartEnemyRed", 10);
//		Invoke ("StartEnemyYellow", 13);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (playerController.isPlaying == true) {
			timer += Time.deltaTime;
			level = 1;
			if (timer <= 25) {
				smallTimer1 += Time.deltaTime;
				smallTimer2 += Time.deltaTime;
				if (smallTimer1 > 1.5){
					Instantiate (enemy [Random.Range (0, 4)], new Vector3 (30, Random.Range (-15.0f, 26.0f), 0), this.transform.rotation);
					smallTimer1 = 0;
				}
				if (smallTimer2 > 2) {
					Instantiate (enemy [Random.Range (4, 7)], new Vector3 (30, Random.Range (-15.0f, 26.0f), 0), this.transform.rotation);
					smallTimer2 = 0;
				}
			}
			if (timer > 25 && timer <= 60) {
				smallTimer1 += Time.deltaTime;
				smallTimer2 += Time.deltaTime;
				smallTimer3 += Time.deltaTime;
				float randomFloat1 = Random.Range (-15.0f, 26.0f);
//				float randomFloat2 = Random.Range (-15.0f, 26.0f);
				float randomFloat3 = Random.Range (-15.0f, 26.0f);
				float randomFloat4 = Random.Range (-15.0f, 26.0f);
				float difCapacity = 7.0f;

				//絶対値
//				if (Mathf.Abs (randomFloat2 - randomFloat1) < 7) {
//					if (randomFloat2 > randomFloat1) {
//						randomFloat2 += difCapacity;
//					} else {
//						randomFloat2 -= difCapacity;
//					}
//				}
				if (Mathf.Abs (randomFloat4 - randomFloat3) < 7) {
					if (randomFloat4 > randomFloat3) {
						randomFloat4 += difCapacity;
					} else {
						randomFloat4 -= difCapacity;
					}
				}

				if (smallTimer1 > 2) {
					Instantiate (enemy [Random.Range (1, 4)], new Vector3 (30, randomFloat1, 0), this.transform.rotation);

					smallTimer1 = 0;
				}
//				if (smallTimer2 > 3) {
//					Instantiate (enemy [Random.Range (2, 4)], this.transform.position + new Vector3 (0, randomFloat2, 0), this.transform.rotation);
//					smallTimer2 = 0;
//				}
				if(smallTimer3 >5){
				
					for (int i = 0; i < 5; i++) {
						Instantiate (enemy [Random.Range (4, 7)],  new Vector3 (4 * i+30, randomFloat3, 0), this.transform.rotation);

						Instantiate (enemy [Random.Range (4, 7)], new Vector3 (4 * i+30, randomFloat4, 0), this.transform.rotation);
				}
					if (randomFloat4 > randomFloat3) {
						Instantiate (enemy [Random.Range (2, 4)], new Vector3 (30+Random.Range(0.0f,16.0f), Random.Range (randomFloat3, randomFloat4), 0), this.transform.rotation);
					} else {
						Instantiate (enemy [Random.Range (2, 4)], new Vector3 (30+Random.Range(0.0f,16.0f), Random.Range (randomFloat4, randomFloat3), 0), this.transform.rotation);
					}
					smallTimer3 = 0;
			}
		}
			if (timer > 60 && timer <= 63) {
				smallTimer1 += Time.deltaTime;
				if (smallTimer1 > 2.5) {
					for (int i=-2; i < 4; i++) {
						Instantiate (enemy [1], new Vector3 (30, 10 * i, 0), this.transform.rotation);
					}
					for (int i = -1; i < 2; i++) {
						Instantiate (enemy [3], new Vector3 (30, 20 * i +5, 0), this.transform.rotation);
					}

					for (int i = 0; i < 2; i++) {
						Instantiate(enemy [2], new Vector3 (30, 20 * i-5, 0), this.transform.rotation);
					}

					smallTimer1 = 0;
				}
			}
			if (timer > 64 && timer <= 78) {
				smallTimer1 +=Time.deltaTime;
				smallTimer2 += Time.deltaTime;
				if (smallTimer1 > 1.5) {
					Instantiate (enemy [Random.Range (0, 4)], new Vector3 (30, Random.Range (-15.0f, 26.0f), 0), this.transform.rotation);
					smallTimer1 = 0;
				}
				if (smallTimer2 > 2) {
					Instantiate (enemy [Random.Range (4, 7)], new Vector3 (30, Random.Range (-15.0f, 26.0f), 0), this.transform.rotation);
					smallTimer2 = 0;
				}
			}
			if (timer > 78 && timer <= 110) {
				smallTimer3 += Time.deltaTime;
				if (isGenerate == true) {
					smallTimer1 += Time.deltaTime;
				} else {
					smallTimer2 += Time.deltaTime;
				}
				if (smallTimer1 > 5) {
//					squareEnemy55 (Random.Range (4, 7));
					squareEnemy552();
					smallTimer1 = 0;
					isGenerate = false;
				}
				if (smallTimer2 > 6) {
					circleEnemy();
					Instantiate (enemy [Random.Range (4, 7)], new Vector3 (35 ,0, 0), this.transform.rotation);
					smallTimer2 = 0;
					isGenerate = true;
				}

				if (smallTimer3 > 2) {
					Instantiate (enemy [Random.Range (1, 4)], new Vector3 (30, Random.Range (-15.0f, 26.0f), 0), this.transform.rotation);
					smallTimer3 = 0;
				}
			}
			if (timer > 110 && timer <= 145) {

			}

			//level調整
			if (timer > 70) {
				levelUp ();
			}
	}
  }



	void levelUp(){
		level++;
		Debug.Log ("Level up!");
	}

	void squareEnemy55(int a){
		int j = 0; float RandomFloat1 = Random.Range(-15.0f,15.0f);
		while( j < 5 ){
			for(int i=0;i<5;i++){
				Instantiate (enemy [a], new Vector3 (30+3*j, RandomFloat1+3 * i, 0), this.transform.rotation);
			}
		  j++;
		}
	} 

	void squareEnemy552(){
		int j = 0; float RandomFloat1 = Random.Range(-15.0f,15.0f);
		while( j < 6 ){
			for(int i=0;i<6;i++){
				Instantiate (enemy [enemyIndex[j,i]], new Vector3 (35+3*j, RandomFloat1+3 * i, 0), this.transform.rotation);
			}
			j++;
		}
	} 

	void circleEnemy(){
		float i = 0; 
		while(i < 13){
			float angle = 30*i;
			Instantiate(enemy[Random.Range(4,7)],new Vector3 (35+10*Mathf.Sin(angle * (Mathf.PI / 180)),10*Mathf.Cos(angle * (Mathf.PI / 180)), 0),this.transform.rotation);
			i++;
		}
	}



}