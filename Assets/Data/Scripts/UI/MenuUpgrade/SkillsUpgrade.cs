using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsUpgrade : MonoBehaviour
{
    public List<Skill> skills;
    private void Awake()
    {
        //Debug.Log("awake menu");
       /* foreach (Skill skill in skills)
            skill.LoadDataSkill();*/
        
    }
    public Skill GetSkillRandom()
    {
        int ran = Random.Range(0, skills.Count);
        return skills[ran];
    }
}
