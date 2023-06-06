using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider))]
public class Skill : MonoBehaviour
{
    [SerializeField] protected SkillAttributeSO skillSO;
    protected new Collider collider;
    protected Animator animator;
    public string Name => skillSO.attributeInit.nameSkill;
    public int Level => skillSO.attribute.level;
    public Sprite Sprite => skillSO.attributeInit.spriteSkill;
    public float DamageInflicted => skillSO.attribute.damageInflicted;
    public float Damage => skillSO.attribute.damage * (1 + skillSO.attributeIncrease.damage / 100);
    public float SkillCD => skillSO.attribute.skillCD * (1 - skillSO.attributeIncrease.skillCD / 100);
    public int BulletNumber => skillSO.attribute.bulletNumber + skillSO.attributeIncrease.bulletNumber;
    public float Speed => skillSO.attribute.speed;
    protected virtual void Awake()
    {
        collider = transform.GetComponent<Collider>();
        animator = transform.GetComponentInChildren<Animator>();
    }
    public virtual void UpgradeSkill()
    {
        skillSO.attribute.level++;
        skillSO.attribute.damage += skillSO.attributeInit.damagePerLevel;
    }
    public virtual void GetSkill()
    {
        skillSO.attribute.level = 1;
    }
    public virtual void LoadDataSkill()
    {
        //load data base;
        skillSO.attribute.damage = skillSO.attributeInit.damage;
        skillSO.attribute.skillCD = skillSO.attributeInit.skillCD;
        skillSO.attribute.bulletNumber = skillSO.attributeInit.bulletNumber;
        skillSO.attribute.timeDuration = skillSO.attributeInit.timeDuration;
        skillSO.attribute.speed = skillSO.attributeInit.speed;
        skillSO.attribute.level = 0;
        skillSO.attribute.damageInflicted = 0;

        skillSO.attributeIncrease.damage = 0;
        skillSO.attributeIncrease.skillCD = 0;
        skillSO.attributeIncrease.speed = 0;
        skillSO.attributeIncrease.timeDuration = 0;
        skillSO.attributeIncrease.bulletNumber = 0;


    }
}
