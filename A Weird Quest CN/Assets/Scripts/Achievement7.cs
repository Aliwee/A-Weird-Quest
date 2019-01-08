using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Achievement7 : MonoBehaviour,AchievementManager {

	public Fungus.Flowchart fc;                 // reference to the Fungus Flowchart
	public CamerFollow cf;                      // reference to the CameraFollow component
	public Animator player;                     // reference to the player Animator
	public PlayerControl pc;                    // reference to the PlayerControl Animator

	private bool isAchievementUnlocked;         // if player unlock Achievement 7

	// Use this for initialization
	void Start () {
		checkAchievementState ();
		MouseLock.instance.lockMouse ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			unlockAchievement ();
		}
	}

	public void checkAchievementState() {
		List<Achievement> achievements = UserDataManager.instance.GetAchievement ();

		int index = achievements.FindIndex (item => item.num == 7);
		if (index < 0)
			isAchievementUnlocked = false;
		else
			isAchievementUnlocked = true;
	}

	public void unlockAchievement() {
		if (isAchievementUnlocked == false) {
			cf.enabled = false;
			pc.enabled = false;
			player.SetFloat ("Speed",0f);
			isAchievementUnlocked = true;
			UserDataManager.instance.AddAchievement (7, true);
			fc.ExecuteBlock ("unlockAchievement7");
		}
	}

	public void unlockPlayer() {
		cf.enabled = true;
		pc.enabled = true;
	}
}
