using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeControl : MonoBehaviour {
	
	public GameObject nextIcon,otherE;   // reference to the next level icon and other E icon
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			nextIcon.SetActive (true);
			// if we need to diable other E button
			if (otherE != null)
				otherE.SetActive (false);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			nextIcon.SetActive (false);
			// if we need to enable other E button
			if (otherE != null)
				otherE.SetActive (true);
		}
	}
}
