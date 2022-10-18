using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButtonScript : MonoBehaviour
{
    ItemShopScript currentItemShop;

    public void SelectItemShop(ItemShopScript itemShop)
    {
        currentItemShop = itemShop;
    }

    void OnMouseDown()
    {
        if (currentItemShop !=null)
        {
            Debug.Log("item select");
            if(currentItemShop.BuyIt())
            {

            }
        }
        else
        {
            Debug.Log("no item select");
        }
    }

        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
