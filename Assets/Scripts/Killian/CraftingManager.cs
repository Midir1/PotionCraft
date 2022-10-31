using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingManager : MonoBehaviour
{
    [SerializeField] List<CraftingRecipe> craftingRecipes;
    [SerializeField] CauldronInventory cauldronInventory;

    public void CraftPotion(CauldronInventory cauldronInventory)
    {
        foreach (CraftingRecipe craftingRecipe in craftingRecipes)
        {
            craftingRecipe.Craft(cauldronInventory);
        }
    }
}
