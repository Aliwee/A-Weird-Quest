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
			"???", "小菜一碟",
			"沉默是金","盲目自信",
			"驱魔者","通关快车道",
			"暴躁老哥","跳跃陷阱",
			"施善者","脚下一滑",
			"意外之财","作弊光荣"};
		achievementDes = new string[12] { 
			"你还没有解锁这个成就呢。别担心，你会想出来办法的。加油吧！",
			"点击一个钥匙图像开始了你的游戏。你真是火眼金睛！",
			"按M键成功地让蛇安静了下来。这谜题困扰了你一些时间，是不？",
			"第一次关闭所有邪灵之眼。一个为你精心准备的经典谜题，而你解开了！干得好。",
			"打败可怕的恶魔，拯救小女孩的灵魂。为你骄傲，亲爱的玩家！",
			"在侦探家忽略来电，直接结束游戏之旅。说真的，你究竟是怎么想到的？你是个天才！",
			"尝试跳过过场动画并卡住。观看过场动画是一件很严肃的事情，懂了吧。",
			"在悬崖前面尝试使用跳跃键。实际上我从未实现这个游戏的跳跃功能，我糊弄你呢。",
			"从老虎机上获得一颗珍珠并给吹笛人。享受一段来自中国传统乐器葫芦丝的美妙旋律。",
			"在黑暗洞穴中直接掉入深水中。让重力效果告诉你下次要离边缘远一些吧。",
			"找到去隐藏之地的办法，并获得了一个石碑。我在想解锁一个成就又花费了你多少时间，嘻嘻。",
			"在最后一战中使用作弊模式。所以你的确再次重新进入了最后一关来查看这个信息，我真开心！" };

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
