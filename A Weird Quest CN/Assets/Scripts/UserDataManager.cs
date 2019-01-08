using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UserDataManager : MonoBehaviour {
	
	public static UserDataManager instance = null;    //一个UserDataManager实例
	public GameObject ratio;                          //ratio对象

	private string userDataXmlPath;                   //xml文件路径
	private XmlDocument userDataXml;                  //userData.xml文件
	private XmlReaderSettings readerSetting;          //xml reader设置
	private XmlNodeList userDataNodes;                //<component>子节点列表
	private int levelNum;                             //关卡索引
	private string isCheatOn;                         //是否解锁了Cheat模式
	private string isCow;                             //是否解锁隐藏关
	private string hasPearl;                          //是否有珍珠
	private List<Achievement> achivementList;         //已解锁成就列表
	private bool isPaused;                            // if player pauses the game
	private bool isState2;                            // if player has enter state 2

	// Use this for initialization
	void Awake () {
		//判断是否已有一个实例
		if (instance == null)
			instance = this;   //如果没有，那么设置实例为该实例
		else if (instance != this)
			Destroy (gameObject);    //保证只能有一个实例

		//设置为重新加载场景时不被销毁
		DontDestroyOnLoad(gameObject);

		//初始化
		userDataXmlPath = Application.dataPath + "/AtadResu/AtadResu.xml";
		userDataXml = new XmlDocument ();
		readerSetting = new XmlReaderSettings ();
		achivementList = new List<Achievement> ();
		isPaused = false;
		isState2 = false;

		//找到xml文件目录
		StartCoroutine (findXML ());

	}

	//使用这个创建和查找xml文件目录
	IEnumerator findXML() {
		//如果不存在那么就创建并且拷贝初始存档
		string path = Application.dataPath + "/AtadResu";
		if (!Directory.Exists (path)) {
			//创建存档目录
			Directory.CreateDirectory (path);
			//拷贝初始存档至该目录
			yield return StartCoroutine (createOriginXML ());
		}

		//加载xml文件
		LoadXML ();

		//获得用户配置数据
		GetUserData ();

		//等待3秒再执行
		yield return new WaitForSeconds (3.0f);

		//开始第一个谜题
		if(ratio != null)
			ratio.SetActive (true);
	}

	//第一次使用时写入一个默认的游戏存档
	IEnumerator createOriginXML() {
		//默认初始存档的路径是在StreamingAssets
		string XMLScrPath = GetStreamingAssetsPath ();
		string XMLDesPath = userDataXmlPath;

		//使用WWW方法
		using (WWW www = new WWW (XMLScrPath)) {
			yield return www;

			//出错
			if (!string.IsNullOrEmpty (www.error))
				Debug .Log (www.error);
			//没出错就下载文件
			else {
				FileStream originXML = File.Create (XMLDesPath);
				originXML.Write (www.bytes, 0, www.bytes.Length);
				originXML.Flush ();
				originXML.Close ();
			}			
		}
	}

	//获得StreamingAssets路径
	string GetStreamingAssetsPath() {
		string prefix;    //前缀

		#if UNITY_EDITOR              //如果是Editor模式
		prefix = "file://";

		#elif UNITY_STANDALONE_WIN    //如果是Windows平台模式
		prefix = "file:///";

		#elif UNITY_STANDALONE_OSX    //如果是MACOS平台
		prefix = "file://";
		#endif 

		string path = prefix + Application.streamingAssetsPath + "/AtadResu.xml";

		return path;
	}

	//使用这个读取xml文件
	void LoadXML() {

		//创建xml文档
		readerSetting.IgnoreComments = true;    //忽略xml文件中注释的影响
		userDataXml.Load (XmlReader.Create (userDataXmlPath, readerSetting));

		//得到xml文件中<data>标签下的所有<component>子节点
		userDataNodes = userDataXml.SelectSingleNode ("data").ChildNodes;
	}
		
	//获得用户配置数据
	void GetUserData() {
		//遍历所有<component>子节点
		foreach (XmlElement component in userDataNodes) {
			//选择标签为level的<component>
			if (component .GetAttribute ("type") == "level") {
				XmlNodeList userLevelNodes = component.ChildNodes;    //获得标签为level的<component>下的子节点
				foreach (XmlElement level in userLevelNodes ) {
					if (level.GetAttribute ("type") == "levelNum")
						this.levelNum = int.Parse (level.InnerText);            //获得章节信息
					else if (level.GetAttribute ("type") == "cow")
						this.isCow = level.InnerText;            //更新隐藏关信息
					else if (level.GetAttribute ("type") == "pearl")
						this.hasPearl = level.InnerText;         //更新特殊道具信息
					else
						this.isCheatOn = level.InnerText;        //获得作弊模式信息
				}
			}
			//选择标签为levelItems的<component>
			else if (component.GetAttribute ("type") == "achievements") {
				XmlNodeList userAchievementNodes = component.ChildNodes;   //获得标签为achievements的<component>下的子节点
				//遍历所有<setting>子节点
				foreach (XmlElement item in userAchievementNodes ) {
					int i = int.Parse (item.InnerText);
					Achievement a = new Achievement (i, true);
					this.achivementList.Add (a);
				}
			}
		}
	}

	//获得用户存档路径
	public string GetUserDataPath() {
		return this.userDataXmlPath;
	}

	//获得用户存档关卡数
	public int GetLevelNum() {
		return this.levelNum;
	}

	//获取用户物品栏
	public List<Achievement> GetAchievement() {
		return this.achivementList;
	}

	public string GetCheat() {
		return this.isCheatOn;
	}

	public string GetCow() {
		return this.isCow;
	}

	public string GetPearl() {
		return this.hasPearl;
	}

	public bool GetIsState2() {
		return this.isState2;
	}

	public void enterState2() {
		this.isState2 = true;
	}

	//解锁作弊模式
	public void activeCheat() {
		this.isCheatOn = "T";
	}

	//解锁隐藏关
	public void activeCow() {
		this.isCow = "T";
	}

	// 解锁隐藏道具
	public void activePearl() {
		this.hasPearl = "T";
	}

	// return the current value of isPause
	public bool getPause() {
		return this.isPaused;
	}

	// when player pause the game
	public void Pause() {
		isPaused = true;
	}

	// when player resumes the game
	public void unPause() {
		isPaused = false;
	}

	/// <summary>
	/// Adds the achievement.
	/// </summary>
	/// <param name="num">Number.</param>
	/// <param name="status">If set to <c>true</c> status.</param>
	public void AddAchievement(int num, bool status) {
		Achievement a = new Achievement (num, status);
		this.achivementList.Add (a);
	}

	//更新用户物品栏和关卡信息
	public void UpdateItemsAndLevelData() {
		//获取退出前的场景信息
		if (SceneManager.GetActiveScene().name != "PreStart")
			SplitLevelName ();
		
		//遍历所有<component>子节点
		foreach (XmlElement component in userDataNodes) {
			//选择标签为setting的<component>
			if (component.GetAttribute ("type") == "level") {
				XmlNodeList userSettingNodes = component.ChildNodes;   //获得标签为level的<component>下的子节点
				//遍历所有<level>子节点
				foreach (XmlElement level in userSettingNodes ) {
					if (level.GetAttribute ("type") == "levelNum")
						level.InnerText = this.levelNum.ToString ();          //更新章节信息
					else if (level.GetAttribute ("type") == "cow")
						level.InnerText = this.isCow;          //更新隐藏关信息
					else if (level.GetAttribute ("type") == "pearl")
						level.InnerText = this.hasPearl;       //更新隐藏道具信息
					else
						level.InnerText = this.isCheatOn;      //更新作弊模式信息
				}
			}
		}

		//删除之前的成就数据
		XmlNode items = userDataNodes.Item (1);
		while (items.HasChildNodes)
			items.RemoveChild (items.FirstChild);
		
		//插入新的成就数据
		for (int i = 0; i < achivementList.Count; i++) {
			XmlElement new_item = userDataXml.CreateElement ("achievement");
			new_item.InnerText = achivementList [i].num.ToString();
			items.AppendChild (new_item);
		}
		//保存更新信息至本地用户存档
		StartCoroutine (saveUserData ());
	}

	//保存用户存档
	IEnumerator saveUserData() {
		//保存xml存档文件
		userDataXml.Save (userDataXmlPath);

		//等待2秒再执行
		yield return new WaitForSeconds (2.0f);

		//如果是Loading页面需要在获取到存档文件之后跳转至下一个页面
		if (SceneManager.GetActiveScene ().name == "Loading") 
			SceneManager.LoadScene ("Start");
	}

	//分割场景名称字符串
	void SplitLevelName() {
		//获取当前场景名称
		string levelName = SceneManager.GetActiveScene ().name;
		//按照-分割
		string[] nameArray = levelName.Split (new char[] { '-' });

		//得到chapter和level的编号
		int currentLevelNum = int.Parse (nameArray [1]);
		if (currentLevelNum > this.levelNum) {
			this.levelNum = int.Parse(nameArray [1]);
		}
	}

	/// <summary>
	/// Clears the user data.
	/// </summary>
	public void clearUserData() {
		// 重制数据
		this.levelNum = 1;
		this.isCheatOn = "F";
		this.isCow = "F";
		this.hasPearl = "F";
		achivementList.Clear ();

		//遍历所有<component>子节点
		foreach (XmlElement component in userDataNodes) {
			//选择标签为setting的<component>
			if (component.GetAttribute ("type") == "level") {
				XmlNodeList userSettingNodes = component.ChildNodes;   //获得标签为level的<component>下的子节点
				//遍历所有<level>子节点
				foreach (XmlElement level in userSettingNodes ) {
					if (level.GetAttribute ("type") == "levelNum")
						level.InnerText = this.levelNum.ToString();        //更新关卡信息
					else if (level.GetAttribute ("type") == "cheat")
						level.InnerText = this.isCheatOn;    //更新作弊模式信息
					else if (level.GetAttribute ("type") == "pearl")
						level.InnerText = this.hasPearl;       //更新隐藏道具信息
					else
						level.InnerText = this.isCow;        //更新隐藏关信息
				}
			}
		}

		//删除之前的物品栏数据
		XmlNode items = userDataNodes.Item (1);
		while (items.HasChildNodes)
			items.RemoveChild (items.FirstChild);

		//保存更新信息至本地用户存档
		StartCoroutine (saveUserData ());
	}
}
