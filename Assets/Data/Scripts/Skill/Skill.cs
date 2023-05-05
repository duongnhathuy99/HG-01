using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider))]
public class Skill : MonoBehaviour
{
    [SerializeField] protected SkillDataSO skillData;
    [SerializeField] protected SkillSO skillSO;
    protected new Collider collider;
    public string Name => skillData.nameSkill;
    public int Level => skillData.level;
    public int Damage => skillData.damage;
    public float SkillCD => skillData.skillCD;
    public int BulletNumber => skillData.bulletNumber;
    public float BulletCD => skillData.bulletCD;
    public Sprite Sprite => skillData.sprite;
    
    protected virtual void Awake()
    {
        collider = transform.GetComponent<Collider>();
    }
    public virtual void UpgradeSkill()
    {
      
        skillData.level++;
        skillData.damage += skillSO.damagePerLevel;
    }
    public virtual void GetSkill()
    {
        skillData.level = 1;
    }
    public virtual void LoadDataSkill()
    {
       //load data base;
        skillData.damage = skillSO.damage;
        skillData.level = 0;
        skillData.nameSkill = transform.name;
        skillData.skillCD = skillSO.skillCD;
        skillData.bulletCD = skillSO.bulletCD;
        skillData.bulletNumber = skillSO.bulletNumber;
        skillData.sprite = skillSO.spriteSkill;
    }
}
