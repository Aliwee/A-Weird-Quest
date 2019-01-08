using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFireball : MonoBehaviour {

	public GameObject fireball;
	public Transform playerPosition;
	public bool isAttakeActive;

	private int currentTime;
	private static int fireballTime = 5;

	// Use this for initialization
	void Start () {
		isAttakeActive = false;
		currentTime = 0;
		InvokeRepeating ("spawn", 0, 2);
	}
	
	// Update is called once per frame
	void Update () {

		if (currentTime == fireballTime) {
			isAttakeActive = false;
			currentTime = 0;
		}
	}

	void spawn() {
		if (isAttakeActive == true) {
			// generate a fireball
			currentTime++;
			Vector3 v = new Vector3 (playerPosition.position.x, 6.23f, 95);
			Instantiate (fireball, v, transform.rotation);
		}
	}

	public void activeAttack1() {
		isAttakeActive = true;
	}
}
