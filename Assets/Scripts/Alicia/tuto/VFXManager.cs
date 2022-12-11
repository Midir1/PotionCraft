using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    void Update()
    {
        if(StateManager.Instance.CurrentState == 14 )
        {
            foreach(Transform child in transform)
            {
                if(child.name == "VFX_Fleche_bas_scroll")
                child.gameObject.SetActive(true);
            }
        }
        else if (StateManager.Instance.CurrentState == 15)
        {
            foreach (Transform child in transform)
            {
                if (child.name == "VFX_Fleche_bas_scroll")
                    child.gameObject.SetActive(false);
            }
        }
        else if (StateManager.Instance.CurrentState == 8)
        {
            foreach (Transform child in transform)
            {
                if (child.name == "VFX_Fleche_bas")
                    child.gameObject.SetActive(true);
            }
        }
        else if (StateManager.Instance.CurrentState == 9)
        {
            foreach (Transform child in transform)
            {
                if (child.name == "VFX_Fleche_bas")
                    child.gameObject.SetActive(false);
            }
        }
    }

}
