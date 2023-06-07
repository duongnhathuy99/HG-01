using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    private static SkillManager _instance;
    public static SkillManager Instance => _instance;
    private void Awake()
    {
        if (_instance != null)
            Destroy(this.gameObject);
        else
            _instance = this;

        LoadDataSkill();
    }

    [SerializeField] List<SkillAttributeSO> skills;
    public void LoadAttributeArtifact(ArtifactSO artifact)
    {
        foreach (SkillAttributeSO skillAttributeSO in skills)
            foreach (ArtifactAttribute artifactAttribute in artifact.listProperties)
                if (skillAttributeSO.attributeInit.nameSkill == artifactAttribute.typeSkill.ToString())
                {
                    switch (artifactAttribute.typeAttribute)
                    {
                        case TypeAttribute.damage:
                            skillAttributeSO.attributeIncrease.damage += artifactAttribute.value;
                            break;
                        case TypeAttribute.countdown:
                            skillAttributeSO.attributeIncrease.skillCD += artifactAttribute.value;
                            //skillAttributeSO.attributeIncrease.skillCD *= 1 - artifactAttribute.value / 100;
                            break;
                        case TypeAttribute.duration:
                            skillAttributeSO.attributeIncrease.timeDuration += artifactAttribute.value;
                            break;
                        case TypeAttribute.bulletNumber:
                            skillAttributeSO.attributeIncrease.bulletNumber += (int)artifactAttribute.value;
                            break;
                        case TypeAttribute.rangeExplosion:
                            skillAttributeSO.attributeIncrease.rangeExplosion += artifactAttribute.value;
                            break;
                        case TypeAttribute.size:
                            skillAttributeSO.attributeIncrease.size += artifactAttribute.value;
                            break;
                        case TypeAttribute.speed:
                            skillAttributeSO.attributeIncrease.speed += artifactAttribute.value;
                            break;
                        default:
                            break;
                    }
                }
    }
    private void LoadDataSkill()
    {
        foreach (SkillAttributeSO skillSO in skills)
        {
            //load data base;
            skillSO.attribute.damage = skillSO.attributeInit.damage;
            skillSO.attribute.skillCD = skillSO.attributeInit.skillCD;
            skillSO.attribute.bulletNumber = skillSO.attributeInit.bulletNumber;
            skillSO.attribute.timeDuration = skillSO.attributeInit.timeDuration;
            skillSO.attribute.speed = skillSO.attributeInit.speed;
            skillSO.attribute.rangeExplosion = 1;
            skillSO.attribute.size = 1;
            skillSO.attribute.level = 0;
            skillSO.attribute.damageInflicted = 0;

            skillSO.attributeIncrease.damage = 0;
            skillSO.attributeIncrease.skillCD = 0;
            skillSO.attributeIncrease.speed = 0;
            skillSO.attributeIncrease.timeDuration = 0;
            skillSO.attributeIncrease.bulletNumber = 0;
            skillSO.attributeIncrease.rangeExplosion = 0;
            skillSO.attributeIncrease.size = 0;
        }

    }
}
