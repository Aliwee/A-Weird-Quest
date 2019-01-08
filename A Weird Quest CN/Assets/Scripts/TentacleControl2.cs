using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleControl2 : MonoBehaviour {

	public Fungus.Flowchart fc;         // reference to the Fungus FLowchart
	public DetectiveBoatControl player;         // reference to the player Animator component
	public GameObject eye;              // reference to the eye gameobject

	private int stayTime = 0;               // the total time the player has stayed on 

	// Update is called once per frame
	void Update () {
		if (stayTime == 30) {
			CancelInvoke ();
			player.enabled = false;
			fc.ExecuteBlock ("hiddenLevel");
			stayTime = 0;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			Camera.main.GetComponent<CameraScroll> ().enabled = false;
			eye.SetActive (true);
			InvokeRepeating ("countTime", 1f, 1f);
		}
	}

	void countTime() {
		stayTime++;
	}

	void OnTriggerExit2D(Collider2D other) {
		stayTime = 0;
		eye.SetActive (false);
		CancelInvoke ();
		Camera.main.GetComponent<CameraScroll> ().enabled = true;
	}
}
