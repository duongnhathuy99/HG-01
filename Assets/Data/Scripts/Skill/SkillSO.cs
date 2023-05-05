using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "SO/Skill")]
public class SkillSO : ScriptableObject
{
    public string nameSkill = "skill";
    public int damage = 50;
    public int damagePerLevel = 10;
    public float skillCD = 1.5f;
    public int bulletNumber = 1;
    public float bulletCD = 0.2f;
    public Sprite spriteSkill;
    public string detailSkill;
    public float speed = 5f;

}
