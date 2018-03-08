using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Instance public in order to be used by any script
	public static GameManager instance = null;

	// Value that change the room
	private int level = 2;

	// 2nd way
	public List<ToDo> toDos;

	// Make sure it is a singleton 
	void Awake(){
		if (instance == null)
			instance = this;
		else if (instance != null)
			Destroy (gameObject);
		DontDestroyOnLoad (gameObject);

		toDos = new List<ToDo>();
	}

	// Use this for initialization
	void Start(){
		// Debug Logs
		//Debug.Log (this.level + " is the default lvl");
		//toDos.Clear ();

	}

	public int getLevel(){
		return this.level;
	}

	public void setLevel(int value){
		this.level = value;
	}


	public void printListToDo(){
		// Print List
		Debug.Log("I am Printing the boolean list!");
		int count = 0;
		foreach (ToDo aDo in toDos) {
			print (count + " " + aDo.todo + " used: " + aDo.done + " cost: " + aDo.cost + " info: " + aDo.info);
			count++;
		}
	}

	public void setToDos(int index, bool value){
		if (index >= 0 && index < toDos.Count)
			toDos [index].done = value;
		else
			Debug.Log ("The index to change is out of range");
	}

}
