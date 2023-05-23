using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IHealth
{
    [SerializeField] protected int health;
    [SerializeField] protected int damage;
    EnemySO enemySO;
    EnemyCtrl enemyCtrl;
    private void Awake()
    {
        enemySO = transform.GetComponent<EnemyCtrl>().EnemySO;
        enemyCtrl = transform.GetComponent<EnemyCtrl>();
    }
    private void OnEnable()
    {
        health = enemySO.heathMax;
        damage = enemySO.damage;
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
        health -= amount;
        if (health > 0) return;
        EnemySpawner.Instance.Despawn(transform);
        enemyCtrl.EnemyDropItem.Drop(enemySO.dropList, transform.position, transform.rotation);
    }

}
