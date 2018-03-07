using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Instance public in order to be used by any script
	public static GameManager instance = null;

	// Value that change the room
	private int level = 2;

	// Length lists
	public int lvlList1 = 5;
	public int lvlList2 = 7;
	private int ListSize = 0;

	// List booleans
	private List<bool> toDosB = new List<bool>();

	// Make sure it is a singleton 
	void Awake(){
		if (instance == null)
			instance = this;
		else if (instance != null)
			Destroy (gameObject);
		DontDestroyOnLoad (gameObject);
	}

	// Use this for initialization
	void Start(){
		// Debug Logs
		Debug.Log (this.level + " is the default lvl");
		generateList();
	}

	public int getLevel(){
		return this.level;
	}

	public void setLevel(int value){
		this.level = value;
	}

	public void generateList(){

		switch (level) {
		case 1:
			ListSize = lvlList1;
			break;
		case 2:
			ListSize = lvlList2;
			break;
		default:
			print ("Level must be 1 or 2 in order to generate List");
			break;
		}

		for (int i = 0; i < ListSize; i++) {
			toDosB.Add (true);
		}


		// printListB ();


	}

	public List<bool> getToDosB(){
		return this.toDosB;
	}

	public void printListB(){
		// Print List
		Debug.Log("I am Printing the boolean list!");
		int count = 0;
		foreach(bool b in toDosB){
			count += 1;
			Debug.Log ("Element #" + count + " : "  + b);
		}
	}

	public void setToDosB(int index, bool value){
		if (index >= 0 && index < ListSize)
			toDosB [index] = value;
		else
			Debug.Log ("The index to change is out of range");
	}

}
