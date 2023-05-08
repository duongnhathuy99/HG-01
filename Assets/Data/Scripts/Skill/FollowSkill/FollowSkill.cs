using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSkill : Skill
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
        
        health.TakeDamage(skillData.damage);
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
