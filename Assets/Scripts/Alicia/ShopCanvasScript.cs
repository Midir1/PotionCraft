using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCanvasScript : MonoBehaviour
{

    void Update()
    {
        if (GameManager.Instance.shopState == ShopState.SHOP)
        {
            foreach (Transform child in transform)
            {
                if (child.name == "ScrollShop")
                    child.gameObject.SetActive(true);
                if (child.name == "ScrollBank")
                    child.gameObject.SetActive(false);
            }
        }
        else if(GameManager.Instance.shopState == ShopState.BANK)
        {
            foreach (Transform child in transform)
            {
                if (child.name == "ScrollShop")
                    child.gameObject.SetActive(false);
                if (child.name == "ScrollBank")
                    child.gameObject.SetActive(true);
            }
        }
    }
}