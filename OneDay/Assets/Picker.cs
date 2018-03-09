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

	// Cost variable
	private int cost;

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

			//this.pickedObject.transform.position = cameraChild.position + cameraChild.forward * Offset;
			//this.pickedObject.transform.Rotate (Vector3.up, speed * Time.deltaTime);
		}
	}

	public void setPickedObject(GameObject go){

		// Check if there is not a picked object still;
		if (pickedObject)
			return;

		// Check if you already used the object
		if( go.GetComponent<ListInteraction>().alreadyUsed() ){
			Debug.Log ("Already used!");
			return;
		}

		// Check if exit
		if ( go.name == "Exit"){
			//Debug.Log ("Object is an exit");
			Debug.Log("Can you go? " + GameManager.instance.completedLevel ());
			if (GameManager.instance.completedLevel ()) {
				GameManager.instance.setLevel (GameManager.instance.getLevel() + 1);
				GameManager.instance.cLevel = false;
				GameManager.instance.toDos.Clear ();

				// Cambiar dinero

				Debug.Log ("Start fading");
				GameObject.Find ("Loader").GetComponent<SceneController> ().loadScene(GameManager.instance.getLevel());

			}
			return;
		}


		// Check if you pay, otherwise not do anything
		this.cost = go.GetComponent<ListInteraction>().getCost();
		if (!(this.gameObject.GetComponent<Money> ().pay (this.cost))) {
			this.gameObject.GetComponent<WelcomeMsg> ().showInfo("Not Enough Money!!! \nToo expensive for you right now", this.cost);
			return;
		}

		Debug.Log ("Got : " + this.gameObject.GetComponent<Money> ().getMoney() + " dlls");

		this.pickedObject = go;
		this.initialPos = go.transform.position;

        // Send show info
        this.gameObject.GetComponent<WelcomeMsg> ().showInfo(this.pickedObject.GetComponent<ListInteraction>().getInfo(), this.cost);

        this.pickedObject.GetComponent<SFXsleep>().PlaySleep();

		//Debug.Log ("Picked " + this.pickedObject.name);
	}

	public void Drop(){

		if (!pickedObject) {
			return;
		}

		this.pickedObject.transform.position = initialPos;
		this.pickedObject.GetComponent<PointerInteraction> ().enabled = false;

		// Before droping, send signal to interact with list
		this.pickedObject.GetComponent<ListInteraction>().setToUsed();


		// Must send stop info
		this.gameObject.GetComponent<WelcomeMsg>().hideInfo();


		this.pickedObject = null;
		this.willDrop = null;
		timer = 0f;

		// Debug List Interaction
		//Debug.Log("In the list interaction you have been used? ");
		GameManager.instance.printListToDo ();


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
