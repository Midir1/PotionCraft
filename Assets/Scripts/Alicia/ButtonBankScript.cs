using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBankScript : MonoBehaviour
{
    void OnMouseDown()
    {
        GameManager.Instance.shopState = ShopState.BANK;
    }
}
