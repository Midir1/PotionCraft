using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [HideInInspector] public int maxIngredient;
    
    public List<Item> ingredients;
    
    [SerializeField] private List<Recipe> recipes;
    [SerializeField] private List<GameObject> potions;
    [SerializeField] private Transform potionParent;
    
    public void CraftPotion()
    {
        for (var i = 0; i < recipes.Count; i++)
        {
            var recipe = recipes[i];
            
            for (var index = 0; index < recipe.ingredients.Count; index++)
            {
                if (!ingredients.Contains(recipe.ingredients[index])) break;

                if (index == recipe.ingredients.Count - 1 && ingredients.Contains(recipe.ingredients[index]))
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