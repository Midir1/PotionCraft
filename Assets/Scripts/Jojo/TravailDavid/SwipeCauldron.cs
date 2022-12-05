using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipeCauldron : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private float lerpSpeed;
    [SerializeField] private float posY;
    
    [SerializeField] private RectTransform cauldron1, cauldron2, cauldron3;
    
    private RectTransform rectTransform;
    
    private ScrollRect scrollRect;
    private Vector2 targetRectPos;

    private float startPosX;

    private bool isRight, isLeft;

    private bool isLerping;
    
    private Vector2 startLerpPos;
    private float lerpTimer;

    private GameManager gameManager;

    private bool cauldron2Unlocked, cauldron3Unlocked;

    private bool IsLerping
    {
        get => isLerping;
        set
        {
            isLerping = value;

            scrollRect.movementType = isLerping ? ScrollRect.MovementType.Clamped : ScrollRect.MovementType.Elastic;
        }
    }

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        scrollRect = GetComponent<ScrollRect>();
        
        
        targetRectPos = rectTransform.anchoredPosition;

        float cauldronHeight = 600f * Screen.height / 1080f;
        
        cauldron1.anchoredPosition = new Vector2(0f, posY);
        cauldron2.anchoredPosition = new Vector2(-Screen.width, posY);
        cauldron3.anchoredPosition = new Vector2(Screen.width, posY);
        
        cauldron1.sizeDelta = new Vector2(Screen.width, cauldronHeight);
        cauldron2.sizeDelta = new Vector2(Screen.width, cauldronHeight);
        cauldron3.sizeDelta = new Vector2(Screen.width, cauldronHeight);
    }

    private void Update()
    {
        if (gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>();
        }
        
        ScrollBetweenCauldrons();
        ClampScroll();
        CauldronUnlock();
    }
    
    public void OnBeginDrag(PointerEventData data)
    {
        startPosX = rectTransform.anchoredPosition.x;
    }
    
    public void OnEndDrag(PointerEventData data)
    {
        if (isLerping) return;
        
        float deltaX = rectTransform.anchoredPosition.x - startPosX;

        if (gameManager.cauldron[1].isAvailable && gameManager.cauldron[2].isAvailable)
        {
            if (isLeft && deltaX > 0f)
            {
                targetRectPos = new Vector2(0f, 0f);
                IsLerping = true;
                isLeft = false;
                startLerpPos = rectTransform.anchoredPosition;
            }
            else if (deltaX > 0f)
            {
                targetRectPos = new Vector2(Screen.width, 0f);
                IsLerping = true;
                isRight = true;
                startLerpPos = rectTransform.anchoredPosition;
            }
        
            if (isRight && deltaX < 0f)
            {
                targetRectPos = new Vector2(0f, 0f);
                IsLerping = true;
                isRight = false;
                startLerpPos = rectTransform.anchoredPosition;
            }
            else if (deltaX < 0f)
            {
                targetRectPos = new Vector2(-Screen.width, 0f);
                IsLerping = true;
                isLeft = true;
                startLerpPos = rectTransform.anchoredPosition;
            }
            
        }
        else if (gameManager.cauldron[1].isAvailable)
        {
            if (deltaX > 0f)
            {
                targetRectPos = new Vector2(Screen.width, 0f);
                IsLerping = true;
                isRight = true;
                startLerpPos = rectTransform.anchoredPosition;
            }
        
            if (isRight && deltaX < 0f)
            {
                targetRectPos = new Vector2(0f, 0f);
                IsLerping = true;
                isRight = false;
                startLerpPos = rectTransform.anchoredPosition;
            }
        }
        else if (gameManager.cauldron[2].isAvailable)
        {
            if (isLeft && deltaX > 0f)
            {
                targetRectPos = new Vector2(0f, 0f);
                IsLerping = true;
                isLeft = false;
                startLerpPos = rectTransform.anchoredPosition;
            }

            if (deltaX < 0f)
            {
                targetRectPos = new Vector2(-Screen.width, 0f);
                IsLerping = true;
                isLeft = true;
                startLerpPos = rectTransform.anchoredPosition;
            }
        }

        
    }

    private void CauldronUnlock()
    {
        if(!cauldron2Unlocked && gameManager.cauldron[1].isAvailable)
        {
            cauldron2Unlocked = true;
            cauldron2.gameObject.SetActive(true);
        }
        else if (!cauldron3Unlocked && gameManager.cauldron[2].isAvailable)
        {
            cauldron3Unlocked = true;
            cauldron3.gameObject.SetActive(true);
        }
    }

    private void ClampScroll()
    {
        if (cauldron2Unlocked && cauldron3Unlocked)
        {
            if (rectTransform.anchoredPosition.x > Screen.width)
                rectTransform.anchoredPosition = new Vector2(Screen.width, 0f);

            if (rectTransform.anchoredPosition.x < -Screen.width)
                rectTransform.anchoredPosition = new Vector2(-Screen.width, 0f);
        }
        else if (cauldron2Unlocked)
        {
            if (rectTransform.anchoredPosition.x > Screen.width)
                rectTransform.anchoredPosition = new Vector2(Screen.width, 0f);

            if (rectTransform.anchoredPosition.x < 0f)
                rectTransform.anchoredPosition = new Vector2(0f, 0f);
        }
        else if (cauldron3Unlocked)
        {
            if (rectTransform.anchoredPosition.x > 0f)
                rectTransform.anchoredPosition = new Vector2(0f, 0f);

            if (rectTransform.anchoredPosition.x < -Screen.width)
                rectTransform.anchoredPosition = new Vector2(-Screen.width, 0f);
        }
        else
        {
            rectTransform.anchoredPosition = new Vector2(0f, 0f);
        }
    }
    
    private void ScrollBetweenCauldrons()
    {
        if(IsLerping)
        {
            lerpTimer += Time.deltaTime / lerpSpeed;
            rectTransform.anchoredPosition = Vector3.Lerp(startLerpPos, targetRectPos, lerpTimer);

            if (lerpTimer >= 1f)
            {
                lerpTimer = 0f;
                IsLerping = false;
            }
        }
    }
}