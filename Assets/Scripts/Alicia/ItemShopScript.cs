using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShopScript : MonoBehaviour
{
    [SerializeField] uint price;
    [SerializeField] string id;
    bool availablePurchase = true;

    public string Id { get => id; }
    public uint Price { get => price; }

    public bool BuyIt()
    {
        if (availablePurchase)
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

    private void Update()
    {

    }

}
