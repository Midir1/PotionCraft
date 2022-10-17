using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    public GameObject cauldron;
    public List<GameObject> cauldronsObject;

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            //Debug.Log("touch");
            startTouchPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;

            if (endTouchPosition.x < startTouchPosition.x)
            {
                ToLeft();
            }
            if (endTouchPosition.x > startTouchPosition.x)
            {
                ToRight();
            }
        }
    }

    private void ToRight()
    {
        int size = cauldronsObject.Count - 1;
        Vector3 temp = cauldronsObject[0].transform.position;
        for (int i = 0; i < size; i++)
        {
            cauldronsObject[i].transform.position = cauldronsObject[i+1].transform.position;
        }
        cauldronsObject[size].transform.position = temp;
    }

    private void ToLeft()
    {
        int size = cauldronsObject.Count - 1;
        Vector3 temp = cauldronsObject[size].transform.position;
        for (int i = size; i > 0; i--)
        {
            cauldronsObject[i].transform.position = cauldronsObject[i - 1].transform.position;
        }
        cauldronsObject[0].transform.position = temp;
    }
}
