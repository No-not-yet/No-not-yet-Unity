using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToDo : MonoBehaviour {

	public string todo;
	public bool done;

	public ToDo(string todo, bool done){
		this.todo = todo;
		this.done = done;
	}
		
}
