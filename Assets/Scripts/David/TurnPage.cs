using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPage : MonoBehaviour
{
    public GameObject page;
    public List<GameObject> pages;
    public float moveSpeed = 100.0f;

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

    private int gameObjectID = 0;
    private bool toLeft = false;
    private bool toRight = false;

    void Update()
    {
        if (!toLeft && !toRight && Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                startTouchPosition = Input.GetTouch(0).position;
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
        }

        if (toLeft)
        {
            if (gameObjectID == pages.Count - 1)
            {
                toLeft = false;
            }
            else
            {
                pages[gameObjectID].transform.Rotate(0.0f, -moveSpeed * Time.deltaTime, 0.0f);

                if (pages[gameObjectID].transform.rotation.y < -0.71f)
                {
                    toLeft = false;
                    gameObjectID++;
                }
            }
        }
        if (toRight)
        {
            if (gameObjectID == 0)
            {
                toRight = false;
            }
            else
            {
                pages[gameObjectID - 1].transform.Rotate(0.0f, moveSpeed * Time.deltaTime, 0.0f);

                if (pages[gameObjectID - 1].transform.rotation.y > 0.0f)
                {
                    pages[gameObjectID - 1].transform.rotation = new Quaternion();
                    toRight = false;
                    gameObjectID--;
                }
            }
        }
    }
}
