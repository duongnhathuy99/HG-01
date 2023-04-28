using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "SO/Skill")]
public class SkillSO : ScriptableObject
{
    public string nameSkill = "skill";
    public int damage = 50;
    public int damagePerLevel = 10;
    public float timeCountdown = 1.5f;
    public Sprite spriteSkill;
    public string detailSkill;
    public float speed = 5f;

}
