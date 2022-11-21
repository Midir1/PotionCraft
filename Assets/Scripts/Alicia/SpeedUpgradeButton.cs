using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeedUpgradeButton : MonoBehaviour
{
    [SerializeField] uint price;
    bool availablePurchase = true;
    private TextMeshProUGUI priceValue;

    void Start()
    {
        priceValue = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        priceValue.text = price.ToString();
    }
    void OnMouseDown()
    {
        if (availablePurchase && GameManager.Instance.CurrentMoney > price && transform.position.y < 3.0f && transform.position.y > -3.3f)
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
    }

}
