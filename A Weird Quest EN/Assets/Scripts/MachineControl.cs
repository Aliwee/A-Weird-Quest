using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineControl : MonoBehaviour {

	public GameObject Ebutton;     // reference to the E button
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			Ebutton.SetActive (true);
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			Ebutton.SetActive (false);
		}
	}
}
