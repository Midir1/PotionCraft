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
class Ingredient
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
    [SerializeField] TMP_Text nom;
    [SerializeField] TMP_Text price;
    [SerializeField] TMP_Text description;
    [SerializeField] Image rune;
    [SerializeField] List<Ingredient> recipe;
    [SerializeField] bool locked = true;

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
        image.color = new Color(255.0f, 255.0f, 255.0f, image.color.a);
        nom.text = "Potion name";
        price.text = "123";
        description.text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam ante velit, aliquet iaculis fringilla ut, gravida suscipit nulla. Aliquam vel mauris lectus. Praesent laoreet nisl eget magna bibendum";
        rune.color = new Color(255.0f, 255.0f, 255.0f, 255.0f);
        for (int i = 0; i < recipe.Count; i++)
        {
            recipe[i].image.color = new Color(255.0f, 255.0f, 255.0f, 255.0f);
            recipe[i].nom.text = "nom";
            recipe[i].quantity.text = "x1";
        }
    }
    private void Locked()
    {
        image.color = new Color(0.0f, 0.0f, 0.0f, image.color.a);
        nom.text = "???";
        price.text = "???";
        description.text = "";
        rune.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        for (int i = 0; i < recipe.Count; i++)
        {
            recipe[i].image.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            recipe[i].nom.text = "";
            recipe[i].quantity.text = "";
        }
    }
}
