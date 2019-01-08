using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonesControl : MonoBehaviour {

	public float speed = 1.5f;

	private Rigidbody2D rd;
	private Animator anim;
	private bool canAttack;
	private BelialControl bc;

	// Use this for initialization
	void Start () {
		rd = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		canAttack = true;
		bc = GameObject.Find ("Belial").GetComponent<BelialControl> ();
		Destroy (gameObject,10f);
	}

	// Update is called once per frame
	void Update() {
		// if player has killed the Belial
		bool needDestroy = bc.canPlayerAttack;
		if (needDestroy == false)
			Destroy (gameObject);
	}

	void moving() {
		rd.velocity = new Vector2 (-speed, 0);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player" && canAttack == true) {
			anim.SetTrigger ("Attack");
			other.gameObject.GetComponent<PlayerControl> ().deathByBones ();
		}
		else if (other.gameObject.tag == "Salt") {
			anim.SetTrigger("Dead");
			canAttack = false;
		}
	} 
}
