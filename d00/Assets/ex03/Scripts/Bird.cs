using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

	private int lost;
	private int score;
	private int pipe1Earn;
	private int pipe2Earn;
	private float initialTime;
	public Pipe pipe1Script;
	public Pipe pipe2Script;
	public GameObject pipe1;
	public GameObject pipe2;


	// Use this for initialization
	void Start () {
		lost = 0;
		score = 0;
		initialTime = Time.time;
	}

	bool check_pipe(GameObject pipe)
	{
		float borneUp;
		float borneDown;
	
		if (pipe.transform.position.x < 1.2f && pipe.transform.position.x > -1.2f) {
			borneUp = pipe.transform.position.y + 1.40f;
			borneDown = pipe.transform.position.y - 1.85f;
			if (this.transform.position.y >= borneUp || this.transform.position.y <= borneDown)
				return true;
		}
		return false;
	}

	bool check_collision()
	{
		if (pipe1.transform.position.x > 5)
			pipe1Earn = 1;
		else if (pipe1Earn == 1 && pipe1.transform.position.x < -2) {
			pipe1Earn = 0;
			score += 5;
		}
		if (pipe2.transform.position.x > 5)
			pipe2Earn = 1;
		else if (pipe2Earn == 1 && pipe2.transform.position.x < -2) {
			pipe2Earn = 0;
			score += 5;
		}
		if (this.transform.position.y < -0.4)
			return true;
		if (check_pipe (pipe1) == true || check_pipe (pipe2) == true)
			return true;
		return false;
	}
	// Update is called once per frame
	void Update () {
		if (lost == 0 && check_collision () == true) {
			lost = 1;
			pipe1Script.canMove = 0;
			pipe2Script.canMove = 0;
			Debug.Log ("Score: " + score);
			Debug.Log ("Time: " + Mathf.RoundToInt(Time.time - initialTime) + "s");
		}
		if (lost == 0) {
			if (Input.GetKeyDown ("space")) {
				if (this.transform.position.y + 0.6f < 5.2f)
					this.transform.Translate (Vector3.up * 0.9f);
			} else
				this.transform.Translate (Vector3.down * 0.05f);
		}
	}
}
