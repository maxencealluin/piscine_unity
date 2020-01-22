using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour {

	private float air;
	private float scale;
	private float bTime;
	private	int	  breath;
	private int   canBreath;
	private float rollingTime;

	void Start () {
		air = 25;
		breath = 20;
		canBreath = 1;
		bTime = Time.time;
		rollingTime = Time.time;
	}

	// Update is called once per frame

	void end () {
		Debug.Log ("Ballon life time: " + Mathf.RoundToInt(Time.time - bTime) + "s");
		GameObject.Destroy (this.gameObject);
	}

	void Update () {
		if (canBreath == 1 && Time.time - rollingTime > 1.0f) {
			rollingTime = Time.time;
			breath += 1;
		} else if (canBreath == 0 && (Time.time - rollingTime > 3.0f)) 
		{
			breath = 15;
			canBreath = 1;
		}
		if (canBreath == 1 && Input.GetKeyDown ("space")) {
			air += 5;
			breath--;
		} else {
			air -= 0.28f;
		}
		if (air <= 0)
			end ();
		if (breath == 0) {
			canBreath = 0;
			rollingTime = Time.time;
			breath = -1;
		}
		if (air > 90)
			end ();
		scale = 0.1f * air;
		transform.localScale = new Vector3(scale, scale, scale);
	}
}
