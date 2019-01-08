using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement3 : MonoBehaviour,AchievementManager {

	public Animator[] eyes;           // reference to all eyes' Animator components
	public AudioClip sound;           // reference to the aggresive sound when player fails to remove the sticker
	public Fungus.Flowchart fc;       // reference to the Fungus Flowchart
	public Transform mainCamera;      // reference to the main camera

	private List<int> eyesStates;     // all eyes' state. 1: Open; 0: Close
	private bool isAchievementUnlocked;    // if  player unlock Achievement 3

	// Use this for initialization
	void Start () {
		MouseLock.instance.lockMouse ();

		eyesStates = new List<int> () { 0, 1, 1, 0, 1, 1, 1 };
		eyes [0].SetTrigger ("Switch");
		eyes [3].SetTrigger ("Switch");

		checkAchievementState ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E)) {
			// check if player close all eyes
			int open = eyesStates.FindIndex (eye => eye == 1);
			if (open < 0) {  // all eyes all closed
				// check if we need to unlock achievement
				if (isAchievementUnlocked == false) {
					UserDataManager.instance.enterState2 ();
					unlockAchievement ();
				}
				else {
					UserDataManager.instance.enterState2 ();
					fc.ExecuteBlock("removeSticker");
				}
			}
			else {
				// plays warning sound
				AudioSource.PlayClipAtPoint (sound, mainCamera.position);

				// for open eyes, change animations
				for (int i = 0; i < 7; i++) {
					if (eyesStates [i] == 1)
						eyes [i].SetTrigger ("Warning");
				}
			}
		}
		if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)) {
			switchEye1 ();
		}
		if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)) {
			switchEye2 ();
		}
		if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3)) {
			switchEye3 ();
		}
		if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4)) {
			switchEye4 ();
		}
		if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5)) {
			switchEye5 ();
		}
		if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6)) {
			switchEye6 ();
		}
		if (Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7)) {
			switchEye7 ();
		}
	}

	public void checkAchievementState () {
		List<Achievement> achievements = UserDataManager.instance.GetAchievement ();

		int index = achievements.FindIndex (item => item.num == 3);
		if (index < 0)
			isAchievementUnlocked = false;
		else 
			isAchievementUnlocked = true;
	}

	public void unlockAchievement() {
		if (isAchievementUnlocked == false) {
			isAchievementUnlocked = true;
			UserDataManager.instance.AddAchievement (3, true);
			fc.ExecuteBlock ("unlockAchievement3");
		}
	}

	void switchEye1() {   // eye 1: controls eye 2,3,4,5,7
		eyesStates [0] = switchState (eyesStates [0]);
		eyes [0].SetTrigger ("Switch");

		eyesStates [1] = switchState (eyesStates [1]);
		eyes [1].SetTrigger ("Switch");

		eyesStates [2] = switchState (eyesStates [2]);
		eyes [2].SetTrigger ("Switch");

		eyesStates [3] = switchState (eyesStates [3]);
		eyes [3].SetTrigger ("Switch");

		eyesStates [4] = switchState (eyesStates [4]);
		eyes [4].SetTrigger ("Switch");

		eyesStates [6] = switchState (eyesStates [6]);
		eyes [6].SetTrigger ("Switch");
	}

	void switchEye2() {  // eye 2: controls eye 5,7
		eyesStates [1] = switchState (eyesStates [1]);
		eyes [1].SetTrigger ("Switch");

		eyesStates [4] = switchState (eyesStates [4]);
		eyes [4].SetTrigger ("Switch");

		eyesStates [6] = switchState (eyesStates [6]);
		eyes [6].SetTrigger ("Switch");
	}

	void switchEye3() {  // eye 3: controls eye 2,5,7
		eyesStates [2] = switchState (eyesStates [2]);
		eyes [2].SetTrigger ("Switch");

		eyesStates [1] = switchState (eyesStates [1]);
		eyes [1].SetTrigger ("Switch");

		eyesStates [4] = switchState (eyesStates [4]);
		eyes [4].SetTrigger ("Switch");

		eyesStates [6] = switchState (eyesStates [6]);
		eyes [6].SetTrigger ("Switch");
	}

	void switchEye4() {  // eye 4: controls eye 3,2,5,7
		eyesStates [3] = switchState (eyesStates [3]);
		eyes [3].SetTrigger ("Switch");

		eyesStates [1] = switchState (eyesStates [1]);
		eyes [1].SetTrigger ("Switch");

		eyesStates [2] = switchState (eyesStates [2]);
		eyes [2].SetTrigger ("Switch");

		eyesStates [4] = switchState (eyesStates [4]);
		eyes [4].SetTrigger ("Switch");

		eyesStates [6] = switchState (eyesStates [6]);
		eyes [6].SetTrigger ("Switch");
	}

	void switchEye5() {  // eye 5: controls eye 7
		eyesStates [4] = switchState (eyesStates [4]);
		eyes [4].SetTrigger ("Switch");

		eyesStates [6] = switchState (eyesStates [6]);
		eyes [6].SetTrigger ("Switch");
	}

	void switchEye6() {  // eye 6: controls all eyes
		eyesStates [5] = switchState (eyesStates [5]);
		eyes [5].SetTrigger ("Switch");

		eyesStates [0] = switchState (eyesStates [0]);
		eyes [0].SetTrigger ("Switch");

		eyesStates [1] = switchState (eyesStates [1]);
		eyes [1].SetTrigger ("Switch");

		eyesStates [2] = switchState (eyesStates [2]);
		eyes [2].SetTrigger ("Switch");

		eyesStates [3] = switchState (eyesStates [3]);
		eyes [3].SetTrigger ("Switch");

		eyesStates [4] = switchState (eyesStates [4]);
		eyes [4].SetTrigger ("Switch");

		eyesStates [6] = switchState (eyesStates [6]);
		eyes [6].SetTrigger ("Switch");
	}

	void switchEye7() { // eye 7: controls itself
		eyesStates [6] = switchState (eyesStates [6]);
		eyes [6].SetTrigger ("Switch");
	}

	int switchState(int i) {
		if (i == 0)
			return 1;
		else
			return 0;
	}


}
