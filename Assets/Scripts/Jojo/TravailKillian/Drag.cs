using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour
{
    protected bool isDragged;
    
    protected Canvas canvas;

    protected virtual void Start()
    {
        canvas = GetComponentInParent<Canvas>();
    }

    [UsedImplicitly]
    public void DragHandler(BaseEventData data)
    {
        isDragged = true;
        
        PointerEventData pointerData = (PointerEventData)data;

        RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)canvas.transform, pointerData.position,
            canvas.worldCamera, out Vector2 position);

        transform.position = canvas.transform.TransformPoint(position);
    }
    
    [UsedImplicitly] public void DropHandler(BaseEventData data) => isDragged = false;
}
