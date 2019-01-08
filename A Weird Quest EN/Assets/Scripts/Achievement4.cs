using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Achievement4 : MonoBehaviour {

	public Fungus.Flowchart fc;                 // reference to the Fungus Flowchart
	public Sprite sp;                           // image of achievement
	public GameObject Ebutton,exit,tryAgain;

	private bool isAchievementUnlocked;         // if player unlock Achievement 4
	private Image achievementImg;               // reference to the Image component
	private Text achievementName;               // reference to the Text component

	// Use this for initialization
	void Start () {
		checkAchievementState ();
		Transform tf = GameObject.Find ("AchievementPanel").transform;
		achievementImg = tf.GetChild (0).gameObject.GetComponent<Image> ();
		achievementName = tf.GetChild (2).gameObject.GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E) && Ebutton.activeSelf == true && exit.activeSelf == false && tryAgain.activeSelf == false) {
			unlockAchievement ();
			Ebutton.SetActive (false);
			UserDataManager.instance.UpdateItemsAndLevelData ();
		}
	}

	public void checkAchievementState () {
		List<Achievement> achievements = UserDataManager.instance.GetAchievement ();

		int index = achievements.FindIndex (item => item.num == 4);
		if (index < 0)
			isAchievementUnlocked = false;
		else
			isAchievementUnlocked = true;
	}

	public void unlockAchievement() {
		if (isAchievementUnlocked == false) {
			loadAchievementInfo ();
			isAchievementUnlocked = true;
			UserDataManager.instance.AddAchievement (4, true);
			fc.ExecuteBlock ("unlockAchievement4");
		} else
			fc.ExecuteBlock ("nextLevel");
	}

	public void loadAchievementInfo() {
		achievementImg.sprite = sp;
		achievementName.text = "The Exorcist";
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			Ebutton.SetActive (true);
		}
	} 

	void OnTriggerExit2D(Collider2D other) {
		Ebutton.SetActive (false);
	} 
}
