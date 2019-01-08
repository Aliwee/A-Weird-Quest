using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Achievement5 : MonoBehaviour, AchievementManager {

	public Fungus.Flowchart fc;                 // reference to the Fungus Flowchart
	public GameObject e;                        // reference to the E icon

	private bool isAchievementUnlocked;         // if player unlock Achievement 5
	private Animator anim;					    // reference to the player's animator component. 

	// Use this for initialization
	void Start () {
		MouseLock.instance.lockMouse ();
		checkAchievementState ();
		anim = GameObject.Find ("DetectiveSleep").GetComponent<Animator> ();
		MouseLock.instance.lockMouse ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E)) {
			if (e.activeSelf == true)
				loadLevel2 ();
		}
	}

	public void checkAchievementState() {
		List<Achievement> achievements = UserDataManager.instance.GetAchievement ();

		int index = achievements.FindIndex (item => item.num == 5);
		if (index < 0)
			isAchievementUnlocked = false;
		else
			isAchievementUnlocked = true;
	}

	public void unlockAchievement() {
		// if player is still in level 1
		if (SceneManager.GetActiveScene().name == "Level-1") {
			// check if needs to unlock Achievement 5
			if (isAchievementUnlocked == false) {
				isAchievementUnlocked = true;
				UserDataManager.instance.AddAchievement (5, true);
				fc.ExecuteBlock ("unlockAchievement5");
			} else 
				fc.ExecuteBlock ("toCredit");
		}
	}

	public void loadLevel2() {
		// change animation of player
		anim.SetTrigger ("Phone");

		// load Level2
		fc.ExecuteBlock ("nextLevel");
	}
}
