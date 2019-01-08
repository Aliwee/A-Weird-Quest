using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CDTime : MonoBehaviour {

	public float time;

	private Vector3 itemScale;
	private RectTransform rt;

	// Use this for initialization
	void Start () {
		rt = GetComponent<RectTransform> ();
		InvokeRepeating ("updateBar", 1f, time);
	}

	void updateBar() {
		// get scale
		itemScale = rt.localScale;

		// if scale y > 0, we need to decrease it once in a while
		if (itemScale.y > 0) {
			rt.localScale = new Vector3 (1, itemScale.y - 0.1f, 1);
		}
		else {
			rt.localScale = new Vector3 (1, 0, 1);
		}
	}
}
