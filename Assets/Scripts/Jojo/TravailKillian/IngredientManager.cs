using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;

public class IngredientManager : MonoBehaviour
{
    [SerializeField] private Item item;

    private Canvas canvas;
    
    private bool isDragged;

    private void Start()
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

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Cauldron") || isDragged) return;
        
        Inventory inventory = other.GetComponent<Inventory>();

        if (inventory.isBrewing) return;
         
        inventory.ingredients.Add(item);
        if (inventory.ingredients.Count == inventory.maxIngredients) inventory.ShowDrawPanel();
        
        Destroy(gameObject);
    }
}