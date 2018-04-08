using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorController : MonoBehaviour {

	public AudioClip jumpSound;


	AudioSource audioSource;
//	Renderer playerRenderer;
	GameObject player;
	public float jumpPower = 10;
	public Sprite[] playerSprite;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player");
//		 playerRenderer= player.GetComponent<Renderer> ();
//		playerRenderer.material.color = Color.red;
//		playerRenderer = player.GetComponent<SpriteRenderer> ();
		 player.GetComponent<Rigidbody> ();
		audioSource = player.GetComponent<AudioSource> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ChangeColorToYellow(){
//		playerRenderer.material.color = Color.yellow;
		player.GetComponent<Rigidbody> ().velocity = new Vector3 (0, jumpPower, 0);
		player.GetComponent<SpriteRenderer> ().sprite = playerSprite[0];
		audioSource.clip = jumpSound;
		audioSource.Play ();
	}

	public void ChangeColorToRed(){
//		playerRenderer.material.color = Color.red;
		player.GetComponent<SpriteRenderer> ().sprite = playerSprite[1];
		player.GetComponent<Rigidbody> ().velocity = new Vector3 (0, jumpPower, 0);
		audioSource.clip = jumpSound;
		audioSource.Play ();
	}
		
}
