using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class InputPaternRecognition : MonoBehaviour
{

    [SerializeField] Object pointToInstantiate;
    [SerializeField] Canvas canva;

    Vector2[] path = { new Vector2(-0.3490258f, 2.7886f), new Vector2(0.08387457f, 2.680376f), new Vector2(0.2281747f, 2.608225f), new Vector2(0.5348125f, 2.42785f), new Vector2(0.7873378f, 2.049062f), new Vector2(0.8955628f, 1.652237f), new Vector2(0.9496754f, 1.345599f), new Vector2(0.9677128f, 1.002886f), new Vector2(0.9496754f, 0.4256856f), new Vector2(0.9136002f, 0.2092355f), new Vector2(0.7512629f, -0.2056274f), new Vector2(0.6069625f, -0.4040402f), new Vector2(0.3003248f, -0.7647905f), new Vector2(0.101912f, -0.9090903f), new Vector2(-0.2227633f, -1.143578f), new Vector2(-0.6195887f, -1.305916f), new Vector2(-0.9081889f, -1.305916f) };

    List<Object> arrPoint = new List<Object>();

    //Drawing
    List<Object> arrDrawing = new List<Object>();
    float actualDistBTWpoint;
    [SerializeField] float distBTWpoint;
    Vector2 lastPointPos;



    void Start()
    {

        foreach (Vector2 pos in path)
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
            if (touch.phase == TouchPhase.Began)
            {
                //prepare for the new drawing
                actualDistBTWpoint = distBTWpoint;
                Vector2 fingerPos = Camera.main.ScreenToWorldPoint(touch.position);
                lastPointPos = fingerPos;
            }
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 fingerPos = Camera.main.ScreenToWorldPoint(touch.position);

                //colition btw finger and point
                foreach (Object point in arrPoint)
                {
                    Vector2 pointPos = point.GetComponent<Transform>().position;
                    float distColiision = Vector2.Distance(fingerPos, pointPos);

                    if (distColiision < 0.2f)
                    {
                        Destroy(point);
                        arrPoint.Remove(point);
                        break;
                    }
                }
                //Drawing
                float distDrawing = Vector2.Distance(fingerPos, lastPointPos);
                if (distDrawing > actualDistBTWpoint)
                {
                    Object circleCopy = Instantiate(pointToInstantiate, fingerPos, Quaternion.identity, canva.transform);
                    UnityEngine.Color color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
                    circleCopy.GetComponent<Image>().color = color;
                    arrDrawing.Add(circleCopy);
                    lastPointPos = fingerPos;
                    //so that point are seperated by the sabe distance
                    actualDistBTWpoint = distBTWpoint - (distDrawing - actualDistBTWpoint);
                }
            }
            if (touch.phase == TouchPhase.Ended)
            {
                if (arrPoint.Count == 0)
                {
                    Debug.Log("braval");
                }
                else
                {
                    Debug.Log(arrPoint.Count);
                    //clear the last path
                    arrPoint.ForEach(Destroy);
                    arrPoint.Clear();
                    arrDrawing.ForEach(Destroy);
                    arrDrawing.Clear();
                    //recrate arrPoint 
                    foreach (Vector2 pos in path)
                    {
                        Object circleCopy = Instantiate(pointToInstantiate, pos, Quaternion.identity, canva.transform);
                        arrPoint.Add(circleCopy);
                    }
                }

            }

            }


    }

    void ClearLastPath()
    {
        arrPoint.ForEach(Destroy);
        arrPoint.Clear();
    }

}
