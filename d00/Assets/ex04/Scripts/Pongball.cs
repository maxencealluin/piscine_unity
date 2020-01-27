using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pongball : MonoBehaviour {

	private int p1_score;
	private int p2_score;
	public GameObject bar_p1;
	public GameObject bar_p2;
	public GameObject bar_up;
	public GameObject bar_down;
	private Vector3 dir;

	// Use this for initialization
	void Start () {
		p1_score = 0;
		p2_score = 0;
		reset_dir ();
	}

	void	reset_dir()
	{
		float y_dir = Random.Range(-1.0f, 1.0f);
		if ((p1_score + p2_score) % 2 == 0)
			if (y_dir > 0f)
				dir = new Vector3 (Random.Range (0.10f, 0.15f), Random.Range (0.10f, 0.15f), 0);
			else
				dir = new Vector3 (Random.Range (0.10f, 0.15f), Random.Range (-0.10f, -0.15f), 0);
		else
			if (y_dir > 0f)
				dir = new Vector3 (Random.Range (-0.10f, -0.15f), Random.Range (0.10f, 0.15f), 0);
			else
				dir = new Vector3 (Random.Range (-0.10f, -0.15f), Random.Range (-0.10f, -0.15f), 0);
		this.transform.Translate (-this.transform.position.x, -this.transform.position.y,0);
	}

	void	print_score()
	{
		Debug.Log ("Player 1: " + p1_score + " | Player 2: " + p2_score);
	}

	// Update is called once per frame
	void Update () {
		this.transform.Translate(dir);
		if (this.transform.position.y > bar_up.transform.position.y - 1.5f ||
		    this.transform.position.y < bar_down.transform.position.y + 1.5f)
			dir = new Vector3(dir.x, -dir.y, dir.z);
		if (this.transform.position.x <= bar_p1.transform.position.x + 0.6f && this.transform.position.y >= bar_p1.transform.position.y - 1.6f && this.transform.position.y <= bar_p1.transform.position.y + 1.6f)
			dir = new Vector3(-dir.x, dir.y, dir.z);
		else if(this.transform.position.x >= bar_p2.transform.position.x - 0.6f  && this.transform.position.y >= bar_p2.transform.position.y - 1.6f && this.transform.position.y <= bar_p2.transform.position.y + 1.6f)
			dir = new Vector3(-dir.x, dir.y, dir.z);
		if (this.transform.position.x > bar_p2.transform.position.x + 0.5) {
			p2_score += 1;
			reset_dir ();
			print_score ();
		}
		else if (this.transform.position.x < bar_p1.transform.position.x - 0.5) {
			p1_score += 1;
			reset_dir ();
			print_score ();
		}
	}
}
