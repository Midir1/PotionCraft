using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static RuneList;
using static UnityEngine.GraphicsBuffer;


public class InputPaternRecognition : MonoBehaviour
{
    [SerializeField] Object pointToInstantiate;
    [SerializeField] Object lineToInstantiate;

    [SerializeField] RuneList runeList;
    [SerializeField] Patern patern = Patern.NotInitialized;
    [SerializeField] private Transform parentTransform;

    Object line;
    RuneDrawLine runeDrawLine;

    //Ptc Point To Check
    [SerializeField] int numPtc;
    [SerializeField] float radiusCollision;
    [SerializeField] float distBTWpoint;
    [SerializeField] float angleLimit;

    float actualDistBTWpoint;

    Vector2 lastPointPos;

    List<Object> arrPointRune = new List<Object>();
    List<Vector2> arrPointLine = new List<Vector2>();
    Vector2[] rune;

    bool flag = false;

    [HideInInspector] public Inventory inventory;

    void Start()
    {
        rune = runeList.GetRune(patern);
        InitRuneDisplay();
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 fingerPos = Camera.main.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {

            }
            else if (touch.phase == TouchPhase.Moved)
            {
                DrawLine();
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                CheckIfOnPath();
            }
        }
    }



    void DrawLine()
    {
        Touch touch = Input.GetTouch(0);
        Vector2 fingerPos = Camera.main.ScreenToWorldPoint(touch.position) - transform.position;

        if (arrPointLine.Count == 0)
        {
            line = Instantiate(lineToInstantiate, gameObject.transform);
            runeDrawLine = line.GetComponent<RuneDrawLine>();

            arrPointLine.Add(fingerPos);
            //ici on dessine
            //runeDrawLine.newLineVertex(fingerPos);

            actualDistBTWpoint = distBTWpoint;
            lastPointPos = fingerPos;
        }

        float distFinger = Vector2.Distance(fingerPos, lastPointPos);
        if (distFinger > actualDistBTWpoint)
        {
            flag = false;

            arrPointLine.Add(fingerPos);
            //ici on dessine
            runeDrawLine.newLineVertex(fingerPos);

            // Vector2 fingerFoward = lastPointPos - fingerPos;
            lastPointPos = fingerPos;
            //so that point are seperated by the same distance
            actualDistBTWpoint = distBTWpoint - (actualDistBTWpoint - distFinger);
        }
    }

    void CheckIfOnPath()
    {
        //premier point sur premier point
        if (arrPointLine.Count <= 0)
        {
            return;
        }
        if (!(Vector2.Distance(arrPointLine[0], rune[0]) < radiusCollision))
        {
            Failure();
            return;
        }

        //Test in 2 part
        //1 - collision finger/ point
        //2 - angle fingerFoward / pointFoward

        Touch touch = Input.GetTouch(0);
        Vector2 fingerPos = Camera.main.ScreenToWorldPoint(touch.position);

        int furthestPointTutched = 0;
        
        for (int i = 0; i < arrPointLine.Count; i++)
        {
            //1 - collision finger/ point
            //check only point around furthest point tutched
            // Ptc For PointToCheck

            int tempFPT = furthestPointTutched;
            for (int ii = (tempFPT - numPtc); ii <= (tempFPT + numPtc); ii++)
            {
                if (ii < 0)
                {
                    ii = 1;
                }
                else if (ii >= rune.Length)
                {
                    break;
                }

                float distColiision = Vector2.Distance(arrPointLine[i], rune[ii]);

                if (distColiision < radiusCollision)
                {
                    if (ii > furthestPointTutched)
                    {
                        furthestPointTutched = ii;
                    }
                    //2 - angle fingerFoward / pointFoward
                    //last Rune point
                    if (ii >= rune.Length -1 )
                    {
                        flag = true;
                        Success();
                        return;
                    }
                    //first line point
                    if (i < 1)
                    {
                        flag = true;
                        break;
                    }

                    Vector2 runeFoward = rune[ii] - rune[ii + 1];
                    Vector2 LineFoward = arrPointLine[i - 1] - arrPointLine[i];
                    float angleRuneLine = Vector3.Angle(runeFoward, LineFoward);
                    if (angleRuneLine < angleLimit)
                    {
                        flag = true;
                    }
                }
            }
            //you fail
            if (!flag)
            {
                Failure();
            }
            flag = false;
        }
        //you fail if you dont win
        Failure();
    }


    void ClearPath()
    {
        //clear the last path
        line = null;
        arrPointLine.Clear();
       
    }


    public void SetPatern(Patern _patern)
    {
        patern = _patern;
        InitRuneDisplay();
    }

    void Success()
    {
        inventory.BeginCraftPotion();
        
        runeDrawLine.Braval();
        ClearPath();
    }

    void Failure()
    {
        runeDrawLine.Fail();
        ClearPath();
    }

    void InitRuneDisplay()
    {
        arrPointRune.ForEach(Destroy);
        arrPointRune.Clear();

        rune = runeList.GetRune(patern);

        bool firstPoint = true;
        foreach (Vector2 pos in rune)
        {
            Object circleCopy = Instantiate(pointToInstantiate, pos + (Vector2)transform.position, Quaternion.identity, parentTransform);
            if (firstPoint)
            {
                circleCopy.GetComponent<CanvasRenderer>().SetColor(UnityEngine.Color.red);
                firstPoint = false;
            }
            arrPointRune.Add(circleCopy);
        }
    }

    
}