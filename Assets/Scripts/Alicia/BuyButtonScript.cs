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
                    case "cauldron1_up1":
                        GameManager.Instance.cauldron[0].SpeedUpgradeIsAvailable();
                        break;
                    case "cauldron2_up1":
                        GameManager.Instance.cauldron[1].SpeedUpgradeIsAvailable();
                        break;
                    case "cauldron3_up1":
                        GameManager.Instance.cauldron[2].SpeedUpgradeIsAvailable();
                        break;
                    case "cauldron1_up2":
                        GameManager.Instance.cauldron[0].TimeUpgradeIsAvailable();
                        break;
                    case "cauldron2_up2":
                        GameManager.Instance.cauldron[1].TimeUpgradeIsAvailable();
                        break;
                    case "cauldron3_up2":
                        GameManager.Instance.cauldron[2].TimeUpgradeIsAvailable();
                        break;
                    case "tipBox":
                        GameManager.Instance.tipBox.TipIsAvailable();
                        break;
                    default :
                        Debug.Log("unknow ItemShop.Id");
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
