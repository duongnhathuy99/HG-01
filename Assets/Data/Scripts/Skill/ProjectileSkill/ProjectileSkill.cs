using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSkill : Skill
{
    protected override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null) return;
        IHealth health = other.GetComponent<IHealth>();
        if (health == null) return;

        if (!health.TakeDamage(skillData.damage)) return;
        ProjectileSkillSpawner.Instance.Despawn(transform);
    }
    public override void UpgradeSkill()
    {
        base.UpgradeSkill();
        skillData.bulletNumber++;
    }
}
