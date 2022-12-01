using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    [SerializeField]int nbRebond = 5;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        nbRebond--;

        if (nbRebond == 0)
        {
            Destroy(gameObject.GetComponent<Rigidbody2D>()); 
        }
    }
}
