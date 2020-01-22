using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour {

	public GameObject	cubeL;
	public GameObject	cubeM;
	public GameObject	cubeR;
	public GameObject	leftLine;
	public GameObject	midLine;
	public GameObject	rightLine;
	private float cTime;
	private float rand;
	private int previous;

	// Use this for initialization
	void Start () {
		cTime = Time.time;
		previous = -1;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > cTime + 0.8f) {
			rand = Random.Range(0.0f, 3.0f);
			if (rand < 1.0 && previous != 1) {
				Instantiate (cubeL, new Vector3 (leftLine.transform.position.x, this.transform.position.y, -0.1f), Quaternion.identity);
				previous = 1;
			} else if (rand > 2.0 && previous != 2) {
				Instantiate (cubeM, new Vector3 (midLine.transform.position.x, this.transform.position.y, -0.1f), Quaternion.identity);
				previous = 2;
			} else if (previous != 3) {
				Instantiate (cubeR, new Vector3 (rightLine.transform.position.x, this.transform.position.y, -0.1f), Quaternion.identity);
				previous = 3;
			} else
				previous = -1;
			cTime = Time.time;
		}
	}
}
