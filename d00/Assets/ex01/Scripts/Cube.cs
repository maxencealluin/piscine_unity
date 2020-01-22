using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour {

	private float speed;
	public string key;

	// Use this for initialization
	void Start () {
		speed = Random.Range (0.04f, 0.1f);
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.down * speed);
		if (Input.GetKeyDown(key)) {
			if (this.transform.position.y >= 0)
				Debug.Log (this.transform.position.y);
			else
				Debug.Log (-this.transform.position.y);
			GameObject.Destroy (this.gameObject);
		}
		else if (transform.position.y < -1)
			GameObject.Destroy (this.gameObject);
	}
}
