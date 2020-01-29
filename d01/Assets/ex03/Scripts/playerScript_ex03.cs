using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerScript_ex03 : MonoBehaviour {

	public	float	jumpHeight = 100f;
	public	float	moveSpeed = 2.0f;
	private int 	isFocused = 0;
	private bool	inGoal;
	private int		grounded;

	// Use this for initialization
	void Start () {
		inGoal = false;
		grounded = 0;
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
		if (this.GetComponent<Rigidbody2D> ().velocity.y < -17f)
			this.GetComponent<Rigidbody2D> ().velocity = new Vector2(this.GetComponent<Rigidbody2D> ().velocity.x, -17f);
//		Debug.Log (this.tag + grounded);
		this.GetComponent<Rigidbody2D> ().velocity = new Vector2(0, this.GetComponent<Rigidbody2D>().velocity.y);
		if (isFocused == 1) {
			if (Input.GetKeyDown ("space") && grounded >= 1 && Mathf.Abs(this.GetComponent<Rigidbody2D> ().velocity.y) <= 0.01f)
				this.GetComponent<Rigidbody2D> ().AddForce (Vector3.up * jumpHeight);
			if (Input.GetKey ("right"))
				this.GetComponent<Rigidbody2D> ().AddForce (Vector3.right * moveSpeed);
			if (Input.GetKey ("left"))
				this.GetComponent<Rigidbody2D> ().AddForce (Vector3.left * moveSpeed);
		} 
		else {
			if (grounded >= 1)
				this.GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
			else
				this.GetComponent<Rigidbody2D> ().constraints =  RigidbodyConstraints2D.FreezeRotation;
		}
	}

	void OnCollisionEnter2D(Collision2D collider){
		Debug.Log ("COLLISION");
		if (collider.gameObject.tag == "movingPlatform") {
			this.transform.SetParent (collider.gameObject.transform); 
		}
	}

	void OnCollisionExit2D(Collision2D collider){
		if (collider.gameObject.tag == "movingPlatform")
			transform.parent = null;
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.tag == this.tag + "goal")
			inGoal = true;
		else if (collider.tag == "teleportIn") {
			this.transform.position = collider.GetComponent<teleport> ().exit.transform.position;
		}
		else
			grounded += 1;
	}
		
	void OnTriggerExit2D(Collider2D collider){
		if (collider.tag == this.tag + "goal")
			inGoal = false;
		else if (collider.tag == "teleportIn")
			;
		else
			grounded -= 1;
	}
}
