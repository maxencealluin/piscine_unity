 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public GameObject	hole;
	private float 		speed;
	private int 		launched;
	private int 		score;

	// Use this for initialization
	void Start () {
		launched = 0;
		speed = 5f;
		score = -15;
	}
	// Update is called once per frame
	void Update () {
		if (launched == 0 && Input.GetKey ("space")) {
			if (speed < 90)
				speed *= 1.07f;
		} else if (launched == 0 && speed != 5f) {
			launched = 1;
			score += 5;
			if (score == 0)
				Debug.Log("You lost but the game continues.");
		}
		else if (launched == 1) {
			if (speed > -0.05 && speed < 0.05)
				speed = 0;
			if ((this.transform.position.y - hole.transform.position.y) < 0.15
				&& (this.transform.position.y - hole.transform.position.y > -0.15) && speed < 5 && speed > -5) {
				this.transform.Translate(new Vector3 (100,100, 0));
				Debug.Log("Game finished");
				launched = -1;
			}
			if (this.transform.position.y < -7) {
				this.transform.Translate(0, -6.9f - this.transform.position.y, 0);
				speed *= -1;
			}
			else if (this.transform.position.y > 2) {
				this.transform.Translate(0, 1.9f - this.transform.position.y, 0);
				speed *= -1;
			}
			if (speed != 0) {
				this.transform.Translate (Vector3.up * speed * 0.01f);
				speed *= 0.96f;
			} else {
				launched = 0;
				speed = 5;
			}
			Debug.Log("Score: " + score);
		}
	}
}
