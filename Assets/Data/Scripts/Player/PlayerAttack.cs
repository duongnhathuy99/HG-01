using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : PlayerAbstract
{
    [SerializeField] protected float attackDelay = 2f;
    [SerializeField] protected float attackCurrent = 0f;
    [SerializeField] protected Transform bulletPrefab;

    //protected Animator anim;

    /*private void Awake()
    {
        anim = GetComponentInParent<Animator>();
    }*/

    private void FixedUpdate()
    {
        Attack();
    }
    protected void Attack()
    {
        attackCurrent += Time.fixedDeltaTime;
        if (attackCurrent < attackDelay) return;
        attackCurrent = 0;

        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        Instantiate(bulletPrefab, transform.parent.position, Quaternion.Euler(0, 0, rot_z));
        PlayerCtrl.Animator.SetTrigger("attack");
    }
}
