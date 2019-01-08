using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Achievement8 : MonoBehaviour,AchievementManager {

	public Fungus.Flowchart fc;                 // reference to the Fungus Flowchart
	public GameObject nextLevel, exit;          // reference to the next level, exit

	private bool isAchievementUnlocked;         // if player unlock Achievement 8
	private string hasPearl;

	// Use this for initialization
	void Start () {
		checkAchievementState ();
		hasPearl = UserDataManager.instance.GetPearl ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E) && nextLevel.activeSelf == false && exit.activeSelf == false && hasPearl == "T") {
			unlockAchievement ();
		}
	}

	public void checkAchievementState() {
		List<Achievement> achievements = UserDataManager.instance.GetAchievement ();

		int index = achievements.FindIndex (item => item.num == 8);
		if (index < 0)
			isAchievementUnlocked = false;
		else
			isAchievementUnlocked = true;
	}

	public void unlockAchievement() {
		if (isAchievementUnlocked == false) {
			isAchievementUnlocked = true;
			UserDataManager.instance.AddAchievement (8, true);
			fc.ExecuteBlock ("unlockAchievement8");
		}
	}
}
