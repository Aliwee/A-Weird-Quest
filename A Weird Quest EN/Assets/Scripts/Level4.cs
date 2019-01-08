using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Level4 : MonoBehaviour {

	public Fungus.Flowchart fc;        // reference to the Fungus Flowchart
	public GameObject nextIcon;        // reference to the next level icon
	public GameObject exit;            // reference to the exit panel

	private Animator anim;             // reference to the Snake Animator component
	private BoxCollider2D bc;          // reference to the Snake BoxCollifer2D component

	// Use this for initialization
	void Start () {
		MouseLock.instance.lockMouse ();
		anim = GetComponent<Animator> ();
		bc = GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		// if player presses E, show the piper's dialog or enter the next level
		if (Input.GetKeyDown(KeyCode.E)) {
			// make sure the player dosen't activate the exit panel
			if (exit.activeSelf == false) {
				// check if the player wannts to enter the next level
				if (nextIcon.activeSelf == true)
					fc.ExecuteBlock ("nextLevel");
				// then the player can active the piper's dialog
				else
					fc.ExecuteBlock ("Dialog");
			}
		}
		// if player presses M, solve the piper's puzzle
		else if (Input.GetKeyDown(KeyCode.M)) {
			anim.SetTrigger("Clam");
			fc.ExecuteBlock ("StopMusic");
			bc.enabled = false;
		}
	}

}
