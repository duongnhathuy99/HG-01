using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FireballAbstract : MonoBehaviour
{
    public FireballCtrl FireballCtrl { get; private set; }
    public Fireball Fireball{ get; private set; }
    protected virtual void Awake()
    {
        Fireball = GetComponentInParent<Fireball>();
    }
}
