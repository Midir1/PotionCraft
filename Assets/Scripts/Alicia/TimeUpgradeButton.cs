using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeUpgradeButton : MonoBehaviour
{
    [SerializeField] uint price;
    bool availablePurchase = true;
    void OnMouseDown()
    {
        if (availablePurchase)
        {
            if (GameManager.Instance.CurrentMoney > price)
            {
                GameManager.Instance.RemoveMoney(price);

                availablePurchase = false;

                switch (GetComponentInParent<ItemShopScript>().Id)
                {
                    case "cauldron1":
                        GameManager.Instance.cauldron[0].TimeUpgradeIsAvailable();
                        break;
                    case "cauldron2":
                        GameManager.Instance.cauldron[1].TimeUpgradeIsAvailable();
                        break;
                    case "cauldron3":
                        GameManager.Instance.cauldron[2].TimeUpgradeIsAvailable();
                        break;
                    default:
                        Debug.Log("unknow ItemShop.Id");
                        break;
                }
            }
        }

        Debug.Log(GetComponentInParent<ItemShopScript>().Id);
       
    }
}
