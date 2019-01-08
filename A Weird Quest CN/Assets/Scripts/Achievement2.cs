using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement2 : MonoBehaviour,AchievementManager {

	public Fungus.Flowchart fc;                 // reference to the Fungus Flowchart

	private bool isAchievementUnlocked;         // if player unlock Achievement 2

	// Use this for initialization
	void Start () {
		checkAchievementState ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.M)) {
			unlockAchievement ();
		}
	}

	public void checkAchievementState () {
		List<Achievement> achievements = UserDataManager.instance.GetAchievement ();

		int index = achievements.FindIndex (item => item.num == 2);
		if (index < 0)
			isAchievementUnlocked = false;
		else
			isAchievementUnlocked = true;
	}

	public void unlockAchievement() {
		if (isAchievementUnlocked == false) {
			isAchievementUnlocked = true;
			UserDataManager.instance.AddAchievement (2, true);
			fc.ExecuteBlock ("unlockAchievement2");
		}
	}
}
