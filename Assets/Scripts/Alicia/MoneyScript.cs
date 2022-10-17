using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyScript : MonoBehaviour
{
    private TextMeshProUGUI moneyValue;
    private int maxMoney;
    private int currentMoney;

    void AddMoney(uint money)
    {
        currentMoney += (int)money;
        if(currentMoney > maxMoney)
        {
            currentMoney = maxMoney;
        }
    }

    void RemoveMoney(uint money)
    {
        currentMoney -= (int)money;
        if (currentMoney < 0)
        {
            currentMoney = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       maxMoney = 999999;
       currentMoney = 100;
       moneyValue = gameObject.GetComponent<TextMeshProUGUI>();

    }

    // Update is called once per frame
    void Update()
    {
        moneyValue.text = currentMoney.ToString();
    }
}
