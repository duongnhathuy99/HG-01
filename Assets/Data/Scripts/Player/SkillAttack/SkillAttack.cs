using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SkillAttack : MonoBehaviour
{
    public PlayerAttack PlayerAttack { get; private set; }
    [SerializeField] protected Skill skill;
    protected float cdSkill;
    protected float cdBullet;
    protected int countBullet;
    protected virtual void Awake()
    {
        PlayerAttack = GetComponentInParent<PlayerAttack>();
    }
    protected virtual void Start()
    {
        LoadSkill();
    }

    public void LoadSkill()
    {
        if (skill != null) return;
        foreach (Skill skill in PlayerAttack.PlayerCtrl.Player.skills)
        {
            if (skill.transform.name == transform.name)
            {
                this.skill = skill;
                countBullet = skill.BulletNumber;
                return;
            }
        }
    }
    public abstract bool Attack();
}
