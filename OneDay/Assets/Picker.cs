using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Picker : MonoBehaviour {

	private GameObject pickedObject;
	private Transform cameraChild;
	private Vector3 initialPos;
	private float Offset = 1.5f;

	// Rotation speed
	private float speed = 50f;

	// Delay picked variables
	private float pickingTime = 3.5f;
	private float timer = 0f;
	Coroutine willDrop;

	// Use this for initialization
	void Start () {
		cameraChild = this.gameObject.transform.GetChild (0);

		// Check camera as first child
		if (!cameraChild){
			Debug.Log ("Camera must be first child of player");
			this.enabled = false;
		}
			
	}
	
	// Update is called once per frame
	void Update () {
		if (this.pickedObject) {

			if (willDrop == null)
				willDrop = StartCoroutine (willDropF ());

			this.pickedObject.transform.position = cameraChild.position + cameraChild.forward * Offset;
			this.pickedObject.transform.Rotate (Vector3.up, speed * Time.deltaTime);
		}
	}

	public void setPickedObject(GameObject go){

		// Check if there is not a picked object still;
		if (pickedObject)
			return;

		this.pickedObject = go;
		this.initialPos = go.transform.position;

		Debug.Log ("Picked " + this.pickedObject.name);
	}

	public void Drop(){

		if (!pickedObject) {
			return;
		}

		this.pickedObject.transform.position = initialPos;
		this.pickedObject.GetComponent<PointerInteraction> ().enabled = false;
		this.pickedObject = null;
		this.willDrop = null;
		timer = 0f;

	}

	IEnumerator willDropF(){
		while (true) {

			timer += Time.deltaTime;
			if (timer > pickingTime) {
				Drop ();
				yield break;
			} else {
				yield return null;
			}
				
		}
	}

}
