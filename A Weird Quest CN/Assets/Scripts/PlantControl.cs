using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantControl : MonoBehaviour {

	private PlayerControl player;
	private Animator playerAni;
	private bool isTrapped;
	private int force,time;
	private static int minForce = 30;
	private static int maxTrapTime = 8;
	private BelialControl bc;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Detective").GetComponent<PlayerControl> ();
		bc = GameObject.Find ("Belial").GetComponent<BelialControl> ();
		playerAni = GameObject.Find ("Detective").GetComponent<Animator> ();
		isTrapped = true;
		force = 0;
		time = 0;
		InvokeRepeating ("checkForce", 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
		// check if player reaches the min break away force
		if (isTrapped == true) {
			playerAni.SetFloat ("Speed", 0f);
			player.enabled = false;
		} else {
			CancelInvoke ();
			player.enabled = true;
			Destroy (gameObject);
		}

		// every time player presses A or D, the force increases
		if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)|| Input.GetKeyDown(KeyCode.D)) {
			force += 2;
		}

		// if player has killed the Belial
		bool needDestroy = bc.canPlayerAttack;
		if (needDestroy == false) {
			player.enabled = true;
			Destroy (gameObject);
		}
	}

	void checkForce() {
		force--;
		time++;
		// check if player reaches the min break away force
		if (force >= minForce)
			isTrapped = false;
		else {
			if (time == maxTrapTime) {
				player.deathByPlant ();
				CancelInvoke ();
				player.enabled = true;
				Destroy (gameObject);
			}
		}
	}
}
