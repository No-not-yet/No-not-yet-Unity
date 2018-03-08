using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PointerInteraction : MonoBehaviour
{
    private float timer;
    public float gazeTimer = 2f;
    private bool gazeAt;
	private Status playerStatus;

	// Tooltip variables
	public float tooltipDelay = 0.3f;
	public string toolTipInfo = "";
	Coroutine mouseOver;
	private Text toolTiptext;
	public GameObject toolTipObj;

	// Picker variables
	private Picker playerPicker;

    // Use this for initialization
    void Start()
    {
		// if still null, change it to name object or specify on editor.
		if (this.toolTipInfo == "") {
			this.toolTipInfo = this.name;
		}
			
		GameObject player = GameObject.Find ("Player");

		// Check exists
		if (player == null || toolTipObj == null) {
			Debug.Log ("Pointer couldn t find a player or his tooltip is not asigned");
			this.enabled = false;
		} 

		playerStatus = player.GetComponent<Status> ();
		toolTiptext = toolTipObj.GetComponent<Text> ();
		playerPicker = player.GetComponent<Picker> ();

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
		if (mouseOver == null) {
			mouseOver = StartCoroutine (showTooltip());
		}
    }

    public void PointerExit()
    {
        gazeAt = false;
		playerStatus.setBusy (false);
		timer = 0f;
		mouseOver = null;
		toolTipObj.SetActive (false);
    }

    public void PointerDown()
    {
		// Not walking to interact
		if (playerStatus.getBusy()) {
			Debug.Log ("Interacting");

			playerPicker.setPickedObject (this.gameObject);
			// Debug List interactives
			//GameManager.instance.toDos[6].done = true;
			//GameManager.instance.printListToDo ();
		}

		// playerStatus.setBusy (false);
    }

	IEnumerator showTooltip(){
		while (gazeAt) {

			timer += Time.deltaTime;

			if (timer > tooltipDelay) {
				toolTipObj.SetActive (true);

				toolTiptext.text = "";
				foreach (char letter in this.toolTipInfo.ToCharArray()) {
					if(gazeAt)
						toolTiptext.text += letter;
					yield return new WaitForSeconds (0.2f);
				}
					
				yield break;
			} else {
				yield return null;
			}
		}
	}

		
}