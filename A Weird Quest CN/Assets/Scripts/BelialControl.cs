using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BelialControl : MonoBehaviour {

	public RectTransform health;
	public AudioClip[] roars;
	public bool canPlayerAttack;
	public Fungus.Flowchart fc;

	private int healthValue = 100;
	private float attackDelay = 10f;
	private Animator anim;
	private bool stopAttack;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		stopAttack = false;
		GameObject.Find ("Detective").GetComponent<PlayerControl> ().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		// if the Belial is dead
		if (healthValue == 0) {
			canPlayerAttack = true;
			CancelInvoke ();
			anim.SetTrigger ("Death");
			fc.ExecuteBlock ("BelialDeath");
			UserDataManager.instance.activeCheat ();
			healthValue = -1;
		}
	}

	// start attack
	void startAttack() {
		stopAttack = false;
	}

	public void initailAttack() {
		InvokeRepeating ("attack", 0, attackDelay);
		canPlayerAttack = true;
	}

	void attack() {
		if (stopAttack == false) {
			int attackIndex = 0;   // 0 for attake 1, 1 for attake 2, and 2 for attake 3

			if (healthValue >= 90)
				attackIndex = 0;
			else if (healthValue >= 70 && healthValue < 90)
				attackIndex = Random.Range (0, 2);
			else if (healthValue < 70)
				attackIndex = Random.Range (0, 3);

			chooseAttack (attackIndex);
		}
	}

	void chooseAttack(int i) {
		switch(i) {
		case 0:    // fireball attack
			anim.SetTrigger ("Attack1");
			//sf.isAttakeActive = true;
			break;
		case 1:    // plant attack
			anim.SetTrigger ("Attack2");
			//sp.isAttakeActive = true;
			break;
		case 2:
			anim.SetTrigger ("Attack3");
			//sb.isAttackActive = true;
			break;
		}
	}

	// when Belial is hurt by cross
	public void hurtByCross() {
		// cancel attack
		stopAttack = true;

		// decrease health value of Belial
		healthValue -= 10;
		if (healthValue < 0)
			healthValue = 0;

		// set anim
		anim.SetTrigger ("Hurt");

		// change health bar
		float newHealthF = healthValue;
		float newHealth = newHealthF / 100f;
		health.localScale = new Vector3 (newHealth, 1, 1);
	}

	// when Belial is hurt by tablet
	public void hurtByTablet() {
		// cancel attack
		stopAttack = true;

		// decrease health value of Belial
		healthValue -= 50;
		if (healthValue < 0)
			healthValue = 0;

		// set anim
		anim.SetTrigger ("Hurt");

		float newHealthF = healthValue;
		float newHealth = newHealthF / 100f;
		health.localScale = new Vector3 (newHealth, 1, 1);
	}

	// play fireball attack sound
	void playRoar1() {
		AudioSource.PlayClipAtPoint (roars [0], Camera.main.transform.position);
	}

	// play plant attack sound
	void playRoar2() {
		AudioSource.PlayClipAtPoint (roars [1], Camera.main.transform.position);
	}

	// play bones attack sound
	void playRoar3() {
		AudioSource.PlayClipAtPoint (roars [2], Camera.main.transform.position);
	}

	// play death sound
	void playRoar4() {
		canPlayerAttack = false;
		AudioSource.PlayClipAtPoint (roars [3], Camera.main.transform.position);
	}
}
