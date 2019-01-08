using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanControl : MonoBehaviour {

	private Animator anim;					// Reference to the bean's animator component. 

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			anim.SetTrigger ("enter");
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.tag == "Player") {
			anim.SetTrigger ("exit");
		}
	}
}
