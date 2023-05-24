using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricOrbAttack: SkillAttack
{
    protected float RotTargeting()
    {
        //Vector3 diff = EnemySpawner.Instance.Objects[0].position - transform.parent.position;
        float x = Random.Range(-10, 10);
        float y = Random.Range(-10, 10);
        Vector3 newPos = new Vector3(x, y, 0);
        newPos.Normalize();
        return Mathf.Atan2(newPos.y, newPos.x) * Mathf.Rad2Deg;
    }
    public override bool Attack()
    {
        if (skill == null) return false;

        cdSkill += Time.fixedDeltaTime;
        if (cdSkill < skill.SkillCD) return false;
        cdSkill = 0;
        float rot_z = RotTargeting();
        Transform newElectricOrb = DurationSkillSpawner.Instance.Spawn(skill.name, transform.parent.position, Quaternion.Euler(0, 0, rot_z));
        newElectricOrb.gameObject.SetActive(true);

        return true;
    }
}
