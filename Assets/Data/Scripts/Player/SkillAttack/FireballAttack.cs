using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballAttack : SkillAttack
{
    protected float RotTargeting()
    {
        Vector3 diff = EnemySpawner.Instance.Objects[0].position - transform.parent.position;
        diff.Normalize();
        return Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
    }
    public override bool Attack()
    {
        if (skill == null) return false;
        cdSkill += Time.fixedDeltaTime;
        if (cdSkill < skill.SkillCD) return false;
        cdSkill = 0;
        if (EnemySpawner.Instance.Objects.Count <= 0) return false;
        float rot_z = RotTargeting();
        Transform newFireball = SkillSpawner.Instance.Spawn(skill.name, transform.parent.position, Quaternion.Euler(0, 0, rot_z));
        newFireball.gameObject.SetActive(true);

        PlayerAttack.PlayerCtrl.Animator.SetTrigger("attack");
        return true;
    }


}
