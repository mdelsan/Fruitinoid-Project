using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {
	
	private bool activeBall;
	private Vector3 ballPosition;
	private Vector2 ballForce;
	public AudioClip soundHit;
	public int speed;

	// Use this for initialization
	void Start () {
		// Create the movement
		ballForce = new Vector2 (100.0f,300.0f);
		// At the begining the ball must be quiet
		activeBall = false;
		// The positionof the ball
		ballPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (!activeBall){
				// the speed of the ball is the lowest
				rigidbody2D.isKinematic = false;
				// add speed to theball
				rigidbody2D.AddForce(ballForce);
				// Ball is activated
				activeBall = !activeBall;
			}
		}
		

		// Check if the user missed and didnt hit the ball
		if (transform.position.y < -5.8 && activeBall) {
			activeBall = !activeBall;
			ballPosition.x = 0f;
			ballPosition.y = -4f;
			transform.position = ballPosition;
			//transform it to kinematic when it is moving
			rigidbody2D.isKinematic = true;

			//If the user fail, a life must be take out
			GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
			player.SendMessage("DiePlayerDie");
		}
	}

	void OnCollisionEnter2D (Collision2D collision){
		if (activeBall) {
			rigidbody2D.AddForce(new Vector2(10.0f,20.0f));
			audio.PlayOneShot(soundHit);	
		}
	}
}


