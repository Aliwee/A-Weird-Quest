using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleControl : MonoBehaviour {

	private Animator anim;    // reference to the tentacle Animator component

	// Use this for initialization
	void Start () {
		anim = transform.GetChild (1).GetComponent<Animator> ();
	}


	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			anim.SetTrigger ("Back");
		}
	}
}
