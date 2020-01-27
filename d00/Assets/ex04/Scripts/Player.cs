using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public string key_up;
	public string key_down;
	public GameObject bar_up;
	public GameObject bar_down;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (key_up) && Input.GetKey (key_down))
			;
		else if (Input.GetKey (key_up)) {
			if (this.transform.position.y < bar_up.transform.position.y - 1.6f)
				this.transform.Translate(Vector3.up * 0.1f);
		}
		else if (Input.GetKey(key_down))
		if (this.transform.position.y > bar_down.transform.position.y + 1.6f)
			this.transform.Translate(Vector3.down * 0.1f);
	}
}
