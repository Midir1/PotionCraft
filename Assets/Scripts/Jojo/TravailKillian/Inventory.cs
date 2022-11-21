using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [HideInInspector] public int maxIngredient;
    
    public List<Item> ingredients;
    
    [SerializeField] private List<Recipe> recipes;
    [SerializeField] private List<GameObject> potions;
    [SerializeField] private Transform potionParent;
    
    //Recipes and Potions Needs to be in the same order in the inspector to give the provided result
    public void CraftPotion()
    {
        foreach (var recipe in recipes)
        {
            Item recipeIngredient1 = recipe.ingredients[0];
            Item recipeIngredient2 = recipe.ingredients[1];
            Item recipeIngredient3 = recipe.ingredients[2];
            
            for (var index = 0; index < recipe.ingredients.Count; index++)
            {
                if (ingredients[index] == recipeIngredient1) recipeIngredient1 = null;
                else if (ingredients[index] == recipeIngredient2) recipeIngredient2 = null;
                else if (ingredients[index] == recipeIngredient3) recipeIngredient3 = null;
                else break;

                if (index == recipe.ingredients.Count - 1)
                {
                    ingredients.Clear();
                    //Instantiate(potions[i], potionParent);
                    Instantiate(potions[0], potionParent);

                    Debug.Log(recipe.name);
                    return;
                }
            }
        }

        ingredients.Clear();
    }
}