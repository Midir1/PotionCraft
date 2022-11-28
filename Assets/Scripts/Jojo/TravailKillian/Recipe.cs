using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu]
public class Recipe : ScriptableObject
{
    public List<Item> ingredients;
    [UsedImplicitly] public Item result;
    public float timeToWait;
    public RuneList.Patern rune = RuneList.Patern.NotInitialized;
}
