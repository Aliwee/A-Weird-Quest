using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour {

	public bool facingRight = true;	        // For determining which way the player is currently facing.

	public float moveForce;			        // Amount of force added to move the player left and right.
	public float maxSpeed;				    // The fastest the player can travel in the x axis.

	private Animator anim;					// Reference to the player's animator component.
	private Level7 l7;                      // reference to the Level 7 component
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();

		if (SceneManager.GetActiveScene ().name == "Level-7")
			l7 = GameObject.Find ("DespensableScripts").GetComponent<Level7> ();
	}
	
	// FixedUpdate is called once per frame
	void FixedUpdate () {
		// Cache the horizontal input.
		float h = Input.GetAxis("Horizontal");

		// The Speed animator parameter is set to the absolute value of the horizontal input.
		anim.SetFloat("Speed", Mathf.Abs(h));

		// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
		if(h * GetComponent<Rigidbody2D>().velocity.x < maxSpeed)
			// ... add a force to the player.
			GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * moveForce);

		// If the player's horizontal velocity is greater than the maxSpeed...
		if(Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > maxSpeed)
			// ... set the player's velocity to the maxSpeed in the x axis.
			GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

		// If the input is moving the player right and the player is facing left...
		if(h > 0 && !facingRight)
			// ... flip the player.
			Flip();
		// Otherwise if the input is moving the player left and the player is facing right...
		else if(h < 0 && facingRight)
			// ... flip the player.
			Flip();
	}

	public void Flip ()
	{
		// Switch the way the player is labelled as facing.
		facingRight = !facingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}


	// when player is killed by fireball
	public void deathByFire() {
		if (l7.hasCheat == "F")
			anim.SetTrigger ("Fire");
	}

	// when player is killed by plants
	public void deathByPlant() {
		if (l7.hasCheat == "F")
			anim.SetTrigger("Plant");
	}

	// when player is killed by bones
	public void deathByBones() {
		if (l7.hasCheat == "F")
			anim.SetTrigger ("Bones");
	}
}
