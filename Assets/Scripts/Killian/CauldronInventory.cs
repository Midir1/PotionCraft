using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronInventory : MonoBehaviour
{
    [SerializeField] List<Item> items;
    [SerializeField] List<GameObject> craftablePotions;

    public bool AddItem(Item item)
    {
        items.Add(item);
        return true;
    }

    public bool RemoveItem(Item item)
    {
        if (items.Remove(item))
        {
            return true;
        }

        return false;
    }

    public int ItemCount(Item item)
    {
        int number = 0;

        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] == item)
            {
                number++;
            }
        }

        return number;
    }

    public bool CraftPotion(Item item)
    {
        foreach (GameObject potion in craftablePotions)
        {
            if (potion.name == item.ItemName)
            {
                Instantiate(potion);
            }
        }
        return true;
    }
}
