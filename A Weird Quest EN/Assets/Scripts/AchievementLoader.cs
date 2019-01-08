using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Fungus;

public class AchievementLoader : MonoBehaviour {

	public Button[] buttons;                              // array of achievement buttons
	public Sprite[] images;                               // arrray of achievement images
	public Fungus.Flowchart fc;                           // reference to the Fungus.Flowchart;

	private List<Achievement> achievementList;            // reference to the achievementList of UserDataManager
	private GameObject lastPickedItem;                    // last picked achievement
	private string[] achievementNames, achievementDes;    // achievement detail info array
	private Text aName, aDes;                             // achievement detail info components

	// Use this for initialization
	void Start () {
		achievementList = UserDataManager.instance.GetAchievement ();

		GameObject detail = GameObject.Find ("Detail").gameObject;
		aName = detail.GetComponent<Text> ();
		aDes = detail.transform.GetChild (0).transform.GetChild(0).gameObject.GetComponent<Text> ();

		achievementNames = new string[12] { 
			"???", "An Easy Piece of Cake",
			"Silence Is Gold","Blind Confidence",
			"The Exorcist","Game Over Fastlane",
			"Burning with Impatience","The Jump Trick",
			"The Benefactor","A Careless Slip",
			"An Unexpected Treasure","Shameless Cheater"};
		achievementDes = new string[12] { 
			"You haven't unlock the achievement. Don't worry, you'll figure it out. You can unlock this, come on!",
			"Click one key image to start the game. Just a simple pun, isn't it?",
			"Succeed at quieting the snake by pressing the M button on keybroad. Got you there, didn't it?",
			"Close all the Evil Eyes for the first time. A classic puzzle for you, and you solved it! Well done.",
			"Defeat the Demon and save the Girl's soul. Good job, deer player!",
			"Ignore the phone call and put an end to the journey immediately at the Detective's home. But seriously, how on earth could you figure that out? You're a genius!",
			"Try to skip the cutscene and get stuck. Well, it is important to watch the cutscene after all.",
			"Try to use the jump function in front of the gaint gap. In fact I've never implemented the jump function in this game, I'm just kidding in that tutorial.",
			"Get a pearl from the slot machine and give it to the Piper. Enjoy a beautiful melody from Hulusi, a traditional Chinese instrument.",
			"Walk towards the deep water inside the dark cave. Let the gravity do its job and stay away from the egde next time!",
			"Find a way to the hidden place and pick up the stone tablet. I wonder how long it took you to get this achievement LOL.",
			"Use the cheat mod in the final battle. So you did return to the last level to check out this mod, I'm so glad!" };

		// load the achievements
		LoadAchievements ();

		// adds click event to each button in Button[]
		for (int i = 0; i < 11; i++)
			buttons [i].onClick.AddListener (AchievementClick);

		// unlock the mouse
		MouseLock.instance.unlockMouse ();
	}
	
	// Update is called once per frame
	void Update () {
		// if the player press Esc
		if (Input.GetKeyDown (KeyCode.Escape))
			fc.ExecuteBlock ("Return");
	}

	void LoadAchievements() {
		int length = achievementList.Count;
		for(int i = 0; i < length; i++) {
			int index = achievementList [i].num - 1;
			buttons [index].GetComponent<Image> ().sprite = images [index];
		}
	}

	void AchievementClick() {
		//get the index of the selected achievment
		GameObject btn = EventSystem.current.currentSelectedGameObject;
		int currentIndex = int.Parse (btn.name);

		if(lastPickedItem != null){
			lastPickedItem.SetActive (false);
			lastPickedItem = btn.transform.GetChild (0).gameObject;
			lastPickedItem.SetActive (true);
		}

		// check if the achievement is unlocked
		int activeIndex = achievementList.FindIndex (item => item.num == currentIndex);
		if (activeIndex < 0)
			currentIndex = 0;

		aName.text = achievementNames [currentIndex];
		aDes.text = achievementDes [currentIndex];
	}
}
