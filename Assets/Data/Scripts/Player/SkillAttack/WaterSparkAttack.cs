using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSparkAttack : SkillAttack
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
        cdBullet += Time.fixedDeltaTime;
        if (cdSkill < skill.SkillCD) return false;
        if (cdBullet < skill.BulletCD) return false;
        if (EnemySpawner.Instance.Objects.Count <= 0) return false;

        float rot_z = RotTargeting();
        Transform newWaterSpark = ProjectileSkillSpawner.Instance.Spawn(skill.name, transform.parent.position, Quaternion.Euler(0, 0, rot_z));
        newWaterSpark.gameObject.SetActive(true);

        countBullet--;
        cdBullet = 0;
        if (countBullet > 0) return true;
        cdSkill = 0;
        countBullet = skill.BulletNumber;
        return true;
    }
}
