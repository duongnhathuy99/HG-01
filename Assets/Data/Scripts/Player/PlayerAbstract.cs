using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAbstract : MonoBehaviour
{
    public PlayerCtrl PlayerCtrl { get; private set; }
    protected virtual void Awake()
    {
        PlayerCtrl = GetComponentInParent<PlayerCtrl>();
    }
}
