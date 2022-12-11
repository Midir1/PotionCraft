using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayPotionPrice : MonoBehaviour
{
    private TextMeshProUGUI moneyValue;
    [SerializeField] PotionBp potion;

    // Start is called before the first frame update
    void Start()
    {
        moneyValue = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        int price = GameManager.Instance.potionPrice[(int)potion];
        price = price / 3;
        moneyValue.text = price.ToString(); 
    }
}
