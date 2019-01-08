using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Level5 : MonoBehaviour {

	public GameObject exit, eye, nextText,pearl;  // reference to the exit panel, eye, next level panel, pearl
	public Fungus.Flowchart fc;    // reference to the Fungus.Flowchart
	public Animator machineAnim;   // reference to the machine's Animator component

	private string colliderName;   // store current collider object name
	private int pressMachineTimes; // store how many times has player press machine in state 3
	private int state;             // the current state of player's slot machine. 1 - none; 2 - ticket; 3 - none; 4 - pearl 

	// Use this for initialization
	void Start () {
		colliderName = "null";

		bool isState2 = UserDataManager.instance.GetIsState2 ();
		if (isState2 == true) {
			state = 2;
			Destroy (eye);
		} else
			state = 1;

		string hasPearl = UserDataManager.instance.GetPearl ();
		if (hasPearl == "T")
			pearl.SetActive (true);

		checkAchievementState ();
			
		pressMachineTimes = 0;

		MouseLock.instance.lockMouse ();
	}

	void checkAchievementState () {
		List<Achievement> achievements = UserDataManager.instance.GetAchievement ();

		int index = achievements.FindIndex (item => item.num == 3);
		if (index < 0) {
			state = 1;
		}
		else {
			state = 2;
			Destroy (eye);
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.E) && exit.activeSelf == false) {
			if (nextText.activeSelf == true)
				fc.ExecuteBlock ("nextLevel");
			else {
				if (colliderName == "PreviousLevel")  // if player colliders with the previous level
					fc.ExecuteBlock("previousLevel");
				
				else if (colliderName == "Eye")       // if player colliders with the eye
					fc.ExecuteBlock("eyeLevel");

				else if (colliderName == "Machine") { // if player colliders with the machine
					if (state == 1)         // state 1: machine produces none
						machineAnim.SetTrigger("None");
					else if (state == 2) {  // state 2: machine produces one ticket 
						machineAnim.SetTrigger("Ticket");
						fc.ExecuteBlock ("Ticket");
						state = 3;
					}
					else if (state == 3) {  // state 3: machine produces none, wait for another 10 times
						pressMachineTimes++;
						if (pressMachineTimes == 10 && pearl.activeSelf == false) {   // enter state 4
							machineAnim.SetTrigger ("None");
							state = 4;
						} else
							machineAnim.SetTrigger ("None");
					}
					else if (state == 4) {  // state 4: machine produces one pearl
						machineAnim.SetTrigger("Pearl");
						fc.ExecuteBlock ("Pearl");
						UserDataManager.instance.activePearl ();
						state = 1;
					}
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		colliderName = other.name;
	}

	void OnTriggerExit2D(Collider2D other) {
		colliderName = "null";
	}
}
