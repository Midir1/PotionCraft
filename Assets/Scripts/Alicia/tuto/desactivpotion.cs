using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desactivpotion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (StateManager.Instance.CurrentState == 13)
        {
            foreach (Transform child in transform)
            {
                Debug.Log(child.gameObject.name);
                child.gameObject.SetActive(false);
            }
        }
        
    }
}
