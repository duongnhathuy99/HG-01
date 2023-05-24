using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : EnemyAbstract
{
    [SerializeField] protected Transform player;
    [SerializeField] protected float speed;
    protected bool isFacingRight = true;
    protected override void Awake()
    {
        base.Awake();
        player = GameObject.FindWithTag("Player").transform;
    }
    private void OnEnable()
    {
        speed = EnemyCtrl.EnemySO.moveSpeed;
        isFacingRight = true;
        transform.parent.Rotate(0.0f, 0.0f, 0.0f);
    }
    private void Update()
    {
        if (EnemyCtrl.Enemy.Dead) return;
        CheckMovementDirection();
    }
    private void FixedUpdate()
    {
        if (EnemyCtrl.Enemy.Dead) return;
        Moving();
    }
    protected virtual void Moving()
    {
        Vector3 targetPosition = player.position;
        Vector3 directionEnemy = (targetPosition - transform.parent.position).normalized;

        EnemyCtrl.Rigidbody.MovePosition(EnemyCtrl.Rigidbody.position + directionEnemy * speed * Time.fixedDeltaTime);
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
