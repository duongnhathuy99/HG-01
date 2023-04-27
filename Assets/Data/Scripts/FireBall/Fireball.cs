using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    protected int damage ;
    protected int level;
    public FireballCtrl fireballCtrl { get; private set; }
    private void Awake()
    {
        fireballCtrl = transform.GetComponent<FireballCtrl>();
        level = GameObject.FindWithTag("Player").GetComponentInChildren<PlayerCtrl>().Player.Level;
    }
    private void Start()
    {
        damage = fireballCtrl.FireballSO.listDamageLevel[level];
    }
    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null) return;
        IHealth health = other.GetComponent<IHealth>();
        if (health == null) return;
        
        health.TakeDamage(damage);
        FireballSpawner.Instance.Despawn(transform);
    }
}
