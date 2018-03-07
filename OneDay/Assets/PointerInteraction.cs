using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerInteraction : MonoBehaviour
{

    private float timer;
    public float gazeTimer = 2f;
    private bool gazeAt;
	private Status playerStatus;

    // Use this for initialization
    void Start()
    {

		GameObject player = GameObject.Find ("Player");

		// Check exists
		if (player == null) {
			Debug.Log ("Pointer couldn t find a player");
			this.enabled = false;

		} 

		playerStatus = player.GetComponent<Status> ();
		//Debug.Log ("Walking is in (checked by Pointer): " + playerStatus.getWalking ());
    }

    // Update is called once per frame
    void Update()
    {
		//sendEventAfterSeconds ();
		changeToBusy();
    }

	public void sendEventAfterSeconds(){
		if (gazeAt)
		{
			timer += Time.deltaTime;
			if (timer >= gazeTimer)
			{
				ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
				timer = 0f;
			}

		}
	}

	public void changeToBusy (){
		if (gazeAt && !playerStatus.getWalking ()) {
			playerStatus.setBusy (true);
		}
	}

    public void PointerEnter()
    {
		// Used for sendAfterSeconds and ChangeTo Busy
		gazeAt = true;
    }

    public void PointerExit()
    {
        gazeAt = false;
		playerStatus.setBusy (false);
    }

    public void PointerDown()
    {
		// Not walking to interact
		if (playerStatus.getBusy()) {
			Debug.Log ("Interacting");
		}

		// playerStatus.setBusy (false);
    }
		
}