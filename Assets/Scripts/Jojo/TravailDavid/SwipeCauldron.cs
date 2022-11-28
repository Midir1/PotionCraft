using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipeCauldron : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private float lerpSpeed;
    
    [SerializeField] private RectTransform cauldron1, cauldron2, cauldron3;
    
    private RectTransform rectTransform;
    
    private ScrollRect scrollRect;
    private Vector2 targetRectPos;

    private float startPosX;

    private bool isRight, isLeft;
    
    private readonly float lerpTolerance = Screen.width / 100f;
    
    private bool isLerping;

    private bool IsLerping
    {
        get => isLerping;
        set
        {
            isLerping = value;

            scrollRect.horizontal = !isLerping;
        }
    }

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        scrollRect = GetComponent<ScrollRect>();
        
        targetRectPos = rectTransform.anchoredPosition;

        float cauldronHeight = 600f * Screen.height / 1080f;
        
        cauldron1.anchoredPosition = new Vector2(0f, 300f);
        cauldron2.anchoredPosition = new Vector2(-Screen.width, 300f);
        cauldron3.anchoredPosition = new Vector2(Screen.width, 300f);
        
        cauldron1.sizeDelta = new Vector2(Screen.width, cauldronHeight);
        cauldron2.sizeDelta = new Vector2(Screen.width, cauldronHeight);
        cauldron3.sizeDelta = new Vector2(Screen.width, cauldronHeight);
    }

    private void Update()
    {
        ScrollBetweenCauldrons();
        ClampScroll();
    }
    
    public void OnBeginDrag(PointerEventData data)
    {
        startPosX = rectTransform.anchoredPosition.x;
    }
    
    public void OnEndDrag(PointerEventData data)
    {
        float deltaX = rectTransform.anchoredPosition.x - startPosX;

        if (isLeft && deltaX > 0f)
        {
            targetRectPos = new Vector2(0f, 0f);
            IsLerping = true;
            isLeft = false;
        }
        else if (deltaX > 0f)
        {
            targetRectPos = new Vector2(Screen.width, 0f);
            IsLerping = true;
            isRight = true;
        }
        
        if (isRight && deltaX < 0f)
        {
            targetRectPos = new Vector2(0f, 0f);
            IsLerping = true;
            isRight = false;
        }
        else if (deltaX < 0f)
        {
            targetRectPos = new Vector2(-Screen.width, 0f);
            IsLerping = true;
            isLeft = true;
        }
    }

    private void ClampScroll()
    {
        if (rectTransform.anchoredPosition.x > Screen.width)
            rectTransform.anchoredPosition = new Vector2(Screen.width, 0f);

        if (rectTransform.anchoredPosition.x < -Screen.width)
            rectTransform.anchoredPosition = new Vector2(-Screen.width, 0f);
    }
    
    private void ScrollBetweenCauldrons()
    {
        if(IsLerping)
        {
            if (Mathf.Abs(rectTransform.anchoredPosition.x - targetRectPos.x) > lerpTolerance)
            {
                rectTransform.anchoredPosition = Vector3.Lerp(rectTransform.anchoredPosition, targetRectPos, 1 - Mathf.Pow(1 - lerpSpeed / 1000f, Time.deltaTime * 60));
            }
            else
            {
                rectTransform.anchoredPosition = targetRectPos;

                IsLerping = false;
            }
        }
    }
}