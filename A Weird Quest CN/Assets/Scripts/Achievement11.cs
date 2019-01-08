using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievement11 : MonoBehaviour {

	public Fungus.Flowchart fc;                 // reference to the Fungus Flowchart
	public Sprite sp;                           // image of achievement
	public GameObject exit,tryAgain;

	private bool isAchievementUnlocked;         // if player unlock Achievement 11
	private Image achievementImg;               // reference to the Image component
	private Text achievementName;               // reference to the Text component
	private string canCheat;

	// Use this for initialization
	void Start () {
		checkAchievementState ();
		Transform tf = GameObject.Find ("AchievementPanel").transform;
		achievementImg = tf.GetChild (0).gameObject.GetComponent<Image> ();
		achievementName = tf.GetChild (2).gameObject.GetComponent<Text> ();
		canCheat = UserDataManager.instance.GetCheat ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Tab) && exit.activeSelf == false && canCheat == "T" && tryAgain.activeSelf == false) {
			unlockAchievement ();
		}
	}

	public void checkAchievementState () {
		List<Achievement> achievements = UserDataManager.instance.GetAchievement ();

		int index = achievements.FindIndex (item => item.num == 11);
		if (index < 0)
			isAchievementUnlocked = false;
		else
			isAchievementUnlocked = true;
	}

	public void unlockAchievement() {
		if (isAchievementUnlocked == false) {
			loadAchievementInfo ();
			isAchievementUnlocked = true;
			UserDataManager.instance.AddAchievement (11, true);
			fc.ExecuteBlock ("unlockAchievement11");
		}
	}

	public void loadAchievementInfo() {
		achievementImg.sprite = sp;
		achievementName.text = "作弊光荣";
	}
}
