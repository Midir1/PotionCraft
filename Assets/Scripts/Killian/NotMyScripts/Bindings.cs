using UnityEngine;

public class Bindings : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector2 yeeeehaa = touch.position - (Vector2)transform.position;

            rb.AddForce(moveDirection * 10f, ForceMode2D.Force);

        }

            //Debug.Log(horizontal + "/" + vertical);

            moveDirection = vertical * transform.up + transform.right * horizontal;
    }

    private void FixedUpdate()
    {
     }
}