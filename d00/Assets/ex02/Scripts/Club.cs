using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : MonoBehaviour {

	public GameObject ball;
	private Vector3 lastStart;
	private Vector3 lastBallPos;
	private int launchable = 1;
	// Use this for initialization
	void Start () {
		this.transform.position = ball.transform.position + Vector3.down * 0.1f;
		lastBallPos = ball.transform.position;
		lastStart = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (ball.transform.position != lastBallPos)
			launchable = 0;
		if (launchable == 1)
		{
			if (Input.GetKey ("space") && this.transform.position.y > -8) {
				this.gameObject.transform.Translate (Vector3.down * 0.05f);
			}
		}
		else if (ball.transform.position == lastBallPos) {
			this.transform.position = ball.transform.position + (Vector3.down * 0.1f);
			launchable = 1;
			lastStart = this.transform.position;
		}
		else if (lastStart != this.transform.position) {
			this.transform.Translate ((lastStart - this.transform.position) * 0.4f);
		}
	lastBallPos = ball.transform.position;
	}
}
