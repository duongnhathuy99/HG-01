using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class SkillAttributeInit
{
    public string nameSkill = "skill";
    public Sprite spriteSkill;
    public string detailSkill;
    public float damage = 50;
    public float damageUpgrade = 10;
    public float skillCD = 1.5f;
    public int bulletNumber = 1;
    public float timeDuration = 0;
    public float speed = 5f;

}

[Serializable]
public class SkillAttribute
{
    public int level;
    public float damage;
    public float skillCD;
    public int bulletNumber;
    public float timeDuration;
    public float speed;
    public float rangeExplosion;
    public float size;
    public float damageInflicted;
}

[Serializable]
public class SkillAttributeIncrease
{
    public float damage;
    public float skillCD;
    public int bulletNumber;
    public float timeDuration;
    public float speed;
    public float rangeExplosion;
    public float size;
}
