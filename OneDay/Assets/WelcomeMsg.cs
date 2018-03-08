using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WelcomeMsg : MonoBehaviour
{
    public GameObject Inst, welcome;
    
    float time = 5f;

    void Start()
    {        
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


        