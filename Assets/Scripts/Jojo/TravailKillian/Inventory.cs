using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> ingredients;
    
    [SerializeField] private List<Recipe> recipes;
    public int maxIngredient = 2;

    public void CraftPotion()
    {
        foreach (var recipe in recipes)
        {
            for (var index = 0; index < recipe.ingredients.Count; index++)
            {
                if (!ingredients.Contains(recipe.ingredients[index])) break;

                if (index == ingredients.Count - 1 && recipe.ingredients.Contains(ingredients[index]))
                {
                    Debug.Log(recipe.name);
                    return;
                }
            }

            //
            // for (var index = 0; index < ingredients.Count; index++)
            // {
            //     if (!recipe.ingredients.Contains(ingredients[index])) break;
            //     
            //     if (index == ingredients.Count - 1 && recipe.ingredients.Contains(ingredients[index]))
            //     {
            //         Debug.Log(recipe.name);
            //         return;
            //     }
            // }
        }
    }
}