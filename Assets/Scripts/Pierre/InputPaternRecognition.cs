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
    [SerializeField] Canvas canva;
    [SerializeField] Object pointToInstantiate;
    [SerializeField] Object lineToInstantiate;

    [SerializeField] RuneList runeList;
    [SerializeField] Patern patern = Patern.NotInitialized;

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

    void Start()
    {
        rune = runeList.GetRune(patern);

        foreach (Vector2 pos in rune)
        {
            Object circleCopy = Instantiate(pointToInstantiate, pos, Quaternion.identity, canva.transform);
            arrPointRune.Add(circleCopy);
        }
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
        Vector2 fingerPos = Camera.main.ScreenToWorldPoint(touch.position);

        if (arrPointLine.Count == 0)
        {
            line = Instantiate(lineToInstantiate);
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
            Debug.Log("premier point return");
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
                    Debug.Log("ii-");
                    ii = 1;
                }
                else if (ii >= rune.Length)
                {
                    Debug.Log("ii+");
                    break;
                }

                float distColiision = Vector2.Distance(arrPointLine[i], rune[ii]);

                if (distColiision < radiusCollision)
                {
                    if (ii > furthestPointTutched)
                    {
                        furthestPointTutched = ii;
                    }
                    Debug.Log("test collision");
                    //2 - angle fingerFoward / pointFoward
                    //last Rune point
                    if (ii >= rune.Length -1 )
                    {
                        Debug.Log("flag last Rune Point");
                        flag = true;
                        Success();
                        return;
                    }
                    //first line point
                    if (i < 1)
                    {
                        Debug.Log("flag First line point");
                        flag = true;
                        break;
                    }

                    Vector2 runeFoward = rune[ii] - rune[ii + 1];
                    Vector2 LineFoward = arrPointLine[i - 1] - arrPointLine[i];
                    float angleRuneLine = Vector3.Angle(runeFoward, LineFoward);
                    if (angleRuneLine < angleLimit)
                    {
                        flag = true;
                        Debug.Log("flag Angle");
                    }
                }
            }
            //you fail
            if (!flag)
            {
                Debug.Log("end");
                Failure();
            }
            flag = false;
        }
        //you fail if you dont win
        Debug.Log("you fail if you dont win");
        Failure();
    }


    void ClearPath()
    {
        //clear the last path
        line = null;
        arrPointRune.ForEach(Destroy);
        arrPointRune.Clear();
        arrPointLine.Clear();
        //recrate arrPoint 
        foreach (Vector2 pos in rune)
        {
            Object circleCopy = Instantiate(pointToInstantiate, pos, Quaternion.identity, canva.transform);
            arrPointRune.Add(circleCopy);
        }
    }


    void SetPatern(Patern _patern)
    {
        patern = _patern;

        arrPointRune.ForEach(Destroy);
        arrPointRune.Clear();

        rune = runeList.GetRune(patern);

        foreach (Vector2 pos in rune)
        {
            Object circleCopy = Instantiate(pointToInstantiate, pos, Quaternion.identity, canva.transform);
            arrPointRune.Add(circleCopy);
        }
    }

    void Success()
    {
        runeDrawLine.Braval();
        ClearPath();
    }

    void Failure()
    {
        runeDrawLine.Fail();
        ClearPath();
    }


}