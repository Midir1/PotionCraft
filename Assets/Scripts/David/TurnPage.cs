using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnPage : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    public AK.Wwise.Event turnPage;
    
    public GameObject page;
    public List<GameObject> pages;
    public float moveSpeed = 100.0f;

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

    private int gameObjectID = 0;
    private float alpha = 255.0f;
    private bool toLeft = false;
    private bool toRight = false;

    void Update()
    {
        if (canvas.enabled)
        {
            for (int i = 0; i < pages.Count; i++) // check each potion if unlocked in GameManager
            {
                pages[i].GetComponent<Potion>().locked = !GameManager.Instance.Bp[i];
            }

            if (!toLeft && !toRight && Input.touchCount > 0) // before action
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

            if (toLeft) // if action mean turn page to the left
            {
                if (gameObjectID == pages.Count - 1)
                {
                    toLeft = false;
                }
                else
                {
                    pages[gameObjectID].transform.Rotate(0.0f, -moveSpeed * Time.deltaTime, 0.0f);
                    if (pages[gameObjectID].transform.rotation.y < -0.8f)
                    {
                        toLeft = false;
                        turnPage.Post(gameObject);
                        gameObjectID++;
                    }
                }
            }
            if (toRight) // if action mean turn page to the right
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
                        toRight = false;
                        turnPage.Post(gameObject);
                        gameObjectID--;
                    }
                }
            }
        }
    }
}
