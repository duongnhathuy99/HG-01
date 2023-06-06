using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Skill", menuName = "SO/Skill")]
public class SkillAttributeSO : ScriptableObject
{
    public SkillAttributeInit attributeInit;
    public SkillAttribute attribute;
    public SkillAttributeIncrease attributeIncrease;
}
