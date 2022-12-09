using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemShopScript : MonoBehaviour
{
    [SerializeField] uint price;
    [SerializeField] string id;
    bool availablePurchase = true;
    private TextMeshProUGUI priceValue;

    public string Id { get => id; }
    public uint Price { get => price; }

    void Start()
    {
        if (id != "cauldron1" && id != "cauldron2" && id != "cauldron3")
        {
            priceValue = gameObject.GetComponentInChildren<TextMeshProUGUI>();
            priceValue.text = price.ToString();
        }
    }
    public bool BuyIt()
    {
        if(!GameManager.Instance.tutoState)
        {
            if (availablePurchase && transform.position.y < 3.0f && transform.position.y > -3.3f)
            {
                if (GameManager.Instance.CurrentMoney >= price)
                {
                    GameManager.Instance.RemoveMoney(price);
                    availablePurchase = false;
                    foreach (Transform child in transform)
                    {
                        if (child.name == "ButtonBuy")
                            child.gameObject.SetActive(false);
                    }
                    return true;
                }
            }
            return false;
        }
        else if(StateManager.Instance.CurrentState == 16)
        {
            foreach (Transform child in transform)
            {
                if (child.name == "ButtonBuy")
                    child.gameObject.SetActive(false);
            }
            StateManager.Instance.CurrentState++;
        }

        return false;
    }

    

}
