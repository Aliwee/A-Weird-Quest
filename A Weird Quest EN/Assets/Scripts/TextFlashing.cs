using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFlashing : MonoBehaviour {

	public float currentTime;    //current game time 当前时间
	public float showTime;       //time to show the image 出现时间
	public float fadeTime;       //time to hide the image 隐藏时间

	private Text tx;             //Text component

	// Use this for initialization
	void Start () {
		tx = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		currentTime += Time.deltaTime;
		currentTime = currentTime % (showTime + fadeTime);

		//When current time is in image-showing time 当前时间在出现时间段
		if (currentTime >= 0 && currentTime < showTime) {
			tx.color = new Color (1, 1, 1, (currentTime / showTime));
		} 
		//When current time is in image-fading time当前时间在隐藏时间段
		else if (currentTime >= showTime && currentTime < showTime+fadeTime) 
		{
			tx.color = new Color (1, 1, 1, 1 - ((currentTime-showTime)/ fadeTime));
		}
		//
		else {
			//do nothing
		}
	}
}
