using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerInteraction : MonoBehaviour
{

    private float timer;
    public float gazeTimer = 2f;
    private bool gazeAt;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
		//sendEventAfterSeconds ();
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

    public void PointerEnter()
    {
		// Used for sendAfterSeconds
		//gazeAt = true;
    }

    public void PointerExit()
    {
        //gazeAt = false;
    }

    public void PointerDown()
    {
        Debug.Log("Click");
    }
		
}