using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderstormAttack: SkillAttack
{
    float x_distance = 10f;
    float y_distance = 4.5f;
    protected Vector3 RandomPosEnemy()
    {
        int random = Random.Range(0, EnemySpawner.Instance.Objects.Count);
        Vector3 posEnemy = EnemySpawner.Instance.Objects[random].position;
        if (Mathf.Abs(posEnemy.x - transform.parent.position.x) > x_distance || Mathf.Abs(posEnemy.y - transform.parent.position.y) > y_distance) return RandomPosEnemy();
        return posEnemy;
    }
    public override bool Attack()
    {
        if (skill == null) return false;

        cdSkill += Time.fixedDeltaTime;
        if (cdSkill < skill.SkillCD) return false;
        cdSkill = 0;
        Vector3 ranPos = RandomPosEnemy();
        Transform newThunderstorm = SkillSpawner.Instance.Spawn(skill.name, ranPos, Quaternion.Euler(0, 0, 0));
        newThunderstorm.gameObject.SetActive(true);

        return true;
    }
}
