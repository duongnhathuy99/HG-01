using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSkill : Skill
{
    protected override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
    }
    private void OnEnable()
    {
    }
    private void OnTriggerEnter(Collider other)
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
        skillSO.attribute.bulletNumber++;
    }
}
