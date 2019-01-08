using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitManager : MonoBehaviour {

	public GameObject exit;                // reference to the Exit panel
	public GameObject[] animationsSource;  // reference to all the game object that have Animation component
	public GameObject[] rigidbodySource;   // reference to all the game object that have Rigibody2D component

	private List<Animator> animators;      // animators in animationsSource
	private List<Rigidbody2D> rbs;         // rigidbody component of player

	// initialization
	void Start() {
		animators = new List<Animator> ();
		rbs = new List<Rigidbody2D> ();

		foreach (GameObject go in animationsSource)
			animators.Add (go.GetComponent<Animator> ());
		
		foreach (GameObject go in rigidbodySource)
			rbs.Add (go.GetComponent<Rigidbody2D> ());
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {             // if player press Escape
			if (exit.activeSelf == false)
				Pause ();
			else
				Resume ();
		}
		else if (Input.GetKeyDown(KeyCode.Return)) {         // if player quit
			if (exit.activeSelf == true) {
				// return to normal time scale
				Time.timeScale = 1f;

				if (SceneManager.GetActiveScene().name == "PreStart") {
					// quit the game
					Application.Quit ();

				} else {
					// save data
					UserDataManager.instance.UpdateItemsAndLevelData ();

					// load Loading scene
					SceneManager.LoadScene ("Loading");
				}
			}
		}
	}

	// pause the game
	void Pause() {
		// change player state
		UserDataManager.instance.Pause ();

		// lock screen
		exit.SetActive (!exit.activeSelf);

		// pause all animations
		foreach (Animator anim in animators)
			anim.enabled = false;

		// pause the player
		foreach (Rigidbody2D rb in rbs)
			rb.constraints = RigidbodyConstraints2D.FreezeAll;

		// pause the time scale
		Time.timeScale = 0f;
	}

	// resume
	void Resume() {
		// change player state
		UserDataManager.instance.unPause ();

		// unlock screen
		exit.SetActive (!exit.activeSelf);

		// resume all animations
		foreach (Animator anim in animators)
			anim.enabled = true;

		// resume the player
		foreach (Rigidbody2D rb in rbs)
			rb.constraints = RigidbodyConstraints2D.FreezeRotation;

		// pause the time scale
		Time.timeScale = 1f;
	}

	public void pauseForTryAgain() {
		// pause all animations
		foreach (Animator anim in animators)
			anim.enabled = false;

		// pause the player
		foreach (Rigidbody2D rb in rbs)
			rb.constraints = RigidbodyConstraints2D.FreezeAll;

		// pause the time scale
		Time.timeScale = 0f;
	}
}
