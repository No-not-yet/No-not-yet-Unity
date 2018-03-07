using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour {

	// Values that will lock the button
	private bool isWalking = false;
	private bool isBusy = false;
	private float timer;


	// Setters and Getters
	public bool getWalking(){
		return this.isWalking;
	}

	public bool getBusy(){
		return this.isBusy;
	}

	public void setWalking(bool value){
		this.isWalking = value;
	}

	public void setBusy(bool value){
		this.isBusy = value;
	}

	public float getTimer(){
		return this.timer;
	}

	// Use this for initialization
	void Start () {
		// Debug Logs
		/*
		Debug.Log (this.isWalking + " is the default isWalking");
		Debug.Log (this.isBusy + " is the default isBusy");
		*/	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
	}
}
