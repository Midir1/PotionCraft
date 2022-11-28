using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButtonScript : MonoBehaviour
{
    ItemShopScript currentItemShop;

    void OnMouseDown()
    {
        currentItemShop = GetComponentInParent<ItemShopScript>();

        if (currentItemShop != null)
        {

            if (currentItemShop.BuyIt())
            {

                switch (currentItemShop.Id)
                {
                    case "cauldron2":
                        GameManager.Instance.cauldron[1].isAvailable = true;
                        break;
                    case "cauldron3":
                        GameManager.Instance.cauldron[2].isAvailable = true;
                        break;
                    case "Tip":
                        GameManager.Instance.tipIsAvailable = true;
                        break;
                    case "Bell":
                        GameManager.Instance.bellIsAvailable = true;
                        break;
                    case "Clean":
                        GameManager.Instance.Bp[(int)PotionBp.Clean] = true;
                            break;
                    case "Drunkard":
                        GameManager.Instance.Bp[(int)PotionBp.Drunkard] = true;
                        break;
                    case "Relaxation":
                        GameManager.Instance.Bp[(int)PotionBp.Relaxation] = true;
                        break;
                    case "Luminescence":
                        GameManager.Instance.Bp[(int)PotionBp.Luminescence] = true;
                        break;
                    case "Spicy":
                        GameManager.Instance.Bp[(int)PotionBp.Spicy] = true;
                        break;
                    case "Horned":
                        GameManager.Instance.Bp[(int)PotionBp.Horned] = true;
                        break;
                    case "Super":
                        GameManager.Instance.Bp[(int)PotionBp.Super] = true;
                        break;
                    case "Strawberry":
                        GameManager.Instance.Bp[(int)PotionBp.Strawberry] = true;
                        break;
                    case "Gamer":
                        GameManager.Instance.Bp[(int)PotionBp.Gamer] = true;
                        break;
                    case "Graphic":
                        GameManager.Instance.Bp[(int)PotionBp.Graphic] = true;
                        break;
                    case "Toad":
                        GameManager.Instance.Bp[(int)PotionBp.Toad] = true;
                        break;
                    case "Heart":
                        GameManager.Instance.Bp[(int)PotionBp.Heart] = true;
                        break;
                    case "Sleep":
                        GameManager.Instance.Bp[(int)PotionBp.Sleep] = true;
                        break;
                    default:
                        Debug.Log("unknow ItemShop.Id");
                        break;
                }
            }
        }
        else
        {
            Debug.Log("no item select");
        }
    }



}
