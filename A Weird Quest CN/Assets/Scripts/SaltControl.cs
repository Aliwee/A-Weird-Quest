using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltControl : MonoBehaviour {

	public float speed = 1.5f;

	private Rigidbody2D rd;
	private PlayerControl player;

	// Use this for initialization
	void Start () {
		rd = GetComponent<Rigidbody2D> ();
		player = GameObject.Find ("Detective").GetComponent<PlayerControl> ();

		if (player.facingRight == true)
			rd.velocity = new Vector2 (speed, 0);
		else
			rd.velocity = new Vector2 (-speed, 0);

		Destroy (gameObject, 5);
	}
}
