using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayPrice : MonoBehaviour
{
    private TextMeshProUGUI priceValue;

    void Start()
    {
        priceValue = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        priceValue.text = GetComponentInParent<ItemShopScript>().Price.ToString();
    }
 
}
