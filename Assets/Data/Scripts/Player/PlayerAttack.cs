using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : PlayerAbstract
{
    public List<SkillAttack> skillAttacks;
    protected override void Awake()
    {
        base.Awake();
        LoadSkillAttacks();
    }
    void LoadSkillAttacks()
    {
        foreach (Transform skill in transform)
        {
            SkillAttack skillAttack = skill.GetComponent<SkillAttack>();
            this.skillAttacks.Add(skillAttack);
        }
    }
    public void LoadSkill()
    {
        foreach (SkillAttack skill in skillAttacks)
        {
            skill.LoadSkill();
        }
    }
    private void FixedUpdate()
    {
        Attack();
    }
    protected void Attack()
    {
        foreach (SkillAttack skill in skillAttacks)
            skill.Attack();
    }
}
