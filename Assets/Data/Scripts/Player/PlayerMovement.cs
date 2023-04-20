using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 1f;
    protected Rigidbody2D rigit;
    protected Animator anim;
    protected bool isFacingRight = true;
    protected bool isMove = false;
    Vector2 movementInputDirection;
    private void Awake()
    {
        rigit = GetComponentInParent<Rigidbody2D>();
        anim = GetComponentInParent<Animator>();
    }
    private void Update()
    {
        CheckInput();
        CheckMovementDirection();
        UpdateAnimation();
    }
    private void FixedUpdate()
    {
        Movement();
    }
    private void Movement()
    {
        if (!isMove) return;
        rigit.MovePosition(rigit.position + movementInputDirection * moveSpeed * Time.fixedDeltaTime);
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.parent.Rotate(0.0f, 180.0f, 0.0f);
    }
    private void CheckMovementDirection()
    {
        if (isFacingRight && movementInputDirection.x < 0)
        {
            Flip();
        }
        else if (!isFacingRight && movementInputDirection.x > 0)
        {
            Flip();
        }
    }
    private void CheckInput()
    {
        movementInputDirection.x = Input.GetAxis("Horizontal");
        movementInputDirection.y = Input.GetAxis("Vertical");

        if (movementInputDirection.x == 0 && movementInputDirection.y == 0) isMove = false;
        else isMove = true;
        
    }

    private void UpdateAnimation()
    {
        anim.SetBool("isMove", isMove);
    }
}
