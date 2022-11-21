using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyScript : MonoBehaviour
{
    private TextMeshProUGUI moneyValue;

    // Start is called before the first frame update
    void Start()
    {
       moneyValue = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        moneyValue.text = GameManager.Instance.CurrentMoney.ToString();
    }
}
