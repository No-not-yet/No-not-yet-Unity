using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToDo : MonoBehaviour {

	public string todo;
	public bool done;
	public int cost;
	public string info;

	public ToDo(string todo, bool done, int cost, string info){
		this.todo = todo;
		this.done = done;
		this.cost = cost;
		this.info = info;
	}
		
}
