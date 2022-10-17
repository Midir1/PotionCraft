using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBackgrounds : MonoBehaviour
{
    [SerializeField] private float lerpDuration;
    [SerializeField] private List<RectTransform> backgroundsRectTransform;
    [SerializeField] private List<Button> swipeButtons;
    [SerializeField] private Vector2 defaultResolution;

    private RectTransform rectTransform, canvasRectTransform;

    private Vector3 currentRectPos, targetRectPos;

    private bool isLerping = false, isSwipingUp = false, isSwipingDown = false;

    private float lerpTime;

    private CanvasScaler canvasScaler;

    private bool IsLerping
    {
        get { return isLerping; }
        set
        {
            foreach (Button swipeButton in swipeButtons)
            {
                swipeButton.enabled = !value;
            }

            isLerping = value;
        }
    }

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasRectTransform = GetComponentInParent<RectTransform>();
        canvasScaler = GetComponentInParent<CanvasScaler>();

        currentRectPos = rectTransform.position;
        targetRectPos = currentRectPos;

        ChangeUIResolution();
    }

    private void Update()
    {
        ScroolBetweenMenus();
    }

    public void SwipeDown() => isSwipingDown = true;
    public void SwipeUp() => isSwipingUp = true;

    private void ChangeUIResolution()
    {
        if (Screen.width == defaultResolution.x && Screen.height == defaultResolution.y) return;

        canvasScaler.referenceResolution = new Vector2(Screen.width, Screen.height);

        ChangeBackgroundsRect();
    }

    private void ChangeBackgroundsRect()
    {
        for (int i = 0; i < backgroundsRectTransform.Count; i++)
        {
            RectTransform backgroundRectTransform = backgroundsRectTransform[i];

            //Todo transition height with shop and room
            /*if(i != 1)
            {
                backgroundRectTransform.anchoredPosition = new Vector2(0f, (Screen.height / 2) * i);
                backgroundRectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
            }
            else
            {
                backgroundRectTransform.anchoredPosition = new Vector2(0f, Screen.height * (i));
                backgroundRectTransform.sizeDelta = new Vector2(Screen.width, (Screen.width * backgroundRectTransform.rect.height) / backgroundRectTransform.rect.height);
            }*/
            
        }
    }

    private void ScroolBetweenMenus()
    {
        if(!IsLerping)
        {
            if (isSwipingUp)
            {
                isSwipingUp = false;

                targetRectPos -= new Vector3(0f, Screen.height * canvasRectTransform.lossyScale.y, 0f);
                IsLerping = true;
            }
            else if (isSwipingDown)
            {
                isSwipingDown = false;

                targetRectPos += new Vector3(0f, Screen.height * canvasRectTransform.lossyScale.y, 0f);
                IsLerping = true;
            }
        }
        else 
        {
            lerpTime += Time.deltaTime / lerpDuration;

            if (rectTransform.position != targetRectPos)
                rectTransform.position = Vector3.Lerp(currentRectPos, targetRectPos, lerpTime);
            else
            {
                currentRectPos = rectTransform.position;

                IsLerping = false;

                lerpTime = 0f;
            }
        }
    }
}