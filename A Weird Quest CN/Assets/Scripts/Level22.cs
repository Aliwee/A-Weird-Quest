using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Level22 : MonoBehaviour {

	public GameObject Ebutton;              // reference to the E button
	public Fungus.Flowchart fc;             // reference to the Fungus Flowchart

	private Animator anim;					// Reference to the player's animator component.

	// Use this for initialization
	void Start () {
		MouseLock.instance.lockMouse ();
		anim = GetComponent<Animator> ();
	}

	void Update() {
		// if the play press E when E icon appears
		if (Input.GetKeyDown(KeyCode.E) && Ebutton.activeSelf == true) {
			anim.SetTrigger("TouchGirl");
			fc.ExecuteBlock ("nextLevel");
		}
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		Ebutton.SetActive (!Ebutton.activeSelf);
	}

	void OnTriggerExit2D(Collider2D other) {
		Ebutton.SetActive (!Ebutton.activeSelf);
	}


}
