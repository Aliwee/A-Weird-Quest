using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLock : MonoBehaviour {

	public static MouseLock instance = null;          // an MouseLock instance

	// Use this for initialization
	void Awake () {
		//判断是否已有一个实例
		if (instance == null)
			instance = this;   //如果没有，那么设置实例为该实例
		else if (instance != this)
			Destroy (gameObject);    //保证只能有一个实例

		//设置为重新加载场景时不被销毁
		DontDestroyOnLoad(gameObject);
	}

	public void lockMouse() {
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	public void unlockMouse() {
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}
}
