using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameBackgrounds : MonoBehaviour, IEndDragHandler
{
    [SerializeField] private float lerpSpeed;
    [SerializeField] private List<RectTransform> backgroundsRectTransform;
    [SerializeField] private Vector2 defaultResolution;

    private RectTransform rectTransform;

    private Vector2 targetRectPos;

    private CanvasScaler canvasScaler;

    private readonly float swipeUpPos = -Screen.height / 40f;
    private readonly float swipeDownPos = -Screen.height * 2f + Screen.height / 40f;
    private readonly float lerpTolerance = Screen.height / 200f;

    private ScrollRect scrollRect;

    private bool isLerping = false, isDownstairs = true;

    private bool IsLerping
    {
        get => isLerping;
        set
        {
            isLerping = value;

            if (isLerping)
                scrollRect.movementType = ScrollRect.MovementType.Clamped;
            else
                scrollRect.movementType = ScrollRect.MovementType.Elastic;
        }
    }

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasScaler = GetComponentInParent<CanvasScaler>();
        scrollRect = GetComponent<ScrollRect>();

        targetRectPos = rectTransform.anchoredPosition;

        ChangeUIResolution();
    }

    private void Update()
    {
        ScroolBetweenFloors();
        ClampScroll();
    }

    public void OnEndDrag(PointerEventData data)
    {
        if (scrollRect.movementType == ScrollRect.MovementType.Clamped) return;

        switch (isDownstairs)
        {
            case true when rectTransform.anchoredPosition.y < swipeUpPos:
                targetRectPos = new Vector2(0f, -Screen.height * 2f);
                IsLerping = true;
                isDownstairs = false;
                break;
            case false when rectTransform.anchoredPosition.y > swipeDownPos:
                targetRectPos = new Vector2(0f, 0f);
                IsLerping = true;
                isDownstairs = true;
                break;
            case true:
                targetRectPos = new Vector2(0f, 0f);
                IsLerping = true;
                break;
            case false:
                targetRectPos = new Vector2(0f, -Screen.height * 2f);
                IsLerping = true;
                break;
        }
    }

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

            backgroundRectTransform.anchoredPosition = new Vector2(0f, Screen.height * i);
            backgroundRectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
        }
    }

    private void ScroolBetweenFloors()
    {
        if(IsLerping)
        {
            if (Mathf.Abs(rectTransform.anchoredPosition.y - targetRectPos.y) > lerpTolerance)
                rectTransform.anchoredPosition = Vector3.Lerp(rectTransform.anchoredPosition, targetRectPos, 1 - Mathf.Pow(1 - lerpSpeed / 1000f, Time.deltaTime * 60));//lerpTime);
            else
            {
                rectTransform.anchoredPosition = targetRectPos;

                IsLerping = false;
            }
        }
    }

    private void ClampScroll()
    {
        if (rectTransform.anchoredPosition.y > 0)
            rectTransform.anchoredPosition = Vector2.zero;

        if (rectTransform.anchoredPosition.y < -Screen.height * 2f)
            rectTransform.anchoredPosition = new Vector2(0f, -Screen.height * 2f);
    }
}