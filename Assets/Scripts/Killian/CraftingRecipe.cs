using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ItemAmount
{
    public Item Item;
    [Range(1, 5)]
    public int Amount;
}

[CreateAssetMenu]
public class CraftingRecipe : ScriptableObject
{
    public List<ItemAmount> Materials;
    public List<ItemAmount> Results;

    public bool CanCraft(CauldronInventory cauldronInventory)
    {
        foreach (ItemAmount itemAmount in Materials)
        {
            if (cauldronInventory.ItemCount(itemAmount.Item) < itemAmount.Amount)
            {
                return false;
            }
        }
        return true;
    }

    public void Craft(CauldronInventory cauldronInventory)
    {
        if (CanCraft(cauldronInventory))
        {
            foreach (ItemAmount itemAmount in Materials)
            {
                for (int i = 0; i < itemAmount.Amount; i++)
                {
                    cauldronInventory.RemoveItem(itemAmount.Item);
                }
            }

            foreach (ItemAmount itemAmount in Results)
            {
                for (int i = 0; i < itemAmount.Amount; i++)
                {
                    cauldronInventory.AddItem(itemAmount.Item);
                    cauldronInventory.CraftPotion(itemAmount.Item);
                }
            }
        }
    }
}
