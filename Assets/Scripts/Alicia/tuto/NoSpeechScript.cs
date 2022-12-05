using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoSpeechScript : MonoBehaviour
{
    void Update()
    {
        switch(StateManager.Instance.CurrentState)
        {
            case 8:
                foreach (Transform child in transform)
                {
                    if (child.name != "@StateManager")
                        child.gameObject.SetActive(false);
                }
                break;
            case 9:
                foreach (Transform child in transform)
                {
                    if (child.name != "@StateManager")
                        child.gameObject.SetActive(true);
                }
                break;
            case 12:
                foreach (Transform child in transform)
                {
                    if (child.name != "@StateManager")
                        child.gameObject.SetActive(false);
                }
                break;
            case 13:
                foreach (Transform child in transform)
                {
                    if (child.name != "@StateManager")
                        child.gameObject.SetActive(true);
                }
                break;
        }


    }
}
