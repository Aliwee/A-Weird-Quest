using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level7 : MonoBehaviour {

	public GameObject tabletIcon;     // reference to the tablet icon
	public GameObject exit,summoning,tryAgain;  // reference to the exit panel, summoning
	public string hasCheat;
	public Animator player;
	public BelialControl bc;
	public PlayerControl pc;
	public RectTransform crossCD, saltCD;
	public GameObject salt;

	private Fungus.Flowchart fc;
	private string canCheat;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1f;
		MouseLock.instance.lockMouse ();

		fc = GameObject.Find ("Flowchart").GetComponent<Fungus.Flowchart> ();

		hasCheat = "F";
		canCheat = UserDataManager.instance.GetCheat ();

		// check if player has found tablet
		if (UserDataManager.instance.GetCow () == "T")
			tabletIcon.SetActive (true);
	}

	// Update is called once per frame
	void Update () {
		// if user presses E when standing on the summoning
		if (Input.GetKeyDown(KeyCode.E)) {
			if(exit.activeSelf == false && summoning.activeSelf == true) {
				summoning.SetActive(false);
				fc.ExecuteBlock ("Dialog1");
				player.SetFloat ("Speed", 0f);
				pc.enabled = false;
			}
		}
		// if player press Enter for tryAgain
		else if (Input.GetKeyDown(KeyCode.Return)) {
			if (exit.activeSelf == false && tryAgain.activeSelf == true) {
				Scene s = SceneManager.GetActiveScene ();
				SceneManager.LoadScene (s.name);
			}
		}

		// if player uses salt
		if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)) {
			if (exit.activeSelf == false && bc.canPlayerAttack == true && tryAgain.activeSelf == false && saltCD.localScale.y == 0) {
				// start CD
				saltCD.localScale = new Vector3 (1, 1, 1);

				// player salt attack animation
				player.SetTrigger ("Salt");

				// create a salt
				Instantiate (salt, player.gameObject.transform.position , Quaternion.Euler(new Vector3 (0,0,0)));
			}
		}
		// if player uses cross
		if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)) {
			if (exit.activeSelf == false && bc.canPlayerAttack == true && tryAgain.activeSelf == false && crossCD.localScale.y == 0 && pc.facingRight == true) {
				// start CD
				crossCD.localScale = new Vector3 (1, 1, 1);

				// player salt attack animation
				player.SetTrigger ("Cross");

				// belial gets hurt by cross
				bc.hurtByCross ();
			}
		}
		// if player uses tablet
		if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3)) {
			if (exit.activeSelf == false && bc.canPlayerAttack == true && tryAgain.activeSelf == false && tabletIcon.activeSelf == true && pc.facingRight == true) {

				// start CD
				tabletIcon.SetActive (false);

				// player salt attack animation
				player.SetTrigger ("Tablet");

				// belial gets hurt by cross
				bc.hurtByTablet ();
			}
		}

		// if player wants to active cheat mod
		if (Input.GetKeyDown(KeyCode.Tab)) {
			if (canCheat == "T") {
				hasCheat = "T";
				player.SetTrigger ("Cheat");
			}
		}
	}
}
