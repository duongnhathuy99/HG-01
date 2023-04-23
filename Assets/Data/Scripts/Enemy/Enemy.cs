using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IHealth
{
    [SerializeField] protected int health;
    [SerializeField] protected int healthMax = 100;
    private void Start()
    {
        health = healthMax;
    }
    private void OnEnable()
    {
        health = healthMax;
    }
    public void TakeDamage(int amount)
    {
        Debug.Log("take dame");
        health -= amount;
        if (health <= 0) EnemySpawner.Instance.Despawn(transform);
    }

}
