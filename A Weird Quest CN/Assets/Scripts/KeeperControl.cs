using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class KeeperControl : MonoBehaviour {

	public GameObject ticket;       // reference to the ticket icon
	public Fungus.Flowchart fc;     // reference to the Fungus Flowchart
	public GameObject nextLevel;    // reference to the next level icon

	private Animator anim;          // reference to the Keeper's Animator component

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		// if the player has ticket
		if (other.gameObject.tag == "Player") {
			if (ticket.activeSelf == true) {
				fc.ExecuteBlock ("pass");
			} else
				fc.ExecuteBlock ("Dialog");
		}

	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			anim.SetTrigger ("Idle");
			nextLevel.SetActive (false);
		}
	}
}
