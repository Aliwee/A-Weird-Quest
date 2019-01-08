using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.SceneManagement;

public class Achievement6 : MonoBehaviour, AchievementManager {

	public GameObject exit,tryAgain;            // reference to the Exit panel
	public Fungus.Flowchart fc;                 // reference to the Fungus Flowchart
	public Animator anim;					    // reference to the player's animator component. 

	private bool isAchievementUnlocked;         // if player unlock Achievement 6

	// Use this for initialization
	void Start () {
		checkAchievementState ();
		MouseLock.instance.lockMouse ();
		StartCoroutine (loadNextLevel());
	}

	IEnumerator loadNextLevel() {
		yield return new WaitForSeconds (34.0f);

		if (tryAgain.activeSelf == false)
			fc.ExecuteBlock("nextLevel");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Return)) {
			// if the exit panel isn't activated
			if (exit.activeSelf == false ) {
				// if the try again isn't activated
				if (tryAgain.activeSelf == false) {
					// pause the animation
					anim.enabled = false;

					// show the pause effect
					fc.ExecuteBlock("snowEffect");

					// check if we need to unlock Achievement 6
					unlockAchievement ();
				}
				else { // then the player wants to try again
					Scene s = SceneManager.GetActiveScene ();
					SceneManager.LoadScene (s.name);
				}
			}
		}

		if (tryAgain.activeSelf == true)
			// pause the animation
			anim.enabled = false;
	}

	public void checkAchievementState() {
		List<Achievement> achievements = UserDataManager.instance.GetAchievement ();

		int index = achievements.FindIndex (item => item.num == 6);
		if (index < 0)
			isAchievementUnlocked = false;
		else
			isAchievementUnlocked = true;
	}

	public void unlockAchievement() {
		if (isAchievementUnlocked == false) {
			isAchievementUnlocked = true;
			UserDataManager.instance.AddAchievement (6, true);
			fc.ExecuteBlock ("unlockAchievement6");
		}
	}
}
