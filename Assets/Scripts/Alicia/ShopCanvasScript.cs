using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCanvasScript : MonoBehaviour
{
    [SerializeField] ShopState shopState;
    void Update()
    {
        if (shopState == ShopState.SHOP)
        {
            foreach (Transform child in transform)
            {
                if (child.name == "ContentShop")
                {
                    if (GameManager.Instance.shopState == shopState)
                        child.gameObject.SetActive(true);
                    else
                        child.gameObject.SetActive(false);
                }

            }
        }
        else if (shopState == ShopState.BANK)
        {
            foreach (Transform child in transform)
            {
                if (child.name == "ContentBank")
                {
                    if (GameManager.Instance.shopState == shopState)
                        child.gameObject.SetActive(true);
                    else
                        child.gameObject.SetActive(false);
                }
            }
        }


    }
}
