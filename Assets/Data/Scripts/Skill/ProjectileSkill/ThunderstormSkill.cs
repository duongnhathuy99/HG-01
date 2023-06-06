using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderstormSkill: ProjectileSkill
{
    protected override void Awake()
    {
        base.Awake();
    }
    private void OnEnable()
    {
    }
    protected override void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null) return;
        IHealth health = other.GetComponent<IHealth>();
        if (health == null) return;

        if (!health.TakeDamage(Damage)) return;
        skillSO.attribute.damageInflicted += Damage;

    }
    public override void UpgradeSkill()
    {
        base.UpgradeSkill();
    }
    void FinishAniThunder()
    {
        ProjectileSkillSpawner.Instance.Despawn(transform);
    }
}
