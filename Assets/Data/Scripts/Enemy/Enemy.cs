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
    public bool Undamaged { get; set; }
    private void Awake()
    {
        enemySO = transform.GetComponent<EnemyCtrl>().EnemySO;
        enemyCtrl = transform.GetComponent<EnemyCtrl>();
    }
    private void OnEnable()
    {
        Undamaged = false;
        Dead = false;
        health = enemySO.heathMax + enemySO.heathIncrease * (int)(Time.time / enemySO.timeIncrease);
        damage = enemySO.damage + enemySO.damageIncrease * (int)(Time.time / enemySO.timeIncrease);
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (Undamaged) return;
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null) return;
        IHealth health = other.GetComponent<IHealth>();
        if (health == null) return;

        health.TakeDamage(damage);
    }
    public bool TakeDamage(float amount)
    {
        if (Undamaged) return false;
        health -= (int)amount;
        enemyCtrl.Animator.SetTrigger("Hit");
        if (health > 0) return true;
        StartDead();
        return true;
    }
    void StartDead()
    {
        Dead = true;
        Undamaged = true;
        enemyCtrl.Animator.SetBool("Dead", true);
    }
    void FinishAniDead()
    {
        EnemySpawner.Instance.Despawn(transform);
        enemyCtrl.EnemyDropItem.Drop(enemySO.dropList, transform.position, transform.rotation);
    }
}
