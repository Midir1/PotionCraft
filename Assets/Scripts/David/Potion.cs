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
    public TMP_Text nom;
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
    private string hideName;
    [SerializeField] TMP_Text price;
    private string hidePrice;
    [SerializeField] TMP_Text description;
    private string hideDescription;
    [SerializeField] Image rune;
    [SerializeField] GameObject recipe;
    private Vector3 position;
    [SerializeField] bool locked = true;
    private void Start()
    {
        hideName = name.text;
        hidePrice = price.text;
        hideDescription = description.text;
        position = recipe.transform.position;
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
        image.color = new Color(255.0f, 255.0f, 255.0f, image.color.a);
        name.text = hideName;
        price.text = hidePrice;
        description.text = hideDescription;
        rune.color = new Color(255.0f, 255.0f, 255.0f, 255.0f);
        recipe.transform.position = position;
    }
    private void Locked()
    {
        image.color = new Color(0.0f, 0.0f, 0.0f, image.color.a);
        name.text = "???";
        price.text = "???";
        description.text = "";
        rune.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        recipe.transform.position = new Vector3(10000, 0, 0);
    }
}
