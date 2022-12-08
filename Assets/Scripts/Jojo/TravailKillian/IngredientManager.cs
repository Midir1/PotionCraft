using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class IngredientManager : Drag
{
    [SerializeField] private Item item;

    public AK.Wwise.Event EventIngrediantIn;
    public AK.Wwise.Event EventBadPotion;

    private bool hasBeenDragged = false;
    private bool inCauldron = false;
    
    private IngredientManager[] ingredientManagers;
    private Image[] images;

    private Image doorButton;
    
    protected override void Start()
    {
        base.Start();

        ingredientManagers = new IngredientManager[5];
        images = new Image[5];

        doorButton = GameObject.FindWithTag("DoorButton")?.GetComponent<Image>();
        
    }


    private void Update()
    {
        if (!hasBeenDragged && isDragged)
        {
            hasBeenDragged = true;
        }

        if (hasBeenDragged && !isDragged && !inCauldron)
        {
            if (!GameManager.Instance.tutoState)
            {
                
                EventBadPotion.Post(transform.parent.gameObject);
                Destroy(gameObject);
            }
            
        }

    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (GameManager.Instance.tutoState)
        {
            Destroy(gameObject);
            if (gameObject.name == "NymphTear(Clone)")
            {
                StateManager.Instance.potionTutoEnd--;
            }
        }
        else
        {
            //Debug.Log("ui");
            inCauldron = true;

            Inventory inventory = other.GetComponent<Inventory>();

            if (!other.CompareTag("Cauldron") || isDragged)
            {
                // EventBadPotion.Post(transform.parent.gameObject);
                return;
            }

            if (inventory.isBrewing)
            {
                EventBadPotion.Post(transform.parent.gameObject);
                return;
            }

            inventory.ingredients.Add(item);
            EventIngrediantIn.Post(transform.parent.gameObject);

            if (inventory.ingredients.Count == inventory.maxIngredients) inventory.CheckPotionExist();

            Destroy(gameObject);
        }

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!GameManager.Instance.tutoState)
        {
            if (collision.CompareTag("Cauldron"))
            {
                inCauldron = false;
            }
        }
    }
    
    [UsedImplicitly]
    public void BeginDrag(BaseEventData data)
    {
        ingredientManagers = FindObjectsOfType<IngredientManager>();

        for (var index = 0; index < ingredientManagers.Length; index++)
        {
            images[index] = ingredientManagers[index].GetComponent<Image>();
                
            if (images[index].gameObject == gameObject) continue;
            images[index].raycastTarget = false;
        }

        if (doorButton != null) doorButton.raycastTarget = false;
    }
    
    [UsedImplicitly] public void EndDrag(BaseEventData data)
    {
        for (var index = 0; index < ingredientManagers.Length; index++)
        {
            if (images[index].gameObject == gameObject) continue;
                
            images[index].raycastTarget = true;
        }
        
        if (doorButton != null) doorButton.raycastTarget = true;
        
        ingredientManagers = new IngredientManager[5];
        images = new Image[5];
    }

}