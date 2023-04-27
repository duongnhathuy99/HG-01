using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FireballAbstract : MonoBehaviour
{
    public FireballCtrl FireballCtrl { get; private set; }
    protected virtual void Awake()
    {
        FireballCtrl = GetComponentInParent<FireballCtrl>();
    }
}
