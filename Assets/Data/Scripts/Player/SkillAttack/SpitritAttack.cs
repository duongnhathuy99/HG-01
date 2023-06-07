using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitritAttack : SkillAttack
{
    float x_distance = 0.25f;
    float y_distance = 0.9f;
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
        int number = FollowSkillSpawner.Instance.GetListObjectByName(skill.name).Count % 2 ;
        float x_pos = x_distance;
        float y_pos = y_distance;
        for (int i = 0; i < FollowSkillSpawner.Instance.GetListObjectByName(skill.name).Count; i++)
        {
            if (i == 0 && number == 1)
            {
                FollowSkillSpawner.Instance.GetListObjectByName(skill.name)[i].localPosition = new Vector3(0, y_pos, 0);
                x_pos /= 2;
            }
            else
            {
                x_pos *= -1 ;
                if (number % 2 == 0 && number != 0) 
                { 
                    y_pos -= y_distance / 3;
                    x_pos -= x_distance;
                }
                FollowSkillSpawner.Instance.GetListObjectByName(skill.name)[i].localPosition = new Vector3(x_pos, y_pos, 0);
            }
            number++;
        }
    }
}
