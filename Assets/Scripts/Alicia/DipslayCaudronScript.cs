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

        if ((!GameManager.Instance.cauldron[1].IsAvailable && currentItemShop.Id == "cauldron2")
            || (!GameManager.Instance.cauldron[2].IsAvailable && currentItemShop.Id == "cauldron3"))
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

        if ((GameManager.Instance.cauldron[1].UpgradeSpeed && currentItemShop.Id == "cauldron2")
           || (GameManager.Instance.cauldron[2].UpgradeSpeed && currentItemShop.Id == "cauldron3")
           || (GameManager.Instance.cauldron[0].UpgradeSpeed && currentItemShop.Id == "cauldron1"))
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

        if ((GameManager.Instance.cauldron[1].UpgradeTime && currentItemShop.Id == "cauldron2")
           || (GameManager.Instance.cauldron[2].UpgradeTime && currentItemShop.Id == "cauldron3")
           || (GameManager.Instance.cauldron[0].UpgradeTime && currentItemShop.Id == "cauldron1"))
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
