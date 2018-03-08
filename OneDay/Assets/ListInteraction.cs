﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListInteraction : MonoBehaviour {

	public string nameToDo;
	public int costToDo = 100;
	public string infoToDo = "leurem ipsum";

	public int indexToDo;
	private ToDo myself;

	// Use this for initialization
	void Start () {
		nameToDo = this.name;
		myself = new ToDo (nameToDo, false, costToDo, infoToDo);
		GameManager.instance.toDos.Add(this.myself);

		indexToDo = GameManager.instance.toDos.Count - 1;
		//Debug.Log ("The IndexOf " + nameToDo + " is: " + indexToDo);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setToUsed(){
		GameManager.instance.setToDos (this.indexToDo, true);
	}

	public bool alreadyUsed(){
		return GameManager.instance.getIfUsed (this.indexToDo);
	}

	public int getCost(){
		return this.costToDo;
	}
}
