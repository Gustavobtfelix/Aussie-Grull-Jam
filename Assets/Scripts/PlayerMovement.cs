using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Animator animator;

    Vector2 movement;
    private PickUp pickUp;
    
    void Start() {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        pickUp = gameObject.GetComponent<PickUp>();
        pickUp.Direction = new Vector2(movement.x, movement.y);
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        if (movement.sqrMagnitude > .1f)
        {
            pickUp.Direction = movement.normalized;
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }
    void FixedUpdate ()
    {
         rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
