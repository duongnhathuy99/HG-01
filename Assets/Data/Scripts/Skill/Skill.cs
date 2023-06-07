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
    public string Detail => skillSO.attributeInit.detailSkill;
    public int Level => skillSO.attribute.level;
    public Sprite Sprite => skillSO.attributeInit.spriteSkill;
    public float DamageInflicted => skillSO.attribute.damageInflicted;
    public float Damage => skillSO.attribute.damage * (1 + skillSO.attributeIncrease.damage / 100);
    public float SkillCD => skillSO.attribute.skillCD * (1 - skillSO.attributeIncrease.skillCD / 100);
    public int BulletNumber => skillSO.attribute.bulletNumber + skillSO.attributeIncrease.bulletNumber;
    public float Speed => skillSO.attribute.speed * (1 + skillSO.attributeIncrease.speed / 100);
    public float TimeDuration => skillSO.attribute.timeDuration * (1 + skillSO.attributeIncrease.timeDuration / 100);
    public virtual float RangeExplosion => skillSO.attribute.rangeExplosion * (1 + skillSO.attributeIncrease.rangeExplosion / 100);
    public float Size => skillSO.attribute.size * (1 + skillSO.attributeIncrease.size / 100);
    protected virtual void Awake()
    {
        collider = transform.GetComponent<Collider>();
        animator = transform.GetComponentInChildren<Animator>();
    }
    public virtual void UpgradeSkill()
    {
        skillSO.attribute.level++;
        skillSO.attribute.damage += skillSO.attributeInit.damageUpgrade;
    }
    public virtual void GetSkill()
    {
        skillSO.attribute.level = 1;
    }
}
