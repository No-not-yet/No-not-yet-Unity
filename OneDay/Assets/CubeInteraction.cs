using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CubeInteraction : MonoBehaviour
{

    public GameObject activList;
    public string tasks;

    public void setTasks(string tasks)
    {
        this.tasks = tasks;

    }


    void Start()
    {   
        //just a test for the setter
        /*string testTasks = "lol\nlol\nlol";
        setTasks(testTasks);*/
    }

    // Update is called once per frame
    void Update()
    {
        if (activList.activeSelf == true && Input.GetMouseButtonDown(0))
        {
            activList.transform.parent.gameObject.SetActive(false);
            //activList.SetActive(false);
        }


    }

    

    public void PointerDown()
    {


        activList.transform.parent.gameObject.SetActive(true);
        activList.GetComponent<Text>().text = tasks;

    }

}