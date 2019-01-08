using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level61 : MonoBehaviour {

	public Fungus.Flowchart fc;         // reference to the Fungus Flowchart

	void Start() {
		MouseLock.instance.lockMouse ();
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		// if  player enters the normal level zone
		if (other.gameObject.name == "nextLevel") {
			Camera.main.GetComponent<CameraScroll> ().enabled = false;
			fc.ExecuteBlock ("nextLevel");
		}
		else if (other.gameObject.name == "safePlace") {  
			fc.ExecuteBlock ("showTentacle");
		}
	}
}
