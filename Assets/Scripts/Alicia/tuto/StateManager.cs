using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{

    #region Attributes

    public int potionTutoEnd;
    public bool oneTear ;
    public bool spawnClient ;
    public bool succesRune ;
    [SerializeField] int currentState;
    [SerializeField] int lastState;
    [SerializeField] List<string> speech;
    [SerializeField] GameObject potion;
    [SerializeField] GameObject drawPanel;
    [SerializeField] GameObject inputManager;
    private static StateManager instance;
    public AK.Wwise.Event stopMusic;

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
            if (speech.Count < i + 1)
                speech.Add("");
        }
        potionTutoEnd = 3;
        oneTear = true;
        spawnClient = false;
        succesRune = false;
        currentState = 0;
        lastState = 18;
    }

    public void ButtonGrimoir()
    {
        if (currentState == 6)
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
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {

            if (currentState <= 5 || currentState == 17 || currentState == 10)
            {
                if (currentState <= lastState)
                    currentState++;
            }
            else if (currentState == 11)
            {
                currentState++;
                potion.SetActive(true);
            }
            else if (currentState == 13)
                currentState++;
            else if (currentState == lastState)
            {
                stopMusic.Post(gameObject);
                GameManager.Instance.tutoState = false;
                SceneManager.LoadSceneAsync("OriginalMergeScene");
            }

        }

        if (currentState == 8 && potionTutoEnd == 0)
        {
            currentState++;

            drawPanel.SetActive(true);
            inputManager.SetActive(true);

            InputPaternRecognition inputPaternRecognition = inputManager.GetComponent<InputPaternRecognition>();
            inputPaternRecognition.SetPatern(RuneList.Patern.balais);
        }
        else if(currentState == 9 && succesRune)
        {
            currentState++;
            drawPanel.SetActive(false);
            inputManager.SetActive(false);
        }
        else if (currentState == 12)
        {
                currentState++;
        }
            
        


    }
}
