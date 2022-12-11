using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayPotionPrice : MonoBehaviour
{
    private TextMeshProUGUI priceValue;
    [SerializeField] PotionBp potion = 0;
    private int price = 0;
    void Start()
    {
        priceValue = gameObject.GetComponent<TextMeshProUGUI>();
        price = GameManager.Instance.potionPrice[(int)potion];
        price = price / 3;
        priceValue.text = price.ToString();

    }
    void Update()
    {
        

    }
}
