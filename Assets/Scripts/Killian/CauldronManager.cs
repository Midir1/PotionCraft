using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronManager : MonoBehaviour
{
    [SerializeField] CauldronInventory cauldronInventory;

    public void AddItemInInventory(Item item)
    {
        cauldronInventory.AddItem(item);
    }
}
