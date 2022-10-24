using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPage : MonoBehaviour
{
    public GameObject page;
    public List<GameObject> pages;
    public int moveSpeed = 5000;

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

    private float offsetX = 0f;
    private int gameObjectID = 0;
    private bool toLeft = false;
    private bool toRight = false;

    void Update()
    {
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
                    pages[gameObjectID].transform.position = new Vector3(Screen.width / 2 + Input.GetTouch(0).position.x - offsetX, pages[gameObjectID].transform.position.y, 0f);
                }
            }
        }
        
        int size = pages.Count - 1;
        if (toLeft)
        {
            for (int i = size; i >= 0; i--)
            {
                pages[i].transform.Translate(-moveSpeed * Time.deltaTime, 0, 0);/**
                if (pages[(gameObjectID + 1) % pages.Count].transform.position.x < Screen.width / 2)
                {
                    toLeft = false;

                    pages[gameObjectID].transform.position = new Vector3(Screen.width / 2 - 1080, pages[gameObjectID].transform.position.y, 0);
                    pages[(gameObjectID + pages.Count - 1) % pages.Count].transform.position = new Vector3(Screen.width / 2 + 1080, pages[(gameObjectID + pages.Count - 1) % pages.Count].transform.position.y, 0);

                    gameObjectID++;
                    if (gameObjectID > size)
                    {
                        gameObjectID = 0;
                    }
                    page = pages[gameObjectID];
                }/**/
            }
        }
        if (toRight)
        {
            for (int i = 0; i <= size; i++)
            {
                pages[i].transform.Translate(moveSpeed * Time.deltaTime, 0, 0);/**
                if (Screen.width / 2 < pages[(gameObjectID + pages.Count - 1) % pages.Count].transform.position.x)
                {
                    toRight = false;

                    pages[(gameObjectID + 1) % pages.Count].transform.position = new Vector3(Screen.width / 2 - 1080, pages[(gameObjectID + 1) % pages.Count].transform.position.y, 0);
                    pages[gameObjectID].transform.position = new Vector3(Screen.width / 2 + 1080, pages[gameObjectID].transform.position.y, 0);

                    gameObjectID--;
                    if (gameObjectID < 0)
                    {
                        gameObjectID = size;
                    }
                    page = pages[gameObjectID % pages.Count];
                }/**/
            }
        }
    }
}
