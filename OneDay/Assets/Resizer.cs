using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resizer : MonoBehaviour {

	public float pixelsPU = 25f;

	public void OnValidate(){
		transform.localScale = new Vector3 (1/ pixelsPU, 1/ pixelsPU, 1);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
