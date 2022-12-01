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
        Debug.Log(speech.Count);
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            currentState++;
            if (currentState > lastState)
                currentState = 0;
        }
    }
}
