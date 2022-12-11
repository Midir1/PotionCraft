using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeaderSpeakerManager : MonoBehaviour
{
    void Start()
    {
        foreach (Transform child in transform)
        {
            //wellcom
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
            //citrouille
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
            //HuberExclamation
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
            //sad
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
            //welcom
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
            //welcom
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
            //pumkin
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
            //hub exclam
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
            //Welcom
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
            //Welcom
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
            //sad hub
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
