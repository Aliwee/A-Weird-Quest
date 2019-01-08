using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleControl3 : MonoBehaviour {

	public GameObject dialog;  // reference to the player dialog
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			dialog.SetActive (true);
			Camera.main.GetComponent<CameraScroll> ().enabled = false;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			dialog.SetActive (false);
			Camera.main.GetComponent<CameraScroll> ().enabled = true;
		}
	}
}
