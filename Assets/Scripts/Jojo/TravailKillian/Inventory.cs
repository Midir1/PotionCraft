using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int maxIngredients;
    
    public List<Item> ingredients;
    
    public bool isBrewing;
    
    [SerializeField] private List<Recipe> recipes;
    [SerializeField] private List<GameObject> potions;
    [SerializeField] private Transform potionParent;
    [SerializeField] private GameObject drawPanel;
    [SerializeField] private GameObject inputManager;

    private int potionIndex = -1;

    private float timer;

    private void Update()
    {
        if (potionIndex == -1 || !isBrewing) return;
        
        timer += Time.deltaTime;
        if (timer > recipes[potionIndex].timeToWait) CraftPotion();
    }

    //Recipes and Potions Needs to be in the same order in the inspector to give the provided result
    public void CheckPotionExist()
    {
        for (var i = 0; i < recipes.Count; i++)
        {
            var recipe = recipes[i];
            
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
                    drawPanel.SetActive(true);
                    inputManager.SetActive(true);

                    potionIndex = i;

                    return;
                }
            }
        }
        
        ingredients.Clear();
    }

    public void BeginCraftPotion()
    {
        drawPanel.SetActive(false);
        inputManager.SetActive(false);
        
        isBrewing = true;
    }

    private void CraftPotion()
    {
        isBrewing = false;
        timer = 0f;

        ingredients.Clear();
        Instantiate(potions[potionIndex], potionParent);

        potionIndex = -1;
    }
}