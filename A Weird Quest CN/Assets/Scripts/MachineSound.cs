using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineSound : MonoBehaviour {

	public Transform mainCamera;     // reference to the main camera
	public AudioClip normal,jetpot;   // reference to the tree cutting sound
	
	void playNormalSound() {
		AudioSource.PlayClipAtPoint (normal, mainCamera.position);
	}

	void playJetSound() {
		AudioSource.PlayClipAtPoint (jetpot, mainCamera.position);
	}
}
