using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] protected int damage = 50;
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("va cham " + other.gameObject.name);
        IHealth health = other.GetComponent<IHealth>();
        if (health == null) return;
        
        health.TakeDamage(damage);
        BulletSpawner.Instance.Despawn(transform);
    }
}
