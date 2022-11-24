using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DipslayCaudronScript : MonoBehaviour
{
    ItemShopScript currentItemShop;
    private void Start()
    {
        currentItemShop = gameObject.GetComponent<ItemShopScript>();
    }
    private void Update()
    {

        if ((!GameManager.Instance.cauldron[1].isAvailable && currentItemShop.Id == "cauldron2")
            || (!GameManager.Instance.cauldron[2].isAvailable && currentItemShop.Id == "cauldron3"))
        {
            foreach (Transform child in transform)
            {
                if (child.name != "CauldronLock")
                    child.gameObject.SetActive(false);
            }
        }
        else
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
                if (child.name == "CauldronLock")
                    child.gameObject.SetActive(false);
            }
        }

        if ((GameManager.Instance.cauldron[1].upgradeSpeed && currentItemShop.Id == "cauldron2")
           || (GameManager.Instance.cauldron[2].upgradeSpeed && currentItemShop.Id == "cauldron3")
           || (GameManager.Instance.cauldron[0].upgradeSpeed && currentItemShop.Id == "cauldron1"))
        {
            foreach (Transform child in transform)
            {
                if (child.name == "upgradeButton")
                {
                    child.gameObject.SetActive(false);
                    break;
                }
            }
        }

        if ((GameManager.Instance.cauldron[1].upgradeTime && currentItemShop.Id == "cauldron2")
           || (GameManager.Instance.cauldron[2].upgradeTime && currentItemShop.Id == "cauldron3")
           || (GameManager.Instance.cauldron[0].upgradeTime && currentItemShop.Id == "cauldron1"))
        {
            foreach (Transform child in transform)
            {
                if (child.name == "upgradeButton (1)")
                {
                    child.gameObject.SetActive(false);
                    break;
                }
            }
        }
    }
}
