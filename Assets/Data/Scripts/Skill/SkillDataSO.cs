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
    public float bulletCD;
    public Sprite sprite;
    public string detail;
    public float speed;
}
