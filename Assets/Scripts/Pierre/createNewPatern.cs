using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UnityEngine;
using UnityEngine.UI;



public class createNewPatern : MonoBehaviour
{

    Vector2 posScreen;
    Vector2 pos;
    Vector2 posLastPoint;

    [SerializeField] float distBTWpoint;
    float actualDistBTWpoint;

    Touch touch;

    [SerializeField] Canvas canva;
    [SerializeField] Object point;

    List<Vector2> path = new List<Vector2>();
    List<Object> arrPoint = new List<Object>();


    Vector2 []arrTemp = {  new Vector2(3f, 3f ), new Vector2(3f, 3f) };
    List<Vector2> patern1;

    void Start()
    {
        patern1 = new List<Vector2>(arrTemp);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);


            if (touch.phase == TouchPhase.Began)
            {
                //clear the last path
                arrPoint.ForEach(Destroy);
                arrPoint.Clear();
                path.Clear();
                //prepare for the new path
                actualDistBTWpoint = distBTWpoint;
                pos = Camera.main.ScreenToWorldPoint(touch.position);
                posLastPoint = pos;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                pos = Camera.main.ScreenToWorldPoint(touch.position);
                float distance = (posLastPoint.x - pos.x) * (posLastPoint.x - pos.x) + (posLastPoint.y - pos.y) * (posLastPoint.y - pos.y);
                
                if (distance > actualDistBTWpoint)
                {
                    Object circleCopy = Instantiate(point, pos, Quaternion.identity, canva.transform);
                    arrPoint.Add(circleCopy);
                    path.Add(pos);
                    posLastPoint = pos;
                   //so that point are seperated by the sabe distance
                    actualDistBTWpoint = distBTWpoint - ( distance - actualDistBTWpoint);
                }
            }

            if (touch.phase == TouchPhase.Ended)
            {

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


