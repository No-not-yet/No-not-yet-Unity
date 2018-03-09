using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CubeInteraction : MonoBehaviour
{

    public GameObject activList;


    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        if (activList.activeSelf == true && Input.GetMouseButtonDown(0))
        {
            activList.SetActive(false);
        }


    }

    /*public void PointerEnter()
    {
        // Debug.Log("Pointer.enter");

    }

    public void PointerExit()
    {
         Debug.Log("Pointer.exit");

    }*/

    public void PointerDown()
    {

        activList.SetActive(true);
        activList.GetComponent<Text>().text = "lol\nlol\nlol";

    }

}