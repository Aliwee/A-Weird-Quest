using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement10 : MonoBehaviour,AchievementManager {

	public Fungus.Flowchart fc;                 // reference to the Fungus Flowchart
	public GameObject tableImg, exit;           // referencce to the tablet, exit panel

	private bool isAchievementUnlocked;         // if player unlock Achievement 8

	// Use this for initialization
	void Start () {
		MouseLock.instance.lockMouse ();
		checkAchievementState ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E)) {
			if (tableImg.activeSelf == true && exit.activeSelf == false) {
				if (isAchievementUnlocked == false) {
					unlockAchievement ();
				}
			}
		}
	}

	public void checkAchievementState() {
		List<Achievement> achievements = UserDataManager.instance.GetAchievement ();

		int index = achievements.FindIndex (item => item.num == 10);
		if (index < 0)
			isAchievementUnlocked = false;
		else
			isAchievementUnlocked = true;
	}

	public void unlockAchievement() {
		if (isAchievementUnlocked == false) {
			isAchievementUnlocked = true;
			UserDataManager.instance.AddAchievement (10, true);
			fc.ExecuteBlock ("unlockAchievement10");
		}
	}
}
