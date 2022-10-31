using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;


public class InputPaternRecognition : MonoBehaviour
{
    enum Patern
    {
        NotInitialized,
        C,
        Z,
        B,
        PaternMax,
    }
    [SerializeField] Patern patern = Patern.NotInitialized;


    [SerializeField] Object pointToInstantiate;
    [SerializeField] Canvas canva;

    Vector2[] pathToCopy;


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

        switch (patern)
        {
            case Patern.C:
                pathToCopy = new Vector2[] { new Vector2(-0.3490258f, 2.7886f), new Vector2(0.08387457f, 2.680376f), new Vector2(0.2281747f, 2.608225f), new Vector2(0.5348125f, 2.42785f), new Vector2(0.7873378f, 2.049062f), new Vector2(0.8955628f, 1.652237f), new Vector2(0.9496754f, 1.345599f), new Vector2(0.9677128f, 1.002886f), new Vector2(0.9496754f, 0.4256856f), new Vector2(0.9136002f, 0.2092355f), new Vector2(0.7512629f, -0.2056274f), new Vector2(0.6069625f, -0.4040402f), new Vector2(0.3003248f, -0.7647905f), new Vector2(0.101912f, -0.9090903f), new Vector2(-0.2227633f, -1.143578f), new Vector2(-0.6195887f, -1.305916f), new Vector2(-0.9081889f, -1.305916f) };
                break;
            case Patern.Z:
                pathToCopy = new Vector2[] { new Vector2(-0.7097762f, 2.247475f), new Vector2(-0.006312944f, 2.247475f), new Vector2(0.7151877f, 2.265512f), new Vector2(1.418651f, 2.28355f), new Vector2(0.8234127f, 1.778499f), new Vector2(0.3183625f, 1.399712f), new Vector2(-0.2227633f, 0.9668112f), new Vector2(-0.7278138f, 0.4617608f), new Vector2(-1.232864f, -0.04328966f), new Vector2(-0.5474386f, 0.08297265f), new Vector2(0.1560246f, 0.1370853f), new Vector2(0.8594878f, 0.1370853f), new Vector2(1.599026f, 0.1370853f) };
                break;
            case Patern.B:
                pathToCopy = new Vector2[] { new Vector2(-0.9934571f, -2.940771f), new Vector2(-1.010675f, -2.561983f), new Vector2(-1.010675f, -2.183195f), new Vector2(-0.9934571f, -1.821625f), new Vector2(-0.9762397f, -1.425619f), new Vector2(-0.959022f, -1.06405f), new Vector2(-0.9418043f, -0.6852615f), new Vector2(-0.9073691f, -0.2892557f), new Vector2(-0.8901514f, 0.08953214f), new Vector2(-0.8729339f, 0.4683203f), new Vector2(-0.8557162f, 0.8815426f), new Vector2(-0.8557162f, 1.260331f), new Vector2(-0.8557162f, 1.690772f), new Vector2(-0.8557162f, 2.017906f), new Vector2(-0.8384985f, 2.396694f), new Vector2(-0.821281f, 2.775482f), new Vector2(-0.821281f, 3.15427f), new Vector2(-0.5113637f, 2.896006f), new Vector2(-0.2530992f, 2.586088f), new Vector2(-0.01205233f, 2.327824f), new Vector2(0.2806474f, 2.052342f), new Vector2(0.5389119f, 1.77686f), new Vector2(0.7455235f, 1.432507f), new Vector2(0.5216942f, 1.139808f), new Vector2(0.1429065f, 0.915978f), new Vector2(-0.1497935f, 0.7093668f), new Vector2(-0.4769283f, 0.502755f), new Vector2(-0.8040633f, 0.3477961f), new Vector2(-0.5974517f, 0.02066135f), new Vector2(-0.3047521f, -0.2720383f), new Vector2(-0.08092292f, -0.5819553f), new Vector2(0.1429065f, -0.8746555f), new Vector2(0.3839533f, -1.167355f), new Vector2(0.6766528f, -1.442837f), new Vector2(0.3150826f, -1.632231f), new Vector2(0.03960051f, -1.890495f), new Vector2(-0.218664f, -2.165978f), new Vector2(-0.4941459f, -2.44146f), new Vector2(-0.7696282f, -2.716942f) };
                break;
            case Patern.NotInitialized: Debug.LogWarning("Initialize patern"); break;
        }
        foreach (Vector2 pos in pathToCopy)
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
                //prepare for the new drawing
                actualDistBTWpoint = distBTWpoint;
                lastPointPos = fingerPos;
                //Collision finger / starPoint
                Vector2 startPointPos = arrPoint[0].GetComponent<Transform>().position;
                float distColiision = Vector2.Distance(fingerPos, startPointPos);
                if (!(distColiision < radiusCollision))
                {
                    ClearPath();
                }
            }
            if (flagTouchBegan)
            {
                CheckIfOnPathAngleCollision();
            }
        }
    }

    void ClearPath()
    {
        //clear the last path
        arrPoint.ForEach(Destroy);
        arrPoint.Clear();
        arrFingerPath.ForEach(Destroy);
        arrFingerPath.Clear();
        //recrate arrPoint 
        foreach (Vector2 pos in pathToCopy)
        {
            Object circleCopy = Instantiate(pointToInstantiate, pos, Quaternion.identity, canva.transform);
            arrPoint.Add(circleCopy);
        }
        Debug.Log("You Fail");
        flagTouchBegan = false;
    }

    void draw(Vector2 _pos)
    {
        Object circleCopy = Instantiate(pointToInstantiate, _pos, Quaternion.identity, canva.transform);
        UnityEngine.Color color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        circleCopy.GetComponent<Image>().color = color;
        arrFingerPath.Add(circleCopy);
    }

    void CheckIfOnPathSimple()
    {
        //    Touch touch = Input.GetTouch(0);
        //    Vector2 fingerPos = Camera.main.ScreenToWorldPoint(touch.position);

        //    if (touch.phase == TouchPhase.Moved)
        //    {
        //        //colition btw finger and point
        //        bool atLestOnePointTutched = false;
        //        for (int i = 0; i < arrPoint.Count; i++)
        //        {
        //            Object point = arrPoint[i];
        //            Vector2 pointPos = point.GetComponent<Transform>().position;
        //            float distColiision = Vector2.Distance(fingerPos, pointPos);
        //            if (distColiision < radiusCollision)
        //            {
        //                if (point.GetComponent<Image>())
        //                {
        //                    if (i == 0 || !arrPoint[i - 1].GetComponent<Image>())
        //                    {
        //                        Destroy(point.GetComponent<Image>());
        //                        if (i == arrPoint.Count - 1)
        //                        {
        //                            Braval();
        //                        }
        //                    }
        //                    else
        //                    {
        //                        ClearLastPath();
        //                        break;
        //                    }
        //                }

        //                atLestOnePointTutched = true;
        //            }
        //        }
        //        if (!atLestOnePointTutched)
        //        {
        //            ClearLastPath();
        //        }
        //    }

        //    if (touch.phase == TouchPhase.Ended)
        //    {
        //        if (arrPoint.Count != 0)
        //        {
        //            ClearLastPath();
        //        }
        //    }
    }

    void CheckIfOnPathAngleCollision()
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
                draw(fingerPos);
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
                Braval();
            }
            else
            {
                ClearPath();
            }
        }
    }

    void Braval()
    {
        Debug.Log("Bravo");
    }

    void SetPatern(Patern _patern)
    {
        patern = _patern;
    }


}
