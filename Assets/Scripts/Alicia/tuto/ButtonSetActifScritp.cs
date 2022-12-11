using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSetActifScritp : MonoBehaviour
{
    [SerializeField] int activeState = 0;

    private void Start()
    {
        GetComponent<Button>().interactable = false;
    }
    void Update()
    {
        if (StateManager.Instance.CurrentState == activeState)
            GetComponent<Button>().interactable = true;
        else if (StateManager.Instance.CurrentState != activeState)
            GetComponent<Button>().interactable = false;
    }
}
