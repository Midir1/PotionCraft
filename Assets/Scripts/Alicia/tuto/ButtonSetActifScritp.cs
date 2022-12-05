using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSetActifScritp : MonoBehaviour
{
    [SerializeField] int activeState = 0;
    [SerializeField] bool OneTime = true;

    private void Start()
    {
        GetComponent<Button>().interactable = false;
    }
    void Update()
    {
        if (StateManager.Instance.CurrentState == activeState)
            GetComponent<Button>().interactable = true;
        if (OneTime && StateManager.Instance.CurrentState == (activeState + 1))
            GetComponent<Button>().interactable = false;
    }
}
