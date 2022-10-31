using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButtonScript : MonoBehaviour
{
    ItemShopScript currentItemShop;

    void OnMouseDown()
    {
        currentItemShop = GetComponentInParent<ItemShopScript>();

        if (currentItemShop !=null)
        {
            Debug.Log("item select : " + currentItemShop.Id);
            if(currentItemShop.BuyIt())
            {
                Debug.Log("achat");
                
                switch(currentItemShop.Id)
                {
                    case "cauldron2":
                        GameManager.Instance.cauldron[1].CauldronIsAvailable();
                        break;
                    case "cauldron3":
                        GameManager.Instance.cauldron[2].CauldronIsAvailable();
                        break;
                    case "tipBox":
                        GameManager.Instance.tipBox.TipIsAvailable();
                        break;
                    default : Debug.Log("unknow ItemShop.Id");
                        break;
                }
            }
        }
        else
        {
            Debug.Log("no item select");
        }
    }

  

}
