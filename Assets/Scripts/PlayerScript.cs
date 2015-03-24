using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float playerVelocity;
	private Vector3 playerPosition;
	public float boundarySides;
	public float boundaryUp;
	public float boundaryDown;
	private static int lives;
	private static int score;
	public GUIStyle myGUIStyle;
	public AudioClip oneLessLife;
	public AudioClip realFanfare;
	public TextMesh buttonText;
	private bool win;
	public GUIStyle winGUIStyle;
	private bool die;
	public float speedUpTheGame;
	public int pointsToIncreaseSpeed;
	private GameObject vidas;


	// Use this for initialization
	void Start () {
		//Initialize the positionof the  player.
		playerPosition = gameObject.transform.position;
		if (Application.loadedLevelName == "Level1") {
			//The amount of lives that the player will have at the  beginning
			lives = 3;
			//The score of the user at the beginning
			score = 0;
		} else {
//			vidas = (GameObject)lives;
//			DontDestroyOnLoad(vidas);
//			DontDestroyOnLoad(score);
			Debug.Log("Fase 2");
		}

		win = false;
		die = false;
		Time.timeScale = 1;
	
	}
	
	// Update is called once per frame
	void Update () {
		//Horizontal
		playerPosition.x += Input.GetAxis ("Horizontal") * playerVelocity;

		//Vertical
		playerPosition.y += Input.GetAxis ("Vertical") * playerVelocity;

		// boundaries for the player
		if (playerPosition.x < -boundarySides) {
			//I set the  position of the player on the boundary like this because if I use transform.position I notice lag
			//or something strange. The same with the right boundary.
			playerPosition.x = -boundarySides;
		} 
		if (playerPosition.x > boundarySides) {
			playerPosition.x = boundarySides;
		}

		if (playerPosition.y < -boundaryDown) {
			//I set the  position of the player on the boundary like this because if I use transform.position I notice lag
			//or something strange. The same with the right boundary.
			playerPosition.y = -boundaryDown;
		} 
		if (playerPosition.y > -boundaryUp) {
			playerPosition.y = -boundaryUp;
		}
		transform.position = playerPosition;
		//if the user wants to quit the game, press Escape.
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Application.Quit();
		}
		//State of the game
		StateOfTheGame ();

	}

	void updateScore(int points){
		score += points;
		//After 6500 points, the game speed up
		if (score > pointsToIncreaseSpeed)
			Time.timeScale = speedUpTheGame;
	}

	void OnGUI(){
		//The GUI from the top
		GUI.Label (new Rect(50.0f,3.0f,200.0f,200.0f),"S c o r e: " + score, myGUIStyle);
		GUI.Label (new Rect(550.0f,3.0f,200.0f,200.0f),"L i f e s: " + lives, myGUIStyle);
		//If the user wins
		if(win){
			GUI.Label (new Rect(250.0f,150.0f,200.0f,200.0f),"YOU WON \n Press return to continue", winGUIStyle);
		}
		//If the user loses
		if (die)
			GUI.Label (new Rect(250.0f,150.0f,200.0f,200.0f),"YOU LOST ALL THE LIFES \n Press return to start", winGUIStyle);
	}

	void StateOfTheGame(){
		//restart thegame
		if (lives <= 0) {
			die = true;
			OnGUI();
			audio.PlayOneShot (oneLessLife);
			//Stop the game
			Time.timeScale=0;
			if (Input.GetKeyDown(KeyCode.Return)){
				Application.LoadLevel ("Level1");
			}
		}

		//User wins
		if (((GameObject.FindGameObjectsWithTag ("Fruits")).Length == 0)) {
			win=true;
			OnGUI();
			audio.PlayOneShot (realFanfare);
			//Stop the game
			Time.timeScale = 0;
			if (Input.GetKeyDown(KeyCode.Return)){
				if (Application.loadedLevelName == "Level1") {
					Application.LoadLevel ("Level2");
				} else {
					//audio.PlayOneShot (realFanfare);
					Application.LoadLevel ("congrats");
				}
			}
		}
	}

	void DiePlayerDie(){
		lives -= 1;
		audio.PlayOneShot (oneLessLife);
//		Place the player in the center
		playerPosition.x = 0f;
		playerPosition.y = -4.7f;
		transform.position = playerPosition;
	}	
	

}

