using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Recipe : ScriptableObject
{
    public List<Item> ingredients;
    public Item result;
    public long timeToWait;
}
