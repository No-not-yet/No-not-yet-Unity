using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WelcomeMsg : MonoBehaviour
{
    public GameObject Inst, welcome, tagObjts;
    
    float time = 5f;

    void Start()
    {        
		//Disable welcome mssg for dev purposes also inst not invoking
		//welcome.SetActive(false);
		Invoke("Hide", time);
    }
    void Hide()
    {
        welcome.SetActive(false);
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


        