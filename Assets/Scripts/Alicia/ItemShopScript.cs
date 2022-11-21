using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemShopScript : MonoBehaviour
{
    [SerializeField] uint price;
    [SerializeField] string id;
    bool availablePurchase = true;
    private TextMeshProUGUI priceValue;

    public string Id { get => id; }
    public uint Price { get => price; }

    void Start()
    {
        if (id != "cauldron1" && id != "cauldron2" && id != "cauldron3")
        {
            priceValue = gameObject.GetComponentInChildren<TextMeshProUGUI>();
            priceValue.text = price.ToString();
        }
    }
    public bool BuyIt()
    {
        if (availablePurchase && transform.position.y < 3.0f && transform.position.y > -3.3f)
        {
            if (GameManager.Instance.CurrentMoney > price)
            {
                GameManager.Instance.RemoveMoney(price);
                availablePurchase = false;
                return true;
            }
        }
        return false;
    }


}
