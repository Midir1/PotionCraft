using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShopScript : MonoBehaviour
{
    [SerializeField] uint price;
    public BuyButtonScript buyButton;
    public MoneyScript money;
    bool availablePurchase = true;

    void OnMouseDown()
    {
        if (availablePurchase)
            buyButton.SelectItemShop(this);
    }
    public uint GetPrice()
    {
        return price;
    }
    public bool BuyIt()
    {
        if(money.GetCurrentMoney() > price)
        {
            money.RemoveMoney(price);
            availablePurchase = false;
            return true;
        }
        return false;
    }

}
