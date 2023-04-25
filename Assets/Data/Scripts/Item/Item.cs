using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public PlayerCtrl PlayerCtrl { get; private set; }
    protected virtual void Awake()
    {
        PlayerCtrl = GameObject.FindWithTag("Player").GetComponent<PlayerCtrl>();
    }
}
