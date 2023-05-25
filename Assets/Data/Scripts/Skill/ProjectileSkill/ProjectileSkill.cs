using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSkill : Skill
{
    public float Speed => skillData.speed;
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

        if (!health.TakeDamage(skillData.damage)) return;
        ProjectileSkillSpawner.Instance.Despawn(transform);
    }
    public override void LoadDataSkill()
    {
        base.LoadDataSkill();
        skillData.speed = skillSO.speed;
    }
    public override void UpgradeSkill()
    {
        base.UpgradeSkill();
        skillData.bulletNumber++;
    }
}
