using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Skill
{
    [SerializeField] protected float speed;
    public float Speed => speed;
    protected override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        //damageSkill = skillSO.damage;
    }
    private void OnEnable()
    {
        damageSkill = skillData.damage;
        levelSkill = skillData.level;
    }
    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null) return;
        IHealth health = other.GetComponent<IHealth>();
        if (health == null) return;
        
        health.TakeDamage(damageSkill);
        FireballSpawner.Instance.Despawn(transform);
    }
    public override void LoadDataSkill()
    {
        base.LoadDataSkill();
        speed = skillSO.speed;

        skillData.speed = skillSO.speed;
    }
}
