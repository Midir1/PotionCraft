using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopTuto : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.tutoState && StateManager.Instance.CurrentState == 15 && GetComponent<Canvas>().enabled)
        {
            StateManager.Instance.CurrentState++;
        }
    }
}
