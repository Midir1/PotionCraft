using UnityEngine;

public class IngredientManager : Drag
{
    [SerializeField] private Item item;

    private bool hasBeenDragged = false;
    private bool inCauldron = false;

    private void Update()
    {
        if (!hasBeenDragged && isDragged)
        {
            hasBeenDragged = true;
        }

        if (hasBeenDragged && !isDragged && !inCauldron)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        inCauldron = true;

        if (!other.CompareTag("Cauldron") || isDragged) return;

        Inventory inventory = other.GetComponent<Inventory>();

        if (inventory.isBrewing) return;
         
        inventory.ingredients.Add(item);
        if (inventory.ingredients.Count == inventory.maxIngredients) inventory.CheckPotionExist();
        
        Destroy(gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Cauldron"))
        {
            inCauldron = false;
        }
    }
}