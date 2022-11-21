using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;

enum INGREDIENT
{
    INGREDIENT_00,
    INGREDIENT_01,
    INGREDIENT_02,
    INGREDIENT_03,
    INGREDIENT_04,
    INGREDIENT_05,
    INGREDIENT_06,
    INGREDIENT_07,
    INGREDIENT_08,
    INGREDIENT_09,
    INGREDIENT_10,
    INGREDIENT_11,
    INGREDIENT_12,
    INGREDIENT_13,
    INGREDIENT_14,
    INGREDIENT_Count
}

[System.Serializable]
struct Ingredient
{
    public Image image;
    public TMP_Text name;
    public TMP_Text quantity;
}
enum RUNE
{
    RUNE0,
    RUNE1,
    RUNE2,
    RUNE3,
    RUNE4,
    RUNE5,
    RUNE6,
    RUNE7,
    RUNE8,
    RUNE9,
    RUNECount
}

enum PotionName
{

}

public class Potion : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] TMP_Text name;
    [SerializeField] Image coin;
    [SerializeField] TMP_Text price;
    [SerializeField] TMP_Text description;
    [SerializeField] Image rune;
    [SerializeField] List<Ingredient> ingredient;
    [SerializeField] bool locked;
    private void Start()
    {

    }

    private void Update()
    {
        if (locked)
        {
            Locked();
        }
        else
        {
            Unlocked();
        }
    }
    private void Unlocked()
    {
        image.color = Color.white;
        name.color = Color.white;
        coin.color = Color.white;
        price.color = Color.white;
        description.color = Color.white;
        rune.color = Color.white;
        for (int i = 0; i < ingredient.Count; i++)
        {
            ingredient[i].image.color = Color.white;
            ingredient[i].name.color = Color.white;
            ingredient[i].quantity.color = Color.white;
        }
    }
    private void Locked()
    {
        image.color = Color.black;
        name.color = Color.clear;
        coin.color = Color.clear;
        price.color = Color.clear;
        description.color = Color.clear;
        rune.color = Color.clear;
        for (int i = 0; i < ingredient.Count; i++)
        {
            ingredient[i].image.color = Color.clear;
            ingredient[i].name.color = Color.clear;
            ingredient[i].quantity.color = Color.clear;
        }
    }
}
