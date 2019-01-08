using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballControl : MonoBehaviour {

	public GameObject explosion;		// Prefab of explosion effect.

	void OnExplode()
	{
		// Create a quaternion 
		Quaternion randomRotation = Quaternion.Euler(new Vector3 (0,0,0));

		// Instantiate the explosion
		Vector3 v = new Vector3 (transform.position.x, transform.position.y - 0.79f, transform.position.z);
		Instantiate(explosion, v, randomRotation);
	}

	void OnTriggerEnter2D (Collider2D col) {
		// If it hits the player...
		if(col.tag == "Player")
		{
			// ... find the PlayerControl script and call the deathByFire function.
			col.gameObject.GetComponent<PlayerControl>().deathByFire();

			// Call the explosion instantiation.
			OnExplode();

			// Destroy the rocket.
			Destroy (gameObject);
		}
		// if it hits the ground
		else if (col.name == "dirt") {
			// Call the explosion instantiation.
			OnExplode();

			// Destroy the fireball.
			Destroy (gameObject);
		}
	}
}
