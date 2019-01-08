using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatControl : MonoBehaviour {
	
	public Fungus.Flowchart fc;               // reference to the Fungus Flowchart
	public GameObject text, exit, tryAgain;   // reference to the text, exit, tryAgain GameObject
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E)) {
			// make sure the tryAgain, exit panel are off and the player enter the boat zone
			if (exit.activeSelf == false && tryAgain.activeSelf == false && text.activeSelf == true) {
				fc.ExecuteBlock ("nextLevel");
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			text.SetActive (true);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.tag == "Player") {
			text.SetActive (false);
		}
	}
}
