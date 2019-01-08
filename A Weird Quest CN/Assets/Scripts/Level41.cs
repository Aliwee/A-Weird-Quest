using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Level41 : MonoBehaviour {

	public Animator snakeAnim,piperAnim;    // reference to the sanke, piper's Animator component
	public GameObject exit,pearl,nextIcon; // reference to the exit panel, pearl icon, next level icon
	public SpriteRenderer sr;     // reference to the piper's dialog SpriteRenderer component
	public Sprite cheer;          // reference to the cheer sprite
	public Fungus.Flowchart fc;        // reference to the Fungus Flowchart

	private string hasPearl;      // if the player has pearl

	// Use this for initialization
	void Start () {
		MouseLock.instance.lockMouse ();
		snakeAnim.SetTrigger ("None");
		hasPearl = UserDataManager.instance.GetPearl ();
		if (hasPearl == "T") {
			pearl.SetActive (true);
			sr.sprite = cheer;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E)) {
			// make sure the player dosen't activate the exit panel
			if (exit.activeSelf == false) {
				// check if the player wannts to enter the next level
				if (nextIcon.activeSelf == true)
					fc.ExecuteBlock ("nextLevel");
				// then the player can active the piper's dialog
				else {
					if (hasPearl == "T") // if player has pearl
						Cheer ();
					else
						fc.ExecuteBlock ("Dialog");
				}
			}
		}
	}

	void Cheer() {

		// play piper's new music
		fc.ExecuteBlock ("Cheer");

		// change snake's and piper's animation
		snakeAnim.SetTrigger ("Cheer");
		piperAnim.SetTrigger ("Cheer");
	}
}
