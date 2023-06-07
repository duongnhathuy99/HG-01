using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireZoneAttack : SkillAttack
{
    float x_distance = 10f;
    float y_distance = 4.5f;
    private Vector3 PosRamdom()
    {
        float x = Random.Range(-x_distance, x_distance);
        float y = Random.Range(-y_distance, y_distance);
        Vector3 newPos = new Vector3(x, y, 0);

        return newPos;
    }
    public override bool Attack()
    {
        if (skill == null) return false;
        cdSkill += Time.fixedDeltaTime;
        if (cdSkill < skill.SkillCD) return false;
        cdSkill = 0;
        Transform fireZone = SkillSpawner.Instance.Spawn(skill.name, transform.parent.position + PosRamdom(), Quaternion.Euler(0, 0, 0));
        fireZone.gameObject.SetActive(true);

        return true;
    }


}
