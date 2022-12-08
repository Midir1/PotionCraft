using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeechScript : MonoBehaviour
{
    private TextMeshProUGUI speechValue;
    void Start()
    {
        speechValue = gameObject.GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        if(GameManager.Instance.tutoState)
        speechValue.text = StateManager.Instance.Speech[StateManager.Instance.CurrentState];
    }
}
