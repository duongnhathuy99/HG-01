using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SkillData", menuName = "Data/Skill")]
public class SkillDataSO : ScriptableObject
{
    public string nameSkill;
    public int level;
    public int damage;
    public float skillCD;
    public int bulletNumber;
    public float timeDuration;
    public float speed;
    public float damageInflicted;
}
