using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButtonScript : MonoBehaviour
{
    public AK.Wwise.Event eventWwiseChaudrond;
    public AK.Wwise.Event eventWwisePostion;
    public AK.Wwise.Event eventWwiseTip;
    public AK.Wwise.Event eventWwiseSonnette;

    ItemShopScript currentItemShop;

    [SerializeField] private Recipe recipe;

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
                        eventWwiseChaudrond.Post(gameObject);
                        break;
                    case "cauldron3":
                        GameManager.Instance.cauldron[2].isAvailable = true;
                        eventWwiseChaudrond.Post(gameObject);
                        break;
                    case "Tip":
                        GameManager.Instance.tipIsAvailable = true;
                        eventWwiseTip.Post(gameObject);
                        break;
                    case "Bell":
                        GameManager.Instance.bellIsAvailable = true;
                        eventWwiseSonnette.Post(gameObject);
                        break;
                    case "Clean":
                        GameManager.Instance.Bp[(int)PotionBp.Clean] = true;
                        eventWwisePostion.Post(gameObject);
                        SetRecipeActive();
                        break;
                    case "Drunkard":
                        GameManager.Instance.Bp[(int)PotionBp.Drunkard] = true;
                        eventWwisePostion.Post(gameObject);
                        SetRecipeActive();
                        break;
                    case "Relaxation":
                        GameManager.Instance.Bp[(int)PotionBp.Champ] = true;
                        eventWwisePostion.Post(gameObject);
                        SetRecipeActive();
                        break;
                    case "Luminescence":
                        GameManager.Instance.Bp[(int)PotionBp.Luminescence] = true;
                        eventWwisePostion.Post(gameObject);
                        SetRecipeActive();
                        break;
                    case "Spicy":
                        GameManager.Instance.Bp[(int)PotionBp.Spicy] = true;
                        eventWwisePostion.Post(gameObject);
                        SetRecipeActive();
                        break;
                    case "Horned":
                        GameManager.Instance.Bp[(int)PotionBp.Horned] = true;
                        eventWwisePostion.Post(gameObject);
                        SetRecipeActive();
                        break;
                    case "Super":
                        GameManager.Instance.Bp[(int)PotionBp.Sea] = true;
                        eventWwisePostion.Post(gameObject);
                        SetRecipeActive();
                        break;
                    case "Strawberry":
                        GameManager.Instance.Bp[(int)PotionBp.Strawberry] = true;
                        eventWwisePostion.Post(gameObject);
                        SetRecipeActive();
                        break;
                    case "Gamer":
                        GameManager.Instance.Bp[(int)PotionBp.Gamer] = true;
                        eventWwisePostion.Post(gameObject);
                        SetRecipeActive();
                        break;
                    case "Graphic":
                        GameManager.Instance.Bp[(int)PotionBp.Graphic] = true;
                        eventWwisePostion.Post(gameObject);
                        SetRecipeActive();
                        break;
                    case "Toad":
                        GameManager.Instance.Bp[(int)PotionBp.Toad] = true;
                        eventWwisePostion.Post(gameObject);
                        SetRecipeActive();
                        break;
                    case "Heart":
                        GameManager.Instance.Bp[(int)PotionBp.Heart] = true;
                        eventWwisePostion.Post(gameObject);
                        SetRecipeActive();
                        break;
                    case "Sleep":
                        GameManager.Instance.Bp[(int)PotionBp.Sleep] = true;
                        eventWwisePostion.Post(gameObject);
                        SetRecipeActive();
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

    private void SetRecipeActive()
    {
        recipe.isActive = true;
    }
}
