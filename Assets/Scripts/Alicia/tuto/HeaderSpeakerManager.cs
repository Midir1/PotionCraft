using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeaderSpeakerManager : MonoBehaviour
{
    void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.name != "HeadHubertNormal")
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
        else if (StateManager.Instance.CurrentState == 4)
        {
            foreach (Transform child in transform)
            {
                if (child.name != "HeadHubertAvide")
                    child.gameObject.SetActive(false);
                else
                    child.gameObject.SetActive(true);
            }
        }
        else if (StateManager.Instance.CurrentState == 5)
        {
            foreach (Transform child in transform)
            {
                if (child.name != "HeadHubertWise")
                    child.gameObject.SetActive(false);
                else
                    child.gameObject.SetActive(true);
            }
        }
        else if (StateManager.Instance.CurrentState == 6)
        {
            foreach (Transform child in transform)
            {
                if (child.name != "HeadHubertSorry")
                    child.gameObject.SetActive(false);
                else
                    child.gameObject.SetActive(true);
            }
        }
        else if (StateManager.Instance.CurrentState == 9)
        {
            foreach (Transform child in transform)
            {
                if (child.name != "HeadHubertWise")
                    child.gameObject.SetActive(false);
                else
                    child.gameObject.SetActive(true);
            }
        }
        else if (StateManager.Instance.CurrentState == 10)
        {
            foreach (Transform child in transform)
            {
                if (child.name != "HeadHubertSmile")
                    child.gameObject.SetActive(false);
                else
                    child.gameObject.SetActive(true);
            }
        }
        else if (StateManager.Instance.CurrentState == 11)
        {
            foreach (Transform child in transform)
            {
                if (child.name != "HeadHubertNormal")
                    child.gameObject.SetActive(false);
                else
                    child.gameObject.SetActive(true);
            }
        }
        else if (StateManager.Instance.CurrentState == 13)
        {
            foreach (Transform child in transform)
            {
                if (child.name != "HeadClient2")
                    child.gameObject.SetActive(false);
                else
                    child.gameObject.SetActive(true);
            }
        }
        else if (StateManager.Instance.CurrentState == 14)
        {
            foreach (Transform child in transform)
            {
                if (child.name != "HeadHubertAvide")
                    child.gameObject.SetActive(false);
                else
                    child.gameObject.SetActive(true);
            }
        }
        else if (StateManager.Instance.CurrentState == 15)
        {
            foreach (Transform child in transform)
            {
                if (child.name != "HeadHubertNormal")
                    child.gameObject.SetActive(false);
                else
                    child.gameObject.SetActive(true);
            }
        }
        else if (StateManager.Instance.CurrentState == 16)
        {
            foreach (Transform child in transform)
            {
                if (child.name != "HeadHubertSmile")
                    child.gameObject.SetActive(false);
                else
                    child.gameObject.SetActive(true);
            }
        }
        else if (StateManager.Instance.CurrentState == 17)
        {
            foreach (Transform child in transform)
            {
                if (child.name != "HeadHubertSorry")
                    child.gameObject.SetActive(false);
                else
                    child.gameObject.SetActive(true);
            }
        }
    }
}
