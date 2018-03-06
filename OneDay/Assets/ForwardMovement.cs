using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Status))]
public class ForwardMovement : MonoBehaviour {

	public float speed = 3;
	private Status playerStatus;

	void Start(){
		playerStatus = this.GetComponent<Status> ();
		Debug.Log ("Walking esta en: " + playerStatus.getWalking ());

		// Test if busy is true
		//playerStatus.setBusy (true);
	}

	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0 && !playerStatus.getBusy() ) {
			Vector3 forward = Camera.main.transform.forward;
			forward.y = 0;
			this.transform.position += forward * Time.deltaTime * speed;
			playerStatus.setWalking (true);
		}

		if( !(Input.touchCount > 0) && playerStatus.getWalking())
			playerStatus.setWalking (false);
	}
}
