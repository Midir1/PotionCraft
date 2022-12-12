using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeTutoState : MonoBehaviour
{
    public bool isTuto;

    private GameManager gameManager;
    
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        if (isTuto) gameManager.tutoState = true;
        else gameManager.tutoState = false;
    }
}
