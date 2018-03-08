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



    public bool pay(int cost)
    {
		if (this.currentValue < cost) {
			Debug.Log ("Not enough money!");
			return false;
		}
		this.currentValue -= cost;
		return true;
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
