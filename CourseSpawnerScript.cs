using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CourseSpawnerScript : MonoBehaviour
{


	float timer;
	float smallTimer1;
	float smallTimer2;
	float smallTimer3;
	GameObject player;
	bool playing;
	PlayerController playerController;
	EnemyScript enemyScript;
	EnemyRedScript enemyRedScript;
	EnemyYellowScript enemyYellowScript;
	GameObject enemy;
	GameObject[] enemyRed;
	GameObject[] enemyGreen;
	public GameObject bonusEffect;
	public GameObject[] enemies;
	public int redBonus;
	public int greenBonus;


	float distance1=21.55f;
	float distance2=21.55f;
	float angle;
	int RandomValue;
	int RandomValue2;
//	bool isPause;

	int[,] enemyIndex = new int[,]{{3,3,4,4,5,5},{3,4,4,4,4,5},{4,4,4,4,4,4},{4,4,4,4,4,4},{5,4,4,4,4,3},{5,5,4,4,3,3}};
	int preRamdomValue;
	// Use this for initialization
	void Start ()
	{  
		player = GameObject.Find ("Player");
		playerController = player.GetComponent<PlayerController> ();
		for (int i = 0; i < 10; i++) {
			Instantiate (enemies [0], this.transform.position + new Vector3 (-4.0f*i, distance1, 0), this.transform.rotation);
			Instantiate (enemies [0], this.transform.position - new Vector3 (4.0f*i, distance2, 0), this.transform.rotation);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (playerController.isPlaying == true) {
			timer += Time.deltaTime;
			smallTimer1 += Time.deltaTime;
			smallTimer2 += Time.deltaTime;
			if (smallTimer1 > 0.6f) {
				//土台コース
				for (int i = 0; i < 7; i++) {
					Instantiate (enemies [0], this.transform.position + new Vector3 (0, 4.0f * i + distance1, 0), this.transform.rotation);
					Instantiate (enemies [0], this.transform.position - new Vector3 (0, 4.0f * i + distance2, 0), this.transform.rotation);
				}
				smallTimer1 = 0;

				//余分ブロック生成確率
				if (timer < 20) {
					RandomValue = Random.Range (1, 11);
				} else {
					RandomValue = Random.Range (0, 9);
				}


				//余分ブロック生成
				if (preRamdomValue == 9 || preRamdomValue == 10) {
					RandomValue = Random.Range (0, 3);
				} else if (preRamdomValue == 3 || preRamdomValue == 4) {
					RandomValue = Random.Range (0, 9);
				} else {
					RandomValue = Random.Range (1, 11);
				}
					if (RandomValue == 1) {

						Instantiate (enemies [0], this.transform.position - new Vector3 (0, -4.0f + distance2, 0), this.transform.rotation);
						Instantiate (enemies [0], this.transform.position + new Vector3 (0, -4.0f + distance1, 0), this.transform.rotation);
					} else if (RandomValue == 2) {
					
						Instantiate (enemies [0], this.transform.position - new Vector3 (0, -4.0f + distance2, 0), this.transform.rotation);

					} else if (RandomValue == 3) {
					
						for (int i = -1; i < 0; i++) {
							Instantiate (enemies [Random.Range (0, 3)], this.transform.position + new Vector3 (0, 4.0f * i + distance1, 0), this.transform.rotation);
						}
						for (int j = -3; j < 0; j++) {
							Instantiate (enemies [Random.Range (0, 3)], this.transform.position - new Vector3 (0, 4.0f * j + distance2, 0), this.transform.rotation);
					
						}
					} else if (RandomValue == 4) {

						for (int i = -3; i < 0; i++) {
							Instantiate (enemies [Random.Range (0, 3)], this.transform.position + new Vector3 (0, 4.0f * i + distance1, 0), this.transform.rotation);
						}
						for (int j = -1; j < 0; j++) {
							Instantiate (enemies [Random.Range (0, 3)], this.transform.position - new Vector3 (0, 4.0f * j + distance2, 0), this.transform.rotation);
						}
					} else if (RandomValue == 5) {
						for (int i = -2; i < 0; i++) {
							Instantiate (enemies [Random.Range (0, 3)], this.transform.position + new Vector3 (0, 4.0f * i + distance1, 0), this.transform.rotation);
						}
						for (int j = -2; j < 0; j++) {
							Instantiate (enemies [Random.Range (0, 3)], this.transform.position - new Vector3 (0, 4.0f * j + distance2, 0), this.transform.rotation);
						}
					} else if (RandomValue == 9) {
						for (int i = -4; i < 0; i++) {
							Instantiate (enemies [Random.Range (0, 3)], this.transform.position + new Vector3 (0, 4.0f * i + distance1, 0), this.transform.rotation);
						}

					} else if (RandomValue == 10) {
						for (int i = -4; i < 0; i++) {
							Instantiate (enemies [Random.Range (0, 3)], this.transform.position - new Vector3 (0, 4.0f * i + distance1, 0), this.transform.rotation);
						}

					}

//					
				preRamdomValue = RandomValue;
			}

//			mini生成

			RandomValue2 = Random.Range (0, 3);

				if (smallTimer2 > 5) {
				if (RandomValue2 == 0) {
						Instantiate (enemies [Random.Range (4, 6)], this.transform.position, this.transform.rotation);
						smallTimer2 = 0;
					}
				if (RandomValue2 == 1) {
					Instantiate (enemies [Random.Range (4, 6)], this.transform.position + new Vector3 (0, Random.Range(-5.0f,5.0f), 0), this.transform.rotation);
						smallTimer2 = 0;
					}

				}
	

				//狭まる
				if (20 < timer && timer < 35) {
//			this.transform.position += new Vector3 (0, speed * Time.deltaTime, 0);
					if (distance1 >= 16.0f) {
						distance1 -= 0.02f;
						distance2 -= 0.02f;
					}
				}
				
				//上がる
				if (timer > 40 && timer < 45) {
					angle += 15 * Time.deltaTime;
					this.transform.position += new Vector3 (0, Mathf.Sin (angle * (Mathf.PI / 180)) * 0.09f, 0);
				}

				//狭まる
				if (50 < timer && timer < 55) {
					//			this.transform.position += new Vector3 (0, speed * Time.deltaTime, 0);
					if (distance1 >= 16.0f) {
						distance1 -= 0.08f;
						distance2 -= 0.08f;
					}
				}

				//下がる
				if (timer > 65 && timer < 72) {
					angle -= 5 * Time.deltaTime;
//				if (this.transform.position.y > 5.55f) {
					this.transform.position -= new Vector3 (0, Mathf.Sin (angle * (Mathf.PI / 180)) * 0.08f, 0);
//				}
				}

				//戻る
				if (timer > 80 && timer < 90) {
					angle += 15 * Time.deltaTime;
					if (this.transform.position.y < 3.35f) {
						this.transform.position += new Vector3 (0, Mathf.Sin (angle * (Mathf.PI / 180)) * 0.1f, 0);
					}
				}






				//広がる
			if (timer > 100&&timer<120) {
					if (distance1 <= 21.55f) {
						distance1 += 0.05f;
						distance2 += 0.05f;
					}
				}
			if (timer > 120) {
				timer = 20;
				timer+= Time.deltaTime;
			}
				

//				if (timer > 120) {
//				
//					smallTimer3 += Time.deltaTime;
//					if (smallTimer3 > 7) {
//						squareEnemy552 ();
//						smallTimer3 = 0;
//					}
//				}
//			if (timer > 30 && timer <33) {
//				distance2 += 0.3f;
//			}
//			if (timer > 35 && timer < 38) {
//				distance1 -= 0.3f;
//			}
//			if (timer > 38) {
//				distance1 += Random.Range (-0.3f, 0.3f);
//			}
			}
			
		}
	


	void squareEnemy552(){
		int j = 0; float RandomValue1 = Random.Range(-10.0f,10.0f);
		while( j < 6 ){
			for(int i=0;i<6;i++){
				Instantiate (enemies [enemyIndex[j,i]], new Vector3 (35+3*j, RandomValue1+3 * i, 0), this.transform.rotation);
			}
			j++;
		}
	} 
	void circleEnemymini(){
		float i = 0; 
		while(i < 13){
			float angle = 30*i;
			Instantiate(enemies[Random.Range(3,6)],new Vector3 (35+8*Mathf.Sin(angle * (Mathf.PI / 180)),8*Mathf.Cos(angle * (Mathf.PI / 180)), 0),this.transform.rotation);
			i++;
		}
	}
	void circleEnemy(){
		float i = 0; 
		while(i < 13){
			float angle = 30*i;
			Instantiate(enemies[Random.Range(0,3)],new Vector3 (35+11*Mathf.Sin(angle * (Mathf.PI / 180)),11*Mathf.Cos(angle * (Mathf.PI / 180)), 0),this.transform.rotation);
			i++;
		}
	}

	public void feverGreen(){

		enemyRed = GameObject.FindGameObjectsWithTag ("EnemyRed");
		greenBonus = enemyRed.Length;
		for (int i = 0; i < greenBonus; i++)
		{
			GameObject effect = Instantiate (bonusEffect, enemyRed [i].transform.position, this.transform.rotation)as GameObject;
			Destroy(enemyRed[i]);
			Destroy (effect,0.3f);
		}
//		Destroy (enemyRed[]);


	}
	public void feverRed(){

		enemyGreen = GameObject.FindGameObjectsWithTag ("EnemyYellow");
		redBonus = enemyGreen.Length;
//		Destroy (enemyGreen);
		for (int i = 0; i < redBonus; i++)
		{   
			GameObject effect = Instantiate (bonusEffect, enemyGreen [i].transform.position, this.transform.rotation) as GameObject;
			Destroy(enemyGreen[i]);
			Destroy (effect,0.1f);
		}


	}

//	public void PauseButton(){
//		Debug.Log ("aaa");
//		if (isPause) {
//			isPause = false;
//			Time.timeScale = 2;
//		} else {
//			Time.timeScale = 0;
//			isPause = true;
//		}
//	}
}





	
	

	

