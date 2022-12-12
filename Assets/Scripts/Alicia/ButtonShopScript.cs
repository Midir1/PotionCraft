using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonShopScript : MonoBehaviour
{
    public UnityEvent ButonShop;
    private void Start()
    {
        ButonShop = new UnityEvent();
    }

    void OnMouseDown()
    {
        ButonShop.Invoke();
        GameManager.Instance.shopState = ShopState.SHOP;
    }
}
