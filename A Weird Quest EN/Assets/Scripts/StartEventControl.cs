using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;
using UnityEngine.SceneManagement;

public class StartEventControl : MonoBehaviour {

	public Fungus.Flowchart fc;            // reference to the Fungus Flowchar
	public GameObject level;               // reference to the level gameobject
	public GameObject clearPanel;          // reference to the clear panel
	public Sprite[] levelImages;           // array of level images
	public string[] levelNames = new string[7] {"The Home","The Hospital","The Forest I","The Forest II",
		"The Forest III","The Dark Cave","The Palace"};         // array of level names

	private bool isEActive = false;        // if the player is enable to press E
	private string currentState = null;    // the name of the next scene the player can enter after pressing E
	private Image im;                      // the levelImage
	private Text tx;                       // the levelText
	private int levelNum = 1;                  // the current level number in UserData.xml
	private int currentLevelNum;           // the current level number the player choose

	// Use this for initialization
	void Start () {
		
		levelNum = UserDataManager.instance.GetLevelNum ();
		currentLevelNum = levelNum;

		im = level.GetComponent<Image> ();
		im.sprite = levelImages [levelNum];

		tx = level.transform.GetChild (0).gameObject.GetComponent<Text> ();
		tx.text = levelNames [levelNum - 1];

		MouseLock.instance.lockMouse ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E)){
			if(isEActive == true) {
				if (currentState == "Achievements")              // if the player active the achievement base
					fc.ExecuteBlock ("Achievements");
				else if (currentState == "Exit")                 // if the player active the exit base
					Application.Quit ();
				else if (currentState == "Clear")                // if the player active the clear base
					clearPanel.SetActive (!clearPanel.activeSelf);
				else if (currentState == "Credit")               // if player active the credit base
					fc.ExecuteBlock("Credit");
				else {                                           // if the player active the start base
					level.SetActive (!level.activeSelf);
				}
			}
		}
		else if (Input.GetKeyDown(KeyCode.F)) {                  // if player selects the next level
			if(level.activeSelf == true)
				chooseLevel ();
		}
		else if (Input.GetKeyDown(KeyCode.Return)) {             // if player enters the cuurrent level
			if (level.activeSelf == true && im.sprite.name != "UI-3_1")
				enterLevel ();
		}
		else if (Input.GetKeyDown(KeyCode.Y)) {                  // if player wants to clear all data
			if (clearPanel.activeSelf == true) {
				clearData ();
			}
		}
		else if (Input.GetKeyDown(KeyCode.N)) {                  // if player dosen't want to clear any data
			clearPanel.SetActive (false);
		}
	}

	/// <summary>
	/// If the player colliders with any base.
	/// </summary>
	/// <param name="other">Other.</param>
	void OnTriggerEnter2D(Collider2D other) {
		isEActive = true;
		currentState = other.gameObject.name;
	}

	/// <summary>
	/// If the player no longer colliders with any base.
	/// </summary>
	void OnTriggerExit2D() {
		level.SetActive (false);
		isEActive = false;
		currentState = "null";
	}

	/// <summary>
	/// Chooses the level.
	/// </summary>
	void chooseLevel() {
		if (currentLevelNum == 7)    // if the next level is greater than the final level
			currentLevelNum = 1;     // back to the first level
		else
			currentLevelNum++;

		if (currentLevelNum <= levelNum)                  // if the current level is unlocked
			im.sprite = levelImages [currentLevelNum];   
		else                                              // if the current levle is locked
			im.sprite = levelImages [0];

		//set the name of the current level
		tx.text = levelNames [currentLevelNum - 1];
	}

	/// <summary>
	/// Enters the level.
	/// </summary>
	void enterLevel() {
		string levelName = "Level" + currentLevelNum.ToString ();
		fc.ExecuteBlock (levelName);
	}

	/// <summary>
	/// Clears the data.
	/// </summary>
	void clearData() {
		UserDataManager.instance.clearUserData ();
		SceneManager.LoadScene ("Loading");
	}
}
