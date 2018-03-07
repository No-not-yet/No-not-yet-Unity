using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerInteraction : MonoBehaviour
{

    private float timer;
    public float gazeTimer = 2f;
    private bool gazeAt;
    public Material Click;
    public Material NoClick;

    // Use this for initialization
    void Start()
    {
        GetComponent<Renderer>().material = Click;
    }

    // Update is called once per frame
    void Update()
    {
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
        

    }

    public void PointerExit()
    {
        gazeAt = false;
        GetComponent<Renderer>().material = NoClick;
    }

    public void PointerDown()
    {
        GetComponent<Renderer>().material = Click;
        Debug.Log("Click");


    }
}