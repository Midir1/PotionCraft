using UnityEngine;

public class IngredientManager : Drag
{
    [SerializeField] private Item item;
    
    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Cauldron") || isDragged) return;
        
        Inventory inventory = other.GetComponent<Inventory>();

        if (inventory.isBrewing) return;
         
        inventory.ingredients.Add(item);
        if (inventory.ingredients.Count == inventory.maxIngredients) inventory.CheckPotionExist();
        
        Destroy(gameObject);
    }
}