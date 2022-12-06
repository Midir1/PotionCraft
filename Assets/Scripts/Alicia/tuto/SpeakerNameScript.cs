using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeakerNameScript : MonoBehaviour
{
    private TextMeshProUGUI nameValue;
    void Start()
    {
        nameValue = gameObject.GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        if(StateManager.Instance.CurrentState == 2 || StateManager.Instance.CurrentState == 3 || StateManager.Instance.CurrentState == 13)
        {
            nameValue.text = "Client";
        }
        else
        {
            nameValue.text = "Hubert";
        }
    }
}
