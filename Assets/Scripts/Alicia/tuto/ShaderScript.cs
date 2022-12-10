using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShaderScript : MonoBehaviour
{
    [SerializeField] private int state;
    [SerializeField] private Material material;
    void Start()
    {
    }
    void Update()
    {
        if (StateManager.Instance.CurrentState == state)
            GetComponent<Image>().material = material;
        else
             GetComponent<Image>().material = null;
    }
}
