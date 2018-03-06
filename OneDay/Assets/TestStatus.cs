using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStatus : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Debug.Log ("Hi, I'm " + this.name + " and I'm gonna change the Player status");

		Status playerStatus = GameObject.Find ("Player").GetComponent <Status>();
		Debug.Log ("Player Busy status is: " + playerStatus.getBusy ());
		playerStatus.setBusy (true);
		Debug.Log ("Player Busy status changed to: " + playerStatus.getBusy ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
