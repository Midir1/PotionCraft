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
        PaternMax,
    }
    [SerializeField] Patern patern = Patern.NotInitialized;


    [SerializeField] Object pointToInstantiate;
    [SerializeField] Canvas canva;

    Vector2[] pathToCopy;

    bool flagTouchBegan = false;
    
    List<Object> arrPoint = new List<Object>();
    [SerializeField] float radiusCollision;
     bool flag = false;
    List<Object> arrFingerPath = new List<Object>();
    float actualDistBTWpoint;
    [SerializeField] float distBTWpoint;
    Vector2 lastPointPos;


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
                for (int i = 0; i < arrPoint.Count; i++)
                {
                    Object point = arrPoint[i];
                    Vector2 pointPos = point.GetComponent<Transform>().position;
                    float distColiision = Vector2.Distance(fingerPos, pointPos);
                    if (distColiision < radiusCollision)
                    {
                        //3 - angle fingerFoward / pointFoward
                        //dont chek engle if last point
                        if (arrPoint.Count <= i + 1)
                        {
                            flag = true;
                            break;
                        }
                        Vector2 pointFoward = pointPos - (Vector2)arrPoint[i + 1].GetComponent<Transform>().position;
                        float angle = Vector3.Angle(pointFoward, fingerFoward);
                        if (angle < 30f)
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
