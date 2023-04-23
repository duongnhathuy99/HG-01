using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] protected Transform player;
    [SerializeField] protected float speed = 0.01f;
    [SerializeField] protected bool isFacingRight = true;
    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
    }
    private void OnEnable()
    {
        isFacingRight = true;
        transform.parent.Rotate(0.0f, 0.0f, 0.0f);
    }
    private void Update()
    {
        CheckMovementDirection();
    }
    private void FixedUpdate()
    {
        Moving();
    }
    protected virtual void Moving()
    {
        Vector3 targetPosition = player.position;

        Vector3 newPos = Vector3.Lerp(transform.parent.position, targetPosition, speed);
        transform.parent.position = newPos;
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.parent.Rotate(0.0f, 180.0f, 0.0f);
    }
    private void CheckMovementDirection()
    {
        if (isFacingRight && player.position.x < transform.parent.position.x)
        {
            Flip();
        }
        else if (!isFacingRight && player.position.x > transform.parent.position.x)
        {
            Flip();
        }
    }
}
