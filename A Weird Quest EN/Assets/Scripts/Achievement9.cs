using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achievement9 : MonoBehaviour,AchievementManager {

	public Fungus.Flowchart fc;                 // reference to the Fungus Flowchart
	public GameObject tryAgain;                 // reference to the tryAgain panel

	private bool isAchievementUnlocked;         // if player unlock Achievement 9

	// Use this for initialization
	void Start () {
		checkAchievementState ();
		MouseLock.instance.lockMouse ();
	}
	
	public void checkAchievementState() {
		List<Achievement> achievements = UserDataManager.instance.GetAchievement ();

		int index = achievements.FindIndex (item => item.num == 9);
		if (index < 0)
			isAchievementUnlocked = false;
		else
			isAchievementUnlocked = true;
	}

	public void unlockAchievement() {
		isAchievementUnlocked = true;
		UserDataManager.instance.AddAchievement (9, true);
		fc.ExecuteBlock ("unlockAchievement9");
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			if (isAchievementUnlocked == false)
				unlockAchievement ();
			else
				tryAgain.SetActive (true);
		}
	}
}
