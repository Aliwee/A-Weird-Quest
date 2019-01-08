using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level62 : MonoBehaviour {

	public Fungus.Flowchart fc;   // reference to the Fungus Flowchart
	public GameObject doorE, nextE, exit, tryAgain;   // reference to the door E icon, nextLevel E icon, exit panel
	public GameObject demonName;    // reference to the name item

	// Use this for initialization
	void Start () {
		MouseLock.instance.lockMouse ();
		checkCow ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E)) {
			if (exit.activeSelf == false) {  // make sure player dosen't active exit panel
				if (doorE.activeSelf == true) {    // if player enters door collider
					fc.ExecuteBlock ("Dialog");
				}
				else if (nextE.activeSelf == true) {   // if player enters nextLevel collider
					fc.ExecuteBlock ("nextLevel");
				}
			}
		}
		else if (Input.GetKeyDown(KeyCode.Return)) {   // if player wants to reload
			if (exit.activeSelf == false && tryAgain.activeSelf == true) {
				Scene s = SceneManager.GetActiveScene ();
				SceneManager.LoadScene (s.name);
			}
		}
	}

	void checkCow() {
		string isCow = UserDataManager.instance.GetCow ();
		if (isCow == "F") {   // player hasn't unlock hidden layer
			fc.ExecuteBlock ("Fade");
		}
		else {
			demonName.SetActive (true);
			fc.ExecuteBlock ("openDoor");
		}
	}

	public void unlockCamera() {
		Camera.main.GetComponent<CamerFollow> ().enabled = true;
	}
}
