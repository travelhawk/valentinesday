using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterToQuit : MonoBehaviour {

	public GameObject text;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
	}

	public void showQuitMessage() {
		text.SetActive (true);
	}
}
