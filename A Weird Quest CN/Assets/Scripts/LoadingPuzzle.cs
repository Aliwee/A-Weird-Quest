using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fungus;

public class LoadingPuzzle : MonoBehaviour {

	public Button ratio;                      //ratio button
	public Fungus.Flowchart fc;               //fungus flowchart

	private int ratioNum = 99;                //initial ratio value
	private Text t;                           //Text component in ratio button
	private bool isPuzzleSolved = false;      //if the puzzle is solved

	void Start() {
		t = ratio.transform.Find("Text").GetComponent<Text> ();
		ratio.onClick.AddListener (ClickIncreasing);
		InvokeRepeating ("Puzzle", 5f, 0.5f);
	}
	
	// puzzle
	void Puzzle () {
		if (ratio.gameObject.activeSelf == true && !isPuzzleSolved) {
			if (ratioNum == 0)           // prevent the ratio value less than 0
				t.text = ratioNum + "%";
			else if (ratioNum > 100) {   // puzzle solved, ready to next level
				t.text = "100%";
				isPuzzleSolved = true;
				fc.ExecuteBlock ("NextLevel");
				CancelInvoke ();
			}
			else {                       //automatically reduce the ratio value
				ratioNum --;
				t.text = ratioNum + "%";
			}				
		}
	}

	// click is called every time player hits the ratio button
	void ClickIncreasing() {
		ratioNum += 10 ;
	}

	void quit() {
		CancelInvoke ();
		Application.Quit ();
	}

}
