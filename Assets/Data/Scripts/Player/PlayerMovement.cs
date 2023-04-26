using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PlayerAbstract
{
    [SerializeField] protected float moveSpeed = 1f;
    protected bool isFacingRight = true;
    [SerializeField] protected bool isMove = false;
    [SerializeField] protected Vector3 movementDirection;
    private void Update()
    {
        MoveDirection();
        CheckMoving();
        CheckMovementDirection();
        UpdateAnimation();
    }
    private void FixedUpdate()
    {
        Moving();
    }
    private void Moving()
    {
        if (!isMove) return;
        PlayerCtrl.Rigidbody.MovePosition(PlayerCtrl.Rigidbody.position + movementDirection * moveSpeed * Time.fixedDeltaTime);
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
    private void CheckMoving()
    {
        
        if (movementDirection.x == 0 && movementDirection.y == 0) isMove = false;
        else isMove = true;
        
    }
    private void UpdateAnimation()
    {
        PlayerCtrl.Animator.SetBool("isMove", isMove);
    }
    private void MoveDirection()
    {
        movementDirection.x = MovementJoystick.Instance.joystickvec.x + Input.GetAxis("Horizontal");
        movementDirection.y = MovementJoystick.Instance.joystickvec.y + Input.GetAxis("Vertical");
        movementDirection.z = 0;
    }
}
