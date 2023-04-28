using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsUpgrade : MonoBehaviour
{
    public List<Skill> skills;
    private void Awake()
    {
        Debug.Log("awake menu");
       /* foreach (Skill skill in skills)
            skill.LoadDataSkill();*/
        
    }
    public Skill GetSkillRandom()
    {
        return skills[0];
    }
}
