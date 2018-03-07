using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

	// x / 60 = time in hours.
	// Init at 8:00 finish at 20:00.
    private int sTimeInt = 480;
	private int sTimeLimit = 1200;
	private float cTime;

    // Use this for initialization
    void Start()
    {
		// this.enabled = false;
		this.cTime = this.sTimeInt;
    }

    // Update is called once per frame
    void Update()
    {   //Test currentTime() must give format 00:00
        Debug.Log(currentTime());
    }

	public void toogleTime(){
		this.enabled = !this.enabled;
	}

    public string currentTime()
    {   
		if (cTime >= sTimeLimit)
		{
			return "El día ha terminado.";
		}

        float elapsed = Time.realtimeSinceStartup;
        cTime = sTimeInt + elapsed;

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


		return currentTime;
        
    }
}