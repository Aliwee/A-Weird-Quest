using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player62 : MonoBehaviour {

	public Fungus.Flowchart fc;     // reference to the Fungus Flowchart
	public GameObject nextText;     // reference to the nextText

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name == "Door") {
			other.transform.GetChild (0).gameObject.SetActive (true);
		}
		else if (other.gameObject.name == "NextLevel") {
			nextText.SetActive(true);
		}
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.gameObject.name == "Door") {
			other.transform.GetChild (0).gameObject.SetActive (true);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.name == "Door") {
			other.transform.GetChild (0).gameObject.SetActive (false);
		}
		else if (other.gameObject.name == "NextLevel") {
			nextText.SetActive (false);
		}
	}
}
