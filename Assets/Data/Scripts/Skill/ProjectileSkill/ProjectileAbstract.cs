using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileAbstract : MonoBehaviour
{
    //public FireballCtrl FireballCtrl { get; private set; }
    public ProjectileSkill ProjectileSkill{ get; private set; }
    protected virtual void Awake()
    {
        ProjectileSkill = GetComponentInParent<ProjectileSkill>();
    }
}
