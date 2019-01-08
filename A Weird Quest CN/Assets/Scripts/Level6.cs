using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level6 : MonoBehaviour {

	public GameObject exit, tryAgain;   // reference to the exit, tryAgain panel
	
	// Update is called once per frame
	void Update () {
		// if player wants to try again, reload the scene
		if (Input.GetKeyDown(KeyCode.Return)) {
			if (exit.activeSelf == false && tryAgain.activeSelf == true) {
				Scene s = SceneManager.GetActiveScene ();
				SceneManager.LoadScene (s.name);
			}
		}
	}
}
