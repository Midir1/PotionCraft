using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefabIngredient;

    private void Update()
    {
        if (transform.childCount <= 0)
        {
            Instantiate(prefabIngredient, transform.position, Quaternion.identity, transform);
        }
    }
}
