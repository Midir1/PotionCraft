using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeaderSpeakerManager : MonoBehaviour
{
    void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.name != "HeadHubert1")
                child.gameObject.SetActive(false);
            else
                child.gameObject.SetActive(true);
        }
    }
    void Update()
    {
        if (StateManager.Instance.CurrentState == 2)
        {
            foreach (Transform child in transform)
            {
                if (child.name != "HeadClient1")
                    child.gameObject.SetActive(false);
                else
                    child.gameObject.SetActive(true);
            }
        }
        else if (StateManager.Instance.CurrentState == 3)
        {
            foreach (Transform child in transform)
            {
                if (child.name != "HeadHubert1")
                    child.gameObject.SetActive(false);
                else
                    child.gameObject.SetActive(true);
            }
        }
        else if (StateManager.Instance.CurrentState == 12)
        {
            foreach (Transform child in transform)
            {
                if (child.name != "HeadClient2")
                    child.gameObject.SetActive(false);
                else
                    child.gameObject.SetActive(true);
            }
        }
        else if (StateManager.Instance.CurrentState == 13)
        {
            foreach (Transform child in transform)
            {
                if (child.name != "HeadHubert1")
                    child.gameObject.SetActive(false);
                else
                    child.gameObject.SetActive(true);
            }
        }
    }
}
