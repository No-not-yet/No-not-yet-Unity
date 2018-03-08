using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WelcomeMsg : MonoBehaviour
{
    public GameObject Inst, welcome, tagObjts;
	private Status playerStatus;
    
    float time = 5f;

    void Start()
    {        
		// Set to Busy
		playerStatus = this.GetComponent<Status> ();
		playerStatus.setBusy (true);

		//Disable welcome mssg for dev purposes also inst not invoking
		//welcome.SetActive(false);
		Invoke("Hide", time);
    }
    void Hide()
    {
        welcome.SetActive(false);
		playerStatus.setBusy (false);
        Inst.SetActive(true);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Inst.SetActive(false);
        }
    }
}


        