using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    private int sTimeInt = 480;

    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {   //Test currentTime() must give format 00:00
        //Debug.Log(currentTime());

    }

    public string currentTime()
    {   
        float elapsed = Time.realtimeSinceStartup;
        float cTime = sTimeInt + elapsed;
        string hrs = ((int)cTime / 60).ToString();
        string min;
        int auxMin = ((int)cTime % 60);

        //Adds a 0 for times with minutes lower than 10, in order to keep format 00:00
        if (auxMin < 10)
        {
            min = "0" + ((int)cTime % 60).ToString();
        }
        else
        {
            min = ((int)cTime % 60).ToString();
        }

        string currentTime = "" + hrs + ":" + min;
        if (cTime >= 1200)
        {
            return "El día ha terminado.";

        }
        else
        {
            return currentTime;
        }

    }
}