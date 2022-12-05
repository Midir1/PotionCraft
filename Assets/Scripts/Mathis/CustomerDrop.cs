using UnityEngine;
using UnityEngine.UI;

public class CustomerDrop : Drag
{
    ButtonManager buttonManager;
    [SerializeField] int potionIndex;

    private Transform potionParent;
    private bool hasBeenDragged = false;
    private bool inCauldron = true;
    bool potionGiven = false;

    override protected void Start()
    {
        potionParent = GameObject.Find("Potions").transform;
        canvas = GetComponentInParent<Canvas>();
    }

    private void Update()
    {
        if (!hasBeenDragged && !isDragged && !inCauldron)
        {
            hasBeenDragged = true;
        }

        if (hasBeenDragged && !inCauldron && !isDragged)
        {
            transform.SetParent(potionParent);
        }
    }

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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Cauldron"))
        {
            inCauldron = false;
        }
    }
}