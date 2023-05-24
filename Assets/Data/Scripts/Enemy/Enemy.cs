using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IHealth
{
    [SerializeField] protected int health;
    [SerializeField] protected int damage;
    EnemySO enemySO;
    EnemyCtrl enemyCtrl;
    public bool Dead { get; private set; }
    float timeDead ;
    private void Awake()
    {
        enemySO = transform.GetComponent<EnemyCtrl>().EnemySO;
        enemyCtrl = transform.GetComponent<EnemyCtrl>();
    }
    private void OnEnable()
    {
        Dead = false;
        timeDead = 1f;
        health = enemySO.heathMax + enemySO.heathIncrease * (int)(Time.time / enemySO.timeIncrease);
        damage = enemySO.damage + enemySO.damageIncrease * (int)(Time.time / enemySO.timeIncrease);
    }
    private void FixedUpdate()
    {
        CheckDead();
    }
    private void OnTriggerStay(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null) return;
        IHealth health = other.GetComponent<IHealth>();
        if (health == null) return;

        health.TakeDamage(damage);
    }
    public void TakeDamage(int amount)
    {
        if (Dead) return;
        health -= amount;
        enemyCtrl.Animator.SetTrigger("Hit");
        if (health > 0) return;
        Dead = true;
        enemyCtrl.Animator.SetBool("Dead", Dead);
    }
    void CheckDead()
    {
        if (!Dead) return;
        timeDead -=Time.fixedDeltaTime;
        if (timeDead > 0) return;
        EnemySpawner.Instance.Despawn(transform);
        enemyCtrl.EnemyDropItem.Drop(enemySO.dropList, transform.position, transform.rotation);
    }
}
