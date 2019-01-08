using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public GameObject tryAgain;

	private ExitManager ex;

	// Use this for initialization
	void Start () {
		ex = GameObject.Find ("DespensableScripts").GetComponent<ExitManager> ();
	}

	// show the Try Again panel to restart
	public void showTryAgain() {
		tryAgain.SetActive (true);
		ex.pauseForTryAgain ();
	}
}
