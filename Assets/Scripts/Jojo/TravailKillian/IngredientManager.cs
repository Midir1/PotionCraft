using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class IngredientManager : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private Item item;

    private bool isDragged;

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

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Cauldron") || isDragged) return;

        Inventory inventory = other.GetComponent<Inventory>();
        inventory.ingredients.Add(item);

        if (inventory.ingredients.Count == inventory.maxIngredient) inventory.StartCraft();
        
        Destroy(gameObject);
    }
}
