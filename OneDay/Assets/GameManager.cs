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
		Debug.Log (this.level + " is the default lvl");

		// 2nd way Test 1.0
		/*Debug.Log ("Tu ToDo Tiene " + toDos.Count + " elementos");
		toDos.Add (new ToDo("cocking", false));
		toDos.Add (new ToDo("bath", false));
		toDos.Add (new ToDo("tv", false));*/

		//setToDos (1, true);
		//setToDos (3, true);

		// Debug Prints
		/*printListToDo();
		Debug.Log ("Tu ToDo Tiene " + toDos.Count + " elementos");

		toDos.Clear ();*/

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
		foreach (ToDo aDo in toDos) {
			print (aDo.todo + " value: " + aDo.done);
		}
	}

	public void setToDos(int index, bool value){
		if (index >= 0 && index < toDos.Count)
			toDos [index].done = value;
		else
			Debug.Log ("The index to change is out of range");
	}

}
