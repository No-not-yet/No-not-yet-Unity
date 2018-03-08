using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour {

    public int currentValue = 1000;

    public void setMoney(int currentValue)
    {
        this.currentValue = currentValue;
    }

    public int getMoney()
    {
        return this.currentValue;
    }



    public void pay(int cost)
    {
        //Debug.Log("Purchase: $" + cost);
        if (this.currentValue >= cost)
        {
            this.currentValue -= cost;
            this.getMoney();
            //Debug.Log("Purchase done!");
        }
        else
        {
            Debug.Log("Not enough money!");
        }
    }



    // Use this for initialization
    void Start () {
        //Debug.Log("Current Money: $" + getMoney());
        //pay(10000);
        //Debug.Log("Current Money: $" + getMoney());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
