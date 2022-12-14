using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameBackgrounds : MonoBehaviour, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private float lerpSpeed;
    [SerializeField] private List<RectTransform> backgroundsRectTransform;
    [SerializeField] private List<RectTransform> resizable;
    [SerializeField] private Vector2 defaultResolution;
    [SerializeField] private float swipeTolerance;

    [SerializeField] private Canvas shopCanvas;
    [SerializeField] private Canvas grimoireCanvas;
    
    [SerializeField] private List<GameObject> uiToHide;

    public AK.Wwise.Event laderEvent;

    private RectTransform rectTransform;

    private Vector2 targetRectPos;

    private CanvasScaler canvasScaler;

    private readonly float swipeUpPos = -Screen.height / 40f;
    private readonly float swipeDownPos = -Screen.height * 2f + Screen.height / 40f;

    private ScrollRect scrollRect;

    private bool isLerping, isDownstairs = true;

    private float startPosY;

    private Vector2 startLerpPos;
    private float lerpTimer;

    private float defaultLerpSpeed;

    public static bool Day;

    private bool IsLerping
    {
        get => isLerping;
        set
        {
            isLerping = value;

            scrollRect.enabled = !isLerping;

            if (!isLerping)
            {
                foreach (var ui in uiToHide)
                {
                    ui.SetActive(true);
                }
            }
        }
    }

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasScaler = GetComponentInParent<CanvasScaler>();
        scrollRect = GetComponent<ScrollRect>();

        targetRectPos = rectTransform.anchoredPosition;

        defaultLerpSpeed = lerpSpeed;

        ChangeUIResolution();
    }

    private void Update()
    {
        if (Day) return;
        if (shopCanvas.isActiveAndEnabled || grimoireCanvas.isActiveAndEnabled) return;

        if (!GameManager.Instance.tutoState || (GameManager.Instance.tutoState && StateManager.Instance.CurrentState == 14))
        {

            ScrollBetweenFloors();
            //ScrollBetweenTransition();
            ClampScroll();

            if (GameManager.Instance.tutoState && StateManager.Instance.CurrentState == 14)
                scrollRect.enabled = true;
            if (transform.position.y <= -19 && GameManager.Instance.tutoState)
            {
                StateManager.Instance.CurrentState++;
            }
        }
        else
        {
            scrollRect.enabled = false;
        }
    }

    public void OnBeginDrag(PointerEventData data)
    {
        startPosY = rectTransform.anchoredPosition.y;

    }

    public void OnEndDrag(PointerEventData data)
    {
        float deltaY = rectTransform.anchoredPosition.y - startPosY;

        switch (isDownstairs)
        {
            case true when rectTransform.anchoredPosition.y < swipeUpPos && deltaY < 0f:
                targetRectPos = new Vector2(0f, -Screen.height * 2f);
                IsLerping = true;
                foreach (var ui in uiToHide)
                {
                    ui.SetActive(false);
                }

                lerpSpeed = defaultLerpSpeed;
                isDownstairs = false;
                startLerpPos = rectTransform.anchoredPosition;
                laderEvent.Post(gameObject);
                break;
            case false when rectTransform.anchoredPosition.y > swipeDownPos && deltaY > 0f:
                targetRectPos = new Vector2(0f, 0f);
                IsLerping = true;
                foreach (var ui in uiToHide)
                {
                    ui.SetActive(false);
                }
                lerpSpeed = defaultLerpSpeed;
                isDownstairs = true;
                startLerpPos = rectTransform.anchoredPosition;
                laderEvent.Post(gameObject);
                break;
            case true:
                targetRectPos = new Vector2(0f, 0f);
                IsLerping = true;
                lerpSpeed = 0.4f;
                startLerpPos = rectTransform.anchoredPosition;
                break;
            case false:
                targetRectPos = new Vector2(0f, -Screen.height * 2f);
                IsLerping = true;
                lerpSpeed = 0.4f;
                startLerpPos = rectTransform.anchoredPosition;
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

        for (int i = 0; i < resizable.Count; i++)
        {
            RectTransform rect = resizable[i];

            float ratioW = defaultResolution.x / (float)Screen.width;
            float ratioH = defaultResolution.y / (float)Screen.height;

            if (rect.gameObject.name.Contains("Cauldron"))
            {
                rect.sizeDelta = new Vector2(rect.sizeDelta.x / ratioW, rect.sizeDelta.y / ratioH);
                rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, rect.anchoredPosition.y / ratioH);
                rect.gameObject.GetComponent<BoxCollider2D>().size = new Vector2(rect.sizeDelta.x, rect.sizeDelta.y * 0.5f);
            }
            else
            {
                rect.anchoredPosition = new Vector2(rect.anchoredPosition.x / ratioW, rect.anchoredPosition.y / ratioH);
                rect.sizeDelta = new Vector2(rect.sizeDelta.x / ratioW, rect.sizeDelta.y / ratioH);
            }

        }
    }

    private void ScrollBetweenFloors()
    {
        if (IsLerping)
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

    private void ScrollBetweenTransition()
    {
        if (!IsLerping) return;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                //Correct deltaPosition != GetAxis
                case TouchPhase.Ended when touch.deltaPosition.y < -swipeTolerance:
                    targetRectPos = new Vector2(0f, -Screen.height * 2f);
                    isDownstairs = false;
                    break;
                case TouchPhase.Ended when touch.deltaPosition.y > swipeTolerance:
                    targetRectPos = new Vector2(0f, 0f);
                    isDownstairs = true;
                    break;
            }
        }
        else
        {
            switch (isDownstairs)
            {
                case true when Input.GetMouseButton(0) && Input.GetAxis("Mouse Y") < -swipeTolerance:
                    targetRectPos = new Vector2(0f, -Screen.height * 2f);
                    isDownstairs = false;
                    break;
                case false when Input.GetMouseButton(0) && Input.GetAxis("Mouse Y") > swipeTolerance:
                    targetRectPos = new Vector2(0f, 0f);
                    isDownstairs = true;
                    break;
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