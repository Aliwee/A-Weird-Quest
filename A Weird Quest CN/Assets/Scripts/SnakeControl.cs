using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class SnakeControl : MonoBehaviour {

	public AudioClip snakeSound;            // reference to the sneak sound
	public Transform mainCamera;            // reference to the main camera
	public Fungus.Flowchart fc;             // reference to the Fungus Flowchart

	private Animator anim;                  // reference to the sneak Animator component

	// Use this for initialization
	void Start () {
		MouseLock.instance.lockMouse ();
		anim = GetComponent<Animator> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			playSneakSound ();
			anim.SetTrigger ("Attack");
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.tag == "Player") {
			anim.SetTrigger ("Idle");
		}
	}

	void playSneakSound() {
		AudioSource.PlayClipAtPoint (snakeSound, mainCamera.position);
		avtiveText ();
	}

	void avtiveText() {
		fc.ExecuteBlock ("Puzzle");
	}
}
