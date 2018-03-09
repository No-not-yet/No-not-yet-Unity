﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WelcomeMsg : MonoBehaviour
{
    public GameObject Inst, welcome, tagObjts, infoBox;
	private Status playerStatus;
    
    float time = 5f;

	// Coroutine for infoBox
	Coroutine typeInfo;
	string finalInfo;
	private Text infoTextField;
	private Text infoCostField;
	private Text[] children;

    void Start()
    {        
		// Set to Busy
		playerStatus = this.GetComponent<Status> ();
		playerStatus.setBusy (true);

		// Get children Texts
		children = this.GetComponentsInChildren<Text>(true);

		// Get text for info
		infoTextField = children[3];
		// Get s4th children Text because it is the cost one
		infoCostField = children [4];

		//Debug.Log("Texto del noteInfo: " + infoTextField.text);
		//Debug.Log("Texto del costInfo: " + infoCostField.text);

		//Disable welcome mssg for dev purposes also inst not invoking
		//welcome.SetActive(false);
		Invoke("Hide", time);
		//showInfo ("Te haz bañado, hueles a popo de todos modos :(");
    }
    void Hide()
    {
        welcome.SetActive(false);
		playerStatus.setBusy (false);
        Inst.SetActive(true);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Inst.SetActive(false);
        }
    }

	public void showInfo(string info, int cost){
		infoBox.SetActive (true);
		this.finalInfo = info;

		if (typeInfo == null) {
			this.infoCostField.text = "-$" + cost;
			typeInfo = StartCoroutine (keyboardTyping());
		}
	}

	public void hideInfo(){
		infoBox.SetActive (false);
		typeInfo = null;
	}

	IEnumerator keyboardTyping(){
			this.infoTextField.text = "";
			foreach (char letter in this.finalInfo.ToCharArray()) {
				yield return new WaitForSeconds (0.02f);
				this.infoTextField.text += letter;
			}
	}

}


        