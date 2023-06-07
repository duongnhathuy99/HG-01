using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSkill : Skill
{
    ProjectileMove projectileMove;
    protected override void Awake()
    {
        base.Awake();
        projectileMove = GetComponentInChildren<ProjectileMove>();
    }
    private void OnEnable()
    {
        transform.localScale = Vector3.one;
        projectileMove.gameObject.SetActive(true);
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null) return;
        IHealth health = other.GetComponent<IHealth>();
        if (health == null) return;

        if (!health.TakeDamage(Damage)) return;
        skillSO.attribute.damageInflicted += Damage;

        animator.SetTrigger("Explosion");
        projectileMove.gameObject.SetActive(false);
    }
    public override void UpgradeSkill()
    {
        base.UpgradeSkill();
        skillSO.attribute.bulletNumber++;
    }
    void StartAniExplosion()
    {
        transform.localScale = new Vector3(RangeExplosion, RangeExplosion, 1);
    }
    void FinishAniExplosion()
    {
        SkillSpawner.Instance.Despawn(transform);
    }
}
