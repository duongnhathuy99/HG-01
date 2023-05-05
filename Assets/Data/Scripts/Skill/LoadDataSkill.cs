using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadDataSkill : MonoBehaviour
{
    [SerializeField] protected List<Skill> skills;
    private void Awake()
    {
        LoadListSkills();
    }

    void LoadListSkills()
    {
        foreach (Transform tranSkill in transform)
        {
            Skill skill = tranSkill.GetComponent<Skill>();
            skill.LoadDataSkill();
            this.skills.Add(skill);
        }
    }

}
