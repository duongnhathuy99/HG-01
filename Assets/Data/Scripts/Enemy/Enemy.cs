using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IHealth
{
    [SerializeField] protected int health;
    EnemySO enemySO;
    private void Awake()
    {
        enemySO = transform.GetComponent<EnemyCtrl>().EnemySO;
    }
    private void OnEnable()
    {
        health = enemySO.heathMax;
    }
    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0) EnemySpawner.Instance.Despawn(transform);
    }

}
