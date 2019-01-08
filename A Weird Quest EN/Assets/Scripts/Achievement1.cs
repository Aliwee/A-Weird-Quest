using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.UI;

public class Achievement1 : MonoBehaviour, AchievementManager {

	public Fungus.Flowchart fc;                 // reference to the Fungus Flowchart
	public Sprite sp;                         // image of achievement

	private bool isAchievementUnlocked;         // if player unlock Achievement 1
	private Image achievementImg;               // reference to the Image component
	private Text achievementName;               // reference to the Text component

	// Use this for initialization
	void Start () {
		checkAchievementState ();

		Transform tf = GameObject.Find ("Panel").transform;
		achievementImg = tf.GetChild (0).gameObject.GetComponent<Image> ();
		achievementName = tf.GetChild (2).gameObject.GetComponent<Text> ();
		loadAchievementInfo ();
	}

	public void checkAchievementState () {
		List<Achievement> achievements = UserDataManager.instance.GetAchievement ();

		int index = achievements.FindIndex (item => item.num == 1);
		if (index < 0)
			isAchievementUnlocked = false;
		else
			isAchievementUnlocked = true;
	}

	public void unlockAchievement() {
		if (isAchievementUnlocked == false) {
			isAchievementUnlocked = true;
			UserDataManager.instance.AddAchievement (1, true);
			fc.ExecuteBlock ("unlockAchievement1");
			UserDataManager.instance.UpdateItemsAndLevelData ();
		} else
			fc.ExecuteBlock ("nextLevel");
	}

	public void loadAchievementInfo() {
		achievementImg.sprite = sp;
		achievementName.text = "An Easy Piece of Cake";
	}
}
