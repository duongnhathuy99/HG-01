using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAbstract : MonoBehaviour
{
    public EnemyCtrl EnemyCtrl { get; private set; }
    protected virtual void Awake()
    {
        EnemyCtrl = GetComponentInParent<EnemyCtrl>();
    }
}
