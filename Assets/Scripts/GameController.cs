using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	
	public GameObject hazard;
	public float timeForNextOrange;
	private float nextOrange;
	public float leftRange;
	public float rightRange;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void FixedUpdate () {
		if (Time.time > nextOrange){
//			Calculate the time for the next orange
			nextOrange = Time.time + timeForNextOrange;
//			Calculate the position where the orange will fall
			Vector3 position = new Vector3 (Random.Range (leftRange, rightRange), 4, 2);
			Quaternion rotation = Quaternion.identity;
//			Instantiate the orange
			GameObject clone = (GameObject) Instantiate (hazard, position, rotation);
//			Destroy the orange after 60 seconds
			Destroy (clone, 60f);

		}	
	}
	
	void OnCollisionEnter2D (Collision2D collision){
		if (collision.gameObject.tag == "Player") {
			GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
			player.SendMessage("DiePlayerDie");
		}
	}
}