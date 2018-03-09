using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Instance public in order to be used by any script
	public static GameManager instance = null;

	// Value that change the room
	private int level = 1;
	public bool cLevel = false;

	public int firstGoal = 3;
	public int minIndex;

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


	// Check if completed
	public bool completedLevel(){

		if (cLevel)
			return cLevel;

		switch (level) {
		case 1:
			Debug.Log ("Checking for lvl 1 completeness");

			if (countToDos()) {
				this.cLevel = true;
			}

			break;
		case 2:
			Debug.Log ("Checking for lvl 2 completeness");

			// Still needs or time limit
			if(basicNeeds()){
				this.cLevel = true;
			}
			break;
		case 3:
			Debug.Log ("Checking for lvl 3 completeness");
			this.cLevel = true;
			break;
		default:
			Debug.Log ("Level outside of 3 scenes");
			break;
		}

		return cLevel;
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

	public bool getIfUsed(int index){
		return toDos [index].done;
	}

	public bool countToDos(){
		int count = 0;
		foreach (ToDo aDo in toDos) {
			if (aDo.done) {
				count++;

				if (count >= firstGoal) {
					return true;
				}

			}
		}

		return false;
	}

	public bool basicNeeds(){
		int count = 0;
		foreach (ToDo aDo in toDos) {
			if ( aDo.done == true && (aDo.todo == "Eat" || aDo.todo == "Bath" || aDo.todo == "Sleep") ) {
				count++;
				if (count >= 3) {
					return true;
				}

			}
		}

		return false;
	}
		
}
