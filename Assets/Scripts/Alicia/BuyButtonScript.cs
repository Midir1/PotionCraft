using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButtonScript : MonoBehaviour
{
    ItemShopScript currentItemShop;

    [SerializeField] private List<Recipe> recipes;

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
                        SetRecipeActive("CleanlinessPotion");
                        break;
                    case "Drunkard":
                        GameManager.Instance.Bp[(int)PotionBp.Drunkard] = true;
                        SetRecipeActive("DrunkardElixir");
                        break;
                    case "Relaxation":
                        GameManager.Instance.Bp[(int)PotionBp.Champ] = true;
                        SetRecipeActive("ChampPotion");
                        break;
                    case "Luminescence":
                        GameManager.Instance.Bp[(int)PotionBp.Luminescence] = true;
                        SetRecipeActive("LuminescencePotion");
                        break;
                    case "Spicy":
                        GameManager.Instance.Bp[(int)PotionBp.Spicy] = true;
                        SetRecipeActive("SpiceyPotion");
                        break;
                    case "Horned":
                        GameManager.Instance.Bp[(int)PotionBp.Horned] = true;
                        SetRecipeActive("HornPotion");
                        break;
                    case "Super":
                        GameManager.Instance.Bp[(int)PotionBp.Sea] = true;
                        SetRecipeActive("SeaElixir");
                        break;
                    case "Strawberry":
                        GameManager.Instance.Bp[(int)PotionBp.Strawberry] = true;
                        SetRecipeActive("StrawberryPotion");
                        break;
                    case "Gamer":
                        GameManager.Instance.Bp[(int)PotionBp.Gamer] = true;
                        SetRecipeActive("GamerPotion");
                        break;
                    case "Graphic":
                        GameManager.Instance.Bp[(int)PotionBp.Graphic] = true;
                        SetRecipeActive("GraphistPotion");
                        break;
                    case "Toad":
                        GameManager.Instance.Bp[(int)PotionBp.Toad] = true;
                        SetRecipeActive("ToadFilter");
                        break;
                    case "Heart":
                        GameManager.Instance.Bp[(int)PotionBp.Heart] = true;
                        SetRecipeActive("BrokenHeartFilter");
                        break;
                    case "Sleep":
                        GameManager.Instance.Bp[(int)PotionBp.Sleep] = true;
                        SetRecipeActive("SleepElixir");
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

    private void SetRecipeActive(string _potionName)
    {
        for (int i = 0; i < recipes.Count; i++)
        {
            var recipe = recipes[i];

            if (recipe.name == _potionName)
            {
                recipe.isActive = true;
                return;
            }
        }
    }
}
