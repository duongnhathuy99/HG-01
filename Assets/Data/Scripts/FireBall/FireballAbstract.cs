using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FireballAbstract : MonoBehaviour
{
    //public FireballCtrl FireballCtrl { get; private set; }
    public ProjectileSkill Fireball{ get; private set; }
    protected virtual void Awake()
    {
        Fireball = GetComponentInParent<ProjectileSkill>();
    }
}
