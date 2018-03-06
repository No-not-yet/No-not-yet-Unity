using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGM : MonoBehaviour {

	// Use this for initialization
	void Start () {

		// Test of GM Manipulation
		Debug.Log ("Hi, I'm: " + this.gameObject.name + " and I'm gonna change the GM");
		Debug.Log("Game Manager has lvl as: " + GameManager.instance.getLevel ());
		GameManager.instance.setLevel (3);
		Debug.Log("Changed to: " + GameManager.instance.getLevel ());
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
