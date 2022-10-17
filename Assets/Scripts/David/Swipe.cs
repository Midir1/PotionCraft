using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    public GameObject cauldron;
    public GameObject clock;
    public List<GameObject> cauldronsObject;
    public List<GameObject> clocksObject;
    public int moveSpeed = 5000;

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

    private float offsetX = 0f;
    private int gameObjectID = 0;
    private bool toLeft = false;
    private bool toRight = false;

    void Update()
    {
        int size = cauldronsObject.Count - 1;
        if (!toLeft && !toRight && Input.touchCount > 0)
        {
            if (Input.GetTouch(0).position.y < Screen.height / 2)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    startTouchPosition = Input.GetTouch(0).position;
                    offsetX = Input.GetTouch(0).position.x;
                }

                if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    endTouchPosition = Input.GetTouch(0).position;

                    if (endTouchPosition.x < startTouchPosition.x)
                    {
                        toLeft = true;
                    }
                    if (endTouchPosition.x > startTouchPosition.x)
                    {
                        toRight = true;
                    }
                }

                if (Input.GetMouseButton(0))
                {
                    cauldronsObject[gameObjectID].transform.position = new Vector3(Screen.width / 2 + Input.GetTouch(0).position.x - offsetX, cauldronsObject[gameObjectID].transform.position.y, 0f);
                }
            }
        }

        if (toLeft)
        {
            for (int i = size; i >= 0; i--)
            {
                cauldronsObject[i].transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);
                if (cauldronsObject[(gameObjectID + 1) % cauldronsObject.Count].transform.position.x < Screen.width / 2)
                {
                    toLeft = false;

                    cauldronsObject[gameObjectID].transform.position = new Vector3(Screen.width / 2 - 1080, cauldronsObject[gameObjectID].transform.position.y, 0);
                    cauldronsObject[(gameObjectID + cauldronsObject.Count - 1) % cauldronsObject.Count].transform.position = new Vector3(Screen.width / 2 + 1080, cauldronsObject[(gameObjectID + cauldronsObject.Count - 1) % cauldronsObject.Count].transform.position.y, 0);

                    clocksObject[(gameObjectID + cauldronsObject.Count - 1) % cauldronsObject.Count].transform.position = new Vector3(Screen.width / 2 + 400, Screen.height / 2 - 200, 0);
                    clocksObject[gameObjectID].transform.position = new Vector3(Screen.width / 2 - 400, Screen.height / 2 - 200, 0);
                    clocksObject[(gameObjectID + 1) % cauldronsObject.Count].transform.position = new Vector3(Screen.width / 2, Screen.height / 2 - 200, 0);

                    gameObjectID++;
                    if (gameObjectID > size)
                    {
                        gameObjectID = 0;
                    }
                    cauldron = cauldronsObject[gameObjectID];
                }
                clocksObject[i].transform.Translate(-moveSpeed * 0.37f * Time.deltaTime, 0, 0);
                if (clocksObject[i].transform.position.x < Screen.width / 2 - 600)
                {
                    clocksObject[i].transform.position = new Vector3(Screen.width / 2 + 600, clocksObject[i].transform.position.y, 0);
                }
            }
        }
        if (toRight)
        {
            for (int i = 0; i <= size; i++)
            {
                cauldronsObject[i].transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
                if (Screen.width / 2 < cauldronsObject[(gameObjectID + cauldronsObject.Count - 1) % cauldronsObject.Count].transform.position.x)
                {
                    toRight = false;

                    cauldronsObject[(gameObjectID + 1) % cauldronsObject.Count].transform.position = new Vector3(Screen.width / 2 - 1080, cauldronsObject[(gameObjectID + 1) % cauldronsObject.Count].transform.position.y, 0);
                    cauldronsObject[gameObjectID].transform.position = new Vector3(Screen.width / 2 + 1080, cauldronsObject[gameObjectID].transform.position.y, 0);

                    clocksObject[(gameObjectID + cauldronsObject.Count - 1) % cauldronsObject.Count].transform.position = new Vector3(Screen.width / 2, Screen.height / 2 - 200, 0);
                    clocksObject[gameObjectID].transform.position = new Vector3(Screen.width / 2 + 400, Screen.height / 2 - 200, 0);
                    clocksObject[(gameObjectID + 1) % cauldronsObject.Count].transform.position = new Vector3(Screen.width / 2 - 400, Screen.height / 2 - 200, 0);

                    gameObjectID--;
                    if (gameObjectID < 0)
                    {
                        gameObjectID = size;
                    }
                    cauldron = cauldronsObject[gameObjectID % cauldronsObject.Count];
                }
                clocksObject[i].transform.Translate(moveSpeed * 0.37f * Time.deltaTime, 0, 0);
                if (clocksObject[i].transform.position.x > Screen.width / 2 + 600)
                {
                    clocksObject[i].transform.position = new Vector3(Screen.width / 2 - 600, clocksObject[i].transform.position.y, 0);
                }
            }
        }
    }
}
