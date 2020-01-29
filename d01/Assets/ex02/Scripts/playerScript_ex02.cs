using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerScript_ex02 : MonoBehaviour {

	public	float	jumpHeight = 100f;
	public	float	moveSpeed = 2.0f;
	private int 	isFocused = 0;
	private bool	inGoal;
	private bool	grounded;

	// Use this for initialization
	void Start () {
		inGoal = false;
		grounded = true;
	}

	public bool isOk()
	{
		return inGoal;
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
		this.GetComponent<Rigidbody2D> ().velocity = new Vector2(0, this.GetComponent<Rigidbody2D>().velocity.y);
		if (isFocused == 1) {
			if (Input.GetKeyDown ("space") && grounded && Mathf.Abs(this.GetComponent<Rigidbody2D> ().velocity.y) <= 0.01f)
				this.GetComponent<Rigidbody2D> ().AddForce (Vector3.up * jumpHeight);
			if (Input.GetKey ("right"))
				this.GetComponent<Rigidbody2D> ().AddForce (Vector3.right * moveSpeed);
			if (Input.GetKey ("left"))
				this.GetComponent<Rigidbody2D> ().AddForce (Vector3.left * moveSpeed);
		} 
		else {
			if (grounded)
				this.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
			else
				this.GetComponent<Rigidbody2D> ().constraints =  RigidbodyConstraints2D.FreezeRotation;
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == this.tag + "goal")
			inGoal = true;
		else
			grounded = true;
	}


	void OnTriggerStay2D(Collider2D collider){
		if (collider.tag == this.tag + "goal")
			inGoal = true;
		else
			grounded = true;
	}

	void OnTriggerExit2D(Collider2D collider){
		if (collider.tag == this.tag + "goal")
			inGoal = false;
		else
			grounded = false;
	}
}
