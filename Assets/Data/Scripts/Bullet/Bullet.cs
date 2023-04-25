using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    protected int damage ;
    public BulletCtrl bulletCtrl { get; private set; }
    private void Awake()
    {
        bulletCtrl = transform.GetComponent<BulletCtrl>();
    }
    private void Start()
    {
        damage = bulletCtrl.BulletSO.damage;
    }
    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null) return;
        IHealth health = other.GetComponent<IHealth>();
        if (health == null) return;
        
        health.TakeDamage(damage);
        BulletSpawner.Instance.Despawn(transform);
    }
}
