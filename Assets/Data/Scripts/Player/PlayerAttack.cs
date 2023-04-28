using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : PlayerAbstract
{
    private float attackDelay;
    private float cdFireball = 0f;
    [SerializeField] protected Transform fireballPrefab;

    private void FixedUpdate()
    {
        Attack();
    }
    private void Start()
    {
        attackDelay = PlayerCtrl.PlayerSO.attackSpeed;
    }
    protected void Attack()
    {
        FireballAttack();
    }
    protected float RotTargeting()
    {
        Vector3 diff = EnemySpawner.Instance.Objects[0].position - transform.parent.position;
        diff.Normalize();
        return Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
    }
    protected void FireballAttack()
    {
        Skill fireball = IsGetSkill("Fireball");
        if (fireball == null) return;
        cdFireball += Time.fixedDeltaTime;
        if (cdFireball < fireball.TimeCountdown) return;
        cdFireball = 0;
        if (EnemySpawner.Instance.Objects.Count <= 0) return;
        float rot_z = RotTargeting();
        Transform newFireball = FireballSpawner.Instance.Spawn(fireballPrefab, transform.parent.position, Quaternion.Euler(0, 0, rot_z));
        newFireball.gameObject.SetActive(true);
        PlayerCtrl.Animator.SetTrigger("attack");
    }
    protected Skill IsGetSkill(string nameSkill)
    {
        foreach (Skill skill in PlayerCtrl.Player.skills)
        {
            if (skill.transform.name == nameSkill)
                return skill;
        }
        return null;
    }
}
