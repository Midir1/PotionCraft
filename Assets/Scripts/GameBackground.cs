using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameBackground : MonoBehaviour
{
    [SerializeField] private float lerpDuration;
    [SerializeField] private List<RectTransform> backgroundsRectTransform;
    [SerializeField] private List<Button> swipeButtons;
    [SerializeField] private Vector2 defaultResolution;
    [SerializeField] private bool isVertical;

    private RectTransform rectTransform, canvasRectTransform;

    private Vector3 currentRectPos, targetRectPos;

    private bool isLerping = false, isSwipingLeft = false, isSwipingRight = false, isSwipingUp = false, isSwipingDown = false;

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

    public void SwipeLeft() => isSwipingLeft = true;
    public void SwipeRight() => isSwipingRight = true;
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

            int middleNbBackgrounds = (backgroundsRectTransform.Count / 2) + 1;


            if(!isVertical)
                backgroundRectTransform.anchoredPosition = new Vector2(Screen.width * (i - middleNbBackgrounds + 1), 0f);
            else
                backgroundRectTransform.anchoredPosition = new Vector2(0f, Screen.height * (i - middleNbBackgrounds + 1));

            backgroundRectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
        }
    }

    private void ScroolBetweenMenus()
    {
        if(!IsLerping)
        {
            if (isSwipingRight)
            {
                isSwipingRight = false;

                targetRectPos -= new Vector3(Screen.width * canvasRectTransform.lossyScale.x, 0f, 0f);
                IsLerping = true;
            }
            else if (isSwipingLeft)
            {
                isSwipingLeft = false;

                targetRectPos += new Vector3(Screen.width * canvasRectTransform.lossyScale.x, 0f, 0f);
                IsLerping = true;
            }
            else if (isSwipingUp)
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