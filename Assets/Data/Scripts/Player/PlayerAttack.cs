using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : PlayerAbstract
{
    private float attackDelay;
    private float attackCurrent = 0f;
    [SerializeField] protected Transform fireballPrefab;

    private void FixedUpdate()
    {
        Attack();
    }
    private void Start()
    {
        attackDelay = PlayerCtrl.PlayerSO.attackSpeed;
    }
    protected void Attack()
    {
        attackCurrent += Time.fixedDeltaTime;
        if (attackCurrent < attackDelay) return;
        attackCurrent = 0;

        //Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.parent.position;
        if (EnemySpawner.Instance.Objects.Count <=0 ) return;
        Vector3 diff = EnemySpawner.Instance.Objects[0].position - transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        Transform newFireball = FireballSpawner.Instance.Spawn(fireballPrefab, transform.parent.position, Quaternion.Euler(0, 0, rot_z));
        newFireball.gameObject.SetActive(true);
        PlayerCtrl.Animator.SetTrigger("attack");
    }
}
