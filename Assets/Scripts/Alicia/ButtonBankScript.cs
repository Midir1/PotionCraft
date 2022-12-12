using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonBankScript : MonoBehaviour
{
    public UnityEvent ButonBank;
    private void Start()
    {
        ButonBank = new UnityEvent();
    }
    void OnMouseDown()
    {
        ButonBank.Invoke();
        GameManager.Instance.shopState = ShopState.BANK;
    }
}
