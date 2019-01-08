using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBones : MonoBehaviour {

	public GameObject bones;
	public bool isAttackActive;

	private int currentTime;
	private static int bonesTime = 4;

	// Use this for initialization
	void Start () {
		isAttackActive = false;
		currentTime = 0;
		InvokeRepeating ("spawn", 0, 2);
	}
	
	// Update is called once per frame
	void Update () {

		if (currentTime == bonesTime) {
			isAttackActive = false;
			currentTime = 0;
		}
	}

	void spawn() {
		if (isAttackActive == true) {
			// generate a random fireball
			currentTime++;
			Vector3 v = new Vector3 (0.48f, -2.84f, 95f);
			Instantiate (bones, v , Quaternion.Euler(new Vector3 (0,0,0)));
		}
	}

	public void activeAttack3() {
		isAttackActive = true;
	}
}
