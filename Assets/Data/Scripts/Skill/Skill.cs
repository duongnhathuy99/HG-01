using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Collider))]
public class Skill : MonoBehaviour
{
    [SerializeField] protected SkillDataSO skillData;
    protected string nameSkill;
    [SerializeField] protected SkillSO skillSO;
    [SerializeField] protected int levelSkill;
    [SerializeField] protected int damageSkill;
    [SerializeField] protected float timeCountdown;
    protected Sprite spriteSkill;
    protected new Collider collider;
    public string Name => nameSkill;
    public int Level => levelSkill;
    public int Damage => damageSkill;
    public float TimeCountdown => timeCountdown;
    public Sprite Sprite => spriteSkill;
    
    protected virtual void Awake()
    {
        collider = transform.GetComponent<Collider>();
    }
    public virtual void UpgradeSkill()
    {
        levelSkill++;
        damageSkill += skillSO.damagePerLevel;
        //skillSO.damage = damageSkill;
        //skill data
        skillData.level++;
        skillData.damage+= skillSO.damagePerLevel;
    }
    public virtual void LoadDataSkill()
    {
        nameSkill = transform.name;
        levelSkill = 0;
        spriteSkill = skillSO.spriteSkill;
        timeCountdown = skillSO.timeCountdown;
        damageSkill = skillSO.damage;

        //skill data
        skillData.damage = skillSO.damage;
        skillData.level = 0;
        skillData.nameSkill = transform.name;
        skillData.timeCountdown = skillSO.timeCountdown;
        skillData.sprite = skillSO.spriteSkill;
    }
}
