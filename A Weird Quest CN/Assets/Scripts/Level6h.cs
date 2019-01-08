using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level6h : MonoBehaviour {

	public Fungus.Flowchart fc;           // reference to the Fungus Flowchart
	public GameObject tabletImg,tablet;          // reference to the tablet image
	public GameObject nextText, exit;     // referencce to the next level text, exit panel
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.E)) {
			if (exit.activeSelf == false) {
				if (tabletImg.activeSelf == true) {
					tablet.GetComponent<TabletControl> ().enabled = false;
					fc.ExecuteBlock ("Pick");
					UserDataManager.instance.activeCow ();
				}
				else if (nextText.activeSelf == true) {
					fc.ExecuteBlock ("nextLevel");
				}
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name == "NextLevel") {
			nextText.SetActive (true);
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.name == "NextLevel") {
			nextText.SetActive (false);
		}
	}
}
