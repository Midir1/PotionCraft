using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonShopScript : MonoBehaviour
{
    void OnMouseDown()
    {
        GameManager.Instance.shopState = ShopState.SHOP;
    }
}
