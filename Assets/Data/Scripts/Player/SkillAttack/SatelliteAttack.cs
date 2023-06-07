using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SatelliteAttack : SkillAttack
{
    float radius = 2.0f;
    public override bool Attack()
    {
        if (skill == null) return false;
        if (FollowSkillSpawner.Instance.GetListObjectByName(skill.name).Count < skill.BulletNumber)
        {
            Vector3 newPos = transform.parent.position;
            Transform newSatellite = FollowSkillSpawner.Instance.Spawn(skill.name,  Vector3.zero, Quaternion.Euler(0, 0, 0));
            newSatellite.gameObject.SetActive(true);
            ArrangeSatellite();
        }
        return true;
    }
    protected void ArrangeSatellite()
    {
        /*float cornerAngle = 360 / FollowSkillSpawner.Instance.Objects.Count * Mathf.Deg2Rad;

        for (int i = 0; i < FollowSkillSpawner.Instance.Objects.Count; i++)
        {
            FollowSkillSpawner.Instance.Objects[i].localPosition = new Vector3(Mathf.Cos(cornerAngle * i) * radius, Mathf.Sin(cornerAngle * i) * radius, 0);
        }*/
        float cornerAngle = 360 / FollowSkillSpawner.Instance.GetListObjectByName(skill.name).Count * Mathf.Deg2Rad;

        for (int i = 0; i < FollowSkillSpawner.Instance.GetListObjectByName(skill.name).Count; i++)
        {
            FollowSkillSpawner.Instance.GetListObjectByName(skill.name)[i].localPosition = new Vector3(Mathf.Cos(cornerAngle * i) * radius, Mathf.Sin(cornerAngle * i) * radius, 0);
        }
    }
}
