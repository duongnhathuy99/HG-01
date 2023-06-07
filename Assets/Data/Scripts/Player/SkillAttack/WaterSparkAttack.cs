using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSparkAttack : SkillAttack
{
    float bulletCD = 0.2f;
   
    public override bool Attack()
    {
        if (skill == null) return false;

        cdSkill += Time.fixedDeltaTime;
        cdBullet += Time.fixedDeltaTime;
        if (cdSkill < skill.SkillCD) return false;
        if (cdBullet < bulletCD) return false;
        if (EnemySpawner.Instance.Objects.Count <= 0) return false;

        Transform newWaterSpark = SkillSpawner.Instance.Spawn(skill.name, transform.parent.position, Quaternion.Euler(0, 0, Random.Range(45, 135)));
        newWaterSpark.gameObject.SetActive(true);

        countBullet--;
        cdBullet = 0;
        if (countBullet > 0) return true;
        cdSkill = 0;
        countBullet = skill.BulletNumber;
        return true;
    }
}
