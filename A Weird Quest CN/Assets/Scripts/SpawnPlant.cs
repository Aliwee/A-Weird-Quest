using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlant : MonoBehaviour {

	public bool isAttakeActive;
	public GameObject plant;

	private Transform tf;      // where the plant would be spawned

	// Use this for initialization
	void Start () {
		isAttakeActive = false;
		tf = GameObject.Find ("Detective").transform;
	}
	
	// Update is called once per frame
	void Update () {
		// if the Belial start using attake 2
		if (isAttakeActive == true) {
			spawn ();
			isAttakeActive = false;
		}
	}

	void spawn() {
		Vector3 v = new Vector3 (tf.position.x, -2.68f, 95f);
		Instantiate (plant, v, transform.rotation);
	}

	public void activeAttack2() {
		isAttakeActive = true;
	}
}
