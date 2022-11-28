using UnityEngine;

public class CustomerDrop : Drag
{

    ButtonManager buttonManager;
    [SerializeField] int potionIndex; 


    bool potionGiven = false;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.transform.parent.name.Contains("Customer") || isDragged) return;

        buttonManager = FindObjectOfType<ButtonManager>();
        string name = gameObject.name;

        if (!potionGiven)
        {
            buttonManager.EraseCustomer(other.transform.parent, potionIndex);
            potionGiven = true;
        }

        Destroy(gameObject);
    }
}