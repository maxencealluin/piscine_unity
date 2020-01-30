﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class camera_follow_04 : MonoBehaviour {

	private GameObject red;
	private GameObject yellow;
	private GameObject blue;
	private int	focus = 1;

	void Start () {
		red = GameObject.FindGameObjectWithTag ("red");
		yellow = GameObject.FindGameObjectWithTag("yellow");
		blue = GameObject.FindGameObjectWithTag("blue");
		red.GetComponent<playerScript_ex04>().Focus();
		yellow.GetComponent<playerScript_ex04>().Unfocus();
		blue.GetComponent<playerScript_ex04>().Unfocus();
	}

	void takePos(GameObject obj)
	{
		this.transform.position = new Vector3(obj.transform.position.x + 0.5f, obj.transform.position.y, this.transform.position.z);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("1")) {
			focus = 1;
			red.GetComponent<playerScript_ex04>().Focus();
			yellow.GetComponent<playerScript_ex04>().Unfocus();
			blue.GetComponent<playerScript_ex04>().Unfocus();
		}
		else if (Input.GetKeyDown ("2")) {
			focus = 2;
			red.GetComponent<playerScript_ex04>().Unfocus();
			yellow.GetComponent<playerScript_ex04>().Focus();
			blue.GetComponent<playerScript_ex04>().Unfocus();
		}
		else if (Input.GetKeyDown ("3")) {
			focus = 3;
			red.GetComponent<playerScript_ex04>().Unfocus();
			yellow.GetComponent<playerScript_ex04>().Unfocus();
			blue.GetComponent<playerScript_ex04>().Focus();

		}
		else if (Input.GetKeyDown ("r")) {
			SceneManager.LoadScene (2);

		}
		if (focus == 1)
			takePos (red);
		else if (focus == 2)
			takePos (yellow);
		else
			takePos (blue);

		if (red.GetComponent<playerScript_ex04> ().isOk () && blue.GetComponent<playerScript_ex04> ().isOk () && yellow.GetComponent<playerScript_ex04> ().isOk ()) {
			Debug.Log ("Congratulations ! You won !");
			SceneManager.LoadScene (1);
		}
	}

}