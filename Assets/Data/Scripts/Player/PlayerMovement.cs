using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PlayerAbstract
{
    [SerializeField] protected float moveSpeed = 1f;
    protected bool isFacingRight = true;
    protected bool isMove = false;
    Vector2 movementDirection;
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
        PlayerCtrl.Rigidbody2D.MovePosition(PlayerCtrl.Rigidbody2D.position + movementDirection * moveSpeed * Time.fixedDeltaTime);
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.parent.Rotate(0.0f, 180.0f, 0.0f);
    }
    private void CheckMovementDirection()
    {
        if (isFacingRight && movementDirection.x < 0)
        {
            Flip();
        }
        else if (!isFacingRight && movementDirection.x > 0)
        {
            Flip();
        }
    }
    private void CheckInput()
    {
        movementDirection.x = Input.GetAxis("Horizontal");
        movementDirection.y = Input.GetAxis("Vertical");

        if (movementDirection.x == 0 && movementDirection.y == 0) isMove = false;
        else isMove = true;
        
    }

    private void UpdateAnimation()
    {
        PlayerCtrl.Animator.SetBool("isMove", isMove);
    }
}
