using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyScript : MonoBehaviour
{
    private TextMeshProUGUI moneyValue;
    [SerializeField] uint maxMoney;
    [SerializeField] uint currentMoney;

    public void AddMoney(uint money)
    {
        currentMoney += money;
        if(currentMoney > maxMoney)
        {
            currentMoney = maxMoney;
        }
    }

    public void RemoveMoney(uint money)
    {
        currentMoney -= money;
        if (currentMoney < 0)
        {
            currentMoney = 0;
        }
    }

    public uint GetCurrentMoney()
    {
        return currentMoney;
    }

    // Start is called before the first frame update
    void Start()
    {
       moneyValue = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        moneyValue.text = currentMoney.ToString();
    }
}
