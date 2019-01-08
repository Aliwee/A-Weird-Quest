using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeControl : MonoBehaviour {

	public GameObject axIcon;       // reference to the ax icon

	private GameObject Ebuttton;    // the E icon

	// Use this for initialization
	void Start () {
		Ebuttton = transform.GetChild (0).gameObject;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			if (axIcon.activeSelf == true)
				Ebuttton.SetActive (true);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.tag == "Player") {
			Ebuttton.SetActive (false);
		}
	}
}
