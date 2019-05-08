using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCanvas : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("hideCanvas", 3.5f);
	}

	void hideCanvas() {
		gameObject.SetActive (false);
	}

}
