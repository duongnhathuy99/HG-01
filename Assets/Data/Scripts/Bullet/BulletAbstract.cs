using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletAbstract : MonoBehaviour
{
    public BulletCtrl BulletCtrl { get; private set; }
    protected virtual void Awake()
    {
        BulletCtrl = GetComponentInParent<BulletCtrl>();
    }
}
