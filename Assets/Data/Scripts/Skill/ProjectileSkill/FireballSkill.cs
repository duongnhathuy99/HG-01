using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSkill : ProjectileSkill
{
    ProjectileMove projectileMove;
    //float rangeExplo = 0.2f;
    protected override void Awake()
    {
        base.Awake();
        projectileMove = GetComponentInChildren<ProjectileMove>();
    }
    private void OnEnable()
    {
       // transform.localScale = Vector3.one;
        projectileMove.gameObject.SetActive(true);
    }
    protected override void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null) return;
        IHealth health = other.GetComponent<IHealth>();
        if (health == null) return;

        if (!health.TakeDamage(skillData.damage)) return;
        skillData.damageInflicted += skillData.damage;

        animator.SetTrigger("Explosion");
        projectileMove.gameObject.SetActive(false);
    }
    public override void UpgradeSkill()
    {
        //transform.localScale *= (1 + rangeExplo * Level);
        base.UpgradeSkill();
    }
    void FinishAniExplosion()
    {
        ProjectileSkillSpawner.Instance.Despawn(transform);
    }
}
