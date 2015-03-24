using UnityEngine;
using System.Collections;

public class menuControl : MonoBehaviour {

	public bool isCredit=false;
	public bool isBack=false;
	public bool isHelp=false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Escape)) {
			Application.Quit();
		}
	}

	void OnMouseEnter(){
		renderer.material.color = Color.blue;
	}

	void OnMouseExit(){
		//change text color
		renderer.material.color=Color.white;
	}

	void OnMouseUp(){
		if (isCredit==true) {
			Application.LoadLevel("Credits");
		} else if (isBack==true){
			Application.LoadLevel("mainMenu");
		} else if (isHelp==true){
			Application.LoadLevel("help");
		}else {
			//load level
			Application.LoadLevel("Level1");
		}
	}
}