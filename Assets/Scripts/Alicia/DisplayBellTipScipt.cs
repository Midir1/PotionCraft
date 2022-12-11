using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayBellTipScipt : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.tipIsAvailable)
        {
            foreach (Transform child in transform)
            {
                if(child.name == "Tip")
                child.gameObject.SetActive(true);
            }
        }
        if (GameManager.Instance.bellIsAvailable)
        {
            foreach (Transform child in transform)
            {
                if (child.name == "Bell")
                    child.gameObject.SetActive(true);
            }
        }
    }
}
