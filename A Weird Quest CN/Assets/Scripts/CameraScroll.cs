using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour {

	public float zoomSpeed = 2.0f;
	public float smoothSpeed = 2.0f;
	public float minOrtho = 3.0f;
	public float maxOrtho = 5.0f;
	public float minY = 0;
	public float maxY = 3.0f;

	private float targetOrtho;
	private float targetY;

	// Use this for initialization
	void Start () {
		targetOrtho = Camera.main.orthographicSize;
		targetY = transform.position.y;
	}
	
	// FixedUpdate is called once per frame
	void Update () {
		// if the player holds D, zoom out the camera
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
			zoomOut ();
		}
		else {  
			zoomIn ();
		}
	}

	// zoom in
	void zoomIn() {
		// position
		targetY = Mathf.MoveTowards (transform.position.y, maxY, smoothSpeed * Time.deltaTime);
		transform.position = new Vector3 (transform.position.x, targetY, transform.position.z);

		// ortho
		targetOrtho -= zoomSpeed;
		targetOrtho = Mathf.Clamp (targetOrtho, minOrtho, maxOrtho);
		Camera.main.orthographicSize = Mathf.MoveTowards (Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);
	}

	// zoom out
	void zoomOut() {
		// position
		targetY = Mathf.MoveTowards (transform.position.y, minY, smoothSpeed * Time.deltaTime);
		transform.position = new Vector3 (transform.position.x, targetY, transform.position.z);

		// ortho
		targetOrtho += zoomSpeed;
		targetOrtho = Mathf.Clamp (targetOrtho, minOrtho, maxOrtho);
		Camera.main.orthographicSize = Mathf.MoveTowards (Camera.main.orthographicSize, targetOrtho, smoothSpeed * Time.deltaTime);
	}
}
