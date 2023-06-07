using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSparkSkill : Skill
{
    protected override void Awake()
    {
        base.Awake();
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null) return;
        IHealth health = other.GetComponent<IHealth>();
        if (health == null) return;

        if (!health.TakeDamage(Damage)) return;
        skillSO.attribute.damageInflicted += Damage;
        SkillSpawner.Instance.Despawn(transform);
    }
    public override void UpgradeSkill()
    {
        base.UpgradeSkill();
        skillSO.attribute.bulletNumber++;
    }
}
