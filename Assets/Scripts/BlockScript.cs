using UnityEngine;
using System.Collections;

public class BlockScript : MonoBehaviour {

	public int hitsToDeleteBlock;
	public int points;
	private int amountOfHits;

	// Use this for initialization
	void Start () {
		amountOfHits = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	//Detect the collisions between the balls and the blocks
	void OnCollisionEnter2D(Collision2D collision){
		
		if (collision.gameObject.tag == "Ball"){
			amountOfHits++;
			//Destroy the block if the user hit the block enough times and add the points
			if (amountOfHits == hitsToDeleteBlock){
				//get the reference of the player
				GameObject player = GameObject.FindGameObjectsWithTag("Player")[0];
				//send the amount of points to the player object
				player.SendMessage("updateScore",points);

				Destroy(this.gameObject);
			}
		}
	}
}
