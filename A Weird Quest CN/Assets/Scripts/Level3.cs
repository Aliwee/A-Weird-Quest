using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Level3 : MonoBehaviour {

	public GameObject axE, treeE;           // reference to the ax and tree E icon
	public GameObject axIcon, nextLevelIcon;// reference to the ax icon
	public Fungus.Flowchart fc;             // reference to the Fungus Flowchart
	public AudioClip cutTreeSound;          // reference to the tree cutting sound
	public Transform mainCamera;            // reference to the main camera

	private Animator anim;                  // reference to the player Animator component
	private int cutTimes = 0;               // how many times the player cut the tree

	// Use this for initialization
	void Start () {
		MouseLock.instance.lockMouse ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E)) {
			if (axE.activeSelf == true) {
				// pick up the ax
				pickAx ();
			}

			if (treeE.activeSelf == true) {
				// cut the tree
				cutTree ();
			} 

			if (nextLevelIcon.activeSelf == true) {
				// go the level 4
				fc.ExecuteBlock ("nextLevel");
			}
		}
	}

	void pickAx() {
		// set the ax to invisible so the player won't see it
		axE.SetActive (false);
		axE.transform.parent.gameObject.SetActive (false);
		axIcon.SetActive (true);
	}

	void cutTree() {
		// play anim
		anim.SetTrigger ("CutTree");

		// add a cut time
		cutTimes++;

		// check if the tree needs to be cut down
		if (cutTimes > 4) {
			treeE.SetActive (false);
			fc.ExecuteBlock ("treeDown");
		}
	}

	void playCutTreeSound() {
		AudioSource.PlayClipAtPoint (cutTreeSound, mainCamera.position);
	}
}
