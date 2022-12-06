using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{

    #region Attributes

    [SerializeField] int currentState = 0;
    [SerializeField] int lastState = 16;
    [SerializeField] List<string> speech;
    private static StateManager instance;
    public int potionTutoEnd;

    #endregion

    #region getters/setters

    public static StateManager Instance { get => instance; }
    public int LastState { get => lastState; set => lastState = value; }
    public int CurrentState { get => currentState; set => currentState = value; }
    public List<string> Speech { get => speech; set => speech = value; }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    #endregion

    private void Start()
    {
        for (int i = 0; i <= lastState; i++)
        {
            if (speech.Count < i+1)
                speech.Add("");
        }
        potionTutoEnd = 1;
    }

    public void ButtonGrimoir()
    {
        if(currentState == 6)
        {
            CurrentState++;
        }
    }
    public void ReturnButtonGrimoir()
    {
        if (currentState == 7)
        {
            CurrentState++;
        }
    }
    private void Update()
    {
        if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            if (currentState <= 5 || currentState  == 10 || currentState == 17)
            {
                currentState++;
                if (currentState > lastState)
                    currentState = 0;
            }
            //temporaire
            if (currentState == 9 || currentState == 10 || currentState == 11)
            {
                currentState++;
            }
        }
        if(currentState == 8 && potionTutoEnd == 0)
        {
            currentState++; 
        }

       
    }
}
