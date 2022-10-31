using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpgradeButton : MonoBehaviour
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
                        GameManager.Instance.cauldron[0].SpeedUpgradeIsAvailable();
                        break;
                    case "cauldron2":
                        GameManager.Instance.cauldron[1].SpeedUpgradeIsAvailable();
                        break;
                    case "cauldron3":
                        GameManager.Instance.cauldron[2].SpeedUpgradeIsAvailable();
                        break;
                    default:
                        Debug.Log("unknow ItemShop.Id");
                        break;
                }
            }

            Debug.Log(GetComponentInParent<ItemShopScript>().Id);
        }
    }
}
