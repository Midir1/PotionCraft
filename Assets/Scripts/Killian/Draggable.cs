using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Draggable : MonoBehaviour
{
    [SerializeField] private UnityEvent OnDropItemInCauldronEvent;

    public bool IsDragging;
    public Vector3 LastPosition;

    private new Collider2D collider;
    private DragController dragController;
    private float movementTime = 15f;
    private System.Nullable<Vector3> movementDestination;

    void Start()
    {
        collider = GetComponent<Collider2D>();
        dragController = FindObjectOfType<DragController>();

        if (OnDropItemInCauldronEvent == null)
        {
            OnDropItemInCauldronEvent = new UnityEvent();
        }
    }

    void FixedUpdate()
    {
        if (movementDestination.HasValue)
        {
            if (IsDragging)
            {
                movementDestination = null;
                return;
            }

            if (transform.position == movementDestination)
            {
                gameObject.layer = Layer.Default;
                movementDestination = null;
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, movementDestination.Value, movementTime * Time.fixedDeltaTime);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (!this.IsDragging)
        {
            Draggable collidedDraggable = other.GetComponent<Draggable>();

            if (collidedDraggable != null && dragController.LastDragged.gameObject == gameObject)
            {
                ColliderDistance2D colliderDistance2D = other.Distance(collider);
                Vector3 diff = new Vector3(colliderDistance2D.normal.x, colliderDistance2D.normal.y) * colliderDistance2D.distance;
                transform.position -= diff;
            }

            if (other.CompareTag("DropValid"))
            {
                movementDestination = other.transform.position;

                if (other.name == "Cauldron")
                {
                    //transform.SetParent(other.transform.GetChild(0).transform);
                    Destroy(gameObject);
                    OnDropItemInCauldronEvent.Invoke();
                }
            }
            else
            {
                //movementDestination = LastPosition;
            }
        }
    }
}
