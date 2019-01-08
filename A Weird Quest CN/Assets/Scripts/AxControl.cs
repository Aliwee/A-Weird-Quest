using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxControl : MonoBehaviour {

	private GameObject Ebuttton;    // the E icon

	// Use this for initialization
	void Start () {
		Ebuttton = transform.GetChild (0).gameObject;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			Ebuttton.SetActive (!Ebuttton.activeSelf);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.tag == "Player") {
			Ebuttton.SetActive (!Ebuttton.activeSelf);
		}
	}
}
