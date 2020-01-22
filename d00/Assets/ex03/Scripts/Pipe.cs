using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour {

	public float initialSpeed = 5f;
	[HideInInspector]
	public int canMove = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (canMove == 1) {
			this.transform.Translate (Vector3.left * initialSpeed * 0.01f);
			if (this.transform.position.x < -4) {
				this.transform.Translate (Vector3.right * 12);
			}
			if (initialSpeed < 100f)
				initialSpeed += 0.01f;
		}
	}
}
