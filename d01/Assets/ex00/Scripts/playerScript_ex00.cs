using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript_ex00 : MonoBehaviour {

	public	float	jumpHeight = 100f;
	private int 	isFocused = 0;

	// Use this for initialization
	void Start () {
		
	}

	public void	Focus()
	{
		isFocused = 1;
		this.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
	}

	public void	Unfocus()
	{
		isFocused = 0;
		this.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
	}
	
	// Update is called once per frame
	void Update () {
		if (isFocused == 1) {
			if (Input.GetKeyDown ("space"))
				this.GetComponent<Rigidbody2D> ().AddForce (Vector3.up * jumpHeight);
			if (Input.GetKey ("right"))
				this.GetComponent<Rigidbody2D> ().velocity = new Vector2(2.0f, this.GetComponent<Rigidbody2D>().velocity.y);
//				this.GetComponent<Rigidbody2D> ().AddForce (Vector3.right * 10.0f);
			if (Input.GetKey ("left"))
				this.GetComponent<Rigidbody2D> ().velocity = new Vector2(-2.0f, this.GetComponent<Rigidbody2D>().velocity.y);
		} else {
			if (this.GetComponent<Rigidbody2D> ().velocity.y == 0f)
				this.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
		}
	}
}
