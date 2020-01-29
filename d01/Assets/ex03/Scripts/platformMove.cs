using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMove : MonoBehaviour {


	public float distLeft = 0;
	public float distRight = 0;
	public float movespeed = 2.0f;
	private Vector3 initialPos;
	private Vector3 leftPos;
	private Vector3 rightPos;
	public int dir = 1;

	// Use this for initialization
	void Start () {
		initialPos = this.transform.position;
		leftPos = new Vector3 (initialPos.x - distLeft, initialPos.y, initialPos.z);
		rightPos = new Vector3 (initialPos.x + distRight, initialPos.y, initialPos.z);
	}
	
	// Update is called once per frame
	void Update () {
//		this.GetComponent<Rigidbody2D> ().velocity = new Vector2(0, this.GetComponent<Rigidbody2D>().velocity.y);
		if (dir == 1) {
			this.transform.Translate (Vector3.right * movespeed);
//			this.GetComponent<Rigidbody2D> ().MovePosition (this.transform.position + Vector3.right * movespeed);

		} else {
//			this.GetComponent<Rigidbody2D> ().MovePosition (this.transform.position + Vector3.left * movespeed);
			this.transform.Translate (Vector3.left * movespeed);
		}
		if (this.transform.position.x >= rightPos.x)
			dir = -1;
		else if (this.transform.position.x <= leftPos.x)
			dir = 1;
	}
}
