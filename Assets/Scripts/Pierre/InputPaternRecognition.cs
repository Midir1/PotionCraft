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
    [SerializeField] RuneList runeList;
    [SerializeField] Patern patern = Patern.NotInitialized;

    [SerializeField] Object lineToInstantiate;
    Object line;
    RuneDrawLine runeDrawLine;
    [SerializeField] Object pointToInstantiate;
    [SerializeField] Canvas canva;

    Vector2[] baseRune;


    bool flag = false;
    bool flagTouchBegan = false;
    //Ptc Point To Check
    [SerializeField] int numPtc;
     int midlePtc;
    List<Object> arrPoint = new List<Object>();
    [SerializeField] float radiusCollision;

    List<Object> arrFingerPath = new List<Object>();
    float actualDistBTWpoint;
    [SerializeField] float distBTWpoint;
    Vector2 lastPointPos;

    [SerializeField] float angle;


    void Start()
    {
        baseRune = runeList.GetRune(patern);
        
        foreach (Vector2 pos in baseRune)
        {
            Object circleCopy = Instantiate(pointToInstantiate, pos, Quaternion.identity, canva.transform);
            arrPoint.Add(circleCopy);
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
                flagTouchBegan = true;
                midlePtc = (int)numPtc / 2;

                line = Instantiate(lineToInstantiate);
                runeDrawLine = line.GetComponent<RuneDrawLine>();

                actualDistBTWpoint = distBTWpoint;
                lastPointPos = fingerPos;

                //Collision finger / starPoint
                Vector2 startPointPos = arrPoint[0].GetComponent<Transform>().position;
                float distColiision = Vector2.Distance(fingerPos, startPointPos);
                if (!(distColiision < radiusCollision))
                {
                    runeDrawLine.Fail();
                    ClearPath();
                }
            }
            if (flagTouchBegan)
            {
                CheckIfOnPath();
            }
        }
    }

    void ClearPath()
    {
        //clear the last path
        line = null;
        arrPoint.ForEach(Destroy);
        arrPoint.Clear();
        arrFingerPath.ForEach(Destroy);
        arrFingerPath.Clear();
        //recrate arrPoint 
        foreach (Vector2 pos in baseRune)
        {
            Object circleCopy = Instantiate(pointToInstantiate, pos, Quaternion.identity, canva.transform);
            arrPoint.Add(circleCopy);
        }
        flagTouchBegan = false;
    }

    void drawPoint(Vector2 _pos)
    {
        Object circleCopy = Instantiate(pointToInstantiate, _pos, Quaternion.identity, canva.transform);
        UnityEngine.Color color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        circleCopy.GetComponent<Image>().color = color;
        arrFingerPath.Add(circleCopy);
    }


    void CheckIfOnPath()
    {
        //Test in 3 part
        //1 - dist btw check
        //2 - collision finger/ point
        //3 - angle fingerFoward / pointFoward

        Touch touch = Input.GetTouch(0);
        Vector2 fingerPos = Camera.main.ScreenToWorldPoint(touch.position);
        if (touch.phase == TouchPhase.Moved)
        {
            //1 - dist btw check
            float distFinger = Vector2.Distance(fingerPos, lastPointPos);
            if (distFinger > actualDistBTWpoint)
            {
                flag = false;

                //ici on dessine
                runeDrawLine.newLineVertex(fingerPos);

                Vector2 fingerFoward = lastPointPos - fingerPos;
                lastPointPos = fingerPos;
                //so that point are seperated by the same distance
                actualDistBTWpoint = distBTWpoint - (actualDistBTWpoint - distFinger);

                //2 - collision finger/ point
                //check only 3Points // Ptc For PointToCheck
                int currentPtc = midlePtc;
                for (int i = currentPtc - numPtc/2; i < currentPtc + numPtc/2; i++)
                {
                    if (i >= arrPoint.Count)
                        break;

                    Object point = arrPoint[i];
                    Vector2 pointPos = point.GetComponent<Transform>().position;
                    float distColiision = Vector2.Distance(fingerPos, pointPos);
                    if (distColiision < radiusCollision)
                    {
                        if (i > midlePtc)
                        {
                            midlePtc = i;
                        }
                        //3 - angle fingerFoward / pointFoward
                        //dont chek engle if last point
                        if (arrPoint.Count <= i + 1)
                        {
                            flag = true;
                            break;
                        }
                        Vector2 pointFoward = pointPos - (Vector2)arrPoint[i + 1].GetComponent<Transform>().position;
                        float anglePontFinger = Vector3.Angle(pointFoward, fingerFoward);
                        if (anglePontFinger < angle)
                        {
                            flag = true;
                        }
                    }
                }
                if (!flag)
                {
                    runeDrawLine.Fail();
                    ClearPath();
                }
            }
        }


        if (touch.phase == TouchPhase.Ended)
        {
            //Collision finger / endPoint
            Vector2 endPointPos = arrPoint[arrPoint.Count-1].GetComponent<Transform>().position;
            float distColiision = Vector2.Distance(fingerPos, endPointPos);
            if (distColiision < radiusCollision)
            {
                runeDrawLine.Braval();
                ClearPath();
            }
            else
            {
                runeDrawLine.Fail();
                ClearPath();
            }
        }
    }



    void SetPatern(Patern _patern)
    {
        patern = _patern;
    }


}
