using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    private static SkillManager _instance;
    //public static SkillManager public static EnemySpawner Instance { get => _instance; };
    public static SkillManager Instance { get => _instance; }
    private void Awake()
    {
        if (_instance != null)
            Destroy(this.gameObject);
        else
            _instance = this;
    }

    [SerializeField] List<SkillAttributeSO> skills;
    public void LoadAttributeArtifact(ArtifactSO artifact)
    {
        foreach (SkillAttributeSO skillAttributeSO in skills)
            foreach (ArtifactAttribute artifactAttribute in artifact.listProperties)
                if (skillAttributeSO.attributeInit.nameSkill == artifactAttribute.typeSkill.ToString())
                {
                    if (artifactAttribute.typeAttribute == TypeAttribute.damage)
                        skillAttributeSO.attributeIncrease.damage += artifactAttribute.value;
                    if (artifactAttribute.typeAttribute == TypeAttribute.countdown)
                        skillAttributeSO.attributeIncrease.skillCD += artifactAttribute.value;
                    if (artifactAttribute.typeAttribute == TypeAttribute.duration)
                        skillAttributeSO.attributeIncrease.timeDuration += artifactAttribute.value;
                    if (artifactAttribute.typeAttribute == TypeAttribute.bulletNumber)
                        skillAttributeSO.attributeIncrease.bulletNumber += (int)artifactAttribute.value;
                }

    }

}
