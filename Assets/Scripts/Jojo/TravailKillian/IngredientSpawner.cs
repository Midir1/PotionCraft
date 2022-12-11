using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IngredientSpawner : MonoBehaviour
{
    [SerializeField] private GameObject prefabIngredient;

    private void Start()
    {
        if (GameManager.Instance.tutoState)
        {
            foreach (Transform child in transform)
            {
                if (child.name == "Trigger" )
                {
                    child.gameObject.SetActive(false);
                }
            }
        }
    }
    private void Update()
    {
        if (!GameManager.Instance.tutoState)
        {
            if (transform.childCount <= 0)
            {
                Instantiate(prefabIngredient, transform.position, Quaternion.identity, transform);
            }
        }
        else
        {
            if (name == "NymphTearSpawner")
            {
                if (transform.childCount <= 1 && StateManager.Instance.oneTear)
                {
                    GameObject gameObject = Instantiate(prefabIngredient, transform.position, Quaternion.identity, transform);
                }
            }
        }

        if (GameManager.Instance.tutoState)
        {
            if (StateManager.Instance.CurrentState == 8)
            {
                foreach (Transform child in transform)
                {
                    if (child.name == "Trigger" || child.name == "NymphTear(Clone)")
                    {
                        child.gameObject.SetActive(true);
                    }
                    else
                    {
                        child.gameObject.SetActive(false);
                    }
                }
            }
            else if (StateManager.Instance.CurrentState == 9)
            {
                foreach (Transform child in transform)
                {
                    if (child.name == "Trigger" || child.name == "NymphTear(Clone)")
                    {
                        child.gameObject.SetActive(false);
                    }
                    else
                    {
                        child.gameObject.SetActive(true);
                    }
                }

            }
        }
    }
}
