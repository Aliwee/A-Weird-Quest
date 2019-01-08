using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Level2 : MonoBehaviour {

	public Fungus.Flowchart fc;         // reference to the Fungus Flowchart
	public GameObject Ebutton;          // reference to the E button

	private Animator anim;              // reference to the Animator component

	// Initailization
	void Start() {
		MouseLock.instance.lockMouse ();
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

		// if player press E
		if (Input.GetKeyDown(KeyCode.E)) {
			if (Ebutton.activeSelf == true) {
				fc.ExecuteBlock ("Dialog");
				anim.SetTrigger("Talk");
			}
		}
	}
}
