using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;



public class createNewPatern : MonoBehaviour
{

    Vector2 posScreen;
    Vector2 pos;
    Vector2 posLastPoint;

    [SerializeField] RuneList.Patern patern;

    [SerializeField] float distBTWpoint;
    float actualDistBTWpoint;

    Touch touch;

    [SerializeField] Canvas canva;
    [SerializeField] Object point;

    Transform origin;

    List<Vector2> path = new List<Vector2>();
    List<Object> arrPoint = new List<Object>();


    Vector2 []arrTemp = {  new Vector2(3f, 3f ), new Vector2(3f, 3f) };
    List<Vector2> patern1;


    void Start()
    {
        patern1 = new List<Vector2>(arrTemp);
        
        origin = canva.transform.Find("RuneShape");
        canva.GetComponentInChildren<RunePathImage>().SetPatern(patern);
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            pos = Camera.main.ScreenToWorldPoint(touch.position) - transform.position;
            if (touch.phase == TouchPhase.Began)
            {
                //clear the last path
                arrPoint.ForEach(Destroy);
                arrPoint.Clear();
                path.Clear();
                //prepare for the new path
                actualDistBTWpoint = distBTWpoint;
                posLastPoint = pos;
            }

            if (touch.phase == TouchPhase.Moved)
            {   
                float distance = (posLastPoint.x - pos.x) * (posLastPoint.x - pos.x) + (posLastPoint.y - pos.y) * (posLastPoint.y - pos.y);
                
                if (distance > actualDistBTWpoint)
                {

                    Object circleCopy = Instantiate(point, new Vector2(transform.position.x + pos.x , transform.position.y + pos.y), Quaternion.identity, origin);
                    arrPoint.Add(circleCopy);
                    path.Add(pos);
                    posLastPoint = pos;
                   //so that point are seperated by the sabe distance
                    actualDistBTWpoint = distBTWpoint - ( distance - actualDistBTWpoint);
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {
                Debug.Log("yeehaaa");
                logRune();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("yeehaaa");
            logRune();
        }
    }

    
    void logRune()
    {
        string result = "List contents: ";
        foreach (Vector2 item in path)
        {
            //new Vector2(3f, 3f), this is result
            result += " new Vector2(" + item.x.ToString(CultureInfo.InvariantCulture.NumberFormat) + "f, " + item.y.ToString(CultureInfo.InvariantCulture.NumberFormat) + "f),";
        }

        Debug.Log(result);
    }

}


