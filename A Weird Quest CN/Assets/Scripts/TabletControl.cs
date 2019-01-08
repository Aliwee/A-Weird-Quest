using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TabletControl : MonoBehaviour {

	public GameObject tabletImg;    // reference to the tablet image
	public Sprite img;              // reference to the sprite source of tablet when player has killed the demon at least once

	void Start() {
		// if it's level 7, table img should be dealt with
		if (SceneManager.GetActiveScene ().name == "Level-7") {
			string isCheat = UserDataManager.instance.GetCheat();
			if (isCheat == "T")
				tabletImg.GetComponent<Image> ().sprite = img;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			tabletImg.SetActive (true);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			tabletImg.SetActive (false);
		}
	}
}
