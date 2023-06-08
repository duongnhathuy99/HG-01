using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritSkill : Skill
{
    float cdSkill;


    private void FixedUpdate()
    {
        Attack();
    }
    protected Vector3 RandomPosEnemy()
    {
        int random = Random.Range(0, EnemySpawner.Instance.Objects.Count);
        Vector3 posEnemy = EnemySpawner.Instance.Objects[random].position;
        return posEnemy;
    }
    protected float RotTargeting()
    {
        Vector3 diff = RandomPosEnemy() - transform.position;
        diff.Normalize();
        return Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
    }

    public bool Attack()
    {
        cdSkill += Time.fixedDeltaTime;
        if (cdSkill < SkillCD) return false;
        cdSkill = 0;
        if (EnemySpawner.Instance.Objects.Count <= 0) return false;
        float rot_z = RotTargeting();
        Transform newSpitritBullet = BulletSpawner.Instance.Spawn("SpitritBullet", transform.position, Quaternion.Euler(0, 0, rot_z));
        newSpitritBullet.gameObject.SetActive(true);

        return true;
    }
    public override void UpgradeSkill()
    {
        base.UpgradeSkill();
        skillSO.attribute.bulletNumber++;
    }
}
